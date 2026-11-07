using System.Linq.Expressions;
namespace ReactByCode.Common.Forms;

public sealed class CriteriaBuilder<TCriteria>
{
    private readonly List<CriteriaField> fields = [];

    public CriteriaBuilder<TCriteria> Text(Expression<Func<TCriteria, object?>> field, string label)
        => Add(field, label, "text", null);

    public CriteriaBuilder<TCriteria> Date(Expression<Func<TCriteria, object?>> field, string label)
        => Add(field, label, "date", null);

    public CriteriaBuilder<TCriteria> Select(Expression<Func<TCriteria, object?>> field, string label, params string[] options)
        => Add(field, label, "select", options.Select(o => new CriteriaOption(o, o)).ToList());

    internal CriteriaMetadata Build()
    {
        if (fields.Count == 0) 
            new InvalidOperationException("A search form requires at least one field.");

        return new CriteriaMetadata { Fields = fields };
    }

    private CriteriaBuilder<TCriteria> Add(Expression<Func<TCriteria, object?>> field, string label, string type, List<CriteriaOption>? options)
    {
        fields.Add(new CriteriaField(FieldExpression.PropertyName(field), label, type, options));
        return this;
    }
}
