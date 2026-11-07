using Microsoft.AspNetCore.Mvc;
using ReactByCode.Common.Forms;
using ReactByCode.Hosting;
namespace ReactByCode.Controllers;

public abstract class PageController : Controller
{
    protected async Task<IActionResult> RenderPage(string configurationAction)
    {
        var renderer = HttpContext.RequestServices.GetRequiredService<ReactDocumentRenderer>();
        var document = await renderer.CreateAsync(HttpContext, Url.Action(configurationAction)!);
        return View("~/Views/Shared/ReactDocument.cshtml", document);
    }

    protected PageMetadata Resolve(PageConfiguration configuration)
        => configuration.Resolve(HttpContext.RequestServices.GetRequiredService<LinkGenerator>(), HttpContext);
}