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
    internal class UserRepo : IRepo<User, int, bool>, IAuth
    {
        MovieTicketContext db;
        internal UserRepo()
        {
            db = new MovieTicketContext();
        }

        public User Authenticate(string username, string password)
        {
            var user = (from u in db.Users
                        where u.Name.Equals(username)
                        && u.Password.Equals(password)
                        select u).SingleOrDefault();
            return user;
        }

        public bool Create(User obj)
        {
            db.Users.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = db.Users.Find(id);
            if (data == null) return false;
            db.Users.Remove(data);
            return db.SaveChanges() > 0; ;
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public bool Update(User obj)
        {
            var existing = db.Users.Find(obj.ID);
            if (existing == null) return false;
            db.Entry(existing).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
