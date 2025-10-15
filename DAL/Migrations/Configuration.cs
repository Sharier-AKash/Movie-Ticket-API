namespace DAL.Migrations
{
    using DAL.EF.Tables;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.MovieTicketContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.EF.MovieTicketContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            for (int i = 1; i <= 10; i++)
            {
                context.Users.AddOrUpdate(u => u.ID, new User
                {
                    ID = i,
                    Name = "User" + i,
                    Email = $"user{i}@mail.com",
                    Password = "123",
                    Role = (i == 1 ? "Admin" : "Customer")
                });
            }

            for (int i = 1; i <= 10; i++)
            {
                context.Movies.AddOrUpdate(m => m.ID, new Movie
                {
                    ID = i,
                    Title = "Movie " + i,
                    Genre = (i % 2 == 0 ? "Action" : "Drama"),
                    DurationMinutes = 120 + i,
                    ReleaseDate = DateTime.Now.AddDays(-i * 5),
                    Language = "English",
                    BasePrice = 300 + (i * 20)
                });
            }


            for (int i = 1; i <= 10; i++)
            {
                context.Showtimes.AddOrUpdate(s => s.ID, new Showtime
                {
                    ID = i,
                    MovieID = i,
                    ShowDateTime = DateTime.Now.AddDays(i),
                    HallName = "Hall " + i
                });
            }


            for (int i = 1; i <= 10; i++)
            {
                context.Tickets.AddOrUpdate(t => t.ID, new Ticket
                {
                    ID = i,
                    SeatNumber = "A" + i,
                    Price = 350 + (i * 10),
                    Status = "Booked",
                    ReservedAt = DateTime.Now,
                    UserID = i,
                    ShowtimeID = i
                });
            }

            for (int i = 1; i <= 10; i++)
            {
                context.Payments.AddOrUpdate(p => p.ID, new Payment
                {
                    ID = i,
                    Amount = 350 + (i * 10),
                    PaymentDate = DateTime.Now,
                    PaymentMethod = (i%2 ==0 ? "Card":"Cash"),
                    TicketID = i
                });
            }


        }
    }
}
