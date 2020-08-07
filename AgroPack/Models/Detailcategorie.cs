using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgroPack.Controllers
{
    public class Detailcategorie
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Category Name Requird")]
        [StringLength(100, ErrorMessage = "Minimum 3 and minimum 5 and maximum 100 characters are allowed", MinimumLength = 3)]
        public string Name { get; set; }
    }

    public class DetailProduit
    {
        public int Id { get; set; }
        public Nullable<int> prop_id { get; set; }
        [Required(ErrorMessage = "Product Name is Required")]
        [StringLength(100, ErrorMessage = "Minimum 3 and minimum 5 and maximum 100 charaters are allwed", MinimumLength = 3)]
        public string nom { get; set; }
        [Range(typeof(int), "1", "500", ErrorMessage = "Invalid Quantity")]
        public Nullable<int> quantite { get; set; }
        [Range(typeof(decimal), "1", "200000", ErrorMessage = "invalid Price")]
        public Nullable<decimal> prix { get; set; }
        public int refChamps { get; set; }
        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }
        public string Image { get; set; }
        [Required]
        [Range(1, 50)]
        public Nullable<int> categorieId { get; set; }
        public SelectList Categories { get; set; }

    }
}