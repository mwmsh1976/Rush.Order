using System;

namespace Rush.Order.Domain.Interfaces
{
    public interface IAddOrderRequest
    {
        Int64 CustomerId { get; set; }
    }
}
