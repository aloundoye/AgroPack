namespace AgroPack
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Produit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Produit()
        {
            DetailsCmds = new HashSet<DetailsCmd>();
            Paniers = new HashSet<Panier>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(128)]
        public string AgriculteurId { get; set; }

        [StringLength(100)]
        public string nom { get; set; }

        public int? quantite { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? prix { get; set; }

        public int? idChamps { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public int? categorieId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }

        public virtual Agriculteur Agriculteur { get; set; }

        public virtual Agriculteur Agriculteur1 { get; set; }

        public virtual Categorie Categorie { get; set; }

        public virtual Categorie Categorie1 { get; set; }

        public virtual Champ Champ { get; set; }

        public virtual Champ Champ1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailsCmd> DetailsCmds { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Panier> Paniers { get; set; }
    }
}
