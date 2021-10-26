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

        IList<OrderDetails> GetOrderDetails();

        IList<Order> GetOrder();
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

        public Category GetCategory(int v)
        {
            var ctx = new NorthwindContext();
            var list =  ctx.Categories.ToList();
            var category = list[v - 1];
            return category;
        }

        public IList<OrderDetails> GetOrderDetails()
        {
            var ctx = new NorthwindContext();
            return ctx.OrderDetails.ToList();
        }

        public void DeleteCategory(int id)
        {
            var ctx = new NorthwindContext();
            ctx.Categories.Remove(ctx.Categories.Find(id));
        }

        public IList<Order> GetOrder()
        {
            var ctx = new NorthwindContext();
            return ctx.Order.ToList();
        }
    }
}
