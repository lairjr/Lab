using BlogBLL;
using BlogBLL.Interfaces;
using BlogEntities.Entities;
using BlogEntities.ViewModels.ReturnViewModels;
using BlogApi.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogApi.Controllers
{
    public class PostController : BaseController
    {
        private IPostBR postBr = BllFactory.CreatePostBR();

        public HttpResponseMessage Delete(int id)
        {
            var success = postBr.Delete(id);
            return CreateResponse(success);
        }

        [Route("api/post/list/{*currentPage}")]
        [LanguageResolver]
        public HttpResponseMessage Get(int? currentPage)
        {
            var cPage = 1;
            if (currentPage.HasValue)
            {
                if (currentPage.Value != 0)
                    cPage = currentPage.Value;
            }
            var postList = postBr.GetAllByLanguageId(base.Language.Id, cPage);
            return CreateResponse(postList);
        }

        [Route("api/post/search/{*currentPage}")]
        [LanguageResolver]
        public HttpResponseMessage GetBySearchString(string searchString, int? currentPage)
        {
            var cPage = 1;
            if (currentPage.HasValue)
            {
                if (currentPage.Value != 0)
                    cPage = currentPage.Value;
            }

            var postListReturn = new PostListVM();
            if (!string.IsNullOrEmpty(searchString))
                postListReturn = postBr.GetAllBySearchString(searchString, base.Language.Id, cPage);
            else
                postListReturn = postBr.GetAllByLanguageId(base.Language.Id, cPage);
            return CreateResponse(postListReturn);
        }

        public HttpResponseMessage Get(int id)
        {   
            var post = postBr.GetByID(id);
            return CreateResponse(post);
        }

        [LanguageResolver]
        public HttpResponseMessage Post(Post post)
        {
            post.Language = base.Language;
            var savedPost = postBr.Save(post);
            return CreateResponse(savedPost);
        }
    }
}
