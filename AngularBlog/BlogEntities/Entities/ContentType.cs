using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEntities.Entities
{
    public class ContentType
    {
        public virtual int Id { get; set; }
        [MaxLength(50)]
        public virtual string Name { get; set; }
        [MaxLength(50)]
        public virtual string Mnemonic { get; set; }

        public virtual Language Language { get; set; }
    }
}
