namespace AgroPack
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Commande
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Commande()
        {
            DetailsCmds = new HashSet<DetailsCmd>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string ClientId { get; set; }

        [Column(TypeName = "text")]
        public string libelle { get; set; }

        [Column(TypeName = "date")]
        public DateTime dateCommande { get; set; }

        public bool validite { get; set; }

        [StringLength(50)]
        public string statut { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailsCmd> DetailsCmds { get; set; }
    }
}
