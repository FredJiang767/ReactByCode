using Microsoft.Extensions.FileProviders;
using ReactByCode.Services.Customer;
namespace ReactByCode.Hosting;

public static class AppHost
{
    public static WebApplication Create(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        builder.Services.AddSingleton(new AppOptions(builder.Configuration));
        builder.Services.AddSingleton<ReactDocumentRenderer>();
        builder.Services.AddSingleton<ICustomerService, MockCustomerService>();
        var app = builder.Build();
        if (builder.Environment.IsDevelopment()) app.UseDeveloperExceptionPage();
        string assets = Path.Combine(builder.Environment.ContentRootPath, "ReactApp", "dist");
        if (Directory.Exists(assets))
            app.UseStaticFiles(new StaticFileOptions { FileProvider = new PhysicalFileProvider(assets), RequestPath = "/ReactApp/dist" });
        app.UseRouting();
        app.MapGet("/health", () => Results.Ok(new { status = "ready" }));
        app.MapGet("/", () => Results.Redirect("/Customers"));
        app.MapControllers();
        return app;
    }
}