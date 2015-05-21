using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace appProfiles.App_Folders.Classes
{
    public class cContentSection : cDataBase
    {
        #region variables declaration

        private int idaccount, idlanguage, idpage, idcontent, idcontentSection, sequence, idsection;

        #endregion

        #region basic methods

        public int Idsection
        {
            get { return idsection; }
            set { idsection = value; }
        }

        public int Sequence
        {
            get { return sequence; }
            set { sequence = value; }
        }

        public int Idpage
        {
            get { return idpage; }
            set { idpage = value; }
        }

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

        public cContentSection()
        { 
        }

        public bool insert(int _idaccount, int _idlanguage, int _idpage, int _idcontent)
        {
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Idaccount = _idaccount;
                Idlanguage = _idlanguage;
                Idpage = _idpage;
                Idcontent = _idcontent;

                Cmd.CommandText = " SELECT MAX(idcontent_section), MAX(sequence) FROM content_section WHERE idaccount = @idaccount AND idlanguage = @idlanguage AND idpage = @idpag AND idcontent = @idcontent ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", Idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@idlanguage", Idlanguage));
                Cmd.Parameters.Add(new MySqlParameter("@idpage", Idpage));
                Cmd.Parameters.Add(new MySqlParameter("@idcontent", Idcontent));
                IdcontentSection = 0;
                Sequence = 0;
                MySqlDataReader _reader = Cmd.ExecuteReader();
                if (_reader.Read())
                {
                    if (!_reader.IsDBNull(0))
                        IdcontentSection = _reader.GetInt32(0);
                    if (!_reader.IsDBNull(1))
                        Sequence = _reader.GetInt32(1);
                }
                IdcontentSection++;
                Sequence++;

                Cmd.CommandText = " INSERT INTO content_section VALUES (@idaccount, @idlanguage, @idpage, @idcontent, @idcontent_section, @sequence, @idsection) ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", Idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@idlanguage", Idlanguage));
                Cmd.Parameters.Add(new MySqlParameter("@idpage", Idpage));
                Cmd.Parameters.Add(new MySqlParameter("@idcontent", Idcontent));
                Cmd.Parameters.Add(new MySqlParameter("@idcontent_section", IdcontentSection));
                Cmd.Parameters.Add(new MySqlParameter("@sequence", Sequence));
                Cmd.Parameters.Add(new MySqlParameter("@idsection", Idsection));
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

        public DataTable getContentSections(int _idaccount, int _idlanguage, int _idpage, int _idcontent)
        {
            DataTable _contentSections = new DataTable();
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " SELECT * FROM content_section WHERE idaccount = @idaccount AND idlanguage = @idlanguage AND idpage = @idpage AND idcontent = @idcontent ORDER BY sequence ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", _idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@idlanguage", _idlanguage));
                Cmd.Parameters.Add(new MySqlParameter("@idpage", _idpage));
                Cmd.Parameters.Add(new MySqlParameter("@idcontent", _idcontent));
                
                MySqlDataReader _reader = Cmd.ExecuteReader();
                _contentSections.Load(_reader);
                return _contentSections;
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