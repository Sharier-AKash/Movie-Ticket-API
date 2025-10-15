namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedData : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Payments", new[] { "TicketId" });
            CreateIndex("dbo.Payments", "TicketID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Payments", new[] { "TicketID" });
            CreateIndex("dbo.Payments", "TicketId");
        }
    }
}
