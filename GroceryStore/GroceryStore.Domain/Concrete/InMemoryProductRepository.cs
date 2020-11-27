using GroceryStore.Domain.Abstract;
using GroceryStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Domain.Concrete
{
    class InMemoryProductRepository : IProductsRepository
    {
        private List<Product> _products = new List<Product>
         {
             new Product{ Name = "Eggplant", Price = 1},
             new Product {Name ="Pepper", Price = 4},
             new Product {Name = "Cucumber", Price = 2}
         };

        public IEnumerable<Product> Products
        {
            get { return _products; }
        }
    }
}
