using ReactByCode.Common.Forms;
namespace ReactByCode.Common.ViewModels.Order;

// The order search form. Each property is also a query string parameter of OrderController.Search.
public sealed class OrderSearchCriteria : ISearchCriteria<OrderSearchCriteria>
{
    public string? CustomerName { get; set; }
    public string? Status { get; set; }
    public DateTime? OrderDateFrom { get; set; }
    public DateTime? OrderDateTo { get; set; }

    public static CriteriaBuilder<OrderSearchCriteria> DefineCriteria()
        => Layout.Criteria<OrderSearchCriteria>()
            .Text(c => c.CustomerName, "Customer")
            .Select(c => c.Status, "Status", "Pending", "Paid", "Shipped", "Refunded")
            .Date(c => c.OrderDateFrom, "Order Date From")
            .Date(c => c.OrderDateTo, "Order Date To");
}