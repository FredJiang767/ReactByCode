namespace ReactByCode.Common.Forms;

internal sealed class PageSectionDefinition(string key, TableMetadata table, CriteriaMetadata? criteria, FormMetadata? form)
{
    public string Key { get; } = key;
    public string? Controller { get; set; }
    public string? Action { get; set; }
    public string? SaveAction { get; set; }

    public PageSectionMetadata Resolve(LinkGenerator links, HttpContext context)
    {
        if (Controller == null || Action == null)
            throw new InvalidOperationException("The Section needs a data source: " + Key);

        string source = links.GetPathByAction(context, Action, Controller)
            ?? throw new InvalidOperationException("The Section data route is missing: " + Key);

        string? saveSource = SaveAction == null ? null : links.GetPathByAction(context, SaveAction, Controller);

        return new PageSectionMetadata
        {
            Key = Key,
            Type = form != null ? "form" : criteria == null ? "table" : "search",
            Criteria = criteria,
            Form = form,
            Table = table,
            Source = source,
            SaveSource = saveSource
        };
    }
}
