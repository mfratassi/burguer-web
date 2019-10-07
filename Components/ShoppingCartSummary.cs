using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LanchesWeb.Models;
using LanchesWeb.ViewModels;

namespace LanchesWeb.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            List<ShoppingCartItem> shoppingCartItems = _shoppingCart.GetItems();

            //List<ShoppingCartItem> shoppingCartItems = new List<ShoppingCartItem>()
            //{
            //    new ShoppingCartItem(){ }, 
            //    new ShoppingCartItem(){ }
            //};

            _shoppingCart.ShoppingCartItems = shoppingCartItems;

            ShoppingCartViewModel shoppingCartViewModel = new ShoppingCartViewModel()
            {
                ShoppingCart = _shoppingCart,
                TotalPrice = _shoppingCart.TotalPrice()
            };

            return View(shoppingCartViewModel);
        }
    }
}
