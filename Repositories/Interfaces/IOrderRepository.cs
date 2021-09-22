using Rush.Order.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rush.Order.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<Domain.Order> GetOrderByOrderId(Int64 orderId);
        Task<Domain.Order> GetOrderByOrderNumber(string orderNumber);
        Task<List<Domain.Order>> GetOrdersByCustomerIdAndDate(OrderListRequest orderListRequest);
        Task<Domain.Order> AddOrder(Int64 customerId);
        Task<Domain.Order> UpdateOrder(UpdateOrderRequest updateOrderRequest);
    }
}
