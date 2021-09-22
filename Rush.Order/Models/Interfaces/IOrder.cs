using System;

namespace Rush.Order.Models.Interfaces
{
    public interface IOrder
    {
        Int64 Id { get; set; }
        Int64 CustomerId { get; set; }
#nullable enable
        string? OrderNumber { get; set; }
        decimal? Total { get; set; }
#nullable disable        
        DateTimeOffset CreateDate { get; set; }
        string Status { get; set; }
    }
}
