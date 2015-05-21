using BlogBLL;
using BlogBLL.Interfaces;
using BlogEntities.Entities;
using BlogApi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogApi.Controllers
{
    public class TagController : BaseController
    {
        private ITagBR tagBr = BllFactory.CreateTagBR();

        public bool Delete(int id)
        {
            return tagBr.Delete(id);
        }

        [LanguageResolver]
        public HttpResponseMessage Get()
        {
            var tagList = tagBr.GetByLanguageId(base.Language.Id);
            return CreateResponse(tagList);
        }

        public HttpResponseMessage Get(int id)
        {
            var tag = tagBr.GetByID(id);
            return CreateResponse(tag);
        }

        [LanguageResolver]
        public HttpResponseMessage Post(Tag tag)
        {
            tag.Language = base.Language;
            var savedTag = tagBr.Save(tag);
            return CreateResponse(savedTag);
        }
    }
}
