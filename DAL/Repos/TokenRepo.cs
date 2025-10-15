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
    internal class TokenRepo : IRepo<Token, string, Token>
    {
        MovieTicketContext db;
        internal TokenRepo()
        {
            db = new MovieTicketContext();
        }

        public Token Create(Token obj)
        {
            db.Tokens.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(string id)
        {
            var data = db.Tokens.FirstOrDefault(t => t.Key.Equals(id));
            if (data == null) return false;
            db.Tokens.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<Token> Get()
        {
            return db.Tokens.ToList();
        }

        public Token Get(string id)
        {
            return db.Tokens.FirstOrDefault(t =>t.Key.Equals(id));
        }

        public Token Update(Token obj)
        {
            throw new NotImplementedException();
        }
    }
}
