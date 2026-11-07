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
    public const string DetailPageUrl = "/Customers/Detail";

    [ReactDocument, HttpGet(PageUrl)]
    public Task<IActionResult> ListPage() => RenderPage(nameof(ListConfiguration));

    [HttpGet]
    public ActionResult<PageMetadata> ListConfiguration() => Resolve(CustomerPage.Configure());

    [HttpGet]
    public TableData<CustomerRow> List() => new() { Items = service.GetAll() };

    [ReactDocument, HttpGet(DetailPageUrl)]
    public Task<IActionResult> DetailPage() => RenderPage(nameof(DetailConfiguration));

    [HttpGet]
    public ActionResult<PageMetadata> DetailConfiguration() => Resolve(CustomerDetailPage.Configure());

    [HttpGet]
    public ActionResult<CustomerDetailForm> Get(int? id)
    {
        if (id == null) return new CustomerDetailForm();

        CustomerRow? row = service.Get(id.Value);
        if (row == null) return NotFound();

        return new CustomerDetailForm { CustomerID = row.CustomerID, Name = row.Name, Email = row.Email };
    }

    [HttpPost]
    public SaveResult Save([FromBody] CustomerDetailForm form)
    {
        var result = new SaveResult { Errors = form.Validate() };
        if (result.Errors.Count == 0) result.Id = service.Save(form);
        return result;
    }
}
