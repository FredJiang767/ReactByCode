using System.Text.Json;
using System.Text.Json.Serialization;
namespace ReactByCode.Hosting;

// Builds the data the Razor shell needs: the page settings JSON and the URLs of the React entry script and styles.
public sealed class ReactDocumentRenderer(IWebHostEnvironment environment, MigrationOptions options)
{
    private const string Entry = "src/integrated/main.tsx";

    public Task<ReactDocument> CreateAsync(HttpContext context, string configurationUrl)
    {
        context.Response.Headers.CacheControl = "no-store";
        string configuration = JsonSerializer.Serialize(new { configurationUrl });

        // Development: load modules straight from the Vite dev server.
        if (options.ViteUrl != null)
        {
            string vite = options.ViteUrl.GetLeftPart(UriPartial.Authority);
            return Task.FromResult(new ReactDocument(configuration, vite + "/" + Entry, [], vite));
        }

        // Production: resolve hashed asset file names from the Vite manifest.
        string path = Path.Combine(environment.ContentRootPath, "ReactApp", "dist", ".vite", "manifest.json");
        var manifest = JsonSerializer.Deserialize<Dictionary<string, ManifestEntry>>(File.ReadAllText(path))
            ?? throw new InvalidOperationException("The React manifest is missing.");
        var styles = new HashSet<string>();
        AddStyles(manifest, Entry, styles, []);
        return Task.FromResult(new ReactDocument(configuration, AssetUrl(manifest[Entry].File), styles.Select(AssetUrl).ToArray(), null));
    }

    // Rejects manifest paths that could escape the assets folder.
    private static string AssetUrl(string file)
    {
        if (file.Contains("..") || file.Contains('\\') || file.Contains(':') || file.StartsWith('/'))
            throw new InvalidOperationException("The React manifest path is invalid.");
        return "/ReactApp/dist/" + file;
    }

    // Collects the CSS of an entry and of every chunk it imports.
    private static void AddStyles(Dictionary<string, ManifestEntry> manifest, string entry, HashSet<string> styles, HashSet<string> visited)
    {
        if (!visited.Add(entry)) return;
        var selected = manifest[entry];
        foreach (string import in selected.Imports ?? []) AddStyles(manifest, import, styles, visited);
        foreach (string css in selected.Css ?? []) styles.Add(css);
    }

    private sealed class ManifestEntry
    {
        [JsonPropertyName("file")] public string File { get; set; } = "";
        [JsonPropertyName("css")] public string[]? Css { get; set; }
        [JsonPropertyName("imports")] public string[]? Imports { get; set; }
    }
}