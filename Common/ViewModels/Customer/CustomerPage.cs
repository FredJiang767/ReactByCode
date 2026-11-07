using ReactByCode.Common.Forms;
using ReactByCode.Controllers;
namespace ReactByCode.Common.ViewModels.Customer;

// Declares the customer page: one table section whose rows load from CustomerController.List.
public static class CustomerPage
{
    public static PageConfiguration Configure() => Page.Configure(pc => pc
        .Section("customers", CustomerTable.DefineTable())
            .LoadFrom<CustomerController>(controller => controller.List()));
}