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
    [RoutePrefix("api/movie")]
    [EnableCors("*", "*", "*")]
    public class MovieController : ApiController
    {
        [Logged]
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Get()
        {
            var data = MovieService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Logged]
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = MovieService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Logged]
        [HttpGet]
        [Route("search")]
        public HttpResponseMessage Search(string keyword = "", string genre = "", string language = "")
        {
            var data = MovieService.Search(keyword, genre, language);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Logged]
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(MovieDTO movie)
        {
            var data = MovieService.Create(movie);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Logged]
        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(MovieDTO movie)
        {
            var data = MovieService.Update(movie);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Logged]
        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var data = MovieService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
