using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgroPack.Repository;

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
    }
}