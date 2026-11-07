using Microsoft.AspNetCore.Mvc;
using ReactByCode.Common.Forms;
using ReactByCode.Common.ViewModels.Customer;
using ReactByCode.Hosting;
using ReactByCode.Services.Customer;
namespace ReactByCode.Controllers;

[Route("api/react/customers/[action]")]
public sealed class CustomerController(ICustomerService service) : PageController
{
    public const string PageUrl = "/Customers";

    // The browser page: returns the React shell.
    [ReactDocument, HttpGet(PageUrl)]
    public Task<IActionResult> ListPage() => RenderPage(nameof(ListConfiguration));

    // The page definition (sections, columns, data URLs).
    [HttpGet]
    public ActionResult<PageMetadata> ListConfiguration() => Resolve(CustomerPage.Configure());

    // The table rows.
    [HttpGet]
    public TableData<CustomerRow> List() => new() { Items = service.GetAll() };
}