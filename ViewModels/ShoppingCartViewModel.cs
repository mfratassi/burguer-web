using LanchesWeb.Models;

namespace LanchesWeb.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
