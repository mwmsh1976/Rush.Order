using System;

namespace Rush.Order.Domain.Interfaces
{
    public interface IOrder
    {
        long Id { get; set; }
        long CustomerId { get; set; }
        string OrderNumber { get; set; }
        decimal Total { get; set; }
        DateTime CreateDate { get; set; }
        string Status { get; set; }
    }
}
