﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LanchesWeb.Models;
using LanchesWeb.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace LanchesWeb.Controllers
{
    public class OrderController : Controller
    {
        //private readonly LanchesWebContext _context;

        private readonly IOrderRepository _orderRepository;

        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        //public OrdersController(LanchesWebContext context)
        //{
        //    _context = context;
        //}

        [HttpGet]
        //[Authorize]
        public IActionResult Checkout()
        {
            //if (_shoppingCart.ShoppingCartItems == null)
            //{
            //    TempData["ModelMessage"] = "Your shopping cart is empty. Go back and add some items!";
            //    return RedirectToAction("Index", "ShoppingCart", TempData);
            //}
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            List<ShoppingCartItem> shoppingCartItems = _shoppingCart.GetItems();
            _shoppingCart.ShoppingCartItems = shoppingCartItems;

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                TempData["ModelMessage"] = "Your shopping cart is empty. Go back and add some items!";
                ModelState.AddModelError("", "Shopping cart is empty. Go back and add some items");
                ViewBag.ModelMessage = ("Shopping cart is empt. Go back and add some items.");
                return Redirect("/ShoppingCart/Index");
            }

            if (User.Identity.IsAuthenticated)
            {               

                if (ModelState.IsValid)
                {
                    _orderRepository.ProcessOrder(order);
                    _shoppingCart.ClearAll();
                    return RedirectToAction("CheckoutSuccess");
                }

                return View(order);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public IActionResult CheckoutSuccess()
        {
            ViewBag.CheckoutSuccessMessage = "Thank you! Your order is being processed and it will take up to 60min to arrive";
            return View();
        }


    }
}
