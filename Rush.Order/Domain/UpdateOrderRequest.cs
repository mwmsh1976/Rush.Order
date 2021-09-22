using Rush.Order.Domain.Interfaces;

namespace Rush.Order.Domain
{
    public class UpdateOrderRequest : IUpdateOrderRequest
    {
        public long Id { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }
    }
}
