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
    internal class PaymentRepo : IRepo<Payment, int, bool>
    {
        MovieTicketContext db;
        internal PaymentRepo()
        {
            db = new MovieTicketContext();
        }

        public bool Create(Payment obj)
        {
            var ticket = db.Tickets.Find(obj.ID);
            if (ticket == null) return false;
            db.Payments.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = db.Payments.Find(id);
            if (data == null) return false;
            db.Payments.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<Payment> Get()
        {
            return db.Payments.ToList();
        }

        public Payment Get(int id)
        {
            return db.Payments.Find(id);
        }

        public bool Update(Payment obj)
        {
            var data = db.Payments.Find(obj.ID);
            if (data == null) return false;
            db.Entry(data).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
