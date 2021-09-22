using Rush.Order.Mappers.Interfaces;
using Rush.Order.Models;
using Rush.Order.Repositories.Interfaces;
using Rush.Order.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rush.Order.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderMapper _orderMapper;

        public OrderService(IOrderRepository orderRepository, IOrderMapper orderMapper)
        {
            _orderRepository = orderRepository;
            _orderMapper = orderMapper;
        }

        public async Task<Models.Order> GetOrderByOrderNumber(string orderNumber)
        {
           var domainOrder = await _orderRepository.GetOrderByOrderNumber(orderNumber);
            if(domainOrder != null)
            {
                return _orderMapper.MapDomainOrderToModel(domainOrder);
            }
            return null;
        }

        public async Task<Models.Order> GetOrderByOrderId(Int64 orderId)
        {
            var domainOrder = await _orderRepository.GetOrderByOrderId(orderId);
            if (domainOrder != null)
            {
                return _orderMapper.MapDomainOrderToModel(domainOrder);
            }
            return null;
        }

        public async Task<List<Models.Order>> GetOrdersByCustomerIdAndDate(OrderListRequest orderListRequest)
        {
            var domainOrderListRequest = _orderMapper.MapModelOrderListRequestToDomain(orderListRequest);
            var domainOrders = await _orderRepository.GetOrdersByCustomerIdAndDate(domainOrderListRequest);
            if(domainOrders != null)
            {
                return _orderMapper.MapDomainOrderListToModel(domainOrders);
            }
            return null;
        }

        public async Task<Models.Order> AddOrder(Int64 customerId)
        {
            var domainOrder = await _orderRepository.AddOrder(customerId);
            return _orderMapper.MapDomainOrderToModel(domainOrder);
        }

        public async Task<Models.Order> UpdateOrder(UpdateOrderRequest updateOrderRequest)
        {
            var domainUpdateOrderRequest = _orderMapper
                .MapModelUpdateOrderRequestToDomain(updateOrderRequest);
            var domainOrder = await _orderRepository.UpdateOrder(domainUpdateOrderRequest);
            if(domainOrder != null)
            {
                return _orderMapper.MapDomainOrderToModel(domainOrder);
            }
            return null;
        }

    }
}
