using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlogBLL.Interfaces;
using BlogBLL;
using BlogEntities.Entities;

namespace Blog.Tests.BusinessRules
{
    [TestClass]
    public class TagTest
    {
        private ITagBR tagBr = BllFactory.CreateTagBR();

        #region CRUD Tests

        [TestMethod]
        public void BrAddTag()
        {
            var tag = new Tag()
            {
                Name = "Test Tag"
            };
            var savedTag = tagBr.Save(tag);
            tag.Id = savedTag.Id;
            Assert.AreEqual(tag, savedTag);
        }

        [TestMethod]
        public void BrUpdateTag()
        {
            var tag = tagBr.GetAll().LastOrDefault();
            var ramdom = new Random();
            tag.Name = "Updated " + ramdom.Next(1000).ToString();
            var savedTag = tagBr.Save(tag);
            Assert.AreEqual(tag, savedTag);
        }

        [TestMethod]
        public void BrDeletePost()
        {
            var tag = tagBr.GetAll().LastOrDefault();
            var success = tagBr.Delete(tag.Id);
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void BrGetTagById()
        {
            var tag = tagBr.GetAll().LastOrDefault();
            var tagId = tagBr.GetByID(tag.Id);
            Assert.AreEqual(tag, tagId);
        }

        #endregion
    }
}
