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

        public List<SelectListItem> GetCategorie()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var cat = _UnitOfWork.GetRepositoryInstance<Categorie>().GetAllRecords();
                foreach (var item in cat)
            {
                list.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name
                });
            }
            return list;
        }
        public List<SelectListItem> GetChamps()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var cat = _UnitOfWork.GetRepositoryInstance<Champ>().GetAllRecords();
            foreach (var item in cat)
            {
                list.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.nom
                });
            }
            return list;
        }
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

            //using (AgroPackDbContext db = new AgroPackDbContext())
            //{
            //    Categorie cat = (from c in db.Categories select c).OrderByDescending(x => x.Id).FirstOrDefault();
            //    categorie.Id = cat.Id + 1;

            //}

            //string guid = Guid.NewGuid().ToString();

            _UnitOfWork.GetRepositoryInstance<Categorie>().Add(categorie);
            return RedirectToAction("Categories");

        }

        public ActionResult Product()
        {
            return View(_UnitOfWork.GetRepositoryInstance<Produit>().GetProduct());
        }
        public ActionResult ProductEdit( int productId)
        {
            ViewBag.CategorieList = GetCategorie();
            ViewBag.ChampsList = GetChamps();
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
            ViewBag.CategorieList = GetCategorie();
            ViewBag.ChampsList = GetChamps();
            
            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(Produit produit)
        {
            produit.CreatedDate = DateTime.Now;
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