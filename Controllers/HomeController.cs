using BicycleShop.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BicycleShop.Controllers {
    public class HomeController : Controller {

        private IBicycle _bicycleRep;

        public HomeController(IBicycle bicycleRep) {
            _bicycleRep = bicycleRep;
        }

        public ViewResult Index() {
            return View();
        }

    }
}
