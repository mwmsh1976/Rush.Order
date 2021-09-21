using Rush.Order.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rush.Order.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Models.Order> GetOrderByOrderNumber(string orderNumber);
        Task<List<Models.Order>> GetOrdersByCustomerIdAndDate(OrderListRequest orderListRequest);
        Task<Models.Order> AddOrder(long customerId);
        Task<Models.Order> UpdateOrder(UpdateOrderRequest updateOrderRequest);
    }
}
