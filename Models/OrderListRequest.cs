using Rush.Order.Models.Base_Classes;
using Rush.Order.Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Rush.Order.Models
{
    public class OrderListRequest : CustomerIdRequest, IOrderListRequest
    {

        [Required(ErrorMessage = "StartDate is a required field.")]
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
    }
}