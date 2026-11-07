using System.Linq.Expressions;
namespace ReactByCode.Common.Forms;

public sealed record TableColumn(string Key, string Title, string Format);

public sealed class TableMetadata
{
    public string Title { get; init; } = "";
    public string RowKey { get; init; } = "";
    public string EmptyMessage { get; init; } = "";
    public List<TableColumn> Columns { get; init; } = [];
}

public sealed class TableBuilder<TRow>
{
    private string title = "";
    private string rowKey = "";
    private string emptyMessage = "No data.";
    private readonly List<TableColumn> columns = [];

    public TableBuilder<TRow> Title(string text) { title = text; return this; }
    public TableBuilder<TRow> EmptyMessage(string text) { emptyMessage = text; return this; }
    public TableBuilder<TRow> RowKey(Expression<Func<TRow, object?>> field) { rowKey = Name(field); return this; }
    public TableBuilder<TRow> Column(Expression<Func<TRow, object?>> field, string header, ColumnFormat format = ColumnFormat.None)
    {
        columns.Add(new TableColumn(Name(field), header, format.ToString().ToLowerInvariant()));
        return this;
    }
    internal TableMetadata Build()
    {
        if (rowKey.Length == 0) throw new InvalidOperationException("A table requires a row key.");
        if (columns.Count == 0) throw new InvalidOperationException("A table requires at least one column.");
        return new TableMetadata { Title = title, RowKey = rowKey, EmptyMessage = emptyMessage, Columns = columns };
    }

    private static string Name(Expression<Func<TRow, object?>> field) => FieldExpression.PropertyName(field);
}
