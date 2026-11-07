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
    public const string SearchPageUrl = "/OrderSearch";

    [ReactDocument, HttpGet(PageUrl)]
    public Task<IActionResult> ListPage() => RenderPage(nameof(ListConfiguration));

    [HttpGet]
    public ActionResult<PageMetadata> ListConfiguration() => Resolve(OrderPage.Configure());

    [HttpGet]
    public TableData<OrderRow> List() => new() { Items = service.GetAll() };

    [ReactDocument, HttpGet(SearchPageUrl)]
    public Task<IActionResult> SearchPage() => RenderPage(nameof(SearchConfiguration));

    [HttpGet]
    public ActionResult<PageMetadata> SearchConfiguration() => Resolve(OrderSearchPage.Configure());

    [HttpGet]
    public TableData<OrderRow> Search([FromQuery] OrderSearchCriteria criteria) => new() { Items = service.Search(criteria) };
}