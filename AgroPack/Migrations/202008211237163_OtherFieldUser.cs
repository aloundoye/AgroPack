namespace AgroPack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OtherFieldUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "LastName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.User", "FirstName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.User", "Address", c => c.String(maxLength: 100));
            AddColumn("dbo.User", "Birthday", c => c.DateTime(storeType: "date"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Birthday");
            DropColumn("dbo.User", "Address");
            DropColumn("dbo.User", "FirstName");
            DropColumn("dbo.User", "LastName");
        }
    }
}
