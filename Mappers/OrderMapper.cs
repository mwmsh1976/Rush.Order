using Rush.Order.Mappers.Interfaces;
using Rush.Order.Models;
using Rush.Order.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace Rush.Order.Mappers
{
    
    public class OrderMapper : IOrderMapper
    {
        public readonly IServiceProvider _services;

        public OrderMapper(IServiceProvider services)
        {
            _services = services;
        }


        public List<Models.Order> MapDomainOrderListToModel(List<Domain.Order> domainOrderList)
        {
            var modelOrderList = new List<Models.Order>();
            foreach(Domain.Order domainOrder in domainOrderList)
            {
                modelOrderList.Add(MapDomainOrderToModel(domainOrder));
            }
            return modelOrderList;
        }

        public Models.Order MapDomainOrderToModel(Domain.Order domainOrder)
        {
            var modelOrder = (Models.Order)_services.GetService(typeof(IOrder));
            modelOrder.CreateDate = domainOrder.CreateDate;
            modelOrder.CustomerId = domainOrder.CustomerId;
            modelOrder.Id = domainOrder.Id;
            modelOrder.OrderNumber = domainOrder.OrderNumber;
            modelOrder.Status = domainOrder.Status;
            modelOrder.Total = domainOrder.Total;
            return modelOrder;
        }

        public Domain.OrderListRequest MapModelOrderListRequestToDomain(
                OrderListRequest modelOrderListRequest)
        {
            var domainOrderListRequest = (Domain.OrderListRequest)_services
                .GetService(typeof(Domain.Interfaces.IOrderListRequest));
            domainOrderListRequest.CustomerId = modelOrderListRequest.CustomerId;
            domainOrderListRequest.EndDate = modelOrderListRequest.EndDate;
            domainOrderListRequest.StartDate = modelOrderListRequest.StartDate;
            return domainOrderListRequest;
        }
         
        public Domain.UpdateOrderRequest MapModelUpdateOrderRequestToDomain(UpdateOrderRequest modelUpdateOrderRequest)
        {
            var domainUpdateOrderRequest = (Domain.UpdateOrderRequest)_services
                .GetService(typeof(Domain.Interfaces.IUpdateOrderRequest));
            domainUpdateOrderRequest.Id = modelUpdateOrderRequest.Id;
            domainUpdateOrderRequest.Total = modelUpdateOrderRequest.Total;
            domainUpdateOrderRequest.Status = modelUpdateOrderRequest.Status;
            return domainUpdateOrderRequest;
        }
    }
}
