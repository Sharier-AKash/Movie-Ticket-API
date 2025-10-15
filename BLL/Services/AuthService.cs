using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Token, TokenDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public static TokenDTO Authenticate(string uname, string pass)
        {
            var user = DataAccessFactory.AuthData().Authenticate(uname, pass);
            if (user != null)
            {
                var token = new Token()
                {
                    Key = Guid.NewGuid().ToString(),
                    CreatedAt = DateTime.Now,
                    ExpiredAt = null,
                    UId = user.ID
                };
                var ret = DataAccessFactory.TokenData().Create(token);
                return GetMapper().Map<TokenDTO>(ret);
            }
            return null;
        }
        public static bool IsTokenValid(string tk)
        {
            var token = DataAccessFactory.TokenData().Get(tk);
            return (token != null && token.ExpiredAt == null);
        }

        public static bool Logout(string tk)
        {
            var token = DataAccessFactory.TokenData().Get(tk);
            if (token != null)
            {
                token.ExpiredAt = DateTime.Now;
                DataAccessFactory.TokenData().Update(token);
                return true;
            }
            return false;
        }
    }
}
