using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEntities.ViewModels.ReceiveViewModels
{
    public class PostTagVM
    {
        public int LanguageId { get; set; }
        public int PostId { get; set; }
        public string Tag { get; set; }
    }
}
