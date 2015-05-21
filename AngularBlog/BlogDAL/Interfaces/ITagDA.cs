﻿using BlogEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDAL.Interfaces
{
    public interface ITagDA
    {
        #region CRUD Methods

        bool Delete(int id);
        Tag GetByID(int id);
        IEnumerable<Tag> GetAll();
        Tag Save(Tag tag);

        #endregion

        IEnumerable<Tag> GetByPostId(int postId);

        IEnumerable<Tag> GetByLanguageId(int languageId);
        Tag GetByName(string name, int languageId);
    }
}