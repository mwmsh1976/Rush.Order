using Rush.Order.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Rush.Order.Models
{
    public class UpdateOrderRequest : IUpdateOrderRequest
    {
        [Required(ErrorMessage = "The Id for the order is required.")]
        public long Id { get; set; }

        [Required(ErrorMessage = "The Total for the order is required.")]
        public decimal Total { get; set; }

        [Required(ErrorMessage = "The Status for the order is required.")]
        public string Status { get; set; }
    }
}