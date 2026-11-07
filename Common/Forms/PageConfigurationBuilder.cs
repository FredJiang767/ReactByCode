namespace ReactByCode.Common.Forms;

public sealed class PageConfigurationBuilder(string title)
{
    private readonly List<PageSection> sections = [];

    public PageConfigurationBuilder Section<TRow, TTable>(string key, string source) where TTable : ITable<TRow>
    {
        if (sections.Any(s => s.Key == key)) throw new InvalidOperationException("Duplicate section key: " + key);
        sections.Add(new PageSection { Key = key, Table = TTable.DefineTable().Build(), Source = source });
        return this;
    }

    public PageConfiguration Build()
    {
        if (sections.Count == 0) throw new InvalidOperationException("A page requires at least one section.");
        return new PageConfiguration { Title = title, Sections = sections };
    }
}

public static class Page
{
    public static PageConfiguration Configure(string title, Func<PageConfigurationBuilder, PageConfigurationBuilder> define)
        => define(new PageConfigurationBuilder(title)).Build();
}