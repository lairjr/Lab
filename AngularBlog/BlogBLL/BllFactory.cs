using BlogBLL.BusinessRules;
using BlogBLL.Interfaces;
using BlogDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBLL
{
    public class BllFactory
    {
        public static IPostBR CreatePostBR()
        {
            return new PostBR();
        }

        public static ITagBR CreateTagBR()
        {
            return new TagBR();
        }

        public static ILanguageBR CreateLanguageBR()
        {
            return new LanguageBR();
        }

        public static IContentBR CreateContentBR()
        {
            return new ContentBR();
        }

        public static IPostTagBR CreatePostTagBR()
        {
            return new PostTagBR();
        }
    }
}
