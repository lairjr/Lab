using BlogEntities.Entities;
using BlogEntities.ViewModels.ReceiveViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBLL.Interfaces
{
    public interface IContentBR
    {
        bool Delete(int id);

        bool DeleteByPostId(int postId);

        bool AddTextContent(ContentTextVM contentText);

        bool AddVideoContent(ContentVideoVM contentVideo);

        List<Content> GetByPostId(int postId, bool eagerLoad);

        Content UpdateContentOrder(int contentId, int newOrder);
    }
}
