using ReactByCode.Common.ViewModels.Customer;
namespace ReactByCode.Services.Customer;

// Returns generated mock customers. Replace the body with a real data source later.
public sealed class CustomerService : ICustomerService
{
    private static readonly string[] Names = ["Alice Johnson", "Bob Smith", "Carol Williams", "David Brown", "Emma Davis", "Frank Miller", "Grace Wilson", "Henry Moore", "Ivy Taylor", "Jack Anderson"];

    public List<CustomerRow> GetAll()
        => Names.Select((name, i) => new CustomerRow
        {
            CustomerID = 1001 + i,
            Name = name,
            Email = name.ToLowerInvariant().Replace(' ', '.') + "@example.com",
            CreatedDate = new DateTime(2025, 1, 1).AddDays(i * 17)
        }).ToList();
}
