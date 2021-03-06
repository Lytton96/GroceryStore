﻿using GroceryStore.Domain.Abstract;
using GroceryStore.Domain.Concrete;
using GroceryStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroceryStore.WebApp.Controllers
{
    public class CartController : Controller
    {
        public IProductsRepository ProductsRepository { get; set; }
= new EFProductRepository();
        public RedirectToRouteResult AddToCart(int productId, string returnUrl)
        {
            Product product = ProductsRepository
            .Products
            .FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                GetCart().AddItem(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = ProductsRepository
            .Products
            .FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                GetCart().RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }
        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];

            if (cart == null)
            {
                cart = new Cart(); Session["Cart"] = cart;
            }

            return cart;
        }
    }

}