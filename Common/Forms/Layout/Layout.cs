namespace ReactByCode.Common.Forms;

public static class Layout
{
    public static TableBuilder<TRow> Table<TRow>() => new();
    public static CriteriaBuilder<TCriteria> Criteria<TCriteria>() => new();
    public static FormBuilder<TForm> Form<TForm>() => new();
}
