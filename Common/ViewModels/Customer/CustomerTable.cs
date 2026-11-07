using ReactByCode.Common.Forms;
namespace ReactByCode.Common.ViewModels.Customer;

public sealed class CustomerTable : ITable<CustomerRow>
{
    public static TableBuilder<CustomerRow> DefineTable()
        => Layout.Table<CustomerRow>()
            .RowKey(row => row.CustomerID)
            .Title("Customers")
            .EmptyMessage("No customers found.")
            .HeaderLink("Add Customer", "/Customers/Detail")
            .Column(row => row.CustomerID, "ID")
            .Link(row => row.Name, "Name", "/Customers/Detail?id={customerID}")
            .Column(row => row.Email, "Email")
            .Column(row => row.CreatedDate, "Created", ColumnFormat.Date);
}
