using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AgroPack.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
      
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class AgroPackDbContext : IdentityDbContext<User>
    {
        public AgroPackDbContext()
            : base("AgroPackDbContext", throwIfV1Schema: false)
        {
        }

        public static AgroPackDbContext Create()
        {
            return new AgroPackDbContext();
        }

        public virtual DbSet<Agriculteur> Agriculteurs { get; set; }
        public virtual DbSet<Categorie> Categories { get; set; }
        public virtual DbSet<Champ> Champs { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Commande> Commandes { get; set; }
        public virtual DbSet<DetailsCmd> DetailsCmds { get; set; }
        public virtual DbSet<Entreprise> Entreprises { get; set; }
        public virtual DbSet<Panier> Paniers { get; set; }
        public virtual DbSet<Produit> Produits { get; set; }
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Here, I am mapping User table User back in DB, and telling instead of using Id property
            //in table, I like to use UserId
            modelBuilder.Entity<User>().ToTable("User").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim").Property(p =>
                p.Id).HasColumnName("UserClaimId");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles").Property(p =>
                p.Id).HasColumnName("RoleId");
            modelBuilder.Entity<Agriculteur>()
                .HasMany(e => e.Commandes)
                .WithRequired(e => e.Agriculteur)
                .HasForeignKey(e => e.prop_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Categorie>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Champ>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<Champ>()
                .HasMany(e => e.Produits)
                .WithOptional(e => e.Champ)
                .HasForeignKey(e => e.idChamps)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Commandes)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.client_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Commande>()
                .Property(e => e.libelle)
                .IsUnicode(false);

            modelBuilder.Entity<Commande>()
                .Property(e => e.statut)
                .IsUnicode(false);

            modelBuilder.Entity<Commande>()
                .HasMany(e => e.DetailsCmds)
                .WithRequired(e => e.Commande)
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

            modelBuilder.Entity<Entreprise>()
                .Property(e => e.Nom)
                .IsUnicode(false);

            modelBuilder.Entity<Entreprise>()
                .Property(e => e.adresse)
                .IsUnicode(false);

            modelBuilder.Entity<Entreprise>()
                .Property(e => e.tel)
                .IsUnicode(false);

            modelBuilder.Entity<Panier>()
                .Property(e => e.Statut)
                .IsUnicode(false);

            modelBuilder.Entity<Produit>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<Produit>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Produit>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Produit>()
                .HasMany(e => e.Commandes)
                .WithRequired(e => e.Produit)
                .HasForeignKey(e => e.prod_id);

            modelBuilder.Entity<Produit>()
                .HasMany(e => e.Paniers)
                .WithOptional(e => e.Produit)
                .HasForeignKey(e => e.idProduit)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Utilisateur>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<Utilisateur>()
                .Property(e => e.prenom)
                .IsUnicode(false);

            modelBuilder.Entity<Utilisateur>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<Utilisateur>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Utilisateur>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Utilisateur>()
                .Property(e => e.photo)
                .IsUnicode(false);

            modelBuilder.Entity<Utilisateur>()
                .Property(e => e.adresse)
                .IsUnicode(false);

            modelBuilder.Entity<Utilisateur>()
                .HasOptional(e => e.Agriculteur)
                .WithRequired(e => e.Utilisateur)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Utilisateur>()
                .HasMany(e => e.Champs)
                .WithRequired(e => e.Utilisateur)
                .HasForeignKey(e => e.prop_id);

            modelBuilder.Entity<Utilisateur>()
                .HasOptional(e => e.Client)
                .WithRequired(e => e.Utilisateur)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Utilisateur>()
                .HasMany(e => e.Paniers)
                .WithOptional(e => e.Utilisateur)
                .HasForeignKey(e => e.idClient);

            modelBuilder.Entity<Utilisateur>()
                .HasMany(e => e.Produits)
                .WithOptional(e => e.Utilisateur)
                .HasForeignKey(e => e.prop_id);
        }
    }


}