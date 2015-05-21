using BlogEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDAL.Interfaces
{
    public interface ILanguageDA
    {
        IEnumerable<Language> GetAll();
        Language GetByLanguageCode(string languageCode);
    }
}
