//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AgroPack
{
    using System;
    using System.Collections.Generic;
    
    public partial class Utilisateur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Utilisateur()
        {
            this.Champs = new HashSet<Champ>();
            this.Paniers = new HashSet<Panier>();
            this.Produits = new HashSet<Produit>();
        }
    
        public int UtilisateurID { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string type { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string photo { get; set; }
        public Nullable<int> tel { get; set; }
        public string adresse { get; set; }
        public Nullable<System.DateTime> dateDeNaissance { get; set; }
        public Nullable<int> idRole { get; set; }
    
        public virtual Agriculteur Agriculteur { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Champ> Champs { get; set; }
        public virtual Client Client { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Panier> Paniers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produit> Produits { get; set; }
    }

    public enum typeCompte
    {
        Agriculteur, Client
    }
}
