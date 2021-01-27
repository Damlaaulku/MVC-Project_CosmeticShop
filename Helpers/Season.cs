using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CosmeticShop.Helpers
{
    public class Season
    {
        public static bool SeasonAdd(string Email, int UserID)
        {
            try
            {              
                HttpContext.Current.Session["Email"] = Email;
                HttpContext.Current.Session["UserID"] = UserID;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool SeasonDelete(string Email)
        {
            if (HttpContext.Current.Session.Count > 0)
            {
                HttpContext.Current.Session.RemoveAll();
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool SeasonContol()
        {

            if (HttpContext.Current.Session.Count > 0)
            {
                var UserEmail = HttpContext.Current.Session["Email"].ToString();
                Context.CosmoContext db = new Context.CosmoContext();
                var Control = db.Users.Where(x => x.Email == UserEmail).ToList();
                if (Control.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
        public static string GetEmail()
        {
            return HttpContext.Current.Session["Email"].ToString(); 
        }
        public static int GetUserID()
        {
            var UserID = 0;
            if (HttpContext.Current.Session.Count > 0)
            {
                UserID = int.Parse(HttpContext.Current.Session["UserID"].ToString());
            }
            return UserID;
        }
        
    }
}