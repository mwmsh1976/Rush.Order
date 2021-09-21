using System;

namespace Rush.Order.Domain.Interfaces
{
    public interface IOrderListRequest
    {
        long CustomerId { get; set; }
        DateTime StartDate { get; set; }
        DateTime? EndDate { get; set; }
    }
}
