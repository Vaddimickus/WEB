using BicycleShop.Data.Interfaces;
using BicycleShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BicycleShop.Data.Repository {
    public class CategoryRepository : ICategory {

        private readonly AppDBContent appDBContent;

        public CategoryRepository(AppDBContent appDBContent) {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Category> AllCategoryes => appDBContent.Category;
    }
}
