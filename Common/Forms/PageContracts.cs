namespace ReactByCode.Common.Forms;

// A table class declares its columns through one static DefineTable method.
public interface ITable<TRow>
{
    static abstract TableBuilder<TRow> DefineTable();
}

// The response body of a table data endpoint.
public sealed class TableData<TRow>
{
    public List<TRow> Items { get; set; } = [];
}