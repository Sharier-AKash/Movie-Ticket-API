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
    internal class MovieRepo : IRepo<Movie, int, bool>
    {
        MovieTicketContext db;
        internal MovieRepo()
        {
            db = new MovieTicketContext();
        }

        public bool Create(Movie obj)
        {
            db.Movies.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var m = db.Movies.Find(id);
            if (m == null) return false;
            db.Movies.Remove(m);
            return db.SaveChanges() > 0;
        }

        public List<Movie> Get()
        {
            return db.Movies.ToList();
        }

        public Movie Get(int id)
        {
            return db.Movies.Find(id);
        }

        public bool Update(Movie obj)
        {
            var existing = db.Movies.Find(obj.ID);
            if (existing == null) return false;
            db.Entry(existing).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
