﻿using BlogEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDAL.Interfaces
{
    public interface IPostTagDA
    {
        bool Insert(PostTag postTag);
        bool Delete(PostTag postTag);
    }
}
