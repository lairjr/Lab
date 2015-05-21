using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlogBLL.Interfaces;
using BlogBLL;
using BlogEntities.Entities;
using BlogEntities.ViewModels.ReceiveViewModels;

namespace Blog.Tests.BusinessRules
{
    [TestClass]
    public class PostTests
    {
        private IPostBR postBr = BllFactory.CreatePostBR();
        private ILanguageBR languageBr = BllFactory.CreateLanguageBR();
        private ITagBR tagBr = BllFactory.CreateTagBR();
        private IContentBR contentBr = BllFactory.CreateContentBR();
        private IPostTagBR postTagBr = BllFactory.CreatePostTagBR();
        
        #region CRUD Tests

        [TestMethod]
        public void BrAddPost()
        {
            var post = new Post()
            {
                Title = "Test Post",
                Description = "Test Description",
                Language = languageBr.GetAll().FirstOrDefault()
            };
            var savedPost = postBr.Save(post);
            post.Id = savedPost.Id;
            Assert.AreEqual(post, savedPost);
        }

        [TestMethod]
        public void BrUpdatePost()
        {
            var post = postBr.GetAll().LastOrDefault();
            var ramdom = new Random();
            post.Title = "Updated " + ramdom.Next(1000).ToString();
            var savedPost = postBr.Save(post);
            Assert.AreEqual(post, savedPost);
        }
        
        [TestMethod]
        public void BrDeletePost()
        {
            var post = postBr.GetAll().LastOrDefault();
            var success = postBr.Delete(post.Id);
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void BrGetPostById()
        {
            var post = postBr.GetAll().LastOrDefault();
            var postReturned = postBr.GetByID(post.Id);
            Assert.AreEqual(post, postReturned);
        }

        #endregion

        [TestMethod]
        public void BrGetAllByLanguageIdPost()
        {
            var language = languageBr.GetAll().FirstOrDefault();
            var languageId = language.Id;
            var postListReturn = postBr.GetAllByLanguageId(language.Id, 1);
            var isAllSameLanguage = true;
            if (postListReturn != null) 
            {
                foreach (var post in postListReturn.Posts) {
                    if (post.LanguageId != languageId)
                        isAllSameLanguage = false;
                }
            }
            Assert.IsTrue(isAllSameLanguage);
        }

        [TestMethod]
        public void BrGetAllBySearchString()
        {
            var language = languageBr.GetAll().FirstOrDefault();
            var languageId = language.Id;
            var searchString = "Post";
            var postListReturn = postBr.GetAllBySearchString(searchString, language.Id, 1);
            var isAllSameString = true;
            if (postListReturn != null)
            {
                foreach (var post in postListReturn.Posts)
                {
                    if (!post.Title.Contains(searchString))
                        isAllSameString = false;
                }
            }
            Assert.IsTrue(isAllSameString);
        }

        [TestMethod]
        public void BrAddTagInPost()
        {
            var post = postBr.GetAll().LastOrDefault();
            var firstCount = tagBr.GetByPostId(post.Id).Count();

            var language = languageBr.GetAll().FirstOrDefault();
            var tag = tagBr.GetByLanguageId(language.Id).FirstOrDefault();
            
            var success = postTagBr.Insert(new PostTagVM()
            {
                PostId = post.Id,
                Tag = tag.Name,
                LanguageId = language.Id
            });

            var lastCount = tagBr.GetByPostId(post.Id).Count();
            Assert.IsTrue((firstCount + 1) == lastCount);
        }

        [TestMethod]
        public void BrRemoveTagInPost()
        {
            var language = languageBr.GetAll().FirstOrDefault();

            
            var post = postBr.GetAllByLanguageId(language.Id, 1).Posts.LastOrDefault();
            var postTagList = postTagBr.GetByPostId(post.Id, false);
            var firstCount = postTagList.Count();

            var postTag = postTagList.LastOrDefault();

            var success = postTagBr.Delete(postTag.Id);

            var lastCount = tagBr.GetByPostId(post.Id).Count();
            Assert.IsTrue((firstCount - 1) == lastCount);
        }

        [TestMethod]
        public void BrAddTextContent()
        {
            var post = postBr.GetAll().LastOrDefault();
            var textContent = new ContentTextVM()
            {
                PostId = post.Id,
                Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
            };
            postBr.AddTextContent(textContent);
        }

        [TestMethod]
        public void BrRemoveContent()
        {
            var post = postBr.GetAll().LastOrDefault();
            var contentPostList = contentBr.GetByPostId(post.Id, false);
            var contentId = 0;
            if (contentPostList.Count > 2)
            {
                contentId = contentPostList.Skip(1).FirstOrDefault().Id;
            }
            else
            {
                contentId = contentPostList.FirstOrDefault().Id;
            }
            var success = postBr.RemoveContent(contentId);
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void BrAddVideoContent()
        {
            var post = postBr.GetAll().LastOrDefault();
            var textContent = new ContentVideoVM()
            {
                PostId = post.Id,
                YoutubeCode = "XADES1234YASP"
            };
            postBr.AddVideoContent(textContent);
        }
    }
}
