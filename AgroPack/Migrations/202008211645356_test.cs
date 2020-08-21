namespace AgroPack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Produits", "AgriculteurId");
            CreateIndex("dbo.Produits", "idChamps");
            CreateIndex("dbo.Produits", "categorieId");
            AddForeignKey("dbo.Produits", "AgriculteurId", "dbo.Agriculteurs", "AgriculteurId");
            AddForeignKey("dbo.Produits", "categorieId", "dbo.Categorie", "Id");
            AddForeignKey("dbo.Produits", "idChamps", "dbo.Champs", "ChampId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produits", "idChamps", "dbo.Champs");
            DropForeignKey("dbo.Produits", "categorieId", "dbo.Categorie");
            DropForeignKey("dbo.Produits", "AgriculteurId", "dbo.Agriculteurs");
            DropIndex("dbo.Produits", new[] { "categorieId" });
            DropIndex("dbo.Produits", new[] { "idChamps" });
            DropIndex("dbo.Produits", new[] { "AgriculteurId" });
        }
    }
}
