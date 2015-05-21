using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEntities.Entities
{
    public class Tag
    {
        public virtual int Id { get; set; }
        [MaxLength(50)]
        public virtual string Name { get; set; }

        public virtual Language Language { get; set; }
    }
}
