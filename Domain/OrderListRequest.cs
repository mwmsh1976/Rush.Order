using Rush.Order.Domain.Interfaces;
using System;

namespace Rush.Order.Domain
{
    public class OrderListRequest : IOrderListRequest
    {
        public long CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
