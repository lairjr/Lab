using BlogDAL.Interfaces;
using BlogEntities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDAL.DataAccess
{
    internal class ContentTypeDA : IContentTypeDA
    {
        private IDbEntities _db;

        public ContentTypeDA(IDbEntities db)
        {
            _db = db;
        }

        #region CRUD Methods

        public bool Delete(int id)
        {
            try
            {
                var contentType = _db.ContentTypes.FirstOrDefault(ct => ct.Id == id);
                _db.ContentTypes.Remove(contentType);
                _db.Save(contentType, EntityState.Deleted);
                return true;
            }
            catch
            {
                throw;
            }
        }

        public ContentType GetByID(int id)
        {
            try
            {
                return _db.ContentTypes.FirstOrDefault(ct => ct.Id == id);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<ContentType> GetAll()
        {
            try
            {
                return _db.ContentTypes.ToList();
            }
            catch
            {
                throw;
            }
        }

        public ContentType Save(ContentType contentType)
        {
            if (contentType.Id != 0)
            {
                return Update(contentType);
            }
            else
            {
                return Insert(contentType);
            }
        }

        private ContentType Insert(ContentType contentType)
        {
            try
            {
                _db.ContentTypes.Add(contentType);
                _db.Save(contentType, EntityState.Added);
                return contentType;
            }
            catch
            {
                throw;
            }
        }

        private ContentType Update(ContentType contentType)
        {
            try
            {
                _db.ContentTypes.Attach(contentType);
                _db.Save(contentType, EntityState.Modified);
                return contentType;
            }
            catch
            {
                throw;
            }
        }

        #endregion
    }
}
