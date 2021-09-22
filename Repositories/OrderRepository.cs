using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Rush.Order.Domain;
using Rush.Order.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rush.Order.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;

        public OrderRepository(OrderContext context)
        {
            _context = context;
        }
        
        public async Task<Domain.Order> GetOrderByOrderId(Int64 orderId)
        {
            return await _context.Order
                    .Where(o => o.Id == orderId)
                    .FirstOrDefaultAsync();
        }

        public async Task<Domain.Order> GetOrderByOrderNumber(string orderNumber)
        {
            var order = await _context.Order
                .Where(o => o.OrderNumber == orderNumber)
                .FirstOrDefaultAsync();
            if(order != null)
            {
                return order;
            }
            return null;
        }

        public async Task<List<Domain.Order>> GetOrdersByCustomerIdAndDate(OrderListRequest orderListRequest)
        {
            List<Domain.Order> orderList;
            if(orderListRequest.EndDate == null)
            {
                orderList = await _context.Order
                .Where(o => o.CustomerId == orderListRequest.CustomerId &&
                       o.CreateDate >= orderListRequest.StartDate)
                .ToListAsync();
            }
            else
            {
                orderList = await _context.Order
                .Where(o => o.CustomerId == orderListRequest.CustomerId &&
                       o.CreateDate >= orderListRequest.StartDate &&
                       o.CreateDate <= orderListRequest.EndDate)
                .ToListAsync();
            }
            if(orderList != null)
            {
                return orderList;
            }
            return null;
        }

        public async Task<Domain.Order> AddOrder(Int64 customerId)
        {
            var customerIdParm = new SqlParameter("@CustomerId", System.Data.SqlDbType.BigInt)
            {
                Value = customerId
            };
            var newOrders = await _context.Order.FromSqlRaw("EXEC sp_AddOrder @CustomerId",
                customerIdParm).ToListAsync();
            if (newOrders.Any()) { return newOrders[0]; }
            return null;
        }
        
        public async Task<Domain.Order> UpdateOrder(UpdateOrderRequest updateOrderRequest)
        {
            var idParm = new SqlParameter("@Id", updateOrderRequest.Id);
            var totalParm = new SqlParameter("@Total", updateOrderRequest.Total);
            var statusParm = new SqlParameter("@Status", updateOrderRequest.Status);
            var result = await _context.Database.ExecuteSqlRawAsync("EXEC sp_UpdateOrder @Id,@Total,@Status",
                idParm, totalParm, statusParm);
            if (result == -1)
            {
                return await GetOrderByOrderId(updateOrderRequest.Id);
            }
            return null;
        }

    }
}
