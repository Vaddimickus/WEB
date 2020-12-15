using BicycleShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BicycleShop.Data.Interfaces {
    public interface IBicycle {

        IEnumerable<Bicycle> Bicycles { get; }
        Bicycle getObjectBicycle(int bicycleID);

    }
}