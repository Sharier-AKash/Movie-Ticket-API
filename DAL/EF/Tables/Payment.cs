using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Payment
    {

        public int ID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; } 
        public string PaymentMethod { get; set; }

        [ForeignKey("Ticket")]
        public int TicketID { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}
