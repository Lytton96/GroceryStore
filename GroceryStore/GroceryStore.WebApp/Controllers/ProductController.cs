using GroceryStore.Domain.Abstract;
using GroceryStore.Domain.Concrete;
using GroceryStore.WebApp.Models;
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
        = new EFProductRepository();

        public int PageSize = 3;
        public ViewResult List(string category, int page =1)
        {
            // M-V-C
            // M -> ProductsRepository.Products
            // V -> View
            // C -> ProductController

            //var model = ProductsRepository
            //    .Products
            //    .OrderBy(p => p.ProductID)
            //    .Skip((page - 1)*PageSize)
            //    .Take(PageSize);

            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = ProductsRepository
                .Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = ProductsRepository
                    .Products
                    .Where(p => category == null || p.Category == category)
                    .Count()
                },
                CurrentCategory = category
            };

            return View(model);
        }
    }
}

