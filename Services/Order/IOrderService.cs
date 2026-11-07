using ReactByCode.Common.ViewModels.Order;
namespace ReactByCode.Services.Order;

public interface IOrderService
{
    List<OrderRow> Search(OrderSearchCriteria criteria);
}