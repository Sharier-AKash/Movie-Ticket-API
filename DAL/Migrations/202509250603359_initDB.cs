namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Genre = c.String(),
                        DurationMinutes = c.Int(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        Language = c.String(),
                        BasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Showtimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartAt = c.DateTime(nullable: false),
                        HallName = c.String(),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeatNumber = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.String(),
                        ReservedAt = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        ShowtimeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Showtimes", t => t.ShowtimeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ShowtimeId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Method = c.String(),
                        PaymentDate = c.DateTime(nullable: false),
                        TicketId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.TicketId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        PasswordHash = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "UserId", "dbo.Users");
            DropForeignKey("dbo.Tickets", "ShowtimeId", "dbo.Showtimes");
            DropForeignKey("dbo.Payments", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.Showtimes", "MovieId", "dbo.Movies");
            DropIndex("dbo.Payments", new[] { "TicketId" });
            DropIndex("dbo.Tickets", new[] { "ShowtimeId" });
            DropIndex("dbo.Tickets", new[] { "UserId" });
            DropIndex("dbo.Showtimes", new[] { "MovieId" });
            DropTable("dbo.Users");
            DropTable("dbo.Payments");
            DropTable("dbo.Tickets");
            DropTable("dbo.Showtimes");
            DropTable("dbo.Movies");
        }
    }
}
