using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CosmeticShop.Entities
{
    public class Products:Base
    {
        public Products()
        {
            Categories = new HashSet<Categories> ();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Photo { get; set; }
        public ICollection<Categories> Categories { get; set; }
    }
}