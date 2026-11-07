using System.Linq.Expressions;
namespace ReactByCode.Common.Forms;

// Fluent definition of a search form, typed on the criteria class so fields are compile-checked.
public sealed class CriteriaBuilder<TCriteria>
{
    private readonly List<CriteriaField> fields = [];

    public CriteriaBuilder<TCriteria> Text(Expression<Func<TCriteria, object?>> field, string label)
        => Add(field, label, "text", null);

    public CriteriaBuilder<TCriteria> Date(Expression<Func<TCriteria, object?>> field, string label)
        => Add(field, label, "date", null);

    // A dropdown. The browser adds an empty "All" choice in front of the given options.
    public CriteriaBuilder<TCriteria> Select(Expression<Func<TCriteria, object?>> field, string label, params string[] options)
        => Add(field, label, "select", options.Select(o => new CriteriaOption(o, o)).ToList());

    internal CriteriaMetadata Build()
    {
        if (fields.Count == 0) throw new InvalidOperationException("A search form requires at least one field.");
        return new CriteriaMetadata { Fields = fields };
    }

    private CriteriaBuilder<TCriteria> Add(Expression<Func<TCriteria, object?>> field, string label, string type, List<CriteriaOption>? options)
    {
        fields.Add(new CriteriaField(FieldExpression.PropertyName(field), label, type, options));
        return this;
    }
}
