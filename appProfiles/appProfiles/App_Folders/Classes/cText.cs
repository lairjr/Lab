using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace appProfiles.App_Folders.Classes
{
    public class cText : cDataBase
    {
        #region variables declarations

        private string text;
        private int idaccount, idlanguage, idpage, idcontent, idcontentSection;

        #endregion

        #region basic methods

        public int IdcontentSection
        {
            get { return idcontentSection; }
            set { idcontentSection = value; }
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

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        #endregion

        public cText()
        { 
        }

        public bool delete()
        {
            try
            {
                if (Connection.State != System.Data.ConnectionState.Open)
                    Connection.Open();

                Cmd.CommandText = " DELETE FROM section_text WHERE idaccount = @idaccount AND idlanguage = @idlanguage AND idpage = @idpage AND idcontent = @idcontent AND idcontent_section = @idcontent_section ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", Idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@idlanguage", Idlanguage));
                Cmd.Parameters.Add(new MySqlParameter("@idpage", Idpage));
                Cmd.Parameters.Add(new MySqlParameter("@idcontent", Idcontent));
                Cmd.Parameters.Add(new MySqlParameter("@idcontent_section", IdcontentSection));
                Cmd.ExecuteNonQuery();

                Cmd.CommandText = " DELETE FROM content_section WHERE idaccount = @idaccount AND idlanguage = @idlanguage AND idpage = @idpage AND idcontent = @idcontent AND idcontent_section = @idcontent_section ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", Idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@idlanguage", Idlanguage));
                Cmd.Parameters.Add(new MySqlParameter("@idpage", Idpage));
                Cmd.Parameters.Add(new MySqlParameter("@idcontent", Idcontent));
                Cmd.Parameters.Add(new MySqlParameter("@idcontent_section", IdcontentSection));
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

        public bool getText(int _idaccount, int _idlanguage, int _idpage, int _idcontent, int _idcontentSection)
        {
            try
            {
                if (Connection.State != System.Data.ConnectionState.Open)
                    Connection.Open();

                Cmd.CommandText = " SELECT * FROM section_text WHERE idaccount = @idaccount AND idlanguage = @idlanguage AND idpage = @idpage AND idcontent = @idcontent AND idcontent_section = @idcontent_section ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", _idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@idlanguage", _idlanguage));
                Cmd.Parameters.Add(new MySqlParameter("@idpage", _idpage));
                Cmd.Parameters.Add(new MySqlParameter("@idcontent", _idcontent));
                Cmd.Parameters.Add(new MySqlParameter("@idcontent_section", _idcontentSection));
                MySqlDataReader _reader = Cmd.ExecuteReader();
                if (_reader.Read())
                {
                    Idaccount = _reader.GetInt32("idaccount");
                    Idlanguage = _reader.GetInt32("idlanguage");
                    Idpage = _reader.GetInt32("idpage");
                    Idcontent = _reader.GetInt32("idcontent");
                    IdcontentSection = _reader.GetInt32("idcontent_section");
                    Text = _reader.GetString("text");
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

        public bool insert(int _idaccount, int _idlanguage, int _idpage, int _idcontent)
        {
            try
            {
                if (Connection.State != System.Data.ConnectionState.Open)
                    Connection.Open();

                cContentSection _contentSection = new cContentSection();
                if (_contentSection.insert(_idaccount, _idlanguage, _idpage, _idcontent))
                {
                    Cmd.CommandText = " INSERT INTO section_text VALUES (@idaccount, @idlanguage, @idpage, @idcontent, @idcontent_section, @text) ";
                    Cmd.Parameters.Clear();
                    Cmd.Parameters.Add(new MySqlParameter("@idaccount", _contentSection.Idaccount));
                    Cmd.Parameters.Add(new MySqlParameter("@idlanguage", _contentSection.Idlanguage));
                    Cmd.Parameters.Add(new MySqlParameter("@idpage", _contentSection.Idpage));
                    Cmd.Parameters.Add(new MySqlParameter("@idcontent", _contentSection.Idcontent));
                    Cmd.Parameters.Add(new MySqlParameter("@idcontent_section", _contentSection.IdcontentSection));
                    Cmd.Parameters.Add(new MySqlParameter("@text", Text));
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

        public bool update()
        {
            try
            {
                if (Connection.State != System.Data.ConnectionState.Open)
                    Connection.Open();

                Cmd.CommandText = " UPDATE section_text SET text = @text WHERE idaccount = @idaccount AND idlanguage = @idlanguage AND idpage = @idpage AND idcontent = @idcontent AND idcontent_section = @idcontent_section ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", Idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@idlanguage", Idlanguage));
                Cmd.Parameters.Add(new MySqlParameter("@idpage", Idpage));
                Cmd.Parameters.Add(new MySqlParameter("@idcontent", Idcontent));
                Cmd.Parameters.Add(new MySqlParameter("@idcontent_section", IdcontentSection));
                Cmd.Parameters.Add(new MySqlParameter("@text", Text));
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