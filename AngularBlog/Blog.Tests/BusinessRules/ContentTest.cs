using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlogBLL.Interfaces;
using BlogBLL;
using BlogEntities.Entities;

namespace Blog.Tests.BusinessRules
{
    [TestClass]
    public class ContentTest
    {
        private IPostBR postBr = BllFactory.CreatePostBR();
        private IContentBR contentBr = BllFactory.CreateContentBR();

        [TestMethod]
        public void BrUpdateContentOrder()
        {
            var post = postBr.GetAll().LastOrDefault();
            var contentList = contentBr.GetByPostId(post.Id, false);
            if (contentList.Count >= 5)
            {
                var firstContent = contentList.FirstOrDefault();
                contentBr.UpdateContentOrder(firstContent.Id, contentList.Count);
                var lastContent = contentList.LastOrDefault();
                contentBr.UpdateContentOrder(lastContent.Id, 3);
            }

            contentList = contentBr.GetByPostId(post.Id, false);
            int order = 1;
            foreach (var content in contentList) 
            {
                Assert.AreEqual(content.Order, order);
                order++;
            }
        }
    }
}
