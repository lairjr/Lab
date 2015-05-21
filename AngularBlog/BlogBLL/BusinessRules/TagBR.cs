using BlogBLL.Interfaces;
using BlogDAL;
using BlogDAL.Interfaces;
using BlogEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BlogBLL.BusinessRules
{
    internal class TagBR : ITagBR
    {
        private ITagDA tagDa = DalFactory.CreateTagDA();
        private IPostDA postDa = DalFactory.CreatePostDA();

        #region CRUD Methods

        public bool Delete(int id)
        {
            return tagDa.Delete(id);
        }

        public Tag GetByID(int id)
        {
            return tagDa.GetByID(id);
        }

        public IEnumerable<Tag> GetAll()
        {
            return tagDa.GetAll();
        }

        public Tag Save(Tag tag)
        {
            return tagDa.Save(tag);
        }

        #endregion

        public IEnumerable<Tag> GetByPostId(int postId)
        {
            return tagDa.GetByPostId(postId);
        }

        public IEnumerable<Tag> GetByLanguageId(int languageId)
        {
            return tagDa.GetByLanguageId(languageId);
        }
    }
}
