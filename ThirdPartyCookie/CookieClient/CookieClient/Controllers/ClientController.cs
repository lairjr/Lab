using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CookieClient.Controllers
{
    public class ClientController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var response = new HttpResponseMessage();
            response.Content = new StringContent(string.Empty);
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }
    }
}
