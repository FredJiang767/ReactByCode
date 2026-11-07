using ReactByCode.Common.Forms;
using ReactByCode.Controllers;
namespace ReactByCode.Common.ViewModels.Order;

public static class OrderPage
{
    public static PageConfiguration Configure() => Page.Configure(pc => pc
        .SearchSection("orders", 
                OrderSearchCriteria.DefineCriteria(), 
                OrderTable.DefineTable())
            .LoadFrom<OrderController>(controller => controller.List(null!)));
}