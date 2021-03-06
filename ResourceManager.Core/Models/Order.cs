﻿using System;
using System.Collections.Generic;

namespace ResourceManager.Core.Models
{
    public class Order : IEntity<int>
    {
        public int Id { get; set; }

        public string OrderNum { get; set; }

        public int? SupplyId { get; set; }

        public decimal OrderPrice { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal ShipmentPrice { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime? CompleteDate { get; set; }

        public int OrderStatusId { get; set; }

        public string OrderedById { get; set; }

        public string ApprovedById { get; set; }

        public int SupplierId { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public Worker OrderedBy { get; set; }

        public Worker ApprovedBy { get; set; }

        public Supplier Supplier { get; set; }

        public Supply Supply { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
