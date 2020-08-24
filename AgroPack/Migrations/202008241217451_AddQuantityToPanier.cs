namespace AgroPack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuantityToPanier : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Panier", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Panier", "Quantity");
        }
    }
}
