using BlogEntities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDAL
{
    internal class DbEntities : DbContext, IDbEntities
    {
        public DbEntities()
            : base("LocalConnection")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<ContentType> ContentTypes { get; set; }
        public DbSet<ContentText> ContentTexts { get; set; }
        public DbSet<ContentVideo> ContentVideos { get; set; }

        public void Save()
        {
            SaveChanges();
        }

        public void Save(object obj, EntityState entityState)
        {
            Entry(obj).State = entityState;
            Save();
        }
    }
}
