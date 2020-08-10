using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgroPack.Models;
using AgroPack.Repository;
using Newtonsoft.Json;

namespace AgroPack.Controllers
{
    public class DashboardController : Controller
    {
        public GenericUnitOfWork _UnitOfWork = new GenericUnitOfWork();
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Categories()
        {
            List<Categorie> allCategories =
                _UnitOfWork.GetRepositoryInstance<Categorie>().GetAllRecordsIQueryable().ToList();
            return View(allCategories);
        }

        public ActionResult CategoriesEdit(int categoryId)
        {

            return View(_UnitOfWork.GetRepositoryInstance<Categorie>().GetFirstorDefault(categoryId));
        }
        [HttpPost]
        public ActionResult CategoriesEdit(Categorie categorie)
        {
            _UnitOfWork.GetRepositoryInstance<Categorie>().Update(categorie);
            return RedirectToAction("Categories");
        }

        public ActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CategoryAdd(Categorie categorie)
        {
            _UnitOfWork.GetRepositoryInstance<Categorie>().Add(categorie);
            return RedirectToAction("Categories");

        }

        public ActionResult Product()
        {
            return View(_UnitOfWork.GetRepositoryInstance<Produit>().GetProduct());
        }
        public ActionResult ProductEdit( int productId)
        {
            
            return View(_UnitOfWork.GetRepositoryInstance<Produit>().GetFirstorDefault(productId));
        }
        [HttpPost]
        public ActionResult ProductEdit(Produit product)
        {
            _UnitOfWork.GetRepositoryInstance<Produit>().Update(product);
            return RedirectToAction("Product");
        }
        public ActionResult ProductAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(Produit produit)
        {
            _UnitOfWork.GetRepositoryInstance<Produit>().Add(produit);
            return RedirectToAction("Product");

        }
        public ActionResult Champs()
        {
            return View();
        }
        public ActionResult Order()
        {
            return View();
        }
    }
}