using BicycleShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BicycleShop.Data.Interfaces {
    public interface IOrders {

        void createOrder(Order order);

    }
}
