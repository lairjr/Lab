using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appProfiles.App_Folders.Classes
{
    public class cPerson
    {
        #region variables declaretions

        string fName, lName;
        DateTime birthDate;
        
        #endregion

        #region basic methods

        public string LName
        {
            get { return lName; }
            set { lName = value; }
        }

        public string FName
        {
            get { return fName; }
            set { fName = value; }
        }

        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        #endregion

        public int getAge()
        {
            int age = -1;
            int year = BirthDate.Year;
            int month = BirthDate.Month;
            int day = BirthDate.Day;
            age = DateTime.Now.Year - year;
            if (DateTime.Now.Month < month)
                age--;
            if (DateTime.Now.Month == month)
            {
                if (DateTime.Now.Day < day)
                    age--;
            }
            return age;
        }
    }
}