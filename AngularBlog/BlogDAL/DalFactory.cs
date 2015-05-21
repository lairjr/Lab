using BlogDAL.DataAccess;
using BlogDAL.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDAL
{
    public class DalFactory 
    {
        public static IPostDA CreatePostDA()
        {
            var kernel = new StandardKernel(new NinjectConfig());
            return new PostDA(kernel.Get<IDbEntities>());
        }

        public static ITagDA CreateTagDA()
        {
            var kernel = new StandardKernel(new NinjectConfig());
            return new TagDA(kernel.Get<IDbEntities>());
        }

        public static IPostTagDA CreatePostTagDA()
        {
            var kernel = new StandardKernel(new NinjectConfig());
            return new PostTagDA(kernel.Get<IDbEntities>());
        }

        public static ILanguageDA CreateLanguageDA()
        {
            var kernel = new StandardKernel(new NinjectConfig());
            return new LanguageDA(kernel.Get<IDbEntities>());
        }

        public static IContentDA CreateContentDA()
        {
            var kernel = new StandardKernel(new NinjectConfig());
            return new ContentDA(kernel.Get<IDbEntities>());
        }

        public static IContentTypeDA CreateContentTypeDA()
        {
            var kernel = new StandardKernel(new NinjectConfig());
            return new ContentTypeDA(kernel.Get<IDbEntities>());
        }

        public static IContentTextDA CreateContentTextDA()
        {
            var kernel = new StandardKernel(new NinjectConfig());
            return new ContentTextDA(kernel.Get<IDbEntities>());
        }

        public static IContentVideoDA CreateContentVideoDA()
        {
            var kernel = new StandardKernel(new NinjectConfig());
            return new ContentVideoDA(kernel.Get<IDbEntities>());
        }
    }
}
