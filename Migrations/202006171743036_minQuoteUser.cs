namespace WebApiPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class minQuoteUser : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Quotes", name: "User_Id", newName: "ApplicationUser_Id");
            RenameIndex(table: "dbo.Quotes", name: "IX_User_Id", newName: "IX_ApplicationUser_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Quotes", name: "IX_ApplicationUser_Id", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Quotes", name: "ApplicationUser_Id", newName: "User_Id");
        }
    }
}
