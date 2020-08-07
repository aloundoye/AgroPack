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

        public ActionResult AddCategory()
        {
            return UpdateCategory(0);
        }

        public ActionResult UpdateCategory(int categoryId)
        {
            Detailcategorie cd;
            if (categoryId != null)
            {
                cd = JsonConvert.DeserializeObject<Detailcategorie>(JsonConvert.SerializeObject(_UnitOfWork.GetRepositoryInstance<Categorie>().GetFirstorDefault(categoryId)));
            }
            else
            {
                cd = new Detailcategorie();
            }
            return View("UpdateCategory", cd);

        }

        public ActionResult Product()
        {
            return View(_UnitOfWork.GetRepositoryInstance<Produit>().GetProduct());
        }
        public ActionResult ProductEdit( int productId)
        {
            var product = _UnitOfWork.GetRepositoryInstance<Produit>().GetFirstorDefault(productId);
            var champs = _UnitOfWork.GetRepositoryInstance<Champ>().GetAllRecordsIQueryable().ToList();
            var utilisateurs = _UnitOfWork.GetRepositoryInstance<Utilisateur>().GetAllRecordsIQueryable().ToList();
            var categories = _UnitOfWork.GetRepositoryInstance<Categorie>().GetAllRecordsIQueryable().ToList();

            var viewModel = new ProduitEditViewModel
            {
                Produit = product,
                Champs = champs,
                Utilisateurs = utilisateurs,
                Categories = categories
            };
            return View(viewModel);
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