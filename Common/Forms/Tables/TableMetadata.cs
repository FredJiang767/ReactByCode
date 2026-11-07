namespace ReactByCode.Common.Forms;

public sealed class TableMetadata
{
    public string Title { get; init; } = "";
    public string RowKey { get; init; } = "";
    public string EmptyMessage { get; init; } = "";
    public List<TableColumn> Columns { get; init; } = [];
    public List<HeaderLink> HeaderLinks { get; init; } = [];
}
