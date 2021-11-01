using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Required { get; set; }
        public DateTime Shipped { get; set; }
        public int Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipCity { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public override string ToString()
        {
            return $"Id = {Id}, Date = {Date}, Required = {Required}, Shipped = {Shipped}, Freight = {Freight}, ShipName = {ShipName}, ShipCity = {ShipCity}, OrderDetails = {OrderDetails}";
        }

    }
}
