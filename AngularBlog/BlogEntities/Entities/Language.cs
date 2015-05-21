using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEntities.Entities
{
    public class Language
    {
        public virtual int Id { get; set; }
        [MaxLength(50)]
        public virtual string Name { get; set; }
        [MaxLength(5)]
        public virtual string LanguageCode { get; set; }
    }
}
