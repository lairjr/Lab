namespace BlogDAL.Migrations
{
    using BlogEntities;
    using BlogEntities.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogDAL.DbEntities>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BlogDAL.DbEntities context)
        {
            var languageList = new List<Language> 
            {
                new Language() {
                    Name = "English",
                    LanguageCode = "en-US"
                },
                new Language() {
                    Name = "Portuguese",
                    LanguageCode = "pt-BR"
                }
            };

            var contentTypeList = new List<ContentType> 
            {
                new ContentType() {
                    Name = "Text",
                    Language = languageList.FirstOrDefault(l => l.Name.ToLower().Equals("english")),
                    Mnemonic = Enums.ContentMnemonic.TEXT.ToString()
                },
                new ContentType() {
                    Name = "YouTube Video",
                    Language = languageList.FirstOrDefault(l => l.Name.ToLower().Equals("english")),
                    Mnemonic = Enums.ContentMnemonic.VIDEO.ToString()
                },
                new ContentType() {
                    Name = "Photo Album",
                    Language = languageList.FirstOrDefault(l => l.Name.ToLower().Equals("english")),
                    Mnemonic = Enums.ContentMnemonic.PHOTOALBUM.ToString()
                }
            };

            var tagList = new List<Tag>
            {
                new Tag() {
                    Name = "Angular JS",
                    Language = languageList.FirstOrDefault(l => l.Name.ToLower().Equals("english")),
                },
                new Tag() {
                    Name = "ASP.NET MVC 4",
                    Language = languageList.FirstOrDefault(l => l.Name.ToLower().Equals("english")),
                }
            };

            var postList = new List<Post>
            {
                new Post() { 
                    Title = "Post 1", 
                    CreatedDate = DateTime.Now.Date, 
                    Description = "Description 1",
                    Language = languageList.FirstOrDefault(l => l.Name.ToLower().Equals("english")),
                    PostTags = new List<PostTag> {
                        new PostTag() {
                            Tag = tagList.FirstOrDefault(t => t.Name == "Angular JS")
                        },
                        new PostTag() {
                            Tag = tagList.FirstOrDefault(t => t.Name == "ASP.NET MVC 4")
                        }
                    }
                },
                new Post() { 
                    Title = "Post 2", 
                    CreatedDate = DateTime.Now.Date, 
                    Description = "Description 2",
                    Language = languageList.FirstOrDefault(l => l.Name.ToLower().Equals("english")),
                    PostTags = new List<PostTag> {
                        new PostTag() {
                            Tag = tagList.FirstOrDefault(t => t.Name == "Angular JS")
                        }
                    }
                },
                new Post() { 
                    Title = "Post 3", 
                    CreatedDate = DateTime.Now.Date, 
                    Description = "Description 3",
                    Language = languageList.FirstOrDefault(l => l.Name.ToLower().Equals("english")),
                    PostTags = new List<PostTag> {
                        new PostTag() {
                            Tag = tagList.FirstOrDefault(t => t.Name == "ASP.NET MVC 4")
                        }
                    }
                }
            };

            languageList.ForEach(l => context.Languages.Add(l));
            contentTypeList.ForEach(ct => context.ContentTypes.Add(ct));
            postList.ForEach(p => context.Posts.Add(p));
            tagList.ForEach(t => context.Tags.Add(t));

            context.SaveChanges();
        }
    }
}
