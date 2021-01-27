using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CosmeticShop.Entities
{
    public class Users:Base
    {
        public Users()
        {
            Wishlist = new HashSet<Wishlist> ();
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Wishlist> Wishlist { get; set; }
    }
}