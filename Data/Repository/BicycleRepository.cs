using BicycleShop.Data.Interfaces;
using BicycleShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BicycleShop.Data.Repository {
    public class BicycleRepository : IBicycle {

        private readonly AppDBContent appDBContent;

        public BicycleRepository(AppDBContent appDBContent) {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Bicycle> Bicycles => appDBContent.Bicycle.Include(c => c.Category);

        public Bicycle getObjectBicycle(int bicycleID) => appDBContent.Bicycle.FirstOrDefault(p => p.id == bicycleID);
    }
}
