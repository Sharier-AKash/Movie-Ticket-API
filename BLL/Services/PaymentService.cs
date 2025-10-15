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
    public class PaymentService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Payment, PaymentDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public static List<PaymentDTO> Get()
        {
            var data = DataAccessFactory.PaymentData().Get();
            return GetMapper().Map<List<PaymentDTO>>(data);
        }

        public static PaymentDTO Get(int id)
        {
            var data = DataAccessFactory.PaymentData().Get(id);
            return GetMapper().Map<PaymentDTO>(data);
        }

        public static bool Create(PaymentDTO payment)
        {
            var data = GetMapper().Map<Payment>(payment);
            return DataAccessFactory.PaymentData().Create(data);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.PaymentData().Delete(id);
        }

        public static decimal CalculateFinalAmount(decimal basePrice, string method)
        {
            decimal final = basePrice;
            if (method == "Card") final *= 1.02M;
            if (method == "Mobile") final *= 1.01M;
            return final;
        }

        public static object GetSummaryReport()
        {
            var payments = DataAccessFactory.PaymentData().Get();
            var total = payments.Sum(p => p.Amount);
            var count = payments.Count;
            return new { TotalRevenue = total, TotalTransactions = count };
        }
    }
}
