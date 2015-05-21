using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appProfiles.App_Folders.Classes
{
    public class cAudio
    {
        private string title, description, filename;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Filename
        {
            get { return filename; }
            set { filename = value; }
        }
    }
}