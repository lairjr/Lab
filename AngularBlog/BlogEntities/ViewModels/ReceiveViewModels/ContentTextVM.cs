using BlogEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEntities.ViewModels.ReceiveViewModels
{
    public class ContentTextVM : ContentText
    {
        public int PostId { get; set; }
    }
}
