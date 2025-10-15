namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Showtimes", new[] { "MovieId" });
            DropIndex("dbo.Tickets", new[] { "UserId" });
            DropIndex("dbo.Tickets", new[] { "ShowtimeId" });
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ExpiredAt = c.DateTime(),
                        UId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UId, cascadeDelete: true)
                .Index(t => t.UId);
            
            AddColumn("dbo.Showtimes", "ShowDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Payments", "PaymentMethod", c => c.String());
            AddColumn("dbo.Users", "Password", c => c.String());
            CreateIndex("dbo.Showtimes", "MovieID");
            CreateIndex("dbo.Tickets", "UserID");
            CreateIndex("dbo.Tickets", "ShowtimeID");
            DropColumn("dbo.Showtimes", "StartAt");
            DropColumn("dbo.Payments", "Method");
            DropColumn("dbo.Users", "PasswordHash");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "PasswordHash", c => c.String());
            AddColumn("dbo.Payments", "Method", c => c.String());
            AddColumn("dbo.Showtimes", "StartAt", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Tokens", "UId", "dbo.Users");
            DropIndex("dbo.Tokens", new[] { "UId" });
            DropIndex("dbo.Tickets", new[] { "ShowtimeID" });
            DropIndex("dbo.Tickets", new[] { "UserID" });
            DropIndex("dbo.Showtimes", new[] { "MovieID" });
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Payments", "PaymentMethod");
            DropColumn("dbo.Showtimes", "ShowDateTime");
            DropTable("dbo.Tokens");
            CreateIndex("dbo.Tickets", "ShowtimeId");
            CreateIndex("dbo.Tickets", "UserId");
            CreateIndex("dbo.Showtimes", "MovieId");
        }
    }
}
