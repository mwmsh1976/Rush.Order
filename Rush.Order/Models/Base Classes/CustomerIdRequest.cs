using System;
using System.ComponentModel.DataAnnotations;

namespace Rush.Order.Models.Base_Classes
{
    public class CustomerIdRequest
    {
        [Required(ErrorMessage = "CustomerId is a required field")]
        public Int64 CustomerId { get; set; }
    }
}
