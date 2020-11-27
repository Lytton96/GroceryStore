using GroceryStore.Domain.Abstract;
using GroceryStore.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroceryStore.WebApp.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public IProductsRepository ProductsRepository { get; set; }
        = new InMemoryProductRepository();
        public ViewResult List()
        {
            // M-V-C
            // M -> ProductsRepository.Products
            // V -> View
            // C -> ProductController
            return View(ProductsRepository.Products);
        }
    }
}

