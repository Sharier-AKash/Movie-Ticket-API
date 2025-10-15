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
    [RoutePrefix("api/user")]
    [EnableCors("*", "*", "*")]
    public class UserController : ApiController
    {
        [Logged]
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAll()
        {
            var data = UserService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Logged]
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = UserService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(UserDTO user)
        {
            var data = UserService.Create(user);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Logged]
        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(UserDTO user)
        {
            var data = UserService.Update(user);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Logged]
        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var data = UserService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
