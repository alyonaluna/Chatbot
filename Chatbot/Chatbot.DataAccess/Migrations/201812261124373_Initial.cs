namespace Chatbot.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Facts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Question = c.String(),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Facts");
        }
    }
}
