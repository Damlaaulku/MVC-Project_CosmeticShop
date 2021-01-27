using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CosmeticShop.Models
{
    public class ProductModel
    {
        public string ProductName { get; set; }
        public string ProductPhoto { get; set; }
        public string ProductDesc { get; set; }
        public string ErrorMessage { get; set; }
        public double ProductPrice { get; set; }
        public int ErrorCode { get; set; }
    }
}