using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BicycleShop.Controllers {
    public class SPAController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
