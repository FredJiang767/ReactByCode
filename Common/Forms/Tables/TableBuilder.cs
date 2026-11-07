using System.Linq.Expressions;
namespace ReactByCode.Common.Forms;

// Fluent definition of a table's columns, typed on the row class so column fields are compile-checked.
public sealed class TableBuilder<TRow>
{
    private string title = "";
    private string rowKey = "";
    private string emptyMessage = "No data.";
    private readonly List<TableColumn> columns = [];

    public TableBuilder<TRow> Title(string text) { title = text; return this; }
    public TableBuilder<TRow> EmptyMessage(string text) { emptyMessage = text; return this; }

    // The row property that uniquely identifies a row (used as the React key).
    public TableBuilder<TRow> RowKey(Expression<Func<TRow, object?>> field) { rowKey = FieldExpression.PropertyName(field); return this; }

    // A data column of one row property, such as .Column(x => x.Name, "Name").
    public TableBuilder<TRow> Column(Expression<Func<TRow, object?>> field, string header, ColumnFormat format = ColumnFormat.None)
    {
        columns.Add(new TableColumn(FieldExpression.PropertyName(field), header, format.ToString().ToLowerInvariant()));
        return this;
    }

    internal TableMetadata Build()
    {
        if (rowKey.Length == 0) throw new InvalidOperationException("A table requires a row key.");
        if (columns.Count == 0) throw new InvalidOperationException("A table requires at least one column.");
        return new TableMetadata { Title = title, RowKey = rowKey, EmptyMessage = emptyMessage, Columns = columns };
    }
}
