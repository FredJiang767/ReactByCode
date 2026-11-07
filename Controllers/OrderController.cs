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

    [ReactDocument, HttpGet(PageUrl)]
    public Task<IActionResult> ListPage() => RenderPage(nameof(ListConfiguration));

    [HttpGet]
    public ActionResult<PageMetadata> ListConfiguration() => Resolve(OrderPage.Configure());

    [HttpGet]
    public TableData<OrderRow> List([FromQuery] OrderSearchCriteria criteria) => new() { Items = service.Search(criteria) };
}