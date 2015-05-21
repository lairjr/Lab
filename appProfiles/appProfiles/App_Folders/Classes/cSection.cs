using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace appProfiles.App_Folders.Classes
{
    public class cSection : cDataBase
    {
        #region variables declarations

        private string table_name, name;
        private int idsection;

        #endregion

        #region basis methods

        public int Idsection
        {
            get { return idsection; }
            set { idsection = value; }
        }

        public string Table_name
        {
            get { return table_name; }
            set { table_name = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        #endregion

        public cSection()
        {

        }

        public bool insert()
        {
            try
            {
                if (Connection.State != System.Data.ConnectionState.Open)
                    Connection.Open();

                Cmd.CommandText = " INSERT INTO section VALUES (null, @table_name, @name) ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@table_name", Table_name));
                Cmd.Parameters.Add(new MySqlParameter("@name", Name));
                Cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (Connection.State == System.Data.ConnectionState.Open)
                    Connection.Close();
            }
        }

        public bool getSectionById(int _idsection)
        {
            try
            {
                if (Connection.State != System.Data.ConnectionState.Open)
                    Connection.Open();

                Cmd.CommandText = " SELECT * FROM section WHERE idsection = @idsection ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idsection", _idsection));
                MySqlDataReader _reader = Cmd.ExecuteReader();
                if (_reader.Read())
                {
                    Idsection = _reader.GetInt32("idsection");
                    Table_name = _reader.GetString("table_name");
                    Name = _reader.GetString("name");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (Connection.State == System.Data.ConnectionState.Open)
                    Connection.Close();
            }
        }
    }
}