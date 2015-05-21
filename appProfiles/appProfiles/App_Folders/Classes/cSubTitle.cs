using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace appProfiles.App_Folders.Classes
{
    public class cSubTitle : cDataBase
    {
        #region variables declarations

        private string subTitle;
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

        public string SubTitle
        {
            get { return subTitle; }
            set { subTitle = value; }
        }

        #endregion

        public cSubTitle()
        { 
        }

        public bool getSubTitle(int _idaccount, int _idlanguage, int _idpage, int _idcontent, int _idcontentSection)
        {
            try
            {
                if (Connection.State != System.Data.ConnectionState.Open)
                    Connection.Open();

                Cmd.CommandText = " SELECT * FROM section_subtitle WHERE idaccount = @idaccount AND idlanguage = @idlanguage AND idpage = @idpage AND idcontent = @idcontent AND idcontent_section = @idcontent_section ";
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
                    SubTitle = _reader.GetString("subtitle");
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