using BlogBLL;
using BlogBLL.Interfaces;
using BlogEntities.Entities;
using BlogEntities.ViewModels.ReceiveViewModels;
using BlogApi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogApi.Controllers
{
    public class PostTagController : BaseController
    {
        private IPostTagBR postTagBr = BllFactory.CreatePostTagBR();

        public HttpResponseMessage Delete(int id)
        {
            var success = postTagBr.Delete(id);
            return CreateResponse(success);
        }

        [LanguageResolver]
        public HttpResponseMessage Post(PostTagVM tag)
        {
            tag.LanguageId = base.Language.Id;
            var success = postTagBr.Insert(tag);
            return CreateResponse(success);
        }
    }
}
