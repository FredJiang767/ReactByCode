namespace ReactByCode.Common.Forms;

// Entry points for defining a table or a search form: Layout.Table<TRow>(), Layout.Criteria<TCriteria>().
public static class Layout
{
    public static TableBuilder<TRow> Table<TRow>() => new();
    public static CriteriaBuilder<TCriteria> Criteria<TCriteria>() => new();
}
