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
    internal class ContentDA : IContentDA
    {
        private IDbEntities _db;

        public ContentDA(IDbEntities db)
        {
            _db = db;
        }

        #region CRUD Methods

        public bool Delete(int id)
        {
            try
            {
                var content = _db.Contents.FirstOrDefault(c => c.Id == id);
                _db.Contents.Remove(content);
                _db.Save(content, EntityState.Deleted);
                return true;
            }
            catch
            {
                throw;
            }
        }

        public Content GetByID(int id)
        {
            try
            {
                return _db.Contents.FirstOrDefault(c => c.Id == id);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Content> GetAll()
        {
            try
            {
                return _db.Contents.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Content Save(Content content)
        {
            if (content.Id != 0)
            {
                return Update(content);
            }
            else
            {
                return Insert(content);
            }
        }

        private Content Insert(Content content)
        {
            try
            {
                _db.Contents.Add(content);
                _db.Save(content, EntityState.Added);
                return content;
            }
            catch
            {
                throw;
            }
        }

        private Content Update(Content content)
        {
            try
            {
                _db.Contents.Attach(content);
                _db.Save(content, EntityState.Modified);
                return content;
            }
            catch
            {
                throw;
            }
        }

        #endregion

        public List<Content> GetByPostId(int postId)
        {
            try
            {
                return _db.Contents.Where(c => c.PostId == postId)
                    .OrderBy(c => c.Order)
                    .ToList();
            }
            catch
            {
                throw;
            }
        }

        public bool DeleteByPostId(int postId)
        {
            try
            {
                var contentList = this.GetByPostId(postId);
                //TODO: Add delete for text, photos and videos
                _db.Contents.RemoveRange(contentList);
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
