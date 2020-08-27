namespace AgroPack
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetailsCmd")]
    public partial class DetailsCmd
    {
        public int id { get; set; }

        public int quantiteProduit { get; set; }

        public int idCommande { get; set; }

        public decimal? totalPrix { get; set; }

        [StringLength(500)]
        public string Adresse { get; set; }

        [StringLength(500)]
        public string Ville { get; set; }

        [StringLength(50)]
        public string TypePaiement { get; set; }

        public int? ProduitId { get; set; }

        public virtual Commande Commande { get; set; }

        public virtual Produit Produit { get; set; }
    }
}
