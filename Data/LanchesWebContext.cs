using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LanchesWeb.Models
{
    public class LanchesWebContext : IdentityDbContext<IdentityUser>
    {
        public LanchesWebContext(DbContextOptions<LanchesWebContext> options) : base(options) { }

        public DbSet<Snack> Snacks { get; set; }

        public DbSet<SnackCategory> SnackCategories { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

    }
}
