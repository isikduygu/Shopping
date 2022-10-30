﻿using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.Entities
{
    public class Order : BaseEntities
    {
        public string CustomerIdentityId { get; set; }
        public string CustomerName { get; set; }
        public List<OrderProduct> Products { get; set; }
        public string AddressTitle { get; set; }
        public string AddressDescription { get; set; }
        public string AddressCity { get; set; }
        public decimal TotalProductPrice { get; set; }
        public string OrderCode { get; set; }
    }
}
