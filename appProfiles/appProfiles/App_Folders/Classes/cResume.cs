using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace appProfiles.App_Folders.Classes
{
    public class cResume : cDataBase
    {
        #region variables declaretions

        private string goals, addInfo;
        private int idAccount, idLanguage;

        public int IdAccount
        {
            get { return idAccount; }
            set { idAccount = value; }
        }

        public int IdLanguage
        {
            get { return idLanguage; }
            set { idLanguage = value; }
        }

        public string AddInfo
        {
            get { return addInfo; }
            set { addInfo = value; }
        }

        public string Goals
        {
            get { return goals; }
            set { goals = value; }
        }

        #endregion

        public cResume()
        {
        }

        public Boolean getResume(int _idaccount, int _idlanguage)
        {
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " SELECT * FROM profile_resume WHERE idaccount = @idaccount AND idlanguage = @idlanguage ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", _idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@idlanguage", _idlanguage));
                MySqlDataReader _reader = Cmd.ExecuteReader();
                if (_reader.Read())
                {
                    IdAccount = _reader.GetInt32("idaccount");
                    IdLanguage = _reader.GetInt32("idlanguage");
                    Goals = _reader.GetString("goal");
                    AddInfo = _reader.GetString("add_info");
                    return true;
                }
                else {
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

        public Boolean insert(int _idaccount, int _idlanguage)
        {
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " INSERT INTO profile_resume VALUES (@idaccount, @idlanguage, @goal, @add_info) ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", _idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@idlanguage", _idlanguage));
                Cmd.Parameters.Add(new MySqlParameter("@goal", Goals));
                Cmd.Parameters.Add(new MySqlParameter("@add_info", AddInfo));
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

        public Boolean update(int _idaccount, int _idlanguage)
        { 
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " UPDATE profile_resume SET goal = @goals, add_info = @add_info WHERE idaccount = @idaccount AND idlanguage = @idlanguage ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", _idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@idlanguage", _idlanguage));
                Cmd.Parameters.Add(new MySqlParameter("@goals", Goals));
                Cmd.Parameters.Add(new MySqlParameter("@add_info", AddInfo));
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

        public Boolean update()
        {
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " UPDATE profile_resume SET goal = @goals, add_info = @add_info WHERE idaccount = @idaccount AND idlanguage = @idlanguage ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", IdAccount));
                Cmd.Parameters.Add(new MySqlParameter("@idlanguage", IdLanguage));
                Cmd.Parameters.Add(new MySqlParameter("@goals", Goals));
                Cmd.Parameters.Add(new MySqlParameter("@add_info", AddInfo));
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
    }
}