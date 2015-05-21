using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEntities.Entities
{
    public class PostTag
    {
        public virtual int Id { get; set; }
        public virtual int PostId { get; set; }
        public virtual int TagId { get; set; }

        /// <summary>
        /// Auxiliar Property
        /// </summary>
        public virtual Tag Tag { get; set; }
    }
}
