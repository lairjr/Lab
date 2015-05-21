using BlogEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBLL.Interfaces
{
    public interface ILanguageBR
    {
        IEnumerable<Language> GetAll();
        Language GetByLanguageCode(string languageCode);
    }
}
