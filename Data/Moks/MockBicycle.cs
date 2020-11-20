using BicycleShop.Data.Interfaces;
using BicycleShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BicycleShop.Data.Moks {
    public class MockBicycle : IBicycle {

        private readonly ICategory categoryBicycle = new MockCategory();

        public IEnumerable<Bicycle> Bicycles { 
            get {
                return new List<Bicycle> {
                    new Bicycle {
                        name = "Stern Dynamic 1.0 26", 
                        desc = "Горный велосипед Stern Dynamic 1.0 станет удачным выбором для новичков в велоспорте. 18-скоростная трансмиссия позволяет выбрать оптимальную нагрузку.",
                        price = 10799,
                        img = "/img/1.jpg",
                        Category = categoryBicycle.AllCategoryes.First()
                    },
                    new Bicycle {
                        name = "Stern Electra 1.0 27,5",
                        desc = "Женский горный велосипед с отличной проходимостью и накатом. Трансмиссия Shimano Acera обеспечит точное переключение 24 скоростей.",
                        price = 20999,
                        img = "/img/2.jpg",
                        Category = categoryBicycle.AllCategoryes.First()
                    },
                    new Bicycle {
                        name = "Mira 1.0 26",
                        desc = "Женский горный велосипед Mira 1.0 с алюминиевой рамой, удобным седлом и надежными дисковыми тормозами для активного отдыха. Трансмиссия Shimano Tourney и удобные шифтеры EZ-Fire Shimano.",
                        price = 15999,
                        img = "/img/3.jpg",
                        Category = categoryBicycle.AllCategoryes.First()
                    },

                    new Bicycle {
                        name = "Stels Miss 6000 V K010",
                        desc = "Stels Miss 6000 V K010 – это очень надёжный велосипед, на качество которого можно положиться.",
                        price = 18630,
                        img = "/img/4.jpg",
                        Category = categoryBicycle.AllCategoryes.Last()
                    },
                    new Bicycle {
                        name = "Stels Miss 6000 D V010",
                        desc = "Miss 6000 D V010 разработан для покорения новых увлекательных маршрутов.",
                        price = 22220,
                        img = "/img/5.jpg",
                        Category = categoryBicycle.AllCategoryes.Last()
                    },
                    new Bicycle {
                        name = "Stinger Siena Std 27.5",
                        desc = "Stinger Siena Std 27.5 – динамичная и прочная модель для любительниц активного отдыха.",
                        price = 33800,
                        img = "/img/6.jpg",
                        Category = categoryBicycle.AllCategoryes.Last()
                    }
                };
            }
        }

        public Bicycle getObjectBicycle(int bicycleID) {
            throw new NotImplementedException();
        }
    }
}
