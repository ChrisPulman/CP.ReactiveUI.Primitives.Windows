#:package Microsoft.CodeAnalysis.CSharp.Workspaces@5.0.0
#:package Microsoft.CodeAnalysis.Workspaces.MSBuild@5.0.0
#:package Microsoft.Build.Locator@1.7.8
#:property TargetFramework=net10.0
#:property ImportDirectoryBuildProps=false
#:property ImportDirectoryPackagesProps=false
#:property ManagePackageVersionsCentrally=false

using System.Text;
using System.Text.Json.Nodes;
using System.Xml.Linq;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;
using static Formats;

// Compile examples, never execute them: many APIs operate on the live desktop.
MSBuildLocator.RegisterDefaults();
var repo = Path.GetFullPath(args.Length > 0 ? args[0] : Path.Combine(Environment.CurrentDirectory));
var names = new[] { "CP.ReactiveUI.Primitives.Windows.Core", "CP.ReactiveUI.Primitives.Windows", "CP.ReactiveUI.Primitives.Windows.Reactive", "CP.ReactiveUI.Primitives.Windows.Integrations" };
var targets = args.Skip(1).Any() ? args.Skip(1).ToArray() : new[] { "net462", "net472", "net48", "net481", "net8.0-windows", "net9.0-windows", "net10.0-windows" };
var entries = new SortedDictionary<string, Entry>(StringComparer.Ordinal);
var failures = new List<string>();
foreach (var target in targets)
{
    foreach (var name in names)
    {
        using var workspace = MSBuildWorkspace.Create(new Dictionary<string, string> { ["TargetFramework"] = target });
        var project = await workspace.OpenProjectAsync(Path.Combine(repo, "src", name, name + ".csproj"));
        var compilation = (CSharpCompilation)(await project.GetCompilationAsync() ?? throw new InvalidOperationException("No compilation: " + name));
        Console.WriteLine($"Inventory {name} / {target}");
        var symbols = Types(compilation.Assembly.GlobalNamespace).Where(t => Visible(t) && !t.Name.StartsWith("<") && !t.DeclaringSyntaxReferences.Any(r => r.GetSyntax() is ExtensionBlockDeclarationSyntax)).SelectMany(t => t.GetMembers()).Where(s => Visible(s) && (s is IMethodSymbol { MethodKind: MethodKind.Ordinary or MethodKind.DelegateInvoke or MethodKind.Constructor or MethodKind.UserDefinedOperator or MethodKind.Conversion } || s is IPropertySymbol)).Distinct(SymbolEqualityComparer.Default).ToArray();
        var samples = new List<(Entry Entry, string Code)>();
        foreach (var symbol in symbols)
        {
            var id = symbol.GetDocumentationCommentId() ?? symbol.ToDisplayString();
            if (symbol is IMethodSymbol { Name: var propertyAccessorName } && propertyAccessorName.StartsWith("get_")) id = "P:" + id.Substring(2).Replace(".get_", ".");
            var key = name + ":" + id + ":" + Signature(symbol);
            var doc = Xml(symbol, compilation);
            var signature = Signature(symbol);
            var example = Example(symbol);
            var entry = entries.TryGetValue(key, out var existing) ? existing : new Entry(name, symbol.ContainingNamespace.ToDisplayString(), symbol.ContainingType.ToDisplayString(), id, signature, Description(doc, symbol), example, Source(symbol, repo), Parameters(doc, symbol) + (symbol is IPropertySymbol { SetMethod: { IsInitOnly: true, DeclaredAccessibility: Accessibility.Public } } ? "\nConfiguration: supply this init-only property in an object initializer when creating the containing instance." : ""));
            entry.Targets.Add(target);
            entries[key] = entry;
            samples.Add((entry, example));
        }
        // Each example has a separate class to preserve generic scopes and prevent overload collisions.
        var trees = samples.Select((s, i) => CSharpSyntaxTree.ParseText("#nullable enable\n" + s.Code.Replace("class ApiExample", "class ApiExample" + i), (CSharpParseOptions)project.ParseOptions!, "sample-" + i + ".cs")).ToArray();
        var verified = compilation.RemoveAllSyntaxTrees().WithAssemblyName("ApiReferenceExamples").AddSyntaxTrees(trees);
        // Reference the original compilation directly, preserving all conditional public APIs.
        verified = verified.AddReferences(compilation.ToMetadataReference());
        var errors = verified.GetDiagnostics().Where(d => d.Severity == DiagnosticSeverity.Error).ToArray();
        foreach (var error in errors)
        {
            var file = error.Location.SourceTree?.FilePath ?? "";
            if (file.StartsWith("sample-") && int.TryParse(Path.GetFileNameWithoutExtension(file).Substring(7), out var index))
            {
                samples[index].Entry.Errors.Add(target + ": " + error);
                failures.Add(name + " " + target + " " + samples[index].Entry.Id + ": " + error);
            }
            else failures.Add(name + " " + target + ": " + error);
        }
        Console.WriteLine($"  {symbols.Length} callable members; {errors.Length} example compiler errors");
    }
}
if (failures.Count > 0) { foreach (var failure in failures) Console.WriteLine(failure); return 1; }
Directory.CreateDirectory(Path.Combine(repo, "docs"));
var markdown = new StringBuilder("# Public callable API reference\n\nGenerated from Roslyn project compilations. Each example is a callable C# method accepting existing typed inputs; examples are compiled but never executed. Supply valid live handles and retain native buffers and COM objects for the duration required by the API. `ref`, `out`, pointer and span APIs keep their direct calling shape. Constructors create instances; operators show the corresponding expression.\n\nRegenerate: `pwsh ./tools/Update-ApiReference.ps1` (requires restored shipping projects). The default inventories all seven shipping targets; pass specific target frameworks after the repository path to restrict a run.\n\n");
foreach (var group in entries.Values.GroupBy(e => e.Package))
{
    markdown.Append("## ").Append(group.Key).Append("\n\n");
    foreach (var e in group)
    {
        markdown.Append("#### `").Append(e.Id).Append("`\n\n").Append(e.Description).Append("\n\n```csharp\n").Append(e.Signature).Append("\n```\n\n");
        markdown.Append("Availability: ").Append(string.Join(", ", e.Targets)).Append(". Source: `").Append(e.Source).Append("`.\n\n");
        if (e.Parameters.Length > 0) markdown.Append(e.Parameters).Append("\n\n");
        markdown.Append("```csharp\n").Append(e.Example).Append("\n```\n\n");
    }
}
var manifest = new JsonObject { ["generator"] = "tools/generate-api-reference.cs", ["memberCount"] = entries.Count, ["exampleCount"] = entries.Count, ["compilerErrorCount"] = failures.Count, ["targets"] = new JsonArray(targets.Select(t => JsonValue.Create(t)).ToArray()), ["members"] = new JsonArray(entries.Values.Select(e => (JsonNode)new JsonObject { ["package"] = e.Package, ["namespace"] = e.Namespace, ["id"] = e.Id, ["signature"] = e.Signature, ["source"] = e.Source, ["targets"] = new JsonArray(e.Targets.Select(t => JsonValue.Create(t)).ToArray()), ["exampleErrors"] = new JsonArray(e.Errors.Select(t => JsonValue.Create(t)).ToArray()) }).ToArray()) };

var pageDirectory = Path.Combine(repo, "docs", "api");
Directory.CreateDirectory(pageDirectory);
var expectedPages = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
const string pageMarker = "<!-- GENERATED PUBLIC API REFERENCE: tools/generate-api-reference.cs -->";
var indexMarkdown = new StringBuilder("# Public callable API reference\n\nEvery public method, overload, constructor, operator, conversion, delegate invocation, property and indexer has an exact signature, description and compiled C# example in the linked reference pages. Availability is recorded for each target framework. Examples accept valid existing typed inputs and are compiled without execution; retain native resources for their required lifetime. Observable sources subscribe directly; operation adapters observe their result before subscribing. Subscription examples return an IDisposable that the caller retains and disposes to control the subscription lifetime. Synchronous desktop methods support deferred fluent observation. Native buffer, pointer, span and by-reference methods retain direct calls.\n\nRegenerate: `pwsh ./tools/Update-ApiReference.ps1`.\n\n");
foreach (var package in entries.Values.GroupBy(e => e.Package))
{
    indexMarkdown.Append("## ").Append(package.Key).Append("\n\n");
    foreach (var ns in package.GroupBy(e => e.Namespace).OrderBy(g => g.Key))
    {
        indexMarkdown.Append("### ").Append(ns.Key).Append("\n\n");
        foreach (var type in ns.GroupBy(e => e.TypeName).OrderBy(g => g.Key))
        {
            var chunks = new List<List<Entry>> { new() };
            var byteCount = 0;
            foreach (var e in type)
            {
                var size = Encoding.UTF8.GetByteCount(Render(e));
                if (byteCount + size > 250_000 && chunks[^1].Count > 0) { chunks.Add(new()); byteCount = 0; }
                chunks[^1].Add(e); byteCount += size;
            }
            for (var chunk = 0; chunk < chunks.Count; chunk++)
            {
                var hash = Convert.ToHexString(System.Security.Cryptography.SHA256.HashData(Encoding.UTF8.GetBytes(package.Key + ":" + type.Key))).Substring(0, 12).ToLowerInvariant();
                var file = hash + (chunks.Count == 1 ? "" : "-" + (chunk + 1)) + ".md";
                expectedPages.Add(file);
                var page = new StringBuilder(pageMarker + "\n\n# " + type.Key + "\n\nPackage: `" + package.Key + "`. [API index](../api-reference-generated.md).\n\n");
                page.Append("## Callable members\n\n");
                foreach (var e in chunks[chunk]) page.Append("- [").Append(e.Id.Replace("`", "\\`")).Append("](#api-").Append(Anchor(e)).Append(")\n");
                page.Append("\n");
                foreach (var e in chunks[chunk]) page.Append(Render(e));
                File.WriteAllText(Path.Combine(pageDirectory, file), page.ToString().TrimEnd() + "\n");
                indexMarkdown.Append("- [").Append(type.Key).Append(chunks.Count == 1 ? "" : " (part " + (chunk + 1) + ")").Append("](api/").Append(file).Append(") — ").Append(chunks[chunk].Count).Append(" callable members.\n");
            }
        }
        indexMarkdown.Append("\n");
    }
}
foreach (var stalePage in Directory.EnumerateFiles(pageDirectory, "*.md", SearchOption.TopDirectoryOnly))
    if (!expectedPages.Contains(Path.GetFileName(stalePage)) && File.ReadLines(stalePage).FirstOrDefault() == pageMarker) File.Delete(stalePage);
File.WriteAllText(Path.Combine(repo, "docs", "api-reference-generated.md"), indexMarkdown.ToString().TrimEnd() + "\n");
File.WriteAllText(Path.Combine(repo, "docs", "api-reference-manifest.json"), manifest.ToJsonString(new System.Text.Json.JsonSerializerOptions { WriteIndented = true }));
Console.WriteLine($"Total: {entries.Count} callable members / examples; {failures.Count} compiler errors");
foreach (var failure in failures.Take(80)) Console.WriteLine(failure);
return failures.Count == 0 ? 0 : 1;

static string Access(Accessibility accessibility) => accessibility switch { Accessibility.ProtectedOrInternal => "protected internal", Accessibility.ProtectedAndInternal => "private protected", _ => accessibility.ToString().ToLowerInvariant() };
static string Signature(ISymbol s)
{
    if (s is IPropertySymbol p)
    {
        var accessors = new List<string>();
        if (p.GetMethod is not null) accessors.Add((p.GetMethod.DeclaredAccessibility == p.DeclaredAccessibility ? "" : Access(p.GetMethod.DeclaredAccessibility) + " ") + "get;");
        if (p.SetMethod is not null) accessors.Add((p.SetMethod.DeclaredAccessibility == p.DeclaredAccessibility ? "" : Access(p.SetMethod.DeclaredAccessibility) + " ") + (p.SetMethod.IsInitOnly ? "init;" : "set;"));
        return p.ToDisplayString(SignatureFormat) + " { " + string.Join(" ", accessors) + " }";
    }
    if (s is IMethodSymbol m && m.Name.StartsWith("get_") && m.Parameters.Length == 1)
        return "extension(" + Declaration(m.Parameters[0]) + ") { public " + m.ReturnType.ToDisplayString(TypeFormat) + " @" + m.Name.Substring(4) + " { get; } }";
    return s.ToDisplayString(SignatureFormat);
}
static string Anchor(Entry e) => Convert.ToHexString(System.Security.Cryptography.SHA256.HashData(Encoding.UTF8.GetBytes(e.Package + ":" + e.Id + ":" + e.Signature))).Substring(0, 12).ToLowerInvariant();
static string Render(Entry e) => "<a id=\"api-" + Anchor(e) + "\"></a>\n\n## `" + e.Id + "`\n\n" + e.Description + "\n\n```csharp\n" + e.Signature + "\n```\n\nAvailability: " + string.Join(", ", e.Targets) + ". Source: `" + e.Source + "`.\n\n" + (e.Parameters.Length == 0 ? "" : e.Parameters + "\n\n") + "```csharp\n" + e.Example + "\n```\n\n";
static IEnumerable<INamedTypeSymbol> Types(INamespaceSymbol ns) => ns.GetNamespaceMembers().SelectMany(Types).Concat(ns.GetTypeMembers().SelectMany(Nested));
static IEnumerable<INamedTypeSymbol> Nested(INamedTypeSymbol type) => new[] { type }.Concat(type.GetTypeMembers().SelectMany(Nested));
static bool Visible(ISymbol s) => s.DeclaredAccessibility == Accessibility.Public && (s.ContainingType is null || Visible(s.ContainingType));
static string Source(ISymbol s, string repo) { var l = s.Locations.FirstOrDefault(l => l.IsInSource); return l is null ? "compiler-generated" : Path.GetRelativePath(repo, l.SourceTree!.FilePath).Replace('\\', '/') + ":" + (l.GetLineSpan().StartLinePosition.Line + 1); }
static SyntaxNode? Syntax(ISymbol s)
{
    var syntax = s.DeclaringSyntaxReferences.Select(r => r.GetSyntax()).FirstOrDefault();
    if (syntax is not null) return syntax;
    var location = s.Locations.FirstOrDefault(l => l.IsInSource);
    return location?.SourceTree?.GetRoot().FindNode(location.SourceSpan).AncestorsAndSelf().FirstOrDefault(n => n is MemberDeclarationSyntax or AccessorDeclarationSyntax);
}
static XElement Xml(ISymbol s, Compilation c)
{
    var xml = s.GetDocumentationCommentXml(expandIncludes: true);
    var root = string.IsNullOrWhiteSpace(xml) ? new XElement("member") : XElement.Parse(xml);
    if (root.Element("summary") is null)
    {
        var syntax = Syntax(s);
        syntax = syntax?.AncestorsAndSelf().FirstOrDefault(n => n is MemberDeclarationSyntax);
        var trivia = syntax?.GetLeadingTrivia().FirstOrDefault(t => t.GetStructure() is DocumentationCommentTriviaSyntax);
        if (trivia is { } value && value.GetStructure() is DocumentationCommentTriviaSyntax comment)
        {
            var fragment = string.Join("\n", comment.ToFullString().Split('\n').Select(line => line.TrimStart().StartsWith("///") ? line.TrimStart().Substring(3) : line));
            root = XElement.Parse("<member>" + fragment + "</member>");
        }
    }
    if (root.Descendants("inheritdoc").Any())
    {
        ISymbol? inherited = s switch { IMethodSymbol m => m.OverriddenMethod, IPropertySymbol p => p.OverriddenProperty, _ => null };
        if (inherited is not null) return Xml(inherited, c);
        foreach (var iface in s.ContainingType.AllInterfaces)
            foreach (var member in iface.GetMembers().Where(x => x.Name == s.Name))
                if (SymbolEqualityComparer.Default.Equals(s.ContainingType.FindImplementationForInterfaceMember(member), s)) return Xml(member, c);
    }
    return root;
}
static string Text(XElement? e)
{
    if (e is null) return "";
    var text = string.Concat(e.DescendantNodes().Select(n => n is XText x ? x.Value : n is XElement element && element.Name == "see" ? ((string?)element.Attribute("cref") ?? (string?)element.Attribute("langword") ?? "").Replace("T:", "") : ""));
    return string.Join(" ", text.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries));
}
static string Description(XElement xml, ISymbol s)
{
    if (s is IMethodSymbol { IsImplicitlyDeclared: true } implicitMethod)
    {
        if (implicitMethod.MethodKind == MethodKind.DelegateInvoke) return "Invokes the delegate's bound callback with the supplied arguments and returns its result.";
        if (s.ContainingType.TypeKind == TypeKind.Delegate && implicitMethod.MethodKind == MethodKind.Constructor) return "Creates a delegate bound to the typed callback shown in the C# example.";
        if (implicitMethod.Name == "BeginInvoke") return "Starts the delegate asynchronous invocation with a completion callback and caller state.";
        if (implicitMethod.Name == "EndInvoke") return "Retrieves the result of the matching asynchronous delegate invocation.";
        if (implicitMethod.Name == "Equals") return "Tests equality using the generated value-equality contract for " + s.ContainingType.Name + ".";
        if (implicitMethod.Name == "GetHashCode") return "Computes a hash code consistent with the generated value-equality contract for " + s.ContainingType.Name + ".";
        if (implicitMethod.Name == "ToString") return "Formats the value using the generated " + s.ContainingType.Name + " representation.";
        if (implicitMethod.Name == "Deconstruct") return "Copies the value's components into the corresponding output parameters.";
        if (implicitMethod.Name == "op_Equality") return "Tests whether both operands have equal component values.";
        if (implicitMethod.Name == "op_Inequality") return "Tests whether the operands have different component values.";
        if (implicitMethod.MethodKind == MethodKind.Constructor && s.ContainingType.TypeKind == TypeKind.Enum) return "Creates the zero-valued default " + s.ContainingType.Name + " value.";
        if (implicitMethod.MethodKind == MethodKind.Constructor && implicitMethod.Parameters.Length == 0) return "Creates the default " + s.ContainingType.Name + " value.";
    }
    if (s is IPropertySymbol property && Syntax(property) is ParameterSyntax)
    {
        var typeXml = property.ContainingType.GetDocumentationCommentXml();
        var parameterDoc = string.IsNullOrWhiteSpace(typeXml) ? "" : Text(XElement.Parse(typeXml).Elements("param").FirstOrDefault(e => (string?)e.Attribute("name") == property.Name));
        if (parameterDoc.Length > 0) return "Gets or initializes " + char.ToLowerInvariant(parameterDoc[0]) + parameterDoc.Substring(1);
    }
    var summary = Text(xml.Element("summary"));
    if (summary.Length > 0) return summary;
    if (s is IMethodSymbol { MethodKind: MethodKind.Constructor } && s.ContainingType.TypeKind == TypeKind.Enum) return "Creates the zero-valued default " + s.ContainingType.Name + " value.";
    if (s is IMethodSymbol { MethodKind: MethodKind.Constructor }) return "Creates a " + s.ContainingType.Name + " instance using the supplied configuration.";
    if (s.Name == "get_SafeHBitmapHandle") return "Creates an owning safe handle for the bitmap\u0027s native GDI HBITMAP; dispose it after use.";
    if (s.Name == "get_SafeIconHandle") return "Creates an owning safe icon handle from the bitmap; dispose it after use.";
    if (s.Name == "get_Handle") return "Gets the native window handle for the WPF window.";
    if (s is IPropertySymbol propertyWithoutDocs)
    {
        var words = string.Concat(propertyWithoutDocs.Name.Select((c, i) => i > 0 && char.IsUpper(c) ? " " + char.ToLowerInvariant(c) : c.ToString())).ToLowerInvariant();
        return (propertyWithoutDocs.GetMethod is null ? "Sets " : propertyWithoutDocs.SetMethod is null ? "Gets " : propertyWithoutDocs.SetMethod.IsInitOnly ? "Gets or initializes " : "Gets or sets ") + "the " + words + (propertyWithoutDocs.Type.SpecialType == SpecialType.System_Boolean ? " flag." : " value.");
    }
    throw new InvalidOperationException("Missing callable documentation: " + s.ToDisplayString());
}
static string Parameters(XElement xml, ISymbol s)
{
    var ps = s is IMethodSymbol m ? m.Parameters : ((IPropertySymbol)s).Parameters;
    return string.Join("\n", ps.Select(p => "- `" + p.Name + "` (`" + p.Type.ToDisplayString() + "`): " + ParameterText(xml, s, p) + (p.HasExplicitDefaultValue ? " Default: `" + (p.ExplicitDefaultValue?.ToString() ?? "null") + "`." : "")));
}
static string ParameterText(XElement xml, ISymbol s, IParameterSymbol p)
{
    var description = Text(xml.Elements("param").FirstOrDefault(e => (string?)e.Attribute("name") == p.Name));
    if (description.Length > 0) return description;
    var block = Syntax(s)?.AncestorsAndSelf().OfType<ExtensionBlockDeclarationSyntax>().FirstOrDefault();
    if (block is not null && s is IMethodSymbol method && SymbolEqualityComparer.Default.Equals(method.Parameters.FirstOrDefault(), p))
    {
        var comment = block.GetLeadingTrivia().Select(t => t.GetStructure()).OfType<DocumentationCommentTriviaSyntax>().FirstOrDefault();
        if (comment is not null)
        {
            var fragment = string.Join("\n", comment.ToFullString().Split('\n').Select(line => line.TrimStart().StartsWith("///") ? line.TrimStart().Substring(3) : line));
            var receiver = Text(XElement.Parse("<member>" + fragment + "</member>").Elements("param").FirstOrDefault());
            if (receiver.Length > 0) return receiver;
        }
        return "The existing instance extended by this member.";
    }
    if (s.ContainingType.TypeKind == TypeKind.Delegate)
    {
        if (p.Name == "callback") return "Callback invoked when the asynchronous delegate invocation completes.";
        if (p.Name == "result") return "The asynchronous result returned by BeginInvoke.";
        if (p.Name == "object") return s is IMethodSymbol { MethodKind: MethodKind.Constructor } ? "The target object captured by the delegate runtime constructor; the C# example uses a typed handler." : "State passed to the asynchronous callback.";
        if (p.Name == "method") return "The delegate runtime method pointer; construct the delegate from a typed handler in C#.";
    }
    var words = string.Concat(p.Name.Select((c, i) => i > 0 && char.IsUpper(c) ? " " + char.ToLowerInvariant(c) : c.ToString()));
    return p.RefKind switch { RefKind.Out => "Receives the " + words + " produced by this call.", RefKind.Ref => "The mutable " + words + " read or updated by this call.", _ => "The " + words + " supplied to this call." };
}
static string Example(ISymbol s)
{
    var type = s.ContainingType;
    var typeGenericParameters = TypeParameters(type).ToArray();
    var typeGenerics = typeGenericParameters.Length == 0 ? "" : "<" + string.Join(", ", typeGenericParameters.Select(t => t.Name)) + ">";
    var typeConstraints = string.Join(" ", typeGenericParameters.Select(Constraint).Where(x => x.Length > 0));
    var m = s as IMethodSymbol;
    var p = s as IPropertySymbol;
    if (m?.MethodKind == MethodKind.Constructor && type.TypeKind == TypeKind.Delegate) return "internal static class ApiExample { internal static void Call" + typeGenerics + "(" + type.ToDisplayString(TypeFormat) + " handler) " + typeConstraints + " { _ = new " + type.ToDisplayString(TypeFormat) + "(handler.Invoke); } }";
    var parameters = (m?.Parameters ?? p!.Parameters).Select(x => Declaration(x)).ToList();
    var receiver = "receiver";
    if (!s.IsStatic && m?.MethodKind != MethodKind.Constructor) parameters.Insert(0, (p is not null && type.IsValueType && p.SetMethod is { DeclaredAccessibility: Accessibility.Public, IsInitOnly: false } ? "ref " : "") + type.ToDisplayString(TypeFormat) + " " + receiver);
    var sourceSyntax = Syntax(s);
    var isBlockExtension = sourceSyntax?.AncestorsAndSelf().Any(n => n is ExtensionBlockDeclarationSyntax) == true && s.IsStatic;
    var argumentList = string.Join(", ", (m?.Parameters ?? p!.Parameters).Select(x => (x.RefKind switch { RefKind.Ref => "ref ", RefKind.Out => "out ", RefKind.In => "in ", _ => "" }) + "@" + x.Name));
    var generic = m is { TypeParameters.Length: > 0 } ? "<" + string.Join(", ", m.TypeParameters.Select(t => t.Name)) + ">" : "";
    var operation = m?.MethodKind switch
    {
        MethodKind.Constructor => "new " + type.ToDisplayString(TypeFormat) + "(" + argumentList + ")",
        MethodKind.Conversion => "(" + m.ReturnType.ToDisplayString(TypeFormat) + ")@" + m.Parameters[0].Name,
        MethodKind.UserDefinedOperator => Operator(m),
        _ => p is not null ? (s.IsStatic ? type.ToDisplayString(TypeFormat) : receiver) + (p.IsIndexer ? "[" + argumentList + "]" : ".@" + p.Name) : (s.IsStatic ? type.ToDisplayString(TypeFormat) : receiver) + ".@" + s.Name + generic + "(" + argumentList + ")"
    };
        var import = "";
    if (isBlockExtension && m is not null && m.Parameters.Length > 0)
    {
        import = "using " + type.ContainingNamespace.ToDisplayString() + ";\n";
        var tail = string.Join(", ", m.Parameters.Skip(1).Select(x => (x.RefKind switch { RefKind.Ref => "ref ", RefKind.Out => "out ", RefKind.In => "in ", _ => "" }) + "@" + x.Name));
        operation = "@" + m.Parameters[0].Name + "." + (m.Name.StartsWith("get_") ? "@" + m.Name.Substring(4) : "@" + m.Name + generic + "(" + tail + ")");
    }
        var setupStatement = "";
    if (p is not null && p.SetMethod is { DeclaredAccessibility: Accessibility.Public, IsInitOnly: false })
    {
        parameters.Add(p.Type.ToDisplayString(TypeFormat) + " configurableValue");
        if (p.GetMethod?.DeclaredAccessibility == Accessibility.Public) setupStatement = operation + " = configurableValue;\n        ";
        else operation += " = configurableValue";
    }
    var allGeneric = typeGenericParameters.Concat(m?.TypeParameters ?? []).Distinct(SymbolEqualityComparer.Default).Cast<ITypeParameterSymbol>().ToArray();
    var declarationGeneric = allGeneric.Length == 0 ? "" : "<" + string.Join(", ", allGeneric.Select(t => t.Name)) + ">";
    var constraints = string.Join("\n", allGeneric.Select(Constraint).Where(x => x.Length > 0));
    var returnsVoid = m?.ReturnsVoid == true || p is not null && p.GetMethod?.DeclaredAccessibility != Accessibility.Public;
    var result = p?.Type ?? m?.ReturnType;
    var observableValue = returnsVoid ? null : ObservableValue(result);
    var operationValue = returnsVoid ? null : OperationValue(result);
    var subscribes = observableValue is not null || operationValue is not null;
    var fluent = !subscribes && m is { MethodKind: MethodKind.Ordinary, ReturnsByRef: false, ReturnsByRefReadonly: false } && type.ContainingNamespace.ToDisplayString().Contains(".Desktop.") && m.Parameters.All(x => x.RefKind == RefKind.None && Capturable(x.Type)) && (m.ReturnsVoid || Capturable(m.ReturnType)) && !type.IsRefLikeType && !m.Name.StartsWith("get_");
    if (subscribes)
    {
        var valueType = (observableValue ?? operationValue)!.ToDisplayString(TypeFormat);
        parameters.Add("global::System.IObserver<" + valueType + "> operationObserver");
        operation = operationValue is not null ? "(" + operation + ").Observe().Subscribe(operationObserver)" : "((global::System.IObservable<" + valueType + ">)(" + operation + ")).Subscribe(operationObserver)";
        returnsVoid = false;
    }
    else if (fluent)
    {
        var resultType = m!.ReturnsVoid ? "global::ReactiveUI.Primitives.RxVoid" : m.ReturnType.ToDisplayString(TypeFormat);
        parameters.Add("global::System.IObserver<" + resultType + "> operationObserver");
        operation = "global::CP.ReactiveUI.Primitives.Windows.Operations.WindowsOperation.From(() => " + operation + ").Select(value => value).Observe().Subscribe(operationObserver)";
        returnsVoid = false;
    }
    subscribes |= fluent;
    return import + "internal static " + ((m?.Parameters.Any(x => x.Type.TypeKind is TypeKind.Pointer or TypeKind.FunctionPointer) == true || m?.ReturnType.TypeKind is TypeKind.Pointer or TypeKind.FunctionPointer || p?.Type.TypeKind is TypeKind.Pointer or TypeKind.FunctionPointer || p?.Parameters.Any(x => x.Type.TypeKind is TypeKind.Pointer or TypeKind.FunctionPointer) == true) ? "unsafe " : "") + "class ApiExample\n{\n    internal static " + (subscribes ? "global::System.IDisposable" : "void") + " Call" + declarationGeneric + "(" + string.Join(", ", parameters) + ")\n" + (constraints.Length == 0 ? "" : "    " + constraints.Replace("\n", "\n    ") + "\n") + "    {\n        " + setupStatement + (subscribes ? "return " : returnsVoid ? "" : "_ = ") + operation + ";\n    }\n}";
}
static ITypeSymbol? ObservableValue(ITypeSymbol? type)
{
    if (type is not INamedTypeSymbol named) return null;
    return new[] { named }.Concat(named.AllInterfaces).FirstOrDefault(t => t.OriginalDefinition.Name == "IObservable" && t.OriginalDefinition.Arity == 1 && t.OriginalDefinition.ContainingNamespace.ToDisplayString() == "System")?.TypeArguments[0];
}
static ITypeSymbol? OperationValue(ITypeSymbol? type) => type is INamedTypeSymbol { TypeArguments.Length: 1 } named && named.Name is "WindowsOperation" or "WindowsAsyncOperation" && named.ContainingNamespace.ToDisplayString() == "CP.ReactiveUI.Primitives.Windows.Operations" ? named.TypeArguments[0] : null;
static IEnumerable<ITypeParameterSymbol> TypeParameters(INamedTypeSymbol t) => (t.ContainingType is null ? [] : TypeParameters(t.ContainingType)).Concat(t.TypeParameters);
static bool Capturable(ITypeSymbol t) => t.TypeKind is not (TypeKind.Pointer or TypeKind.FunctionPointer) && t is not INamedTypeSymbol { IsRefLikeType: true };
static string Declaration(IParameterSymbol p) => (p.RefKind switch { RefKind.Ref => "ref ", RefKind.Out => "out ", RefKind.In => "in ", _ => "" }) + p.Type.ToDisplayString(TypeFormat) + " @" + p.Name;
static string Constraint(ITypeParameterSymbol t)
{
    var c = new List<string>();
    if (t.HasUnmanagedTypeConstraint) c.Add("unmanaged"); else if (t.HasValueTypeConstraint) c.Add("struct"); else if (t.HasReferenceTypeConstraint) c.Add("class"); else if (t.HasNotNullConstraint) c.Add("notnull");
    c.AddRange(t.ConstraintTypes.Select(x => x.ToDisplayString(TypeFormat)));
    if (t.HasConstructorConstraint) c.Add("new()");
    return c.Count == 0 ? "" : "where " + t.Name + " : " + string.Join(", ", c);
}
static string Operator(IMethodSymbol m)
{
    var op = m.DeclaringSyntaxReferences.Select(r => r.GetSyntax()).OfType<OperatorDeclarationSyntax>().FirstOrDefault()?.OperatorToken.Text ?? m.Name switch { "op_Equality" => "==", "op_Inequality" => "!=", "op_Addition" => "+", "op_Subtraction" => "-", "op_Multiply" => "*", "op_Division" => "/", "op_Increment" => "++", "op_Decrement" => "--", _ => throw new InvalidOperationException(m.Name) };
    return m.Parameters.Length == 1 ? op + "@" + m.Parameters[0].Name : "@" + m.Parameters[0].Name + " " + op + " @" + m.Parameters[1].Name;
}
static class Formats
{
public static SymbolDisplayFormat TypeFormat => SymbolDisplayFormat.FullyQualifiedFormat.WithMiscellaneousOptions(SymbolDisplayMiscellaneousOptions.EscapeKeywordIdentifiers | SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier);
public static SymbolDisplayFormat SignatureFormat => SymbolDisplayFormat.CSharpErrorMessageFormat.WithMemberOptions(SymbolDisplayMemberOptions.IncludeAccessibility | SymbolDisplayMemberOptions.IncludeModifiers | SymbolDisplayMemberOptions.IncludeContainingType | SymbolDisplayMemberOptions.IncludeType | SymbolDisplayMemberOptions.IncludeParameters | SymbolDisplayMemberOptions.IncludeRef).WithParameterOptions(SymbolDisplayParameterOptions.IncludeType | SymbolDisplayParameterOptions.IncludeName | SymbolDisplayParameterOptions.IncludeDefaultValue | SymbolDisplayParameterOptions.IncludeParamsRefOut).WithGenericsOptions(SymbolDisplayGenericsOptions.IncludeTypeParameters | SymbolDisplayGenericsOptions.IncludeTypeConstraints);
}
sealed record Entry(string Package, string Namespace, string TypeName, string Id, string Signature, string Description, string Example, string Source, string Parameters)
{
    public SortedSet<string> Targets { get; } = new(StringComparer.Ordinal);
    public List<string> Errors { get; } = [];
}
