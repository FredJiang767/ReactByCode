namespace ReactByCode.Common.Forms;

public sealed class PageSectionMetadata
{
    public string Key { get; set; } = "";
    public string Type { get; set; } = "table";
    public CriteriaMetadata? Criteria { get; set; }
    public FormMetadata? Form { get; set; }
    public TableMetadata Table { get; set; } = new();
    public string Source { get; set; } = "";
    public string? SaveSource { get; set; }
}
