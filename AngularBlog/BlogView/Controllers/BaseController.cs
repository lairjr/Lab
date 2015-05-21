using BlogEntities.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogApi.Controllers
{
    public class BaseController : ApiController
    {
        public Language Language { get; set; }

        [NonAction]
        public HttpResponseMessage CreateResponse()
        {
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }

        [NonAction]
        public HttpResponseMessage CreateResponse(object obj)
        {
            return CreateResponse(obj, (obj != null) ? HttpStatusCode.OK : HttpStatusCode.NotFound);
        }

        [NonAction]
        public HttpResponseMessage CreateResponse(HttpStatusCode statusCode)
        {
            return CreateResponse(null, statusCode);
        }

        [NonAction]
        public HttpResponseMessage CreateResponse(object obj, HttpStatusCode statusCode)
        {
            var response = new HttpResponseMessage();
            response.Content = new StringContent(JsonConvert.SerializeObject(obj));
            response.StatusCode = statusCode;
            return response;
        }
    }
}
