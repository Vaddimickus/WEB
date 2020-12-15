using BicycleShop.Data.Interfaces;
using BicycleShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BicycleShop.Data.Moks {
    public class MockCategory : ICategory {
        public IEnumerable<Category> AllCategoryes {
            get {
                return new List<Category> {
                    new Category { categoryName = "Горные велосипеды", desc = "Предназначены для езды по бездорожью."},
                    new Category { categoryName = "Шоссейные велосипеды", desc = "Предназначены для шоссейных велогонок"}
                };
            }
        }

    }
}
