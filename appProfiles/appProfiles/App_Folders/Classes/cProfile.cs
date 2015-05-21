using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace appProfiles.App_Folders.Classes
{
    public class cProfile : cDataBase
    {
        #region variables declaretions

        private cLanguage language;

        private int idaccount, main;
        private DateTime updated;
        private string title;

        #endregion

        #region basic methods

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public int Idaccount
        {
            get { return idaccount; }
            set { idaccount = value; }
        }

        public cLanguage Language
        {
            get { return language; }
            set { language = value; }
        }

        public int Main
        {
            get { return main; }
            set { main = value; }
        }

        public DateTime Updated
        {
            get { return updated; }
            set { updated = value; }
        }

        #endregion

        public cProfile()
        {
            language = new cLanguage();
        }

        public Boolean delete(int _idaccount, int _idlanguage)
        {
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " DELETE FROM profile WHERE idaccount = @idaccount AND idlanguage = @idlanguage ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", _idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@idlanguage", _idlanguage));
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

        public Boolean insert(int _idaccount, int _idlanguage)
        {
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " INSERT INTO profile VALUES (@idaccount, @idlanguage, @main, @title, @updated) ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", _idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@idlanguage", _idlanguage));
                Cmd.Parameters.Add(new MySqlParameter("@main", Main));
                Cmd.Parameters.Add(new MySqlParameter("@title", Title));
                Cmd.Parameters.Add(new MySqlParameter("@updated", Updated));
                Cmd.ExecuteNonQuery();

                cResume _resume = new cResume();
                if (_resume.insert(Idaccount, Language.Idlanguage))
                {
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

        public DataTable getPages()
        {
            DataTable _pages = new DataTable();
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " SELECT * FROM profile_page WHERE idaccount = @idaccount AND idlanguage = @idlanguage ORDER BY name ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", Idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@idlanguage", Language.Idlanguage));
                MySqlDataReader _reader = Cmd.ExecuteReader();
                _pages.Load(_reader);
                _reader.Close();
                return _pages;
            }
            catch (Exception)
            {
                return _pages;
            }
            finally
            {
                if (Connection.State == System.Data.ConnectionState.Open)
                    Connection.Close();
            }
        }

        public Boolean getProfileByLanguage(int _idaccount, string _languageCode)
        {
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " SELECT profile.* FROM `language`, profile WHERE profile.idaccount = @idaccount AND profile.idlanguage = `language`.idlanguage AND `language`.`code` = @language ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", _idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@language", _languageCode));
                MySqlDataReader _reader = Cmd.ExecuteReader();
                if (!_reader.Read())
                {
                    _reader.Close();
                    Cmd.CommandText = " SELECT profile.* FROM profile WHERE profile.idaccount = '12' AND profile.main = '1' ";
                    Cmd.Parameters.Clear();
                    Cmd.Parameters.Add(new MySqlParameter("@idaccount", _idaccount));
                    _reader = Cmd.ExecuteReader();
                    _reader.Read();
                }

                Idaccount = _reader.GetInt32("idaccount");
                Title = _reader.GetString("title");
                Language.Idlanguage = _reader.GetInt32("idlanguage");
                Updated = _reader.GetDateTime("updated");
                Main = _reader.GetInt32("main");
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