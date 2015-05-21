using BlogBLL.Interfaces;
using BlogDAL;
using BlogDAL.Interfaces;
using BlogEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Transactions;
using BlogEntities.ViewModels.ReceiveViewModels;
using BlogEntities.ViewModels.ReturnViewModels;

namespace BlogBLL.BusinessRules
{
    internal class PostBR : IPostBR
    {
        private IPostDA da = DalFactory.CreatePostDA();
        private IPostTagBR postTagBr = BllFactory.CreatePostTagBR();
        private IContentBR contentBr = BllFactory.CreateContentBR();

        private int recordsByPage;

        public PostBR()
        {
            this.recordsByPage = int.Parse(System.Configuration.ConfigurationManager.AppSettings["RecordsByPage"].ToString());
        }

        #region CRUD Methods

        public bool Delete(int id)
        {
            var success = false;

            using (var scope = new TransactionScope())
            {
                success = postTagBr.DeleteByPostId(id);
                success = (success && contentBr.DeleteByPostId(id));
                success = (success && da.Delete(id));

                scope.Complete();
            }

            return success;
        }

        public Post GetByID(int id)
        {
            var post = da.GetByID(id);

            if (post != null)
            {
                post.PostTags = postTagBr.GetByPostId(id, true);
                post.Contents = contentBr.GetByPostId(id, true);
            }

            return post;
        }

        public IEnumerable<Post> GetAll()
        {
            return da.GetAll();
        }

        public Post Save(Post post)
        {
            return da.Save(post);
        }

        #endregion

        public PostListVM GetAllByLanguageId(int languageId, int currentPage)
        {
            var postListReturn = new PostListVM();

            postListReturn.IsLastPage = this.VerifyLastPage(da.GetCountByLanguageId(languageId), currentPage);
            postListReturn.Posts = da.GetAllByLanguageId(languageId, (currentPage - 1), recordsByPage);

            return postListReturn;
        }

        public PostListVM GetAllBySearchString(string searchString, int languageId, int currentPage)
        {
            var postListReturn = new PostListVM();

            postListReturn.IsLastPage = this.VerifyLastPage(da.GetCountBySearchString(searchString, languageId), currentPage);
            postListReturn.Posts = da.GetAllBySearchString(searchString, languageId, (currentPage - 1), recordsByPage);

            return postListReturn;
        }
        
        public bool RemoveContent(int contentId)
        {
            return contentBr.Delete(contentId);
        }

        public bool AddTextContent(ContentTextVM contentText)
        {
            return contentBr.AddTextContent(contentText);
        }

        public bool AddVideoContent(ContentVideoVM contentVideo)
        {
            return contentBr.AddVideoContent(contentVideo);
        }

        private bool VerifyLastPage(int totalRecordsCount, int currentPage)
        {
            var currentRecordsCount = currentPage * recordsByPage;
            var differenceCount = totalRecordsCount - currentRecordsCount;

            return (differenceCount < recordsByPage);
        }
    }
}
