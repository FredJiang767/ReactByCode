using System.Linq.Expressions;
namespace ReactByCode.Common.Forms;

public sealed class TableBuilder<TRow>
{
    private string title = "";
    private string rowKey = "";
    private string emptyMessage = "No data.";
    private readonly List<TableColumn> columns = [];
    private readonly List<HeaderLink> headerLinks = [];

    public TableBuilder<TRow> Title(string text) { title = text; return this; }
    public TableBuilder<TRow> EmptyMessage(string text) { emptyMessage = text; return this; }

    public TableBuilder<TRow> RowKey(Expression<Func<TRow, object?>> field) { rowKey = FieldExpression.PropertyName(field); return this; }

    public TableBuilder<TRow> Column(Expression<Func<TRow, object?>> field, string header, ColumnFormat format = ColumnFormat.None)
    {
        columns.Add(new TableColumn(FieldExpression.PropertyName(field), header, format.ToString().ToLowerInvariant()));
        return this;
    }

    public TableBuilder<TRow> Link(Expression<Func<TRow, object?>> field, string header, string href)
    {
        columns.Add(new TableColumn(FieldExpression.PropertyName(field), header, "link", href));
        return this;
    }

    public TableBuilder<TRow> HeaderLink(string label, string href)
    {
        headerLinks.Add(new HeaderLink(label, href));
        return this;
    }

    internal TableMetadata Build()
    {
        if (rowKey.Length == 0) throw new InvalidOperationException("A table requires a row key.");
        if (columns.Count == 0) throw new InvalidOperationException("A table requires at least one column.");
        return new TableMetadata { Title = title, RowKey = rowKey, EmptyMessage = emptyMessage, Columns = columns, HeaderLinks = headerLinks };
    }
}
