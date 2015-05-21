using BlogEntities.Entities;
using BlogEntities.ViewModels.ReceiveViewModels;
using BlogEntities.ViewModels.ReturnViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBLL.Interfaces
{
    public interface IPostBR
    {
        #region CRUD Methods

        bool Delete(int id);
        Post GetByID(int id);
        IEnumerable<Post> GetAll();
        Post Save(Post post);

        #endregion

        PostListVM GetAllByLanguageId(int languageId, int currentPage);

        PostListVM GetAllBySearchString(string searchString, int languageId, int currentPage);

        bool AddTextContent(ContentTextVM contentText);

        bool AddVideoContent(ContentVideoVM contentVideo);

        bool RemoveContent(int contentId);
    }
}
