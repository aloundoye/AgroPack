using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgroPack.Models.Home;
using AgroPack.Repository;

namespace AgroPack.Controllers
{
    public class HomeController : Controller
    {
        AgroPackDbContext context = new AgroPackDbContext();
        public GenericUnitOfWork _UnitOfWork = new GenericUnitOfWork();

        public ActionResult Index( string search, int? page)
        {
            HomeIndexViewModel model = new HomeIndexViewModel();
            return View(model.CreateModel(search, 10, page));
        }

        public ActionResult AddToCart(int productId)
        {

            if (Session["cart"] == null)
            {
                var cart = new List<Item>();
                var product = context.Produits.Find(productId);
                cart.Add(new Item()
                {
                    Produit = product,
                    Quantity = 1
                });
                Session["cart"] = cart;
            }
            else
            {
                var cart = (List<Item>)Session["cart"];
                var product = context.Produits.Find(productId);
                cart.Add(new Item()
                {
                    Produit = product,
                    Quantity = 1
                });
                Session["cart"] = cart;
            }
            return Redirect("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Product(int productId)
        {
            return View(_UnitOfWork.GetRepositoryInstance<Produit>().GetFirstorDefault(productId));
        }
    }
}