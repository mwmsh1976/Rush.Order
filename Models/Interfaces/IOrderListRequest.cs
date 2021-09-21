using System;

namespace Rush.Order.Models.Interfaces
{
    public interface IOrderListRequest
    {
        DateTime StartDate { get; set; }
        DateTime? EndDate { get; set; }
    }
}
