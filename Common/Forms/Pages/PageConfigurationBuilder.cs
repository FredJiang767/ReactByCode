using System.Linq.Expressions;
namespace ReactByCode.Common.Forms;

public sealed class PageConfigurationBuilder
{
    private readonly PageConfiguration configuration = new();

    // Adds a table section. Follow it with LoadFrom to say where the rows come from.
    public PageConfigurationBuilder Section<TRow>(string key, TableBuilder<TRow> table)
    {
        configuration.Definitions.Add(new PageSectionDefinition(key, table.Build(), null));
        return this;
    }

    // Adds a search section: a criteria form above a result table. The endpoint receives the criteria as query string values.
    public PageConfigurationBuilder SearchSection<TCriteria, TRow>(string key, CriteriaBuilder<TCriteria> criteria, TableBuilder<TRow> table)
    {
        configuration.Definitions.Add(new PageSectionDefinition(key, table.Build(), criteria.Build()));
        return this;
    }

    // Binds the last section to a controller action, e.g. LoadFrom<CustomerController>(c => c.List()).
    // Arguments of the call are ignored; only the action name is used.
    public PageConfigurationBuilder LoadFrom<TController>(Expression<Func<TController, object?>> action)
    {
        if (configuration.Definitions.Count == 0)
            throw new InvalidOperationException("LoadFrom requires a preceding Section.");
        if (action.Body is not MethodCallExpression call)
            throw new InvalidOperationException("LoadFrom requires a controller method call.");

        PageSectionDefinition section = configuration.Definitions[^1];
        section.Controller = typeof(TController).Name.Replace("Controller", "");
        section.Action = call.Method.Name;
        return this;
    }

    internal PageConfiguration Build() => configuration;
}
