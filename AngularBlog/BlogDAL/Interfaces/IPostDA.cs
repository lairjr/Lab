using BlogEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDAL.Interfaces
{
    public interface IPostDA
    {
        #region CRUD Methods

        bool Delete(int id);
        Post GetByID(int id);
        IEnumerable<Post> GetAll();
        Post Save(Post post);

        #endregion

        IEnumerable<Post> GetAllBySearchString(string searchString, int languageId, int currentPage, int totalRecords);

        int GetCountBySearchString(string searchString, int languageId);
        
        IEnumerable<Post> GetAllByLanguageId(int languageId, int currentPage, int totalRecords);

        int GetCountByLanguageId(int languageId);
    }
}
