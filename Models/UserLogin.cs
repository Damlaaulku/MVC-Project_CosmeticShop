using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CosmeticShop.Models
{
    public class UserLogin
    {
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public int Errorcode { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsLogin { get; set; }
    }
}