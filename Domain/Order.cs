using Rush.Order.Domain.Interfaces;
using System;

namespace Rush.Order.Domain
{
    public class Order : IOrder
    {
        public Int64 Id { get; set; }
        public Int64 CustomerId { get; set; }
        public string OrderNumber { get; set; }
        public decimal Total { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public string Status { get; set; }
    }
}
