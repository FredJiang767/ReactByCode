namespace ReactByCode.Common.Forms;

// The serialized page definition sent to the browser.
public sealed class PageMetadata
{
    public int SchemaVersion { get; set; } = 1;
    public List<PageSectionMetadata> Sections { get; set; } = [];
}
