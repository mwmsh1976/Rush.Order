using System.ComponentModel.DataAnnotations;

namespace Rush.Order.Models
{
    public class OrderByNumberRequest
    {
        [Required(ErrorMessage = "OrderNumber is required.")]
        [MaxLength(16, ErrorMessage = "OrderNumber must be between 1 and 16 charactere long.")]
        [MinLength(1, ErrorMessage = "OrderNumber must be between 1 and 16 charactere long.")]
        public string OrderNumber { get; set; }
    }
}
