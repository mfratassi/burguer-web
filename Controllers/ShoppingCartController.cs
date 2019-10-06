using LanchesWeb.Models;
using LanchesWeb.Repositories;
using LanchesWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace LanchesWeb.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ISnackRepository _snackRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(ISnackRepository snackRepository, ShoppingCart shoppingCart)
        {
            _snackRepository = snackRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            List<ShoppingCartItem> shoppingCartItems = _shoppingCart.GetItems();
            _shoppingCart.ShoppingCartItems = shoppingCartItems;

            ShoppingCartViewModel shoppingCartViewModel = new ShoppingCartViewModel()
            {
                ShoppingCart = _shoppingCart,
                TotalPrice = _shoppingCart.TotalPrice()
            };


            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddItem(int snackId)
        {
            Snack snack = _snackRepository.Snacks.FirstOrDefault(s => s.Id == snackId);

            if (snack != null)
                _shoppingCart.AddItem(snack, 1);

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveItem(int snackId)
        {
            Snack snack = _snackRepository.Snacks.FirstOrDefault(s => s.Id == snackId);

            if (snack != null)
                _shoppingCart.RemoveItem(snack);

            return RedirectToAction("Index");
        }
    }
}