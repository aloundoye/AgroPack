namespace AgroPack
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Panier")]
    public partial class Panier
    {
        public int id { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        public int? idProduit { get; set; }

        [StringLength(50)]
        public string Statut { get; set; }
        
        public int Quantity { get; set; }

        public virtual Produit Produit { get; set; }
    }
}
