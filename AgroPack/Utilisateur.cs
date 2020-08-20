namespace AgroPack
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public enum typeCompte
    {
        Client, Agriculteur
    }

    public partial class Utilisateur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Utilisateur()
        {
            Champs = new HashSet<Champ>();
            Paniers = new HashSet<Panier>();
            Produits = new HashSet<Produit>();
        }

        public int UtilisateurID { get; set; }

        [Required]
        [StringLength(100)]
        public string nom { get; set; }

        [Required]
        [StringLength(100)]
        public string prenom { get; set; }

        [StringLength(50)]
        public string type { get; set; }

        [Required]
        [StringLength(100)]
        public string email { get; set; }

        [Required]
        [StringLength(100)]
        public string password { get; set; }

        [StringLength(100)]
        public string photo { get; set; }

        public int? tel { get; set; }

        [StringLength(100)]
        public string adresse { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateDeNaissance { get; set; }

        public virtual Agriculteur Agriculteur { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Champ> Champs { get; set; }

        public virtual Client Client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Panier> Paniers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produit> Produits { get; set; }
    }
}
