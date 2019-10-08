using System;
using System.Collections.Generic;
using LanchesWeb.Models;

namespace LanchesWeb.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private LanchesWebContext _lanchesWebContext;

        private ShoppingCart _shoppingCart;

        public OrderRepository(LanchesWebContext lanchesWebContext, ShoppingCart shoppingCart)
        {
            _lanchesWebContext = lanchesWebContext;
            _shoppingCart = shoppingCart;
        }

        public void ProcessOrder(Order order)
        {
            order.OrderDate = DateTime.Now;
            //if (order.OrderId >= 0)
            //    order.OrderId = null;

            foreach (ShoppingCartItem sci in _shoppingCart.ShoppingCartItems)
                order.Total += sci.Snack.Price * sci.Quantity;


            _lanchesWebContext.Orders.Add(order);

            _lanchesWebContext.SaveChanges();

            List<ShoppingCartItem> shoppingCartItems = _shoppingCart.GetItems();

            foreach (ShoppingCartItem shoppingCartItem in shoppingCartItems)
            {
                OrderItem orderItem = new OrderItem
                {
                    OrderId = order.OrderId,
                    Quantity = shoppingCartItem.Quantity,
                    SnackId = shoppingCartItem.Snack.Id,
                    Price = shoppingCartItem.Snack.Price
                };

                _lanchesWebContext.OrderItems.Add(orderItem);
            }

            _lanchesWebContext.SaveChanges();

        }
    }
}
