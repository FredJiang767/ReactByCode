using ReactByCode.Common.Forms;
using ReactByCode.Controllers;
namespace ReactByCode.Common.ViewModels.Order;

// Declares the order page: one table section whose rows load from OrderController.List.
public static class OrderPage
{
    public static PageConfiguration Configure() => Page.Configure(pc => pc
        .Section("orders", OrderTable.DefineTable())
            .LoadFrom<OrderController>(controller => controller.List()));
}