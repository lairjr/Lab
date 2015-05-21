using BlogBLL.Interfaces;
using BlogDAL;
using BlogDAL.Interfaces;
using BlogEntities.Entities;
using BlogEntities.ViewModels.ReceiveViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBLL.BusinessRules
{
    internal class PostTagBR : IPostTagBR
    {
        private IPostTagDA da = DalFactory.CreatePostTagDA();
        private ITagDA tagDa = DalFactory.CreateTagDA();

        public List<PostTag> GetByPostId(int postId, bool eagerLoad)
        {
            if (eagerLoad)
            {
                var postTagList = da.GetByPostId(postId);

                foreach (var postTag in postTagList)
                {
                    postTag.Tag = tagDa.GetByID(postTag.TagId);
                }

                return postTagList;
            }
            else
            {
                return da.GetByPostId(postId);
            }
        }

        public bool Delete(int id)
        {
            return da.Delete(id);
        }

        public bool Insert(PostTagVM postTagVM)
        {
            var tag = tagDa.GetByName(postTagVM.Tag, postTagVM.LanguageId);
            if (tag != null)
            {
                var postTags = da.GetByPostId(postTagVM.PostId);
                var postTagCount = postTags.Count(pt => pt.TagId == tag.Id);
                if (postTagCount <= 0)
                {
                    var postTag = new PostTag()
                    {
                        PostId = postTagVM.PostId,
                        TagId = tag.Id
                    };
                    return da.Insert(postTag);
                }
                else 
                {
                    return false;
                }
            }
            else
            {
                var newTag = new Tag()
                {
                    Name = postTagVM.Tag,
                    Language = new Language()
                    {
                        Id = postTagVM.LanguageId
                    }
                };
                tag = tagDa.Save(newTag);

                var postTag = new PostTag()
                {
                    PostId = postTagVM.PostId,
                    TagId = tag.Id
                };
                return da.Insert(postTag);
            }
        }

        public bool DeleteByPostId(int postId)
        {
            return da.DeleteByPostId(postId);
        }
    }
}
