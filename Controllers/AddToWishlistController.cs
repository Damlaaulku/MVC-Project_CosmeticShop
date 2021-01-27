using CosmeticShop.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace CosmeticShop.Controllers
{
    public class AddToWishlistController : ApiController
    {
        [System.Web.Http.HttpGet()]
        [System.Web.Http.Route("api/AddToWishlist/WishAdd")]
        [System.Web.Http.ActionName("WishAdd")]
        public HttpResponseMessage WishAdd(int ProductID, int UserID)
        {
            if (UserID > 0)
            {
                Context.CosmoContext db = new Context.CosmoContext();
                var Control = db.Users.Where(x => x.Id == UserID).SelectMany(x => x.Wishlist).Where(x=>x.ProductID == ProductID).ToList();
                if (Control.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Status = false, Redirect = false , Response = "Bu ürün zaten ekli!" }, Configuration.Formatters.JsonFormatter);

                }
                else
                {
                    var user = db.Users.Where(x => x.Id == UserID).FirstOrDefault();
                    user.Wishlist.Add(new Entities.Wishlist
                    {
                        ProductID = ProductID,
                        UserID = user.Id
                    });
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, new { Status = true, Redirect = false, Response = "Ürün başarıyla eklendi!" }, Configuration.Formatters.JsonFormatter);

                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Status = false, Redirect = true, Response = "Üye değilsiniz!" }, Configuration.Formatters.JsonFormatter);
            }
        }
    }
}
