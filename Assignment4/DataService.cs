using Assignment4.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{

    public interface IDataService
    {
        IList<Category> GetCategories();

        Category GetCategory(int v);

        Category CreateCategory(string name, string description);

        IList<Product> GetProducts();

        Product CreateProduct(string Name, int price, string quant, int stock);

        IList<OrderDetails> GetOrderDetails();

        IList<Order> GetOrders();

        bool DeleteCategory(int id);

        bool UpdateCategory(int id, string name, string desc);

        Product GetProduct(int id);

        List<Product> GetProductByCategory(int catId);

        List<Product> GetProductByName(string v);
        Order CreateOrder(DateTime date, DateTime req, DateTime ship, int fre, string sName, string sCity);
        Order GetOrder(int orderId);
        List<OrderDetails> GetOrderDetail(int id);



    }

    public class DataService : IDataService
    {
        public Category CreateCategory(string name, string description)
        {
            var ctx = new NorthwindContext();
            Category category = new Category();
            category.Id = ctx.Categories.Max(x => x.Id) + 1;
            category.Name = name;
            category.Description = description;
            ctx.Add(category);
            ctx.SaveChanges();
            return category;
        }

        public IList<Category> GetCategories()
        {
            var ctx = new NorthwindContext();
            return ctx.Categories.ToList();
        }

        public IList<Product> GetProducts()
        {
            var ctx = new NorthwindContext();
            return ctx.Products.ToList();
        }

        public Product CreateProduct(string name, int price, string quant, int stock)
        {
            var ctx = new NorthwindContext();
            Product product = new Product();
            product.Id = ctx.Products.Max(x => x.Id) + 1;
            product.Name = name;
            product.UnitPrice = price;
            product.QuantityPerUnit = quant;
            product.UnitsInStock = stock;
            product.Category = GetCategory(product.CategoryId);
            ctx.Add(product);
            ctx.SaveChanges();
            return product;
        }

        public Category GetCategory(int v)
        {
            var ctx = new NorthwindContext();
            return ctx.Categories.FirstOrDefault(x => x.Id == v);
        }

        public IList<OrderDetails> GetOrderDetails()
        {
            var ctx = new NorthwindContext();
            return ctx.OrderDetails.ToList();
        }

        public bool DeleteCategory(int id)
        {
            var ctx = new NorthwindContext();
            var categoryToRemove = GetCategory(id);
            if (categoryToRemove == null)
            { 
                return false; 
            }
            ctx.Categories.Remove(categoryToRemove);
            ctx.SaveChanges();
            return true;
        }

        public IList<Order> GetOrders()
        {
            var ctx = new NorthwindContext();
            return ctx.Orders.ToList();
        }

        public bool UpdateCategory(int id, string name, string desc)
        {
            var ctx = new NorthwindContext();
            var cat = GetCategory(id);
            if (cat == null) 
            {
                return false;
            }
            ctx.Categories.Find(id).Name = name;
            ctx.Categories.Find(id).Description = desc;
            ctx.SaveChanges();
            return true;
        }

        public Product GetProduct(int v)
        {
            var ctx = new NorthwindContext();
            var product = ctx.Products.FirstOrDefault(x => x.Id == v);
            product.Category = GetCategory(product.CategoryId);
            return product;
        }

        public List<Product> GetProductByCategory(int catId)
        {
            List<Product> returnList = new List<Product>();
            foreach (Product p in GetProducts())
            {
                if (catId == p.CategoryId)
                {
                    returnList.Add(GetProduct(p.Id));
                }
            }
            return returnList;

        }

        public List<Product> GetProductByName(string v)
        {
            List<Product> returnList = new List<Product>();
            foreach (Product p in GetProducts())
            {
                if (p.Name.Contains(v))
                {
                    returnList.Add(GetProduct(p.Id));
                }
            }
            return returnList;
        }
        public Order CreateOrder(DateTime date, DateTime req, DateTime ship, int fre, string sName, string sCity)
        {
            var ctx = new NorthwindContext();
            Order order = new Order();
            order.Id = ctx.Categories.Max(x => x.Id) + 1;
            order.Date = date;
            order.Required = req;
            order.Shipped = ship;
            order.Freight = fre;
            order.ShipName = sName;
            order.ShipCity = sCity;
            order.OrderDetails = GetOrderDetail(order.Id);
            ctx.Add(order);
            ctx.SaveChanges();
            return order;
        }

        public List<OrderDetails> GetOrderDetail(int id)
        {

            List<OrderDetails> returnList = new List<OrderDetails>();
            foreach (OrderDetails orderDetails in GetOrderDetails())
            {
                if (orderDetails.OrderId == id)
                {
                    returnList.Add(orderDetails);
                }
            }
            return returnList;
        }

        public Order GetOrder(int orderId)
        {
            var ctx = new NorthwindContext();
            var order = ctx.Orders.FirstOrDefault(x => x.Id == orderId);
            order.OrderDetails = GetOrderDetail(order.Id);
            return order;
        }
    }
}
