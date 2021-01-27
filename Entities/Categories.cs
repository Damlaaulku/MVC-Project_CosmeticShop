using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CosmeticShop.Entities
{
    public class Categories:Base
    {
        public Categories()
        {
            Products = new HashSet<Products>();
        }
        public string CatName { get; set; }
        public ICollection<Products> Products { get; set; }
    }
}