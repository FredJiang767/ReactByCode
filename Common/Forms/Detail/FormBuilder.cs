using System.Linq.Expressions;
namespace ReactByCode.Common.Forms;

public sealed class FormBuilder<TForm>
{
    private readonly List<FormField> fields = [];

    public FormBuilder<TForm> Text(Expression<Func<TForm, object?>> field, string label, bool required = false)
    {
        fields.Add(new FormField(FieldExpression.PropertyName(field), label, "text", required));
        return this;
    }

    internal FormMetadata Build()
    {
        if (fields.Count == 0)
            throw new InvalidOperationException("A form requires at least one field.");

        return new FormMetadata { Fields = fields };
    }
}
