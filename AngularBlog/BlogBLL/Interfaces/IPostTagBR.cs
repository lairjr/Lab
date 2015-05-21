using BlogEntities.Entities;
using BlogEntities.ViewModels.ReceiveViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBLL.Interfaces
{
    public interface IPostTagBR
    {
        #region CRUD Methods

        bool Delete(int id);
        bool Insert(PostTagVM postTagVM);

        #endregion

        bool DeleteByPostId(int postId);

        List<PostTag> GetByPostId(int postId, bool eagerLoad);
    }
}
