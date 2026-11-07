using Microsoft.AspNetCore.Routing;
namespace ReactByCode.Common.Forms;

// One section of a page: a table, optionally with a search form, plus the controller action that supplies its rows.
internal sealed class PageSectionDefinition(string key, TableMetadata table, CriteriaMetadata? criteria)
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
        return new PageSectionMetadata
        {
            Key = Key,
            Type = criteria == null ? "table" : "search",
            Criteria = criteria,
            Table = table,
            Source = source
        };
    }
}
