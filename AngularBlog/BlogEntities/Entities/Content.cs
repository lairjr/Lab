using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEntities.Entities
{
    public class Content
    {
        public virtual int Id { get; set; }
        public virtual int Order { get; set; }
        [MaxLength(50)]
        public virtual string ContentTypeMnemonic { get; set; }

        public virtual int PostId { get; set; }

        public virtual int? TextId { get; set; }
        public virtual ContentText Text { get; set; }
        public virtual int? VideoId { get; set; }
        public virtual ContentVideo Video { get; set; }
    }
}
