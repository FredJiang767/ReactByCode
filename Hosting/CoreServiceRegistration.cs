using ReactByCode.Services.Customer;
namespace ReactByCode.Hosting;

// Registers the services the host needs.
public static class CoreServiceRegistration
{
    public static void Register(WebApplicationBuilder builder)
    {
        builder.Services.AddControllersWithViews();
        builder.Services.AddSingleton(new MigrationOptions(builder.Configuration));
        builder.Services.AddSingleton<ReactDocumentRenderer>();
        builder.Services.AddSingleton<ICustomerService, CustomerService>();
    }
}