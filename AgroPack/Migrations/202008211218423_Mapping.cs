namespace AgroPack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mapping : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetRoles", newName: "Roles");
            RenameTable(name: "dbo.AspNetUserRoles", newName: "UserRole");
            RenameTable(name: "dbo.AspNetUsers", newName: "User");
            RenameTable(name: "dbo.AspNetUserClaims", newName: "UserClaim");
            RenameTable(name: "dbo.AspNetUserLogins", newName: "UserLogin");
            RenameColumn(table: "dbo.Roles", name: "Id", newName: "RoleId");
            RenameColumn(table: "dbo.User", name: "Id", newName: "UserId");
            RenameColumn(table: "dbo.UserClaim", name: "Id", newName: "UserClaimId");

        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.UserClaim", name: "UserClaimId", newName: "Id");
            RenameColumn(table: "dbo.User", name: "UserId", newName: "Id");
            RenameColumn(table: "dbo.Roles", name: "RoleId", newName: "Id");
            RenameTable(name: "dbo.UserLogin", newName: "AspNetUserLogins");
            RenameTable(name: "dbo.UserClaim", newName: "AspNetUserClaims");
            RenameTable(name: "dbo.User", newName: "AspNetUsers");
            RenameTable(name: "dbo.UserRole", newName: "AspNetUserRoles");
            RenameTable(name: "dbo.Roles", newName: "AspNetRoles");
        }
    }
}
