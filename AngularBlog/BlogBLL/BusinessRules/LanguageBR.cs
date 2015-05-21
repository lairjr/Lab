using BlogBLL.Interfaces;
using BlogDAL;
using BlogDAL.Interfaces;
using BlogEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBLL.BusinessRules
{
    internal class LanguageBR : ILanguageBR
    {
        private ILanguageDA languageDa = DalFactory.CreateLanguageDA();

        public IEnumerable<Language> GetAll()
        {
            return languageDa.GetAll();
        }
        
        public Language GetByLanguageCode(string languageCode)
        {
            return languageDa.GetByLanguageCode(languageCode);
        }
    }
}
