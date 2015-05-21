using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appProfiles.App_Folders.Classes
{
    public class cGlobalResourceObject
    {
        public cGlobalResourceObject()
        { 
        }

        public static string getGlobalResource(string _key, string _languageCode)
        {
            switch (_languageCode)
            { 
                case "pt":
                    _languageCode = "pt-BR";
                    break;
                case "es":
                    _languageCode = "es-AR";
                    break;
                default:
                    _languageCode = "en-US";
                    break;
            }
            System.Globalization.CultureInfo _cu = new System.Globalization.CultureInfo(_languageCode);
            string _word = HttpContext.GetGlobalResourceObject("string", _key, _cu).ToString();
            return _word;
        }
    }
}