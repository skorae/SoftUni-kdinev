﻿namespace FastFood.Models
{
    using System;
    using FastFood.Models.Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Order
    {
        public Order()
        {
            this.OrderItems = new HashSet<OrderItem>();
        }
        public int Id { get; set; }

        [Required]
        public string Customer { get; set; }
        
        public DateTime DateTime { get; set; }

        [Required]
        public OrderType Type { get; set; }

        public decimal TotalPrice
            => this.OrderItems.Sum(x => x.Item.Price * x.Quantity);

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}