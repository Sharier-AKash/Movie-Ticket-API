using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Ticket
    {
        public int ID { get; set; }
        public string SeatNumber { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }  
        public DateTime ReservedAt { get; set; } 

        [ForeignKey("User")]
        public int UserID { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Showtime")]
        public int ShowtimeID { get; set; }
        public virtual Showtime Showtime { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
        public Ticket()
        {
            Payments = new List<Payment>();
        }
    }
}
