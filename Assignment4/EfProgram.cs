using Assignment4.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Assignment4
{
    internal class EfProgram
    {
        static void Main(string[] args)
        {
            var dataService = new DataService();

            foreach(var category in dataService.GetCategories())
            {
                Console.WriteLine(category);
            }      

        }
    }
}
