namespace ReactByCode.Common.Forms;

public static class Page
{
    public static PageConfiguration Configure(Func<PageConfigurationBuilder, PageConfigurationBuilder> define)
        => define(new PageConfigurationBuilder()).Build();
}
