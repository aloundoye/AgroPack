namespace AgroPack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Agriculteur : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Agriculteurs", "id", "dbo.Utilisateurs");
            DropForeignKey("dbo.Commandes", "prop_id", "dbo.Agriculteurs");
            DropIndex("dbo.Agriculteurs", new[] { "id" });
            DropIndex("dbo.Commandes", new[] { "prop_id" });
            AlterColumn("dbo.Agriculteurs", "id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Commandes", "prop_id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Agriculteurs", "id");
            CreateIndex("dbo.Agriculteurs", "id");
            CreateIndex("dbo.Commandes", "prop_id");
            AddForeignKey("dbo.Agriculteurs", "id", "dbo.User", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Commandes", "prop_id", "dbo.Agriculteurs", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Commandes", "prop_id", "dbo.Agriculteurs");
            DropForeignKey("dbo.Agriculteurs", "id", "dbo.User");
            DropIndex("dbo.Commandes", new[] { "prop_id" });
            DropIndex("dbo.Agriculteurs", new[] { "id" });
            DropPrimaryKey("dbo.Agriculteurs");
            AlterColumn("dbo.Commandes", "prop_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Agriculteurs", "id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Agriculteurs", "id");
            CreateIndex("dbo.Commandes", "prop_id");
            CreateIndex("dbo.Agriculteurs", "id");
            AddForeignKey("dbo.Commandes", "prop_id", "dbo.Agriculteurs", "id");
            AddForeignKey("dbo.Agriculteurs", "id", "dbo.Utilisateurs", "UtilisateurID", cascadeDelete: true);
        }
    }
}
