using Microsoft.AspNetCore.Mvc;
using ReactByCode.Common.Forms;
using ReactByCode.Common.ViewModels.Order;
using ReactByCode.Hosting;
using ReactByCode.Services.Order;
namespace ReactByCode.Controllers;

[Route("api/react/orders/[action]")]
public sealed class OrderController(IOrderService service) : PageController
{
    public const string PageUrl = "/Orders";

    // The browser page: returns the React shell.
    [ReactDocument, HttpGet(PageUrl)]
    public Task<IActionResult> ListPage() => RenderPage(nameof(ListConfiguration));

    // The page definition (sections, columns, data URLs).
    [HttpGet]
    public ActionResult<PageMetadata> ListConfiguration() => Resolve(OrderPage.Configure());

    // The table rows.
    [HttpGet]
    public TableData<OrderRow> List() => new() { Items = service.GetAll() };
}