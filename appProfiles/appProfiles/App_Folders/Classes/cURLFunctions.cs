using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appProfiles.App_Folders.Classes
{
    public class cURLFunctions
    {
        public static int getPageId(string _url)
        {
            int _pageId = -1; 
            //5 Number of caracters of the String 'Page/' 
            int _iPage = _url.IndexOf("Page/", StringComparison.Ordinal) + 5; // Getting index after Page/
            if (_iPage > 5)
            {
                string _afterPage = _url.Substring(_iPage); // Getting string after Page/
                if (_afterPage.Contains("/")) // if there is another bar it gonna get the number between the _iPage and the other bar
                {
                    int _iBar = _afterPage.IndexOf("/");
                    _pageId = int.Parse(_afterPage.Substring(0, _iBar));
                }
                else
                    _pageId = int.Parse(_url.Substring(_iPage));

            }
            return _pageId;
        }

        public static int getContentId(string _url)
        {
            int _contentId = -1;
            //8 Number of caracters of the String 'Content/' 
            int _iContent = _url.IndexOf("Content/", StringComparison.Ordinal) + 8; // Getting index after Content/
            if (_iContent > 8)
            {
                string _afterContent = _url.Substring(_iContent); // Getting string after Content/
                if (_afterContent.Contains("/")) // if there is another bar it gonna get the number between the _iContent and the other bar
                {
                    int _iBar = _afterContent.IndexOf("/");
                    _contentId = int.Parse(_afterContent.Substring(0, _iBar));
                }
                else
                    _contentId = int.Parse(_url.Substring(_iContent));

            }
            return _contentId;
        }
    }
}