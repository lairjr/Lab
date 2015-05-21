using BlogEntities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDAL
{
    public interface IDbEntities
    {
        DbSet<Post> Posts { get; set; }
        DbSet<Content> Contents { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<PostTag> PostTags { get; set; }
        DbSet<Language> Languages { get; set; }
        DbSet<ContentType> ContentTypes { get; set; }
        DbSet<ContentText> ContentTexts { get; set; }
        DbSet<ContentVideo> ContentVideos { get; set; }

        void Save();
        void Save(object obj, EntityState entityState);
    }
}
