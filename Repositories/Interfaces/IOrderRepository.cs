using Rush.Order.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rush.Order.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<Domain.Order> GetOrderByOrderNumber(string orderNumber);
        Task<List<Domain.Order>> GetOrdersByCustomerIdAndDate(OrderListRequest orderListRequest);
        Task<Domain.Order> AddOrder(long customerId);
        Task<Domain.Order> UpdateOrder(UpdateOrderRequest updateOrderRequest);
    }
}
