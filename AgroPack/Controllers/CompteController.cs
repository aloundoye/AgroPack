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
    [Authorize]
    public class CompteController : Controller
    {
        private AgroPackDbContext agroPackDbContext = new AgroPackDbContext();
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
                    Value = item.ChampId.ToString(),
                    Text = item.Nom
                });
            }
            return list;
        }

        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        //Catégorie
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

        public ActionResult CategoryDelete(int categoryId)
        {
            return View(_UnitOfWork.GetRepositoryInstance<Categorie>().GetFirstorDefault(categoryId));
        }
        [HttpPost]
        public ActionResult CategoryDelete(Categorie categorie)
        {

            var category = agroPackDbContext.Categories.Find(categorie.Id);
            agroPackDbContext.Categories.Remove(category);

            try
            {
                agroPackDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Provide for exceptions.
            }
            return RedirectToAction("Categories");
        }


        //Produit
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
        public ActionResult ProductEdit(Produit produit, HttpPostedFileBase file)
        {
            string pic = null;
            if (file != null)
            {
                string[] filename = file.FileName.Split('.');
                string type = filename[filename.Length - 1];
                pic = System.IO.Path.GetFileName(Guid.NewGuid().ToString() + "." + type);
                string path = System.IO.Path.Combine(Server.MapPath("~/Images/Produits"), pic);
                // file is uploaded
                file.SaveAs(path);

            }
            produit.Image = file != null ? pic : produit.Image;
            _UnitOfWork.GetRepositoryInstance<Produit>().Update(produit);
            return RedirectToAction("Product");
        }
        public ActionResult ProductAdd()
        {
            ViewBag.CategorieList = GetCategorie();
            ViewBag.ChampsList = GetChamps();
            
            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(Produit produit, HttpPostedFileBase file)
        {
            string pic = null;
            if (file != null)
            {
                string[] filename = file.FileName.Split('.');
                string type = filename[filename.Length - 1];
                pic = System.IO.Path.GetFileName(Guid.NewGuid().ToString() + "." + type);
                string path = System.IO.Path.Combine(Server.MapPath("~/Images/Produits"), pic);
                // file is uploaded
                file.SaveAs(path);
                
            }
            produit.Image = pic;
            produit.CreatedDate = DateTime.Now;
            _UnitOfWork.GetRepositoryInstance<Produit>().Add(produit);
            return RedirectToAction("Product");

        }

        public ActionResult ProductDelete(int productId)
        {
            return View(_UnitOfWork.GetRepositoryInstance<Produit>().GetFirstorDefault(productId));
        }
        [HttpPost]
        public ActionResult ProductDelete(Produit produit)
        {

            var product = agroPackDbContext.Produits.Find(produit.Id);
            agroPackDbContext.Produits.Remove(product);

            try
            {
                agroPackDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Provide for exceptions.
            }
            return RedirectToAction("Product");
        }

        //Champs
        public ActionResult Champs()
        {
            return View();
        }

        //Commandes
        public ActionResult Order()
        {
            return View();
        }
    }
}