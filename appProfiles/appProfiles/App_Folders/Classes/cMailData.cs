using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appProfiles.App_Folders.Classes
{
    public class cMailData
    {
        string name, email;

        public cMailData(string _name, string _email)
        {
            this.name = _name;
            this.email = _email;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}