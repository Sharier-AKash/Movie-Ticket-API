using BLL.DTOs;
using BLL.Services;
using PresentationAPI.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PresentationAPI.Controllers
{
    [RoutePrefix("api/payment")]
    [EnableCors("*", "*", "*")]
    public class PaymentController : ApiController
    {
        [Logged]
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = PaymentService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Logged]
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(PaymentDTO payment)
        {
            var data = PaymentService.Create(payment);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Logged]
        [HttpGet]
        [Route("summary")]
        public HttpResponseMessage Summary()
        {
            var data = PaymentService.GetSummaryReport();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Logged]
        [HttpGet]
        [Route("calculate")]
        public HttpResponseMessage Calculate(decimal basePrice, string method)
        {
            var data = PaymentService.CalculateFinalAmount(basePrice, method);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
