using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CosmeticShop.Entities
{
    public class Wishlist:Base
    {
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public Products Product { get; set; }
        public Users User { get; set; }
    }
}