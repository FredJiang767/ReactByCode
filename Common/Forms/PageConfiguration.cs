using Microsoft.AspNetCore.Routing;
namespace ReactByCode.Common.Forms;

// A page declared in code. Resolve turns it into the metadata the browser renders.
public sealed class PageConfiguration
{
    internal List<PageSectionDefinition> Definitions { get; } = [];

    public PageMetadata Resolve(LinkGenerator links, HttpContext context)
    {
        var metadata = new PageMetadata();
        var keys = new HashSet<string>(StringComparer.Ordinal);
        foreach (PageSectionDefinition section in Definitions)
        {
            if (string.IsNullOrWhiteSpace(section.Key) || !keys.Add(section.Key))
                throw new InvalidOperationException("A Page requires unique nonblank Section keys: " + section.Key);

            metadata.Sections.Add(section.Resolve(links, context));
        }

        if (metadata.Sections.Count == 0)
            throw new InvalidOperationException("A Page requires at least one Section.");

        return metadata;
    }
}

// The serialized page definition sent to the browser.
public sealed class PageMetadata
{
    public int SchemaVersion { get; set; } = 1;
    public List<PageSectionMetadata> Sections { get; set; } = [];
}

public sealed class PageSectionMetadata
{
    public string Key { get; set; } = "";
    public string Type { get; set; } = "table";
    public TableMetadata Table { get; set; } = new();
    public string Source { get; set; } = "";
}

// Entry point for declaring a page: Page.Configure(pc => pc.Section(...).LoadFrom(...)).
public static class Page
{
    public static PageConfiguration Configure(Func<PageConfigurationBuilder, PageConfigurationBuilder> define)
        => define(new PageConfigurationBuilder()).Build();
}