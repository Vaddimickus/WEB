using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BicycleShop.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BicycleShop.Controllers {
    public class CategoryController : Controller {

        private readonly ICategory allcategory;

        public CategoryController(ICategory icategory) {
            allcategory = icategory;
        }

        public ViewResult Index() {
            return View(allcategory.AllCategoryes);
        }
    }
}
