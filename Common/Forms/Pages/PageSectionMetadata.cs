namespace ReactByCode.Common.Forms;

// Type is "table" (rows only) or "search" (criteria form above the rows).
public sealed class PageSectionMetadata
{
    public string Key { get; set; } = "";
    public string Type { get; set; } = "table";
    public CriteriaMetadata? Criteria { get; set; }
    public TableMetadata Table { get; set; } = new();
    public string Source { get; set; } = "";
}
