using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Showtime
    {
        public int ID { get; set; }
        public DateTime ShowDateTime { get; set; }
        public string HallName { get; set; }

        [ForeignKey("Movie")]
        public int MovieID { get; set; }
        public virtual Movie Movie { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
        public Showtime()
        {
            Tickets = new List<Ticket>();
        }
    }
}
