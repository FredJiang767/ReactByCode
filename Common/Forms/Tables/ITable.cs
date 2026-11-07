namespace ReactByCode.Common.Forms;

public interface ITable<TRow>
{
    static abstract TableBuilder<TRow> DefineTable();
}
