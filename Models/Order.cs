﻿using Rush.Order.Models.Interfaces;
using System;

namespace Rush.Order.Models
{
    public class Order : IOrder
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public string OrderNumber { get; set; }
        public decimal Total { get; set; }
        public DateTime CreateDate { get; set; }
        public string Status { get; set; }
    }
}
