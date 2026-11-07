using ReactByCode.Common.ViewModels.Customer;
namespace ReactByCode.Services.Customer;

public interface ICustomerService
{
    List<CustomerRow> GetAll();
}