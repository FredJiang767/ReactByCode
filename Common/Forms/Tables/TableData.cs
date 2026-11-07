namespace ReactByCode.Common.Forms;

// The response body of a table data endpoint.
public sealed class TableData<TRow>
{
    public List<TRow> Items { get; set; } = [];
}
