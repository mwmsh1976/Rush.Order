using Rush.Order.Models.Base_Classes;
using Rush.Order.Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Rush.Order.Models
{
    public class OrderListRequest : CustomerIdRequest, IOrderListRequest
    {
        [Required(ErrorMessage = "StartDate is a required field.")]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}