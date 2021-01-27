using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CosmeticShop.Models
{
    public class CatalogModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string ProductPhooto { get; set; }
    }
}