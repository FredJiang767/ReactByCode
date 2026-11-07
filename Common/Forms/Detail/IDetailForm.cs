namespace ReactByCode.Common.Forms;

public interface IDetailForm<TForm>
{
    static abstract FormBuilder<TForm> DefineForm();
}
