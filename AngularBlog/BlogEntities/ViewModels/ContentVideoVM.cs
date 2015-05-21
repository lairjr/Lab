using BlogEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEntities.ViewModels
{
    public class ContentVideoVM : ContentVideo
    {
        public int PostId { get; set; }
    }
}
