using CosmeticShop.Context;
using CosmeticShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CosmeticShop.Controllers
{
    public class PartialsController : Controller
    {
        CosmoContext Context = new CosmoContext();
        // GET: Partials
        public PartialViewResult Header()
        {
            var Model = new List<CategoryModel>();
            var Categories = Context.Categories.ToList();
            foreach (var Item in Categories)
            {
                Model.Add(new CategoryModel
                {
                    CategoryID = Item.Id,
                    CategoryName = Item.CatName
                });
            }
            return PartialView(Model);
        }
        public PartialViewResult Footer()
        {
            return PartialView();
        }
    }
}