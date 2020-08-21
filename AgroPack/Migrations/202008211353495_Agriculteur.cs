namespace AgroPack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Agriculteur : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Agriculteurs", "id", "dbo.Utilisateurs");
            DropIndex("dbo.Agriculteurs", new[] { "id" });
            RenameColumn(table: "dbo.Utilisateurs", name: "id", newName: "Agriculteur_id");
            AddColumn("dbo.Agriculteurs", "Utilisateur_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Agriculteurs", "Utilisateur_Id");
            CreateIndex("dbo.Utilisateurs", "Agriculteur_id");
            AddForeignKey("dbo.Agriculteurs", "Utilisateur_Id", "dbo.User", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Utilisateurs", "Agriculteur_id", "dbo.Agriculteurs", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Utilisateurs", "Agriculteur_id", "dbo.Agriculteurs");
            DropForeignKey("dbo.Agriculteurs", "Utilisateur_Id", "dbo.User");
            DropIndex("dbo.Utilisateurs", new[] { "Agriculteur_id" });
            DropIndex("dbo.Agriculteurs", new[] { "Utilisateur_Id" });
            DropColumn("dbo.Agriculteurs", "Utilisateur_Id");
            RenameColumn(table: "dbo.Utilisateurs", name: "Agriculteur_id", newName: "id");
            CreateIndex("dbo.Agriculteurs", "id");
            AddForeignKey("dbo.Agriculteurs", "id", "dbo.Utilisateurs", "UtilisateurID", cascadeDelete: true);
        }
    }
}
