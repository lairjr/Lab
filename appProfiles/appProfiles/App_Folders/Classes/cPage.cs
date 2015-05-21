using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace appProfiles.App_Folders.Classes
{
    public class cPage : cDataBase
    {
        #region variables declaretions

        private int idaccount, idlanguage, idpage;
        private string name;

        #endregion

        #region basic methods

        public int Idlanguage
        {
            get { return idlanguage; }
            set { idlanguage = value; }
        }

        public int Idaccount
        {
            get { return idaccount; }
            set { idaccount = value; }
        }

        public int Idpage
        {
            get { return idpage; }
            set { idpage = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        #endregion

        public cPage()
        {
        }

        public Boolean delete()
        { 
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " DELETE FROM profile_page WHERE idaccount = @idaccount AND idlanguage = @idlanguage AND idpage = @idpage ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", Idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@idlanguage", Idlanguage));
                Cmd.Parameters.Add(new MySqlParameter("@idpage", Idpage));
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

        public Boolean getPage(int _idaccount, int _idlanguage, int _idpage)
        {
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " SELECT * FROM profile_page WHERE idaccount = @idaccount AND idlanguage = @idlanguage AND idpage = @idpage ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", _idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@idlanguage", _idlanguage));
                Cmd.Parameters.Add(new MySqlParameter("@idpage", _idpage));
                MySqlDataReader _reader = Cmd.ExecuteReader();
                if (_reader.Read())
                {
                    Idaccount = _reader.GetInt32("idaccount");
                    Idlanguage = _reader.GetInt32("idlanguage");
                    Idpage = _reader.GetInt32("idpage");
                    Name = _reader.GetString("name");
                    _reader.Close();
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

        public Boolean insert(int _idaccount, int _idlanguage)
        {
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " SELECT MAX(idpage) FROM profile_page WHERE idaccount = @idaccount AND idlanguage = @idlanguage ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", _idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@idlanguage", _idlanguage));
                Idpage = 0;
                Object _oIdage = Cmd.ExecuteScalar();
                if (_oIdage.ToString() != "")
                    Idpage = (int)_oIdage;
                Idpage++;

                Cmd.CommandText = " INSERT INTO profile_page VALUES (@idaccount, @idlanguage, @idpage, @name) ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", _idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@idlanguage", _idlanguage));
                Cmd.Parameters.Add(new MySqlParameter("@idpage", Idpage));
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

        public Boolean update()
        { 
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " UPDATE profile_page SET NAME = @name WHERE IDACCOUNT = @idaccount AND IDLANGUAGE = @idlanguage AND IDPAGE = @idpage ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", Idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@idlanguage", Idlanguage));
                Cmd.Parameters.Add(new MySqlParameter("@idpage", Idpage));
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

        public DataTable getSections()
        {
            DataTable _sections = new DataTable();
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " SELECT * FROM page_section WHERE idaccount = @idaccount AND idlanguage = @idlanguage AND idpage = @idpage ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", Idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@idlanguage", Idlanguage));
                Cmd.Parameters.Add(new MySqlParameter("@idpage", Idpage));
                MySqlDataReader _reader = Cmd.ExecuteReader();
                _sections.Load(_reader);
                return _sections;
            }
            catch (Exception)
            {
                return _sections;
            }
            finally
            {
                if (Connection.State == System.Data.ConnectionState.Open)
                    Connection.Close();
            }
        }
    }
}