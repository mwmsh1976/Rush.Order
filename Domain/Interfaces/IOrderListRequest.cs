using System;

namespace Rush.Order.Domain.Interfaces
{
    public interface IOrderListRequest
    {
        Int64 CustomerId { get; set; }
        DateTimeOffset StartDate { get; set; }
        DateTimeOffset? EndDate { get; set; }
    }
}
