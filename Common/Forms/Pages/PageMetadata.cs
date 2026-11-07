namespace ReactByCode.Common.Forms;

public sealed class PageMetadata
{
    public int SchemaVersion { get; set; } = 1;
    public List<PageSectionMetadata> Sections { get; set; } = [];
}
