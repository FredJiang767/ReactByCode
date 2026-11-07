namespace ReactByCode.Common.Forms;

// A table class declares its columns through one static DefineTable method.
public interface ITable<TRow>
{
    static abstract TableBuilder<TRow> DefineTable();
}
