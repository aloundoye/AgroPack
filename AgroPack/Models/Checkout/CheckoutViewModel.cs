using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AgroPack.Models.Home;

namespace AgroPack.Models
{
    public class CheckoutViewModel
    {
        public Commande Commande ;
        public List<DetailsCmd> DetailsCmds;

        
    }

    public class VerifyAddressViewModel
    {
        [Display(Name = "Adresse")]
        [StringLength(100)]
        public string Address { get; set; }
        [Display(Name = "Ville")]
        [StringLength(100)]
        public string City { get; set; }
    }
}