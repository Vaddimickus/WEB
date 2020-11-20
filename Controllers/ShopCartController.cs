using BicycleShop.Data.Interfaces;
using BicycleShop.Data.Models;
using BicycleShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BicycleShop.Controllers {
    public class ShopCartController : Controller {

        private IBicycle _bicycleRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(IBicycle bicycleRep, ShopCart shopCart) {
            _bicycleRep = bicycleRep;
            _shopCart = shopCart;
        }

        public ViewResult Index() {
            var items = _shopCart.getShopItems();
            _shopCart.listShopItems = items;

            var obj = new ShopCartViewModel {
                shopCart = _shopCart
            };

            return View(obj);

        }

        public RedirectToActionResult addToCart(int id) {
            var item = _bicycleRep.Bicycles.FirstOrDefault(i => i.id == id);
            if(item != null) {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }

    }
}
