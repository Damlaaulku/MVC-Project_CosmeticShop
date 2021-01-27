using CosmeticShop.Context;
using CosmeticShop.Entities;
using CosmeticShop.Helpers;
using CosmeticShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CosmeticShop.Controllers
{

    public class HomeController : Controller
    {
        CosmoContext Context = new CosmoContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }
      
        [HttpGet]
        public ActionResult Login()
        {
            var Model = new UserLogin();
            ModelState.Clear();

            if (Season.SeasonContol())
            {
                Model.IsLogin = true;
                return RedirectToAction("Profil", new { UserEmail = Season.GetEmail() });
            }
            return View(Model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin PostDatalar)
        {
            var Model = new UserLogin();
            if (ModelState.IsValid)
            {
                var LoginControl = Context.Users.Where(x => x.Email == PostDatalar.UserEmail && x.Password == PostDatalar.Password).FirstOrDefault();
                if (LoginControl != null)
                {
                    if (Season.SeasonAdd(PostDatalar.UserEmail, LoginControl.Id))
                    {
                        return RedirectToAction("Profil", new { UserEmail = PostDatalar.UserEmail });
                    }
                    else
                    {
                        Model.Errorcode = 1;
                        Model.ErrorMessage = "System Failure! You couldn't login.";
                    }
                }
                else
                {
                    Model.Errorcode = 1;
                    Model.ErrorMessage = "The username or password is incorrect. Please try again!";
                }
            }

            return View(Model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout(UserLogout Post)
        {
            Season.SeasonDelete(Post.Email);
            return RedirectToAction("Login");
        }
        public ActionResult Wishlist()
        {
            var Model = new List<WishlistDisplayModel>();
            ViewBag.Error = 0;
            var UserID = Season.GetUserID();
            if (UserID > 0)
            {
                var ProductList = Context.Users.Where(x => x.Id == UserID).SelectMany(x => x.Wishlist).ToList();
                foreach(var item in ProductList)
                {
                    var Product = Context.Products.Where(x => x.Id == item.ProductID).FirstOrDefault();
                    if(Product != null)
                    {
                        Model.Add(new WishlistDisplayModel
                        {
                            ProductID = Product.Id,
                            ProductName = Product.Name,
                            ProductPhoto = Product.Photo,
                            ProductDesc = Product.Description,
                            ProductPrice = Product.Price
                        }); ;
                        
                    }                   
                }
            }
            else
            {
                ViewBag.Error = 1;
            }
            return View(Model);
        }
        public ActionResult Register()
        {
            var Model = new RegisterModel();
            ModelState.Clear();
            return View(Model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel Post)
        {
            var Model = new RegisterModel();
            var UserEntity = new Users();
            if (ModelState.IsValid)
            {
                if (UserCheck(Post.UserEmail))
                {
                    UserEntity.Name = Post.UserName;
                    UserEntity.Surname = Post.UserSurname;
                    UserEntity.Email = Post.UserEmail;
                    UserEntity.Password = Post.UserPass;
                    Context.Users.Add(UserEntity);
                    Context.SaveChanges();
                    return RedirectToAction("Profil", new { UserEmail = Post.UserEmail });

                }
                else
                {
                    return View(Model);
                }


            }
            return View(Model);
        }
        public bool UserCheck(string Email)
        {
            var Control = Context.Users.Where(x => x.Email == Email).ToList();
            if (Control.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public ActionResult Profil(string UserEmail)
        {
            var Model = new ProfilModel();
            var User = Context.Users.Where(x => x.Email.Equals(UserEmail)).FirstOrDefault();
            if (User != null)
            {
                Model.UserMail = User.Email;
                Model.UserName = User.Name;
                Model.UserSurname = User.Surname;
            }
            return View(Model);
        }

        public ActionResult Product(int ProductID = 0)
        {
            var Model = new ProductModel();
            if (ProductID > 0)
            {
                var Product = Context.Products.Where(x => x.Id == ProductID).FirstOrDefault();
                if (Product != null)
                {
                    Model.ProductName = Product.Name;
                    Model.ProductDesc = Product.Description;
                    Model.ProductPhoto = Product.Photo;
                    Model.ProductPrice = Product.Price;
                    Model.ErrorCode = 0;
                    Model.ErrorMessage = "";
                }
            }
            else
            {
                Model.ErrorCode = 1;
                Model.ErrorMessage = "404 NOT FOUND";
            }
            return View(Model);
        }
        public ActionResult Category(int CatId = 0)
        {
            if (CatId == 0)
            {
                return RedirectToAction("Catalog");
            }
            else
            {
                var Control = Context.Categories.Where(x => x.Id == CatId).FirstOrDefault();
                if (Control == null)
                {
                    return RedirectToAction("Catalog");
                }
                else
                {
                    return RedirectToAction("Catalog",new { CatId=Control.Id});
                }
            }
        }
        public ActionResult Catalog(int CatId = 0)
        {
            var Model = new List<CatalogModel>();

            if (CatId == 0)
            {
                var Products = Context.Products.ToList();
                foreach (var Item in Products)
                {
                    Model.Add(new CatalogModel
                    {
                        Id = Item.Id,
                        ProductName = Item.Name,
                        ProductPrice = Item.Price,
                        ProductPhooto = Item.Photo
                    });
                }
            }
            else
            {
                var Products = Context.Categories.Where(x => x.Id == CatId).SelectMany(x => x.Products).ToList();
                foreach (var Item in Products)
                {
                    Model.Add(new CatalogModel
                    {
                        Id = Item.Id,
                        ProductName = Item.Name,
                        ProductPrice = Item.Price,
                        ProductPhooto = Item.Photo
                    });
                }
            }
            return View(Model);

        }

    }
}