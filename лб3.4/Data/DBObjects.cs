using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BicycleShop.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BicycleShop.Data {
    public class DBObjects {
        public static void Initial(AppDBContent content) {
            
            

            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));

            if (!content.Bicycle.Any()) {
                content.AddRange(
                    new Bicycle {
                        name = "Stern Dynamic 1.0 26",
                        desc = "Горный велосипед Stern Dynamic 1.0 станет удачным выбором для новичков в велоспорте. 18-скоростная трансмиссия позволяет выбрать оптимальную нагрузку.",
                        price = 10799,
                        img = "/img/1.jpg",
                        Category = Categories["Горные велосипеды"]
                    },
                    new Bicycle {
                        name = "Stern Electra 1.0 27,5",
                        desc = "Женский горный велосипед с отличной проходимостью и накатом. Трансмиссия Shimano Acera обеспечит точное переключение 24 скоростей.",
                        price = 20999,
                        img = "/img/2.jpg",
                        Category = Categories["Горные велосипеды"]
                    },
                    new Bicycle {
                        name = "Mira 1.0 26",
                        desc = "Женский горный велосипед Mira 1.0 с алюминиевой рамой, удобным седлом и надежными дисковыми тормозами для активного отдыха. Трансмиссия Shimano Tourney и удобные шифтеры EZ-Fire Shimano.",
                        price = 15999,
                        img = "/img/3.jpg",
                        Category = Categories["Горные велосипеды"]
                    },

                    new Bicycle {
                        name = "Stels Miss 6000 V K010",
                        desc = "Stels Miss 6000 V K010 – это очень надёжный велосипед, на качество которого можно положиться.",
                        price = 18630,
                        img = "/img/4.jpg",
                        Category = Categories["Шоссейные велосипеды"]
                    },
                    new Bicycle {
                        name = "Stels Miss 6000 D V010",
                        desc = "Miss 6000 D V010 разработан для покорения новых увлекательных маршрутов.",
                        price = 22220,
                        img = "/img/5.jpg",
                        Category = Categories["Шоссейные велосипеды"]
                    },
                    new Bicycle {
                        name = "Stinger Siena Std 27.5",
                        desc = "Stinger Siena Std 27.5 – динамичная и прочная модель для любительниц активного отдыха.",
                        price = 33800,
                        img = "/img/6.jpg",
                        Category = Categories["Шоссейные велосипеды"]
                    }
                );
            }

            content.SaveChanges();

        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories {
            get {
                if(category == null) {
                    var list = new Category[] {
                        new Category { categoryName = "Горные велосипеды", desc = "Предназначены для езды по бездорожью."},
                        new Category { categoryName = "Шоссейные велосипеды", desc = "Предназначены для шоссейных велогонок"}
                    };

                    category = new Dictionary<string, Category>();
                    foreach(Category el in list)
                        category.Add(el.categoryName, el);
                }

                return category;
            }
        }
    }
}
