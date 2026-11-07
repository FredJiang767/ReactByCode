namespace ReactByCode.Common.ViewModels.Order;

public sealed class OrderRow
{
    public int OrderID { get; set; }
    public string? CustomerName { get; set; }
    public string? Status { get; set; }
    public decimal Total { get; set; }
    public DateTime? OrderDate { get; set; }
}