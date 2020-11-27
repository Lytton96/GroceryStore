using GroceryStore.Domain.Concrete;
using GroceryStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.DebugConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using ( var ctx = new EFDbContext())
            {

                for (int i = 0; i < 10; i++)
                {
                    var product = new Product()
                    {
                        Name = $"Breakfast Pork _{i}",
                        Price = 6.5m,
                        Description = "This is pork",
                        Category = "Meat"
                    };

                    ctx.Products.Add(product);
                }
                
                ctx.SaveChanges();
            }

            Console.WriteLine("done.");
            Console.ReadLine();
        }
    }
}
