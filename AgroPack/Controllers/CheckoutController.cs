using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgroPack.Models;
using AgroPack.Models.Home;
using Microsoft.AspNet.Identity;

namespace AgroPack.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private AgroPackDbContext db = new AgroPackDbContext();
        // GET: Checkout
        public ActionResult VerifyAddress()
        {
            User user = db.Users.Find(User.Identity.GetUserId());
            

            if (user != null)
            {
                if (string.IsNullOrWhiteSpace(user.Address))
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Delivery");
                }
            }

            return RedirectToAction("Delivery");
        }
        [HttpPost]
        public ActionResult VerifyAddress(VerifyAddressViewModel mUser)
        {
            User user = db.Users.Find(User.Identity.GetUserId());
            user.Address = mUser.Address;
            user.City = mUser.City;
            db.SaveChanges();
            return RedirectToAction("Delivery");
        }

        public ActionResult Delivery()
        {
            User user = db.Users.Find(User.Identity.GetUserId());
            List<Item> orderItems = (List<Item>)Session["cart"];
         Commande commande = new Commande()
         {
             ClientId = User.Identity.GetUserId(),
             libelle = Guid.NewGuid().ToString(),
             dateCommande = DateTime.Now,
             statut = "Commande créée"
         };
         List<DetailsCmd> detailsCmds = new List<DetailsCmd>();
         foreach (var orderItem in orderItems)
         {
             detailsCmds.Add(new DetailsCmd()
             {
                 idCommande = commande.Id,
                 ProduitId = orderItem.Produit.Id,
                 quantiteProduit = orderItem.Quantity,
                 totalPrix = orderItem.Produit.prix * orderItem.Quantity,
                 Adresse = user.Address,
                 Ville = user.City
             });
         }

         db.DetailsCmds.AddRange(detailsCmds);
         db.Commandes.Add(commande);
         db.SaveChanges();
         CheckoutViewModel model =new CheckoutViewModel()
         {
             Commande = commande,
             DetailsCmds = detailsCmds
         };
         return View(model);
        }

        public ActionResult Payment()
        {
            return View();
        }
    }
}