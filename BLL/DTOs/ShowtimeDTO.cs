using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ShowtimeDTO
    {
        public int ID { get; set; }
        public DateTime ShowDateTime { get; set; }
        public string HallName { get; set; }
        public int MovieID { get; set; }
    }
}
