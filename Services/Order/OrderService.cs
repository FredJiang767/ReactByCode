using ReactByCode.Common.ViewModels.Order;
namespace ReactByCode.Services.Order;

// Returns generated mock orders. Replace the body with a real data source later.
public sealed class OrderService : IOrderService
{
    private static readonly string[] Customers = ["Alice Johnson", "Bob Smith", "Carol Williams", "David Brown", "Emma Davis"];
    private static readonly string[] Statuses = ["Pending", "Paid", "Shipped", "Refunded"];

    public List<OrderRow> GetAll()
        => Enumerable.Range(0, 12).Select(i => new OrderRow
        {
            OrderID = 5001 + i,
            CustomerName = Customers[i % Customers.Length],
            Status = Statuses[i % Statuses.Length],
            Total = 19.99m + i * 12.5m,
            OrderDate = new DateTime(2026, 3, 1, 9, 30, 0).AddDays(i * 3).AddHours(i)
        }).ToList();
}