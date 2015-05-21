using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace appProfiles.App_Folders.Classes
{
    public class cLanguage : cDataBase
    {
        #region variables declaretions

        private int idlanguage;
        private string name, code;

        #endregion

        #region basic methods

        public int Idlanguage
        {
            get { return idlanguage; }
            set { idlanguage = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        #endregion

        public cLanguage()
        {
        }

        public Boolean getLanguageById(int _idlanguage)
        {
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " SELECT * FROM language WHERE idlanguage = @idlanguage ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idlanguage", _idlanguage));
                MySqlDataReader _reader = Cmd.ExecuteReader();
                if (_reader.Read())
                {
                    Idlanguage = _reader.GetInt32("idlanguage");
                    Name = _reader.GetString("name");
                    Code = _reader.GetString("code");
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

        public Boolean getLanguageByCode(string _code)
        {
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " SELECT * FROM language WHERE code = @code ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@code", _code));
                MySqlDataReader _reader = Cmd.ExecuteReader();
                if (_reader.Read())
                {
                    Name = _reader.GetString("name");
                    Idlanguage = _reader.GetInt32("idlanguage");
                    Code = _reader.GetString("code");
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