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
            AddColumn("dbo.Agriculteurs", "User_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Agriculteurs", "User_Id");
            AddForeignKey("dbo.Agriculteurs", "User_Id", "dbo.User", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agriculteurs", "User_Id", "dbo.User");
            DropIndex("dbo.Agriculteurs", new[] { "User_Id" });
            DropColumn("dbo.Agriculteurs", "User_Id");
            CreateIndex("dbo.Agriculteurs", "id");
            AddForeignKey("dbo.Agriculteurs", "id", "dbo.Utilisateurs", "UtilisateurID", cascadeDelete: true);
        }
    }
}
