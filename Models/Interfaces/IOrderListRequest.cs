using System;

namespace Rush.Order.Models.Interfaces
{
    public interface IOrderListRequest
    {
        DateTimeOffset StartDate { get; set; }
        DateTimeOffset? EndDate { get; set; }
    }
}
