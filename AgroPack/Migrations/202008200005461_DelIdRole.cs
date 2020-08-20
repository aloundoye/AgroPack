namespace AgroPack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DelIdRole : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Utilisateurs", "idRole");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Utilisateurs", "idRole", c => c.Int());
        }
    }
}
