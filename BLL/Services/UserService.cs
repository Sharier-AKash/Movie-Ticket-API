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
    public class UserService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public static List<UserDTO> Get()
        {
            var data = DataAccessFactory.UserData().Get();
            return GetMapper().Map<List<UserDTO>>(data);
        }

        public static UserDTO Get(int id)
        {
            var data = DataAccessFactory.UserData().Get(id);
            return GetMapper().Map<UserDTO>(data);
        }

        public static bool Create(UserDTO user)
        {
            var data = GetMapper().Map<User>(user);
            return DataAccessFactory.UserData().Create(data);
        }

        public static bool Update(UserDTO user)
        {
            var data = GetMapper().Map<User>(user);
            return DataAccessFactory.UserData().Update(data);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.UserData().Delete(id);
        }

        public static UserDTO Authenticate(string username, string password)
        {
            var user = DataAccessFactory.AuthData().Authenticate(username, password);
            if (user != null)
            {
                return GetMapper().Map<UserDTO>(user);
            }
            return null;
        }
    }
}
