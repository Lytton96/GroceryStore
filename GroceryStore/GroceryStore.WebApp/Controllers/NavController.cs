using GroceryStore.Domain.Abstract;
using GroceryStore.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroceryStore.WebApp.Controllers
{
    public class NavController : Controller
    {
        public IProductsRepository ProductsRepository { get; set; }
      = new EFProductRepository();
        // GET: Nav
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = ProductsRepository
                .Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return PartialView(categories);
        }
    }
}