namespace AgroPack
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AgroPackContext : DbContext
    {
        public AgroPackContext()
            : base("name=AgroPackContext1")
        {
        }

        public virtual DbSet<Agriculteurs> Agriculteurs { get; set; }
        public virtual DbSet<Categorie> Categorie { get; set; }
        public virtual DbSet<Champs> Champs { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Commandes> Commandes { get; set; }
        public virtual DbSet<DetailsCmd> DetailsCmd { get; set; }
        public virtual DbSet<Entreprises> Entreprises { get; set; }
        public virtual DbSet<Panier> Panier { get; set; }
        public virtual DbSet<Produits> Produits { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorie>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Champs>()
                .Property(e => e.Nom)
                .IsUnicode(false);

            modelBuilder.Entity<Commandes>()
                .Property(e => e.libelle)
                .IsUnicode(false);

            modelBuilder.Entity<Commandes>()
                .Property(e => e.statut)
                .IsUnicode(false);

            modelBuilder.Entity<Commandes>()
                .HasMany(e => e.DetailsCmd)
                .WithRequired(e => e.Commandes)
                .HasForeignKey(e => e.idCommande);

            modelBuilder.Entity<DetailsCmd>()
                .Property(e => e.totalPrix)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DetailsCmd>()
                .Property(e => e.Adresse)
                .IsUnicode(false);

            modelBuilder.Entity<DetailsCmd>()
                .Property(e => e.Ville)
                .IsUnicode(false);

            modelBuilder.Entity<DetailsCmd>()
                .Property(e => e.TypePaiement)
                .IsUnicode(false);

            modelBuilder.Entity<Entreprises>()
                .Property(e => e.Nom)
                .IsUnicode(false);

            modelBuilder.Entity<Entreprises>()
                .Property(e => e.adresse)
                .IsUnicode(false);

            modelBuilder.Entity<Entreprises>()
                .Property(e => e.tel)
                .IsUnicode(false);

            modelBuilder.Entity<Entreprises>()
                .HasMany(e => e.Agriculteurs)
                .WithOptional(e => e.Entreprises)
                .HasForeignKey(e => e.idEntreprise);

            modelBuilder.Entity<Panier>()
                .Property(e => e.Statut)
                .IsUnicode(false);

            modelBuilder.Entity<Produits>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<Produits>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Produits>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Produits>()
                .HasMany(e => e.Commandes)
                .WithRequired(e => e.Produits)
                .HasForeignKey(e => e.AgriculteurId);

            modelBuilder.Entity<Produits>()
                .HasMany(e => e.Panier)
                .WithOptional(e => e.Produits)
                .HasForeignKey(e => e.idProduit)
                .WillCascadeOnDelete();
        }
    }
}
