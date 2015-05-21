using BlogEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDAL.Interfaces
{
    public interface IContentDA
    {
        #region CRUD Methods

        bool Delete(int id);
        Content GetByID(int id);
        IEnumerable<Content> GetAll();
        Content Save(Content content);

        #endregion

        List<Content> GetByPostId(int postId);

        bool DeleteByPostId(int postId);
    }
}
