using System;
using System.Collections.Generic;
using System.Linq;
using LanchesWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.DependencyInjection;

namespace LanchesWeb.Models
{
    public class ShoppingCart
    {
        private readonly LanchesWebContext _context;
        public ShoppingCart(LanchesWebContext context)
        {
            _context = context;
        }

        public string ShoppingCartId { get; set; } //Guid Identificador Global (Quase) Unico 

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetId(System.IServiceProvider services)
        {
            //Define uma sessao acessando o contexto atual (Tem que registrar em IServicesCollection)
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //Obtém um serviço do tipo do nosso contexto
            var context = services.GetService<LanchesWebContext>();

            //Obtém ou gera o Id do Carrinho
            string shoppingCartId = session.GetString("ShoppingCartId") ?? Guid.NewGuid().ToString();

            //Atribui o Id do Carrinho na sessão
            session.SetString("ShoppingCartId", shoppingCartId);

            //Retorna o Carrinho com o contexto atual e o Id atribuído ou obtido
            return new ShoppingCart(context) { ShoppingCartId = shoppingCartId };
        }

        public void AddItem(Snack snack, int quantity)
        {
            ShoppingCartItem shoppingCartItem = _context
                .ShoppingCartItems
                .SingleOrDefault(sci => sci.Snack.Id == snack.Id && sci.ShoppingCartId == ShoppingCartId); 

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Snack = snack,
                    Quantity = quantity
                };
                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Quantity++;
            }
            _context.SaveChanges();
        }

        public int RemoveItem(Snack snack)
        {
            ShoppingCartItem shoppingCartItem= _context
                .ShoppingCartItems
                .SingleOrDefault(sci => sci.Snack.Id == snack.Id && sci.ShoppingCartId == ShoppingCartId);
            
            int currentQuantity = 0; 

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Quantity > 1)
                {
                    shoppingCartItem.Quantity--;
                    currentQuantity = shoppingCartItem.Quantity;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
                _context.SaveChanges();
            }
            return currentQuantity;
        }

        public List<ShoppingCartItem> GetItems()
        {
            return ShoppingCartItems ??
                (ShoppingCartItems =
                    _context
                        .ShoppingCartItems
                            .Where(sci => sci.ShoppingCartId == ShoppingCartId)
                            .Include(sci => sci.Snack)
                            .ToList());
        }

        public void ClearAll()
        {
            var shoppingCartItems =
                _context.ShoppingCartItems
                .Where(sci => sci.ShoppingCartId == ShoppingCartId);

            _context.ShoppingCartItems.RemoveRange(shoppingCartItems);

            _context.SaveChanges();
        }

        public decimal TotalPrice()
        {
            return 
                _context.ShoppingCartItems
                .Where(sci => sci.ShoppingCartId == ShoppingCartId)
                .Select(sci => sci.Snack.Price * sci.Quantity)
                .Sum(); 
        }
    }
}

