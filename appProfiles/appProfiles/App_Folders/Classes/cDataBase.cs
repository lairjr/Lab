using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace appProfiles.App_Folders.Classes
{
    public class cDataBase
    {
        private const string stringConnection = "server=mysql.lairjr.com; User Id=lairjr01; password=garnett; database=lairjr01; allow zero datetime=yes;";

        private MySqlConnection connection;
        private MySqlCommand cmd;

        public MySqlCommand Cmd
        {
            get { return cmd; }
            set { cmd = value; }
        }

        public cDataBase()
        { 
            Connection = new MySqlConnection(stringConnection);
            Cmd = Connection.CreateCommand();
        }

        public MySqlConnection Connection
        {
            get
            {
                return connection;
            }
            set
            {
                connection = value;
            }
        }
    }
}