using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgroPack.Models
{
    public class DetailCommande
    {
        [Required]
        public int id { get; set; }
        [Required]
        public int quantiteProduit { get; set; }
        [Required]
        public int idCommande { get; set; }
        public Nullable<decimal> totalPrix { get; set; }
        [Required]
        public string Adresse { get; set; }
        [Required]
        public string Ville { get; set; }
        [Required]
        public string TypePaiement { get; set; }
    }
}