
namespace Rush.Order.Domain.Interfaces
{
    public interface IUpdateOrderRequest
    {
        long Id { get; set; }
        decimal Total { get; set; }
        string Status { get; set; }
    }
}
