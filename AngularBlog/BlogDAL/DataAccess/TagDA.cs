using BlogDAL.Interfaces;
using BlogEntities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDAL.DataAccess
{
    internal class TagDA : ITagDA
    {
        private IDbEntities _db;

        public TagDA(IDbEntities db)
        {
            _db = db;
        }

        #region CRUD Methods

        public bool Delete(int id)
        {
            try
            {
                var tag = _db.Tags.FirstOrDefault(t => t.Id == id);
                _db.Tags.Remove(tag);
                _db.Save(tag, EntityState.Deleted);
                return true;
            }
            catch
            {
                throw;
            }
        }

        public Tag GetByID(int id)
        {
            try
            {
                return _db.Tags.FirstOrDefault(t => t.Id == id);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Tag> GetAll()
        {
            try
            {
                return _db.Tags.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Tag Save(Tag tag)
        {
            if (tag.Id != 0)
            {
                return Update(tag);
            }
            else
            {
                return Insert(tag);
            }
        }

        private Tag Insert(Tag tag)
        {
            try
            {
                _db.Tags.Add(tag);
                _db.Save(tag, EntityState.Added);
                return tag;
            }
            catch
            {
                throw;
            }
        }

        private Tag Update(Tag tag)
        {
            try
            {
                _db.Tags.Attach(tag);
                _db.Save(tag, EntityState.Modified);
                return tag;
            }
            catch
            {
                throw;
            }
        }

        #endregion

        public IEnumerable<Tag> GetByPostId(int postId)
        {
            try
            {
                var tagList = _db.PostTags.Where(pt => pt.PostId == postId).Select(pt => pt.Tag);

                return tagList;
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Tag> GetByLanguageId(int languageId)
        {
            try
            {
                return _db.Tags.Where(t => t.Language.Id == languageId);
            }
            catch
            {
                throw;
            }
        }

        public Tag GetByName(string name, int languageId)
        {
            return _db.Tags.FirstOrDefault(t => t.Language.Id == languageId && t.Name.ToLower().Equals(name.ToLower()));
        }
    }
}
