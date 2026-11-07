namespace ReactByCode.Common.Forms;

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
