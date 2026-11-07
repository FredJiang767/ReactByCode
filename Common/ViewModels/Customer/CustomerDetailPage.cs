using ReactByCode.Common.Forms;
using ReactByCode.Controllers;
namespace ReactByCode.Common.ViewModels.Customer;

public static class CustomerDetailPage
{
    public static PageConfiguration Configure() => Page.Configure(pc => pc
        .FormSection("customer", CustomerDetailForm.DefineForm())
            .LoadFrom<CustomerController>(controller => controller.Get(null))
            .SaveTo<CustomerController>(controller => controller.Save(null!)));
}
