using System.Text.Json;
namespace ReactByCode.Hosting;

public sealed record ReactDocument(string ConfigurationJson, string ScriptUrl, string[] Styles, string? ViteBasePath);

public sealed class ReactDocumentRenderer(IWebHostEnvironment environment, AppOptions options)
{
    private const string Entry = "src/integrated/main.tsx";

    public Task<ReactDocument> CreateAsync(HttpContext context, string configurationUrl)
    {
        context.Response.Headers.CacheControl = "no-store";
        string configuration = JsonSerializer.Serialize(new { configurationUrl });
        if (options.ViteUrl != null)
        {
            string vite = options.ViteUrl.GetLeftPart(UriPartial.Authority);
            return Task.FromResult(new ReactDocument(configuration, vite + "/" + Entry, [], vite));
        }
        string path = Path.Combine(environment.ContentRootPath, "ReactApp", "dist", ".vite", "manifest.json");
        var manifest = JsonSerializer.Deserialize<Dictionary<string, ManifestEntry>>(File.ReadAllText(path))
            ?? throw new InvalidOperationException("The React manifest is missing.");
        var styles = new HashSet<string>();
        AddStyles(manifest, Entry, styles, []);
        return Task.FromResult(new ReactDocument(configuration, AssetUrl(manifest[Entry].file), styles.Select(AssetUrl).ToArray(), null));
    }

    private static string AssetUrl(string file)
    {
        if (file.Contains("..") || file.Contains('\\') || file.Contains(':') || file.StartsWith('/'))
            throw new InvalidOperationException("The React manifest path is invalid.");
        return "/ReactApp/dist/" + file;
    }

    private static void AddStyles(Dictionary<string, ManifestEntry> manifest, string entry, HashSet<string> styles, HashSet<string> visited)
    {
        if (!visited.Add(entry)) return;
        var selected = manifest[entry];
        foreach (string import in selected.Imports ?? []) AddStyles(manifest, import, styles, visited);
        foreach (string css in selected.Css ?? []) styles.Add(css);
    }

    private sealed class ManifestEntry
    {
        [System.Text.Json.Serialization.JsonPropertyName("file")] public string file { get; set; } = "";
        [System.Text.Json.Serialization.JsonPropertyName("css")] public string[]? Css { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("imports")] public string[]? Imports { get; set; }
    }
}