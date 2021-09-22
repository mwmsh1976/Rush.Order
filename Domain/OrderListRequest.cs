using Rush.Order.Domain.Interfaces;
using System;

namespace Rush.Order.Domain
{
    public class OrderListRequest : IOrderListRequest
    {
        public Int64 CustomerId { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
    }
}
