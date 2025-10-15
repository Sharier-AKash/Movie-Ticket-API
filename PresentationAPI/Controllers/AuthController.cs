using BLL.Services;
using PresentationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PresentationAPI.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("login")]
        public HttpResponseMessage Login(Login login)
        {
            var res = AuthService.Authenticate(login.Username, login.Password);
            if (res != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized, "Username password invalid");
        }


        [HttpPost]
        [Route("logout/{key}")]
        public HttpResponseMessage Logout(string key)
        {
            var res = AuthService.Logout(key);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }
    }
}
