namespace AgroPack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCityFielUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "City", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "City");
        }
    }
}
