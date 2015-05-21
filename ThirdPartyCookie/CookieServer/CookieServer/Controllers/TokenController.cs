using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CookieServer.Controllers
{
    [EnableCors("*", "*", "*")]
    public class TokenController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var response = new HttpResponseMessage();

            var cookie = new CookieHeaderValue("token", DateTime.Now.ToString());
            //cookie.Expires = DateTime.Now.AddDays(1);
            cookie.Domain = "chrome-extension://fdmmgilgnpjigdojojpjoooidkmcomcm/";
            //cookie.Path = "/";

            response.Headers.AddCookies(new CookieHeaderValue[] { cookie });
            return response;
        }
    }
}
