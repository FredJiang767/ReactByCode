namespace ReactByCode.Hosting;

public sealed class AppOptions(IConfiguration configuration)
{
    public Uri? ViteUrl { get; } = Uri.TryCreate(configuration["ViteUrl"], UriKind.Absolute, out var url) ? url : null;
}