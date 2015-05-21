using BlogBLL.Interfaces;
using BlogEntities.ViewModels.ReceiveViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogApi.Controllers
{
    public class ContentController : BaseController
    {
        private IContentBR contentBr;

        public ContentController(IContentBR contentBr)
        {
            this.contentBr = contentBr;
        }

        public HttpResponseMessage Post(ContentTextVM contentTextVM)
        {
            var sucess = contentBr.AddTextContent(contentTextVM);
            if (sucess)
            {
                return CreateResponse();
            }
            else
            {
                return CreateResponse(HttpStatusCode.NotFound);
            }
        }
    }
}
