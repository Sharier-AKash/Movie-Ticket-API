using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class User
    {
        public int ID { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<Token> Tokens { get; set; }

        public User()
        {
            Tickets = new List<Ticket>();
            Tokens = new List<Token>();
        }
    }
}
