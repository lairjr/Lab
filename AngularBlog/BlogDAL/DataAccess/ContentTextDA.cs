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
    internal class ContentTextDA : IContentTextDA
    { 
        private IDbEntities _db;

        public ContentTextDA(IDbEntities db)
        {
            _db = db;
        }

        #region CRUD Methods

        public bool Delete(int id)
        {
            try
            {
                var contentText = _db.ContentTexts.FirstOrDefault(ct => ct.Id == id);
                _db.ContentTexts.Remove(contentText);
                _db.Save(contentText, EntityState.Deleted);
                return true;
            }
            catch
            {
                throw;
            }
        }

        public ContentText GetByID(int id)
        {
            try
            {
                return _db.ContentTexts.FirstOrDefault(ct => ct.Id == id);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<ContentText> GetAll()
        {
            try
            {
                return _db.ContentTexts.ToList();
            }
            catch
            {
                throw;
            }
        }

        public ContentText Save(ContentText contentText)
        {
            if (contentText.Id != 0)
            {
                return Update(contentText);
            }
            else
            {
                return Insert(contentText);
            }
        }

        private ContentText Insert(ContentText contentText)
        {
            try
            {
                _db.ContentTexts.Add(contentText);
                _db.Save(contentText, EntityState.Added);
                return contentText;
            }
            catch
            {
                throw;
            }
        }

        private ContentText Update(ContentText contentText)
        {
            try
            {
                _db.ContentTexts.Attach(contentText);
                _db.Save(contentText, EntityState.Modified);
                return contentText;
            }
            catch
            {
                throw;
            }
        }

        #endregion
    }
}
