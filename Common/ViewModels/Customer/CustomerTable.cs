using ReactByCode.Common.Forms;
namespace ReactByCode.Common.ViewModels.Customer;

// Declares the customer table columns.
public sealed class CustomerTable : ITable<CustomerRow>
{
    public static TableBuilder<CustomerRow> DefineTable()
        => Layout.Table<CustomerRow>()
            .RowKey(row => row.CustomerID)
            .Title("Customers")
            .EmptyMessage("No customers found.")
            .Column(row => row.CustomerID, "ID")
            .Column(row => row.Name, "Name")
            .Column(row => row.Email, "Email")
            .Column(row => row.Phone, "Phone")
            .Column(row => row.State, "State")
            .Column(row => row.Balance, "Balance", ColumnFormat.Currency)
            .Column(row => row.CreatedDate, "Created", ColumnFormat.Date);
}