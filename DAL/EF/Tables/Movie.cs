using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }  
        public string Genre { get; set; }   
        public int DurationMinutes { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Language { get; set; }
        public decimal BasePrice { get; set; }

        public virtual ICollection<Showtime> Showtimes { get; set; }
        public Movie()
        {
            Showtimes = new List<Showtime>();
        }

    }
}
