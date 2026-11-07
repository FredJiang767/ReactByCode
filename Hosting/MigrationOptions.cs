namespace ReactByCode.Hosting;

// Host settings. ViteUrl is set only while developing with the Vite dev server (hot reload).
public sealed class MigrationOptions(IConfiguration configuration)
{
    public Uri? ViteUrl { get; } = Uri.TryCreate(configuration["ViteUrl"], UriKind.Absolute, out var url) ? url : null;
}