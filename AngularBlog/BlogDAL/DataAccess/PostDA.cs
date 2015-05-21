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
    internal class PostDA : IPostDA
    {
        private IDbEntities _db;

        public PostDA(IDbEntities db)
        {
            _db = db;
        }

        #region CRUD Methods
        
        public bool Delete(int id)
        {
            try
            {
                var post = _db.Posts.FirstOrDefault(p => p.Id == id);
                _db.Posts.Remove(post);
                _db.Save(post, EntityState.Deleted);
                return true;
            }
            catch
            {
                throw;
            }
        }

        public Post GetByID(int id)
        {
            try
            {
                return _db.Posts.FirstOrDefault(p => p.Id == id);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Post> GetAll()
        {
            try
            {
                return _db.Posts;
            }
            catch
            {
                throw;
            }
        }

        public Post Save(Post post)
        {
            if (post.Id != 0)
            {
                return Update(post);
            }
            else
            {
                return Insert(post);
            }
        }

        private Post Insert(Post post)
        {
            try
            {
                post.CreatedDate = DateTime.Now;
                _db.Posts.Add(post);
                _db.Save(post, EntityState.Added);
                return post;
            }
            catch
            {
                throw;
            }
        }

        private Post Update(Post post)
        {
            try
            {
                _db.Posts.Attach(post);
                _db.Save(post, EntityState.Modified);
                return post;
            }
            catch
            {
                throw;
            }
        }

        #endregion

        public IEnumerable<Post> GetAllByLanguageId(int languageId, int currentPage, int totalRecords)
        {
            try
            {
                return _db.Posts.Where(p => p.Language.Id == languageId)
                    .OrderBy(p => p.CreatedDate)
                    .Skip((currentPage * totalRecords))
                    .Take(totalRecords);
            }
            catch
            {
                throw;
            }
        }

        public int GetCountByLanguageId(int languageId)
        {
            try
            {
                return _db.Posts.Where(p => p.Language.Id == languageId)
                    .Count();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Post> GetAllBySearchString(string searchString, int languageId, int currentPage, int totalRecords)
        {
            try
            {
                searchString = searchString.ToLower();
                return _db.Posts.Where(p => p.Language.Id == languageId)
                    .Where(p => (p.Title.ToLower().Contains(searchString)) || (p.Description.ToLower().Contains(searchString)))
                    .OrderBy(p => p.CreatedDate)
                    .Skip((currentPage * totalRecords))
                    .Take(totalRecords);
            }
            catch
            {
                throw;
            }
        }
        
        public int GetCountBySearchString(string searchString, int languageId)
        {
            try
            {
                searchString = searchString.ToLower();
                return _db.Posts.Where(p => p.Language.Id == languageId)
                    .Where(p => (p.Title.ToLower().Contains(searchString)) || (p.Description.ToLower().Contains(searchString)))
                    .Count();
            }
            catch
            {
                throw;
            }
        }
    }
}
