using BicycleShop.Data.Interfaces;
using BicycleShop.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BicycleShop.Controllers {
    public class OrderController : Controller {

        private readonly IOrders orders;
        private readonly ShopCart shopCart;

        public OrderController(IOrders orders, ShopCart shopCart) {
            this.orders = orders;
            this.shopCart = shopCart;
        }

        public IActionResult Checkout() {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order) {

            shopCart.listShopItems = shopCart.getShopItems();
            if(shopCart.listShopItems.Count == 0) {
                ModelState.AddModelError("", "Корзина пустая");
            }
            if (ModelState.IsValid) {
                orders.createOrder(order);
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public IActionResult Complete() {
            return View();
        }

    }
}
