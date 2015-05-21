using BlogEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDAL.Interfaces
{
    public interface IContentTextDA
    {
        #region CRUD Methods

        bool Delete(int id);
        ContentText GetByID(int id);
        IEnumerable<ContentText> GetAll();
        ContentText Save(ContentText contentText);

        #endregion
    }
}
