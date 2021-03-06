﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AgroPack.Repository;
using PagedList;

namespace AgroPack.Models.Home
{
    public class HomeIndexViewModel
    {
        public GenericUnitOfWork _UnitOfWork = new GenericUnitOfWork();
        AgroPackDbContext context = new AgroPackDbContext();
        public IPagedList<Produit> ListOfProduits { get; set; }
        public HomeIndexViewModel CreateModel(string search, int pageSize, int? page)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@search", search??(object)DBNull.Value), 
            };
             IPagedList<Produit> data =  context.Database.SqlQuery<Produit>("GetBySearch @search", parameters).ToList().ToPagedList(page ?? 1, pageSize);
            return new HomeIndexViewModel
            {
                ListOfProduits = data
            };
        }
    }
}