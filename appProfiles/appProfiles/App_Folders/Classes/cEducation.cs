using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace appProfiles.App_Folders.Classes
{
    public class cEducation : cDataBase
    {
        #region variables declarations

        private string school, course;
        private int idEducation, startM, startY, endM, endY;

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

        public int IdEducation
        {
            get { return idEducation; }
            set { idEducation = value; }
        }

        public string Course
        {
            get { return course; }
            set { course = value; }
        }

        public string School
        {
            get { return school; }
            set { school = value; }
        }

        #endregion

        public cEducation()
        { 
        }

        public bool Insert(int _idaccount, int _idlanguage)
        {
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " SELECT MAX(idprofile_resume_school) FROM `profile_resume_school` WHERE idaccount = @idaccount AND idlanguage = @idlanguage ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", _idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@idlanguage", _idlanguage));
                IdEducation = 0;
                Object _oIdEducation = Cmd.ExecuteScalar();
                if (_oIdEducation.ToString() != "")
                    IdEducation = (int)_oIdEducation;
                IdEducation++;

                Cmd.CommandText = "";
                Cmd.CommandText = " INSERT INTO `profile_resume_school` VALUES (@idaccount, @idlanguage, @ideducation, @school, @course, @startm, @starty, @endm, @endy) ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@account", _idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@idlanguage", _idlanguage));
                Cmd.Parameters.Add(new MySqlParameter("@ideducation", IdEducation));
                Cmd.Parameters.Add(new MySqlParameter("@school", School));
                Cmd.Parameters.Add(new MySqlParameter("@course", Course));
                Cmd.Parameters.Add(new MySqlParameter("@startm", StartM));
                Cmd.Parameters.Add(new MySqlParameter("@starty", StartY));
                Cmd.Parameters.Add(new MySqlParameter("@endm", EndM));
                Cmd.Parameters.Add(new MySqlParameter("@endy", EndY));
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

                Cmd.CommandText = " DELETE FROM FROM `profile_resume_school` WHERE idaccount = @idaccount AND idlanguage = @idlanguage AND idprofile_resume_school = @ideducation ";
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

        public bool Update(int _idaccount, int _idlanguage, int _ideducation)
        {
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " UPDATE profile_resume_school` SET school = @school, course = @course, startm = @startm, starty = @starty, endm = @endm, endy = @endy WHERE idaccount = @idaccount AND idlanguage = @idlanguage AND idprofile_resume_school = @ideducation ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", _idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@idlanguage", _idlanguage));
                Cmd.Parameters.Add(new MySqlParameter("@ideducation", _ideducation));
                Cmd.Parameters.Add(new MySqlParameter("@school", School));
                Cmd.Parameters.Add(new MySqlParameter("@course", Course));
                Cmd.Parameters.Add(new MySqlParameter("@startm", StartM));
                Cmd.Parameters.Add(new MySqlParameter("@starty", StartY));
                Cmd.Parameters.Add(new MySqlParameter("@endm", EndM));
                Cmd.Parameters.Add(new MySqlParameter("@endy", EndY));
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

        public DataTable GetEducations(int _idaccount, int _idlanguage)
        {
            DataTable _educations = new DataTable();
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " SELECT * FROM `profile_resume_school` WHERE `idaccount` = @idaccount AND `idlanguage` = @idlanguage ORDER BY endm, endy DESC  ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", _idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@idlanguage", _idlanguage));
                MySqlDataReader _reader = Cmd.ExecuteReader();
                _educations.Load(_reader);
                return _educations;
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