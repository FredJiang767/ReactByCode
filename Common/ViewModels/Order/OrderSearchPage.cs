using ReactByCode.Common.Forms;
using ReactByCode.Controllers;
namespace ReactByCode.Common.ViewModels.Order;

// Declares the order search page: criteria form above the order table, rows from OrderController.Search.
public static class OrderSearchPage
{
    public static PageConfiguration Configure() => Page.Configure(pc => pc
        .SearchSection("orders", OrderSearchCriteria.DefineCriteria(), OrderTable.DefineTable())
            .LoadFrom<OrderController>(controller => controller.Search(null!)));
}