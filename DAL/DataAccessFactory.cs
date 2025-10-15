using DAL.EF.Tables;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<User, int, bool> UserData()
        {
            return new UserRepo();
        }

        public static IAuth AuthData()
        {
            return new UserRepo();
        }

        public static IRepo<Movie, int, bool> MovieData()
        {
            return new MovieRepo();
        }

        public static IRepo<Showtime, int, bool> ShowtimeData()
        {
            return new ShowtimeRepo();
        }

        public static IRepo<Ticket, int, bool> TicketData()
        {
            return new TicketRepo();
        }

        public static IRepo<Payment, int, bool> PaymentData()
        {
            return new PaymentRepo();
        }

        public static IRepo<Token, string, Token> TokenData()
        {
            return new TokenRepo();
        }
    }
}
