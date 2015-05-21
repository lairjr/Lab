using BlogDAL.Interfaces;
using BlogEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDAL.DataAccess
{
    internal class LanguageDA : ILanguageDA
    {
        private IDbEntities _db;

        public LanguageDA(IDbEntities db)
        {
            _db = db;
        }

        public IEnumerable<Language> GetAll()
        {
            try
            {
                return _db.Languages.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Language GetByLanguageCode(string languageCode)
        {
            try
            {
                return _db.Languages.FirstOrDefault(l => l.LanguageCode.ToLower().Equals(languageCode.ToLower()));
            }
            catch
            {
                throw;
            }
        }
    }
}
