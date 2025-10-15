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
    public class ShowtimeService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Showtime, ShowtimeDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public static List<ShowtimeDTO> Get()
        {
            var data = DataAccessFactory.ShowtimeData().Get();
            return GetMapper().Map<List<ShowtimeDTO>>(data);
        }

        public static ShowtimeDTO Get(int id)
        {
            var data = DataAccessFactory.ShowtimeData().Get(id);
            return GetMapper().Map<ShowtimeDTO>(data);
        }

        public static bool Create(ShowtimeDTO showtime)
        {
            var data = GetMapper().Map<Showtime>(showtime);
            return DataAccessFactory.ShowtimeData().Create(data);
        }

        public static bool Update(ShowtimeDTO showtime)
        {
            var data = GetMapper().Map<Showtime>(showtime);
            return DataAccessFactory.ShowtimeData().Update(data);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.ShowtimeData().Delete(id);
        }
    }
}
