using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Require { get; set; }
        public string Shipped { get; set; }
        public int Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipCity { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public override string ToString()
        {
            return $"Id = {Id}, Date = {Date}, Require = {Require}, Shipped = {Shipped}, Freight = {Freight}, ShipName = {ShipName}, ShipCity = {ShipCity}, OrderDetails = {OrderDetails}";
        }

    }
}
