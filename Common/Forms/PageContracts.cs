namespace ReactByCode.Common.Forms;

// A table class declares its columns through one static DefineTable method.
public interface ITable<TRow>
{
    static abstract TableBuilder<TRow> DefineTable();
}

// A search criteria class declares its form through one static DefineCriteria method.
// Its properties are bound from the query string of the search endpoint.
public interface ISearchCriteria<TCriteria>
{
    static abstract CriteriaBuilder<TCriteria> DefineCriteria();
}

// The response body of a table data endpoint.
public sealed class TableData<TRow>
{
    public List<TRow> Items { get; set; } = [];
}