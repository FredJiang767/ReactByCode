using ReactByCode.Common.Forms;
namespace ReactByCode.Common.ViewModels.Order;

public sealed class OrderTable : ITable<OrderRow>
{
    public static TableBuilder<OrderRow> DefineTable()
        => Layout.Table<OrderRow>()
            .RowKey(row => row.OrderID)
            .Title("Orders")
            .EmptyMessage("No orders found.")
            .Column(row => row.OrderID, "Order #")
            .Column(row => row.CustomerName, "Customer")
            .Column(row => row.Status, "Status")
            .Column(row => row.Total, "Total", ColumnFormat.Currency)
            .Column(row => row.OrderDate, "Order Date", ColumnFormat.DateTime);
}