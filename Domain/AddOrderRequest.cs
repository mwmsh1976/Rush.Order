using Rush.Order.Domain.Interfaces;
using Rush.Order.Models.Base_Classes;

namespace Rush.Order.Domain
{
    public class AddOrderRequest : CustomerIdRequest, IAddOrderRequest
    {

#nullable enable

        public string? OrderNumber { get; set; }
        public decimal? Total { get; set; }

#nullable enable

    }
}
