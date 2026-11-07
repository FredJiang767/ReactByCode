using System.Linq.Expressions;
namespace ReactByCode.Common.Forms;

internal static class FieldExpression
{
    public static string PropertyName<T>(Expression<Func<T, object?>> field)
    {
        Expression body = field.Body is UnaryExpression { NodeType: ExpressionType.Convert } unary ? unary.Operand : field.Body;

        if (body is not MemberExpression member) 
            throw new InvalidOperationException("A field must select a property.");

        return char.ToLowerInvariant(member.Member.Name[0]) + member.Member.Name[1..];
    }
}