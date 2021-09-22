using Rush.Order.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rush.Order.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Models.Order> GetOrderByOrderId(Int64 orderId);
        Task<Models.Order> GetOrderByOrderNumber(string orderNumber);
        Task<List<Models.Order>> GetOrdersByCustomerIdAndDate(OrderListRequest orderListRequest);
        Task<Models.Order> AddOrder(Int64 customerId);
        Task<Models.Order> UpdateOrder(UpdateOrderRequest updateOrderRequest);
    }
}
