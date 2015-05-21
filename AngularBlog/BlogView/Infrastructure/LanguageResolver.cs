using BlogBLL;
using BlogBLL.Interfaces;
using BlogApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace BlogApi.Infrastructure
{
    public class LanguageResolver : ActionFilterAttribute
    {
        private ILanguageBR languageBr = BllFactory.CreateLanguageBR();

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            //TODO: Think something to get the value
            //var prefferedLanguage = actionContext.Request.Headers.GetValues("PrefferedLanguage");
            var prefferedLanguage = "en-US";
            var controller = (BaseController)actionContext.ControllerContext.Controller;
            //controller.Language = languageBr.GetByLanguageCode(prefferedLanguage);
            controller.Language = new BlogEntities.Entities.Language()
            {
                Id = 1,
                LanguageCode = prefferedLanguage
            };
            base.OnActionExecuting(actionContext);
        }
    }
}