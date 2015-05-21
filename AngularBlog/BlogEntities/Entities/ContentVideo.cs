using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEntities.Entities
{
    public class ContentVideo
    {
        public virtual int Id { get; set; }
        [MaxLength(100)]
        public virtual string YoutubeCode { get; set; }
    }
}
