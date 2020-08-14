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
        public GenericUnitOfWork _UnitOfWork = new GenericUnitOfWork();

        public ActionResult Index( string search, int? page)
        {
            HomeIndexViewModel model = new HomeIndexViewModel();
            return View(model.CreateModel(search, 2, page));
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