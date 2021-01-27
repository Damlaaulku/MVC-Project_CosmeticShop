using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CosmeticShop.Models
{
    public class WishlistDisplayModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductPhoto { get; set; }
        public string ProductDesc { get; set; }
        public double ProductPrice { get; set; }
    }
}