using BlogEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDAL.Interfaces
{
    public interface IContentVideoDA
    {
        #region CRUD Methods

        bool Delete(int id);
        ContentVideo GetByID(int id);
        IEnumerable<ContentVideo> GetAll();
        ContentVideo Save(ContentVideo contentVideo);

        #endregion
    }
}
