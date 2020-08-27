using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgroPack.Models;
using AgroPack.Models.Home;
using AgroPack.Repository;
using PagedList;

namespace AgroPack.Controllers
{
    public class HomeController : Controller
    {
        AgroPackDbContext context = new AgroPackDbContext();
        public GenericUnitOfWork _UnitOfWork = new GenericUnitOfWork();

        public ActionResult Index( string search, int? page, string Category = null)
        {
            if (Category == null)
            {
                HomeIndexViewModel model = new HomeIndexViewModel();
                return View(model.CreateModel(search, 12, page));
            }
            else
            {
                List<Categorie> dataCategories = _UnitOfWork.GetRepositoryInstance<Categorie>().GetAllRecords().ToList();
                Categorie categorie = context.Categories.SingleOrDefault(c => c.Name == Category);
                IPagedList<Produit> dataProduits = context.Produits.Where(p => p.categorieId == categorie.Id).ToList().ToPagedList(page ?? 1, 12); ;
                HomeIndexViewModel model = new HomeIndexViewModel()
                {
                    ListCategories = dataCategories,
                    ListOfProduits = dataProduits
                };


                return View(model);
            }
        }

        public ActionResult CheckoutDetails()
        {
            return View();
        }

        public ActionResult AddToCart(int productId)
        {
            var itemCarts = (List<Item>)Session["cart"];
            if (Session["cart"] == null || itemCarts.Count == 0)
            {
                var cart = new List<Item>();
                var product = context.Produits.Find(productId);
                cart.Add(new Item()
                {
                    Produit = product,
                    Quantity = 1
                });
                Session["cart"] = cart;
            }
            else
            {
                var cart = (List<Item>)Session["cart"];
                var product = context.Produits.Find(productId);
                bool trouve = false;
                int indice = cart.Count;
                for (int i = 0; i < cart.Count; i++)
                {

                    if (cart[i].Produit.Id == productId)
                    {
                        
                        trouve = true;
                        indice = i;
                        break;

                    }
                }
            
                if (trouve)
                {
                    ++cart[indice].Quantity;
                }
                else
                {
                    cart.Add(new Item()
                    {
                        Produit = product,
                        Quantity = 1
                    });
                }

                
                Session["cart"] = cart;

            }
            return Redirect("Cart");
        }

        public ActionResult RemoveFromCart(int productId)
        {
            var cart = (List<Item>)Session["cart"];
            foreach (var item in cart)
            {
                if (item.Produit.Id == productId)
                {
                    cart.Remove(item);
                    break;
                }
            }
           
            Session["cart"] = cart;
            return Redirect("Cart");
        }
        
        public ActionResult Cart()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateQuantity(string Quantity, int productId)
        {
            var cart = (List<Item>)Session["cart"];
            var product = context.Produits.Find(productId);
            bool trouve = false;
            int indice = cart.Count;
            for (int i = 0; i < cart.Count; i++)
            {

                if (cart[i].Produit.Id == productId)
                {

                    trouve = true;
                    indice = i;
                    break;

                }
            }

            if (trouve)
            {
                if (Quantity != null)
                {
                    int quantity = Convert.ToInt32(Quantity);
                    cart[indice].Quantity = quantity;
                }
            }
            Session["cart"] = cart;
            return Redirect("Cart");
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