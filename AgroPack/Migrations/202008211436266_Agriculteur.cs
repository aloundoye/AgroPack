namespace AgroPack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Agriculteur : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Commandes", "prop_id", "dbo.Agriculteurs");
            DropForeignKey("dbo.Agriculteurs", "id", "dbo.Utilisateurs");
            DropIndex("dbo.Agriculteurs", new[] { "id" });
            DropIndex("dbo.Commandes", new[] { "prop_id" });
            RenameColumn(table: "dbo.Utilisateurs", name: "id", newName: "Agriculteur_Id");
            DropPrimaryKey("dbo.Agriculteurs");
            AddColumn("dbo.Agriculteurs", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Commandes", "Agriculteur_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Commandes", "prop_id", c => c.String());
            AddPrimaryKey("dbo.Agriculteurs", "UserId");
            CreateIndex("dbo.Utilisateurs", "Agriculteur_Id");
            CreateIndex("dbo.Commandes", "Agriculteur_Id");
            CreateIndex("dbo.Agriculteurs", "UserId");
            AddForeignKey("dbo.Agriculteurs", "UserId", "dbo.User", "UserId");
            AddForeignKey("dbo.Commandes", "Agriculteur_Id", "dbo.Agriculteurs", "UserId");
            AddForeignKey("dbo.Utilisateurs", "Agriculteur_Id", "dbo.Agriculteurs", "UserId");
            DropColumn("dbo.Agriculteurs", "id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Agriculteurs", "id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Utilisateurs", "Agriculteur_Id", "dbo.Agriculteurs");
            DropForeignKey("dbo.Commandes", "Agriculteur_Id", "dbo.Agriculteurs");
            DropForeignKey("dbo.Agriculteurs", "UserId", "dbo.User");
            DropIndex("dbo.Agriculteurs", new[] { "UserId" });
            DropIndex("dbo.Commandes", new[] { "Agriculteur_Id" });
            DropIndex("dbo.Utilisateurs", new[] { "Agriculteur_Id" });
            DropPrimaryKey("dbo.Agriculteurs");
            AlterColumn("dbo.Commandes", "prop_id", c => c.Int(nullable: false));
            DropColumn("dbo.Commandes", "Agriculteur_Id");
            DropColumn("dbo.Agriculteurs", "UserId");
            AddPrimaryKey("dbo.Agriculteurs", "id");
            RenameColumn(table: "dbo.Utilisateurs", name: "Agriculteur_Id", newName: "id");
            CreateIndex("dbo.Commandes", "prop_id");
            CreateIndex("dbo.Agriculteurs", "id");
            AddForeignKey("dbo.Agriculteurs", "id", "dbo.Utilisateurs", "UtilisateurID", cascadeDelete: true);
            AddForeignKey("dbo.Commandes", "prop_id", "dbo.Agriculteurs", "id");
        }
    }
}
