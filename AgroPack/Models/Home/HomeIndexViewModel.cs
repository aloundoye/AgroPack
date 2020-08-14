using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AgroPack.Repository;

namespace AgroPack.Models.Home
{
    public class HomeIndexViewModel
    {
        public GenericUnitOfWork _UnitOfWork = new GenericUnitOfWork();
        AgroPackDbContext context = new AgroPackDbContext();
        public IEnumerable<Produit> ListOfProduits { get; set; }

        public HomeIndexViewModel CreateModel(string search)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@search", search??(object)DBNull.Value), 
            };
             IEnumerable<Produit> data =  context.Database.SqlQuery<Produit>("GetBySearch @search", parameters).ToList();
            return new HomeIndexViewModel
            {
                ListOfProduits = data
            };
        }
    }
}