using BicycleShop.Data.Interfaces;
using BicycleShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BicycleShop.Data.Repository {
    public class OrdersRepository : IOrders {

        private readonly AppDBContent appDBContent;
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart) {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }

        public void createOrder(Order order) {
            order.orderTime = DateTime.Now;
            appDBContent.Order.Add(order);
            appDBContent.SaveChanges();
            var items = shopCart.listShopItems;

            foreach(var el in items) {
                var orderDetail = new OrderDetail() {
                    bicycleID = el.bicycle.id,
                    orderID = order.id,
                    price = el.bicycle.price
                };
                appDBContent.OrderDetail.Add(orderDetail);
            }
            
        }
    }
}
