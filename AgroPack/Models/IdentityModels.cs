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
        [Required]
        [Display(Name = "Nom")]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Prénom")]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Display(Name = "Adresse")]
        [StringLength(100)]
        public string Address { get; set; }
        [Display(Name = "Ville")]
        [StringLength(100)]
        public string City { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }

        public string DisplayAddress
        {
            get
            {
                string dspAddress =
                    string.IsNullOrWhiteSpace(this.Address) ? "" : this.Address;
                string dspCity =
                    string.IsNullOrWhiteSpace(this.City) ? "" : this.City;

                return string
                    .Format("{0}, {1}", dspAddress, dspCity);
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public enum TypeCompte
    {
        Client, Agriculteur
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
                .HasMany(e => e.Produits)
                .WithOptional(e => e.Agriculteur)
                .HasForeignKey(e => e.AgriculteurId);

            modelBuilder.Entity<Agriculteur>()
                .HasMany(e => e.Produits1)
                .WithOptional(e => e.Agriculteur1)
                .HasForeignKey(e => e.AgriculteurId);

            modelBuilder.Entity<Categorie>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Categorie>()
                .HasMany(e => e.Produits)
                .WithOptional(e => e.Categorie)
                .HasForeignKey(e => e.categorieId);

            modelBuilder.Entity<Categorie>()
                .HasMany(e => e.Produits1)
                .WithOptional(e => e.Categorie1)
                .HasForeignKey(e => e.categorieId);

            modelBuilder.Entity<Champ>()
                .Property(e => e.Nom)
                .IsUnicode(false);

            modelBuilder.Entity<Champ>()
                .HasMany(e => e.Produits)
                .WithOptional(e => e.Champ)
                .HasForeignKey(e => e.idChamps);

            modelBuilder.Entity<Champ>()
                .HasMany(e => e.Produits1)
                .WithOptional(e => e.Champ1)
                .HasForeignKey(e => e.idChamps);

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

            modelBuilder.Entity<Entreprise>()
                .HasMany(e => e.Agriculteurs)
                .WithOptional(e => e.Entreprise)
                .HasForeignKey(e => e.idEntreprise);

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
                .HasMany(e => e.Paniers)
                .WithOptional(e => e.Produit)
                .HasForeignKey(e => e.idProduit)
                .WillCascadeOnDelete();
        }
    }


}