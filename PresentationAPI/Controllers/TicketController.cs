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
    [RoutePrefix("api/ticket")]
    [EnableCors("*", "*", "*")]
    public class TicketController : ApiController
    {
        [Logged]
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = TicketService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Logged]
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(TicketDTO ticket)
        {
            var data = TicketService.Create(ticket);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Logged]
        [HttpGet]
        [Route("confirm/{id}")]
        public HttpResponseMessage Confirm(int id)
        {
            var data = TicketService.ConfirmPayment(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Logged]
        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var data = TicketService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
