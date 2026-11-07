namespace ReactByCode.Common.Forms;

// Entry point for declaring a page: Page.Configure(pc => pc.Section(...).LoadFrom(...)).
public static class Page
{
    public static PageConfiguration Configure(Func<PageConfigurationBuilder, PageConfigurationBuilder> define)
        => define(new PageConfigurationBuilder()).Build();
}
