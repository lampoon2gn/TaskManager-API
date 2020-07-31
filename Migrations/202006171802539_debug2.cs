namespace WebApiPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class debug2 : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.QuoteID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Quotes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Quotes", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Quotes");
        }
    }
}
