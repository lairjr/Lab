using BlogBLL.Interfaces;
using BlogDAL;
using BlogDAL.Interfaces;
using BlogEntities;
using BlogEntities.Entities;
using BlogEntities.ViewModels.ReceiveViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BlogBLL.BusinessRules
{
    internal class ContentBR : IContentBR
    {
        private IContentDA contentDa = DalFactory.CreateContentDA();
        private IContentTextDA contentTextDa = DalFactory.CreateContentTextDA();
        private IContentVideoDA contentVideoDa = DalFactory.CreateContentVideoDA();

        public bool Delete(int id)
        {
            using (var scope = new TransactionScope())
            {
                var content = contentDa.GetByID(id);
                var contentPostList = contentDa.GetByPostId(content.PostId).Where(c => c.Order > content.Order);

                bool hasItems = !((contentPostList == null) || (contentPostList.Count() == 0));

                if (hasItems)
                {
                    foreach (var contentItem in contentPostList)
                    {
                        contentItem.Order--;
                        contentDa.Save(contentItem);
                    }
                }

                var contentId = GetContentId(content);
                var contentType = (Enums.ContentMnemonic)Enum.Parse(typeof(Enums.ContentMnemonic), content.ContentTypeMnemonic);

                contentDa.Delete(content.Id);

                switch (contentType)
                {
                    case Enums.ContentMnemonic.TEXT:
                        if (contentId.HasValue)
                            contentTextDa.Delete(contentId.Value);
                        break;
                    case Enums.ContentMnemonic.VIDEO:
                        if (contentId.HasValue)
                            contentVideoDa.Delete(contentId.Value);
                        break;
                };

                scope.Complete();
                return true;
            }
        }

        public bool DeleteByPostId(int postId)
        {
            var contentList = contentDa.GetByPostId(postId);
            foreach (var content in contentList)
            {
                this.Delete(content.Id);
            }
            return true;
        }

        public bool AddTextContent(ContentTextVM contentText)
        {
            using (var scope = new TransactionScope())
            {
                var cText = new ContentText()
                {
                    Text = contentText.Text
                };
                cText = contentTextDa.Save(cText);

                var lastContent = contentDa.GetByPostId(contentText.PostId).OrderBy(ct => ct.Order).LastOrDefault();
                var content = new Content()
                {
                    PostId = contentText.PostId,
                    ContentTypeMnemonic = Enums.ContentMnemonic.TEXT.ToString(),
                    Order = (lastContent != null) ? lastContent.Order + 1 : 1,
                    Text = cText
                };

                contentDa.Save(content);

                scope.Complete();
            }
            return true;
        }

        public bool AddVideoContent(ContentVideoVM contentVideo)
        {
            using (var scope = new TransactionScope())
            {
                var cVideo = new ContentVideo()
                {
                    YoutubeCode = contentVideo.YoutubeCode
                };
                cVideo = contentVideoDa.Save(cVideo);

                var lastContent = contentDa.GetByPostId(contentVideo.PostId).OrderBy(ct => ct.Order).LastOrDefault();
                var content = new Content()
                {
                    PostId = contentVideo.PostId,
                    ContentTypeMnemonic = Enums.ContentMnemonic.VIDEO.ToString(),
                    Order = (lastContent != null) ? lastContent.Order + 1 : 1,
                    Video = cVideo
                };

                contentDa.Save(content);

                scope.Complete();
            }
            return true;
        }

        public List<Content> GetByPostId(int postId, bool eagerLoad)
        {
            if (eagerLoad)
            {
                var contentList = contentDa.GetByPostId(postId);
                foreach (var content in contentList)
                {
                    if (!string.IsNullOrEmpty(content.ContentTypeMnemonic))
                    {
                        var contentType = (Enums.ContentMnemonic)Enum.Parse(typeof(Enums.ContentMnemonic), content.ContentTypeMnemonic);

                        switch (contentType)
                        {
                            case Enums.ContentMnemonic.TEXT:
                                content.Text = contentTextDa.GetByID(content.TextId.Value);
                                break;
                            case Enums.ContentMnemonic.VIDEO:
                                content.Video = contentVideoDa.GetByID(content.VideoId.Value);
                                break;
                        }
                    }
                }
                return contentList;
            }
            else
            {
                return contentDa.GetByPostId(postId);
            }
        }

        public Content UpdateContentOrder(int contentId, int newOrder)
        {
            using (var scope = new TransactionScope())
            {
                var content = contentDa.GetByID(contentId);

                bool wasOrderChanged = (newOrder != content.Order);
                if (wasOrderChanged)
                {
                    var contentList = contentDa.GetByPostId(content.PostId).OrderBy(c => c.Order);
                    bool isNewOrderHigher = (newOrder > content.Order);

                    if (isNewOrderHigher)
                    {
                        var contentToBeUpdated = contentList.Where(c => (c.Order <= newOrder) && (c.Order > content.Order) && (c.Id != contentId));
                        foreach (var _content in contentToBeUpdated)
                        {
                            _content.Order--;
                            contentDa.Save(_content);
                        }
                    }
                    else
                    {
                        var contentToBeUpdated = contentList.Where(c => (c.Order >= newOrder) && (c.Order < content.Order) && (c.Id != contentId));
                        foreach (var _content in contentToBeUpdated)
                        {
                            _content.Order++;
                            contentDa.Save(_content);
                        }
                    }
                }

                content.Order = newOrder;
                var savedContent = contentDa.Save(content);
                scope.Complete();

                return savedContent;
            }
        }

        private int? GetContentId(Content content)
        {
            var contentType = (Enums.ContentMnemonic)Enum.Parse(typeof(Enums.ContentMnemonic), content.ContentTypeMnemonic);

            switch (contentType)
            {
                case Enums.ContentMnemonic.TEXT:
                    return content.TextId;
                case Enums.ContentMnemonic.VIDEO:
                    return content.VideoId;
            };
            return null;
        }
    }
}

