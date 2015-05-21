using BlogEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDAL.Interfaces
{
    public interface IContentTypeDA
    {
        #region CRUD Methods

        bool Delete(int id);
        ContentType GetByID(int id);
        IEnumerable<ContentType> GetAll();
        ContentType Save(ContentType contentType);

        #endregion
    }
}
