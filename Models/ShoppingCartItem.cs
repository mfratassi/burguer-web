using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanchesWeb.Models;
using System.ComponentModel.DataAnnotations;

namespace LanchesWeb.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Snack Snack { get; set; }
        public int Quantity { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "Quantidade máxima de carácteres para {0}: {1}")]
        public string ShoppingCartId { get; set; }
    }
}
