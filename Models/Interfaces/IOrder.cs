using System;

namespace Rush.Order.Models.Interfaces
{
    public interface IOrder
    {
        Int64 Id { get; set; }
        Int64 CustomerId { get; set; }
        string OrderNumber { get; set; }
        decimal Total { get; set; }
        DateTimeOffset CreateDate { get; set; }
        string Status { get; set; }
    }
}
