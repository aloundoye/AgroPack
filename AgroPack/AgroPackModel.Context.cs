﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AgroPackDbContext : DbContext
    {
        public AgroPackDbContext()
            : base("name=AgroPackDbContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Agriculteur> Agriculteurs { get; set; }
        public virtual DbSet<Champ> Champs { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Commande> Commandes { get; set; }
        public virtual DbSet<DetailsCmd> DetailsCmds { get; set; }
        public virtual DbSet<Entreprise> Entreprises { get; set; }
        public virtual DbSet<Panier> Paniers { get; set; }
        public virtual DbSet<Produit> Produits { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Categorie> Categories { get; set; }
    }
}
