using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace appProfiles.App_Folders.Classes
{
    public class cProfExp : cDataBase
    {
        
        #region variables declarations

        private string companyName, jobName, jobDescription;
        private int idProfExp, startM, startY, endM, endY;

        public int EndY
        {
            get { return endY; }
            set { endY = value; }
        }

        public int EndM
        {
            get { return endM; }
            set { endM = value; }
        }

        public int StartY
        {
            get { return startY; }
            set { startY = value; }
        }

        public int StartM
        {
            get { return startM; }
            set { startM = value; }
        }

        public string JobName
        {
            get { return jobName; }
            set { jobName = value; }
        }

        public string JobDescription
        {
            get { return jobDescription; }
            set { jobDescription = value; }
        }

        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }

        public int IdProfExp
        {
            get { return idProfExp; }
            set { idProfExp = value; }
        }

        #endregion

        public cProfExp()
        { 
        }

        public bool Insert(int _idaccount, int _idlanguage)
        {
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " SELECT MAX(idpage) FROM profile_page WHERE idaccount = @idaccount AND idlanguage = @idlanguage ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", _idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@idlanguage", _idlanguage));
                IdProfExp = 0;
                Object _oIdProfExp = Cmd.ExecuteScalar();
                if (_oIdProfExp.ToString() != "")
                    IdProfExp = (int)_oIdProfExp;
                IdProfExp++;

                Cmd.CommandText = "";
                Cmd.CommandText = " INSERT INTO ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@", _idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@", _idlanguage));
                Cmd.Parameters.Add(new MySqlParameter("@", IdProfExp));
                Cmd.Parameters.Add(new MySqlParameter("@", CompanyName));
                Cmd.Parameters.Add(new MySqlParameter("@", JobName));
                Cmd.Parameters.Add(new MySqlParameter("@", JobDescription));
                Cmd.Parameters.Add(new MySqlParameter("@", StartM));
                Cmd.Parameters.Add(new MySqlParameter("@", StartY));
                Cmd.Parameters.Add(new MySqlParameter("@", EndM));
                Cmd.Parameters.Add(new MySqlParameter("@", EndY));
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

        public bool Delete(int _idaccount, int _idlanguage, int _ideducation)
        {
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " DELETE FROM ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@", _idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@", _idlanguage));
                Cmd.Parameters.Add(new MySqlParameter("@", _ideducation));
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

        public bool Update(int _idaccount, int _idlanguage)
        {
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " DELETE FROM ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@", _idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@", _idlanguage));
                Cmd.Parameters.Add(new MySqlParameter("@", IdProfExp));
                Cmd.Parameters.Add(new MySqlParameter("@", JobName));
                Cmd.Parameters.Add(new MySqlParameter("@", CompanyName));
                Cmd.Parameters.Add(new MySqlParameter("@", JobDescription));
                Cmd.Parameters.Add(new MySqlParameter("@", StartM));
                Cmd.Parameters.Add(new MySqlParameter("@", StartY));
                Cmd.Parameters.Add(new MySqlParameter("@", EndM));
                Cmd.Parameters.Add(new MySqlParameter("@", EndY));
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

        public DataTable GetProfessionalExperiences(int _idaccount, int _idlanguage)
        {
            DataTable _profExps = new DataTable();
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " SELECT * FROM `profile_resume_profexp` WHERE `idaccount` = @idaccount AND `idlanguage` = @idlanguage ORDER BY endm, endy DESC ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", _idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@idlanguage", _idlanguage));
                MySqlDataReader _reader = Cmd.ExecuteReader();
                _profExps.Load(_reader);
                return _profExps;
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