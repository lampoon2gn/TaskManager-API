namespace WebApiPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class debug1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Quotes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Quotes", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Quotes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Quotes",
                c => new
                    {
                        QuoteID = c.String(nullable: false, maxLength: 128),
                        QuoteType = c.String(),
                        Contact = c.String(),
                        Task = c.String(),
                        DueDate = c.String(),
                        TaskType = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.QuoteID);
            
            CreateIndex("dbo.Quotes", "ApplicationUser_Id");
            AddForeignKey("dbo.Quotes", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
