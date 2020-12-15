using BicycleShop.Data.Interfaces;
using BicycleShop.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BicycleShop.Controllers {
    public class BicyclesController : Controller {
        private readonly IBicycle allbicycle;
        private readonly ICategory allcategory;

        public BicyclesController(IBicycle ibicycle, ICategory icategory) {
            allbicycle = ibicycle;
            allcategory = icategory;
        }

        [Route("Bicycles/List")]
        [Route("Bicycles/List/{category}")]
        public ViewResult List(string category) {
            string _category = category;
            IEnumerable<Bicycle> bicycles = null;
            if (string.IsNullOrEmpty(category)) {
                bicycles = allbicycle.Bicycles.OrderBy(i => i.id);
            } else {
                if(string.Equals("mountain", category, StringComparison.OrdinalIgnoreCase) 
                    | string.Equals("Горные велосипеды", category, StringComparison.OrdinalIgnoreCase)) {
                    bicycles = allbicycle.Bicycles.Where(i => i.Category.categoryName.Equals("Горные велосипеды")).OrderBy(i => i.id);
                } else if (string.Equals("highway", category, StringComparison.OrdinalIgnoreCase)
                    | string.Equals("Шоссейные велосипеды", category, StringComparison.OrdinalIgnoreCase)) {
                    bicycles = allbicycle.Bicycles.Where(i => i.Category.categoryName.Equals("Шоссейные велосипеды")).OrderBy(i => i.id);
                }
            }


            return View(bicycles);
        }

        [Route("Bicycles/List")]
        [Route("Bicycles/List/{category}")]
        [HttpGet]
        public ActionResult List2(string category) {
            string _category = category;
            IEnumerable<Bicycle> bicycles = null;
            if (string.IsNullOrEmpty(category)) {
                bicycles = allbicycle.Bicycles.OrderBy(i => i.id);
            }
            else {
                if (string.Equals("mountain", category, StringComparison.OrdinalIgnoreCase)
                    | string.Equals("Горные велосипеды", category, StringComparison.OrdinalIgnoreCase)) {
                    bicycles = allbicycle.Bicycles.Where(i => i.Category.categoryName.Equals("Горные велосипеды")).OrderBy(i => i.id);
                }
                else if (string.Equals("highway", category, StringComparison.OrdinalIgnoreCase)
                  | string.Equals("Шоссейные велосипеды", category, StringComparison.OrdinalIgnoreCase)) {
                    bicycles = allbicycle.Bicycles.Where(i => i.Category.categoryName.Equals("Шоссейные велосипеды")).OrderBy(i => i.id);
                }
            }


            return PartialView(bicycles);
        }

    }
}
