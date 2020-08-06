using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

    }
}