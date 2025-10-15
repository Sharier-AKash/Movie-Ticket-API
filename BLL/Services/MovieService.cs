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
    public class MovieService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Movie, MovieDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public static List<MovieDTO> Get()
        {
            var data = DataAccessFactory.MovieData().Get();
            return GetMapper().Map<List<MovieDTO>>(data);
        }

        public static MovieDTO Get(int id)
        {
            var data = DataAccessFactory.MovieData().Get(id);
            return GetMapper().Map<MovieDTO>(data);
        }

        public static bool Create(MovieDTO movie)
        {
            var data = GetMapper().Map<Movie>(movie);
            return DataAccessFactory.MovieData().Create(data);
        }

        public static bool Update(MovieDTO movie)
        {
            var data = GetMapper().Map<Movie>(movie);
            return DataAccessFactory.MovieData().Update(data);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.MovieData().Delete(id);
        }

        public static List<MovieDTO> Search(string keyword, string genre, string language)
        {
            var movies = DataAccessFactory.MovieData().Get();
            var result = movies.Where(m =>
                (string.IsNullOrEmpty(keyword) || m.Title.ToLower().Contains(keyword.ToLower())) &&
                (string.IsNullOrEmpty(genre) || m.Genre.ToLower() == genre.ToLower()) &&
                (string.IsNullOrEmpty(language) || m.Language.ToLower() == language.ToLower())
            ).ToList();
            return GetMapper().Map<List<MovieDTO>>(result);
        }
    }
}
