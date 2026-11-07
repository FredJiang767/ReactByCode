namespace ReactByCode.Common.Forms;

public interface ITable<TRow>
{
    static abstract TableBuilder<TRow> DefineTable();
}

public sealed class TableData<TRow>
{
    public List<TRow> Items { get; set; } = [];
}

public sealed class PageSection
{
    public string Key { get; init; } = "";
    public string Type { get; init; } = "table";
    public TableMetadata Table { get; init; } = new();
    public string Source { get; init; } = "";
}

public sealed class PageConfiguration
{
    public int SchemaVersion { get; init; } = 1;
    public string Title { get; init; } = "";
    public List<PageSection> Sections { get; init; } = [];
}