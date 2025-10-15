using DAL.EF;
using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TicketRepo : IRepo<Ticket, int, bool>
    {
        MovieTicketContext db;
        internal TicketRepo()
        {
            db = new MovieTicketContext();
        }

        public bool Create(Ticket obj)
        {
            db.Tickets.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = db.Tickets.Find(id);
            db.Tickets.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<Ticket> Get()
        {
            return db.Tickets.ToList();
        }

        public Ticket Get(int id)
        {
            return db.Tickets.Find(id);
        }

        public bool Update(Ticket obj)
        {
            var data = db.Tickets.Find(obj.ID);
            db.Entry(data).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
