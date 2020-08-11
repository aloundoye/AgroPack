using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AgroPack.Repository;

namespace AgroPack.Models.Home
{
    public class HomeIndexViewModel
    {
        public GenericUnitOfWork _UnitOfWork = new GenericUnitOfWork();
        public IEnumerable<Produit> ListOfProduits { get; set; }

        public HomeIndexViewModel CreateModel()
        {
            return new HomeIndexViewModel
            {
                ListOfProduits = _UnitOfWork.GetRepositoryInstance<Produit>().GetAllRecords()
            };
        }
    }
}