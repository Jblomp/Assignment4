﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4.Domain
{
    class OrderDetails
    {

        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }

        public override string ToString()
        {
            return $"UnitPrice = {UnitPrice}, Quantity = {Quantity}, Discount = {Discount}, Order = {Order}, Product = {Product}";
        }

    }
}
