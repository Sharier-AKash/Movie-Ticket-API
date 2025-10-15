using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TicketDTO
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ShowtimeID { get; set; }
        public string SeatNumber { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public DateTime ReservedAt { get; set; }
    }
}
