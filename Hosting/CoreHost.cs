using Microsoft.Extensions.FileProviders;
namespace ReactByCode.Hosting;

// Builds the web application: services, static React assets, and routes.
public static class CoreHost
{
    public static WebApplication Create(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        CoreServiceRegistration.Register(builder);

        var app = builder.Build();
        if (builder.Environment.IsDevelopment()) app.UseDeveloperExceptionPage();

        // Serve the built React bundle (ReactApp/dist) under /ReactApp/dist.
        string assets = Path.Combine(builder.Environment.ContentRootPath, "ReactApp", "dist");
        if (Directory.Exists(assets))
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(assets),
                RequestPath = "/ReactApp/dist"
            });

        app.UseRouting();
        app.MapGet("/health", () => Results.Ok(new { status = "ready" }));
        app.MapGet("/", () => Results.Redirect("/Customers"));
        app.MapControllers();
        return app;
    }
}