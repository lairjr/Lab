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
    internal class PostTagDA : IPostTagDA
    {
        private IDbEntities _db;

        public PostTagDA(IDbEntities db)
        {
            _db = db;
        }

        public bool Insert(PostTag postTag)
        {
            try
            {
                _db.PostTags.Add(postTag);
                _db.Save(postTag, EntityState.Added);
                return true;
            }
            catch
            {
                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var pTag = _db.PostTags.FirstOrDefault(pt => pt.Id == id);
                _db.PostTags.Remove(pTag);
                _db.Save(pTag, EntityState.Deleted);
                return true;
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
                var postTagsList = _db.PostTags.Where(pt => pt.PostId == postId);

                bool hasTags = !((postTagsList == null) || (postTagsList.Count() == 0));

                if (hasTags)
                {
                    _db.PostTags.RemoveRange(postTagsList);
                }

                return true;
            }
            catch
            {
                throw;
            }
        }

        public List<PostTag> GetByPostId(int postId)
        {
            return _db.PostTags.Where(pt => pt.PostId == postId).ToList();
        }
    }
}
