namespace ReactByCode.Common.Forms;

// The serialized table definition sent to the browser.
public sealed class TableMetadata
{
    public string Title { get; init; } = "";
    public string RowKey { get; init; } = "";
    public string EmptyMessage { get; init; } = "";
    public List<TableColumn> Columns { get; init; } = [];
}
