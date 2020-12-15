using BicycleShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BicycleShop.Data {
    public class AppDBContent : DbContext {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) { 
        }

        public DbSet<Bicycle> Bicycle { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ShopCartItem> ShopCartItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
    }
}
