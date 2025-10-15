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
    [RoutePrefix("api/showtime")]
    [EnableCors("*", "*", "*")]
    public class ShowtimeController : ApiController
    {
        [Logged]
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Get()
        {
            var data = ShowtimeService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Logged]
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(ShowtimeDTO show)
        {
            var data = ShowtimeService.Create(show);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Logged]
        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(ShowtimeDTO show)
        {
            var data = ShowtimeService.Update(show);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Logged]
        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var data = ShowtimeService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
