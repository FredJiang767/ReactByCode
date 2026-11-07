using Microsoft.AspNetCore.Mvc;
using ReactByCode.Common.Forms;
using ReactByCode.Common.ViewModels.Customer;
using ReactByCode.Hosting;
using ReactByCode.Services.Customer;
namespace ReactByCode.Controllers;

public sealed class CustomerController(ICustomerService service, ReactDocumentRenderer renderer) : Controller
{
    [HttpGet("/Customers")]
    public async Task<IActionResult> Page()
        => View("~/Views/Shared/ReactDocument.cshtml", await renderer.CreateAsync(HttpContext, Url.Action(nameof(Configuration))!));

    [HttpGet("api/react/customers/configuration")]
    public ActionResult<PageConfiguration> Configuration()
        => CustomerPage.Configure(Url.Action(nameof(Customers))!);

    [HttpGet("api/react/customers/customers")]
    public TableData<CustomerRow> Customers() => new() { Items = service.GetAll() };
}