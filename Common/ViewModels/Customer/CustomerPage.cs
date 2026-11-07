using ReactByCode.Common.Forms;
namespace ReactByCode.Common.ViewModels.Customer;

public static class CustomerPage
{
    public static PageConfiguration Configure(string dataUrl)
        => Page.Configure("Customers", page => page
            .Section<CustomerRow, CustomerTable>("customers", dataUrl));
}