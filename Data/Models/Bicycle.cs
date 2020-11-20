using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BicycleShop.Data.Models {
    public class Bicycle {
        public int id { set; get; }
        public string name { set; get; }
        public string desc { set; get; }
        public ushort price { set; get; }
        public string img { set; get; }
        public int categoryID { set; get; }
        public virtual Category Category { set; get; }

    }
}
