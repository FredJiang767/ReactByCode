using ReactByCode.Common.ViewModels.Customer;
namespace ReactByCode.Services.Customer;

public sealed class CustomerService : ICustomerService
{
    private static readonly string[] Names = ["Alice Johnson", "Bob Smith", "Carol Williams", "David Brown", "Emma Davis", "Frank Miller", "Grace Wilson", "Henry Moore", "Ivy Taylor", "Jack Anderson"];

    private static readonly List<CustomerRow> Customers = Names.Select((name, i) => new CustomerRow
    {
        CustomerID = 1001 + i,
        Name = name,
        Email = name.ToLowerInvariant().Replace(' ', '.') + "@example.com",
        CreatedDate = new DateTime(2025, 1, 1).AddDays(i * 17)
    }).ToList();

    public List<CustomerRow> GetAll()
    {
        lock (Customers) return Customers.ToList();
    }

    public CustomerRow? Get(int id)
    {
        lock (Customers) return Customers.FirstOrDefault(c => c.CustomerID == id);
    }

    public int Save(CustomerDetailForm form)
    {
        lock (Customers)
        {
            CustomerRow? row = form.CustomerID == null ? null : Customers.FirstOrDefault(c => c.CustomerID == form.CustomerID);
            if (row == null)
            {
                row = new CustomerRow { CustomerID = Customers.Max(c => c.CustomerID) + 1, CreatedDate = DateTime.Now };
                Customers.Add(row);
            }

            row.Name = form.Name!.Trim();
            row.Email = form.Email!.Trim();
            return row.CustomerID;
        }
    }
}
