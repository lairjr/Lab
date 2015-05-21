using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEntities.Entities
{
    public class Post
    {
        public virtual int Id { get; set; }
        [MaxLength(200)]
        public virtual string Title { get; set; }
        [MaxLength(4000)]
        public virtual string Description { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual int LanguageId { get; set; }

        public virtual ICollection<Content> Contents { get; set; }
        public virtual ICollection<PostTag> PostTags { get; set; }
        public virtual Language Language { get; set; }
    }
}
