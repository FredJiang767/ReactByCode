using System.Linq.Expressions;
namespace ReactByCode.Common.Forms;

public sealed class PageConfigurationBuilder
{
    private readonly PageConfiguration configuration = new();

    public PageConfigurationBuilder Section<TRow>(string key, TableBuilder<TRow> table)
    {
        configuration.Definitions.Add(new PageSectionDefinition(key, table.Build(), null, null));
        return this;
    }

    public PageConfigurationBuilder SearchSection<TCriteria, TRow>(string key, CriteriaBuilder<TCriteria> criteria, TableBuilder<TRow> table)
    {
        configuration.Definitions.Add(new PageSectionDefinition(key, table.Build(), criteria.Build(), null));
        return this;
    }

    public PageConfigurationBuilder FormSection<TForm>(string key, FormBuilder<TForm> form)
    {
        configuration.Definitions.Add(new PageSectionDefinition(key, new TableMetadata(), null, form.Build()));
        return this;
    }

    public PageConfigurationBuilder LoadFrom<TController>(Expression<Func<TController, object?>> action)
    {
        PageSectionDefinition section = LastSection();
        section.Controller = ControllerName<TController>();
        section.Action = ActionName(action);
        return this;
    }

    public PageConfigurationBuilder SaveTo<TController>(Expression<Func<TController, object?>> action)
    {
        LastSection().SaveAction = ActionName(action);
        return this;
    }

    internal PageConfiguration Build() => configuration;

    private PageSectionDefinition LastSection()
    {
        if (configuration.Definitions.Count == 0)
            throw new InvalidOperationException("The call requires a preceding Section.");

        return configuration.Definitions[^1];
    }

    private static string ControllerName<TController>() => typeof(TController).Name.Replace("Controller", "");

    private static string ActionName<TController>(Expression<Func<TController, object?>> action)
    {
        if (action.Body is not MethodCallExpression call)
            throw new InvalidOperationException("The call requires a controller method call.");

        return call.Method.Name;
    }
}
