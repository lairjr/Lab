using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace appProfiles.App_Folders.Classes
{
    public class cContent : cDataBase
    {
        #region variable declarations

        private int idaccount, idlanguage, idpage, idcontent;
        private string title;

        #endregion

        #region basic methods

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public int Idcontent
        {
            get { return idcontent; }
            set { idcontent = value; }
        }

        public int Idpage
        {
            get { return idpage; }
            set { idpage = value; }
        }

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

        #endregion

        public cContent()
        {
        }

        public Boolean insert(int _idaccount, int _idlanguage, int _idpage)
        {
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " SELECT MAX(idcontent) FROM page_content WHERE idaccount = @idaccount AND idlanguage = @idlanguage AND idpage = @idpage ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", _idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@idlanguage", _idlanguage));
                Cmd.Parameters.Add(new MySqlParameter("@idpage", _idpage));
                Idcontent = 0;
                Object _oIcontent = Cmd.ExecuteScalar();
                if (_oIcontent.ToString() != "")
                    Idcontent = (int)_oIcontent;
                Idcontent++;

                Cmd.CommandText = " INSERT INTO page_content VALUES (@idaccount, @idlanguage, @idpage, @idcontent, @title) ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", _idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@idlanguage", _idlanguage));
                Cmd.Parameters.Add(new MySqlParameter("@idpage", _idpage));
                Cmd.Parameters.Add(new MySqlParameter("@idcontent", Idcontent));
                Cmd.Parameters.Add(new MySqlParameter("@title", Title));
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

        public Boolean delete()
        {
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " DELETE FROM page_content WHERE idaccount = @idaccount AND idlanguage = @idlanguage AND idpage = @idpage AND idcontent = @idcontent ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", Idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@idlanguage", Idlanguage));
                Cmd.Parameters.Add(new MySqlParameter("@idpage", Idpage));
                Cmd.Parameters.Add(new MySqlParameter("@idcontent", Idcontent));
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

        public Boolean delete(int _idaccount, int _idlanguage, int _idpage, int _idcontent)
        {
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " DELETE FROM page_content WHERE idaccount = @idaccount AND idlanguage = @idlanguage AND idpage = @idpage AND idcontent = @idcontent ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", _idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@idlanguage", _idlanguage));
                Cmd.Parameters.Add(new MySqlParameter("@idpage", _idpage));
                Cmd.Parameters.Add(new MySqlParameter("@idcontent", _idcontent));
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

                Cmd.CommandText = " UPDATE page_content SET title = @title WHERE idaccount = @idaccount AND idlanguage = @idlanguage AND idpage = @idpage AND idcontent = @idcontent ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", Idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@idlanguage", Idlanguage));
                Cmd.Parameters.Add(new MySqlParameter("@idpage", Idpage));
                Cmd.Parameters.Add(new MySqlParameter("@idcontent", Idcontent));
                Cmd.Parameters.Add(new MySqlParameter("@title", Title));
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

        public Boolean getContent(int _idaccount, int _idlanguage, int _idpage, int _idcontent)
        {
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " SELECT * FROM page_content WHERE idaccount = @idaccount AND idlanguage = @idlanguage AND idpage = @idpage AND idcontent = @idcontent ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", _idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@idlanguage", _idlanguage));
                Cmd.Parameters.Add(new MySqlParameter("@idpage", _idpage));
                Cmd.Parameters.Add(new MySqlParameter("@idcontent", _idcontent));
                MySqlDataReader _reader = Cmd.ExecuteReader();
                if (_reader.Read())
                {
                    Idaccount = _reader.GetInt32("idaccount");
                    Idlanguage = _reader.GetInt32("idlanguage");
                    Idpage = _reader.GetInt32("idpage");
                    Idcontent = _reader.GetInt32("idcontent");
                    Title = _reader.GetString("title");
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

        public DataTable getContents(int _idaccount, int _idlanguage, int _idpage)
        {
            DataTable _contents = new DataTable();
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " SELECT * FROM page_content WHERE idaccount = @idaccount AND idlanguage = @idlanguage AND idpage = @idpage ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", _idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@idlanguage", _idlanguage));
                Cmd.Parameters.Add(new MySqlParameter("@idpage", _idpage));
                MySqlDataReader _reader = Cmd.ExecuteReader();
                _contents.Load(_reader);
                return _contents;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (Connection.State == System.Data.ConnectionState.Open)
                    Connection.Close();
            }
        }
    }
}