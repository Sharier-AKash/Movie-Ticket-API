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
    public class TicketService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Ticket, TicketDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public static TicketDTO Get(int id)
        {
            var data = DataAccessFactory.TicketData().Get(id);
            return GetMapper().Map<TicketDTO>(data);
        }

        public static bool Create(TicketDTO ticket)
        {
            var data = GetMapper().Map<Ticket>(ticket);
            return DataAccessFactory.TicketData().Create(data);
        }

        public static bool Update(TicketDTO ticket)
        {
            var data = GetMapper().Map<Ticket>(ticket);
            return DataAccessFactory.TicketData().Update(data);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.TicketData().Delete(id);
        }

        public static bool ConfirmPayment(int ticketId)
        {
            var ticket = DataAccessFactory.TicketData().Get(ticketId);
            if (ticket == null) return false;

            ticket.Status = "Paid";
            return DataAccessFactory.TicketData().Update(ticket);
        }
    }
}
