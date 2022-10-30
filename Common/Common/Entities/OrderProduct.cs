﻿namespace Common.Entities
{
    public class OrderProduct : AuditableBaseEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}