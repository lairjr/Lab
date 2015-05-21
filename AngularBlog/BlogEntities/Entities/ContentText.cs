using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEntities.Entities
{
    public class ContentText
    {
        public virtual int Id { get; set; }
        [Column(TypeName = "Text")]
        public virtual string Text { get; set; }
    }
}
