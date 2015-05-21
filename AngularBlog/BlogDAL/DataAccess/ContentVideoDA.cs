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
    internal class ContentVideoDA : IContentVideoDA
    {
        private IDbEntities _db;

        public ContentVideoDA(IDbEntities db)
        {
            _db = db;
        }

        #region CRUD Methods

        public bool Delete(int id)
        {
            try
            {
                var contentVideo = _db.ContentVideos.FirstOrDefault(cv => cv.Id == id);
                _db.ContentVideos.Remove(contentVideo);
                _db.Save(contentVideo, EntityState.Deleted);
                return true;
            }
            catch
            {
                throw;
            }
        }

        public ContentVideo GetByID(int id)
        {
            try
            {
                return _db.ContentVideos.FirstOrDefault(cv => cv.Id == id);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<ContentVideo> GetAll()
        {
            try
            {
                return _db.ContentVideos.ToList();
            }
            catch
            {
                throw;
            }
        }

        public ContentVideo Save(ContentVideo contentVideo)
        {
            if (contentVideo.Id != 0)
            {
                return Update(contentVideo);
            }
            else
            {
                return Insert(contentVideo);
            }
        }

        private ContentVideo Insert(ContentVideo contentVideo)
        {
            try
            {
                _db.ContentVideos.Add(contentVideo);
                _db.Save(contentVideo, EntityState.Added);
                return contentVideo;
            }
            catch
            {
                throw;
            }
        }

        private ContentVideo Update(ContentVideo contentVideo)
        {
            try
            {
                _db.ContentVideos.Attach(contentVideo);
                _db.Save(contentVideo, EntityState.Modified);
                return contentVideo;
            }
            catch
            {
                throw;
            }
        }

        #endregion
    }
}
