using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogEntities.Entities;

namespace BlogEntities.ViewModels.ReturnViewModels
{
    public class PostListVM
    {
        public bool IsLastPage { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}
