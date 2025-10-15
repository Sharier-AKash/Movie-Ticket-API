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
    internal class ShowtimeRepo : IRepo<Showtime, int, bool>
    {
        MovieTicketContext db;
        internal ShowtimeRepo()
        {
            db = new MovieTicketContext();
        }

        public bool Create(Showtime obj)
        {
            db.Showtimes.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = db.Showtimes.Find(id);
            if (data == null) return false;
            db.Showtimes.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<Showtime> Get()
        {
            return db.Showtimes.ToList();
        }

        public Showtime Get(int id)
        {
            return db.Showtimes.Find(id);
        }

        public bool Update(Showtime obj)
        {
            var data = db.Showtimes.Find(obj.ID);
            if (data == null) return false;
            db.Entry(data).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

    }
}
