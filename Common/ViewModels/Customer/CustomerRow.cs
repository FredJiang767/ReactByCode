namespace ReactByCode.Common.ViewModels.Customer;

// One row of the customer table. Property names become the camelCase JSON keys.
public sealed class CustomerRow
{
    public int CustomerID { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? State { get; set; }
    public decimal Balance { get; set; }
    public DateTime? CreatedDate { get; set; }
}