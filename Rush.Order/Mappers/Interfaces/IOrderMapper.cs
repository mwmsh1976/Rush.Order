using Rush.Order.Models;
using System.Collections.Generic;

namespace Rush.Order.Mappers.Interfaces
{
    public interface IOrderMapper
    {
        Models.Order MapDomainOrderToModel(Domain.Order domainOrder);
        Domain.OrderListRequest MapModelOrderListRequestToDomain(
                OrderListRequest modelOrderListRequest);
        List<Models.Order> MapDomainOrderListToModel(List<Domain.Order> domainOrderList);
        Domain.UpdateOrderRequest MapModelUpdateOrderRequestToDomain(UpdateOrderRequest modelUpdateOrderRequest);
    }
}
