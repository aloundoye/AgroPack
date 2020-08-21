using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgroPack.Models
{
    public class ProduitEditViewModel
    {
        public IEnumerable<Champ> Champs { get; set; }
        public IEnumerable<Categorie> Categories { get; set; }
        public IEnumerable<User> Utilisateurs { get; set; }
        public Produit Produit { get; set; }
    }
}