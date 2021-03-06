namespace AgroPack
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Champ
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Champ()
        {
            Produits = new HashSet<Produit>();
        }

        public int ChampId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nom { get; set; }

        [StringLength(128)]
        public string AgriculteurId { get; set; }

        public virtual Agriculteur Agriculteur { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produit> Produits { get; set; }
    }
}
