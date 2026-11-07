using System.Linq.Expressions;
namespace ReactByCode.Common.Forms;

// One section of a page: a table plus the controller action that supplies its rows.
internal sealed class PageSectionDefinition(string key, TableMetadata table)
{
    public string Key { get; } = key;
    public string? Controller { get; set; }
    public string? Action { get; set; }

    public PageSectionMetadata Resolve(LinkGenerator links, HttpContext context)
    {
        if (Controller == null || Action == null)
            throw new InvalidOperationException("The Section needs a data source: " + Key);

        string source = links.GetPathByAction(context, Action, Controller)
            ?? throw new InvalidOperationException("The Section data route is missing: " + Key);
        return new PageSectionMetadata { Key = Key, Table = table, Source = source };
    }
}

public sealed class PageConfigurationBuilder
{
    private readonly PageConfiguration configuration = new();

    // Adds a table section. Follow it with LoadFrom to say where the rows come from.
    public PageConfigurationBuilder Section<TRow>(string key, TableBuilder<TRow> table)
    {
        configuration.Definitions.Add(new PageSectionDefinition(key, table.Build()));
        return this;
    }

    // Binds the last section to a controller action, e.g. LoadFrom<CustomerController>(c => c.List()).
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