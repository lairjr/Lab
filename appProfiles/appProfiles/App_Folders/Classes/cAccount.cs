using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace appProfiles.App_Folders.Classes
{
    public class cAccount : cDataBase
    {
        #region variables declaretions

        private cPerson user;
        private DateTime startdate, enddate;
        private int idaccount;
        private int status; // 0 - Not Actived,  1 - Actived
        private string accountName, login, password, email;

        #endregion

        #region basic methods

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string AccountName
        {
            get { return accountName; }
            set { accountName = value; }
        }

        public cPerson User
        {
            get { return user; }
            set { user = value; }
        }

        public DateTime Startdate
        {
            get { return startdate; }
            set { startdate = value; }
        }

        public DateTime Enddate
        {
            get { return enddate; }
            set { enddate = value; }
        }

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        public int Idaccount
        {
            get { return idaccount; }
            set { idaccount = value; }
        }

        #endregion

        public cAccount()
        {
            user = new cPerson();
        }

        public Boolean activeAccount(string _activationCode)
        {
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " UPDATE account SET STATUS = 1 WHERE idaccount = (SELECT idaccount FROM account_login WHERE activationcode = @activationcode) ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@activationcode", _activationCode));

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

        public Boolean checkLogin(string _login, string _password)
        {
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " SELECT idaccount FROM account WHERE idaccount = (SELECT idaccount FROM account_login WHERE login = @login AND password = @password) AND wtatus = 1 ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@login", _login));
                Cmd.Parameters.Add(new MySqlParameter("@password", _password));
                MySqlDataReader _reader = Cmd.ExecuteReader();
                if (_reader.Read())
                {
                    Idaccount = _reader.GetInt32("idaccount");
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

        public Boolean getAccountByAccountName(string _accountName)
        {
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " SELECT * FROM account_name WHERE accountname = @accountname ";
                Cmd.Parameters.Add(new MySqlParameter("@accountname", _accountName));

                MySqlDataReader _reader = Cmd.ExecuteReader();
                if (_reader.Read())
                {
                    int _idaccount = _reader.GetInt32("idaccount");

                    _reader.Close();
                    if (getAccountById(_idaccount))
                        return true;
                    else
                        return false;
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

        public Boolean getAccountById(int _idaccount)
        {
            try
            {
                if (Connection.State != System.Data.ConnectionState.Open)
                    Connection.Open();

                Cmd.CommandText = " SELECT *, account_login.login, account_login.password, account_login.activationcode, account_name.accountname FROM account, account_login, account_name WHERE account.idaccount = @idaccount AND account.idaccount = account_login.idaccount AND account.idaccount = account_name.idaccount  ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", _idaccount));

                MySqlDataReader _reader = Cmd.ExecuteReader();
                if (_reader.Read())
                {
                    user.FName = _reader.GetString("fname");
                    user.LName = _reader.GetString("lname");
                    user.BirthDate = _reader.GetDateTime("birthdate");

                    Idaccount = _reader.GetInt32("idaccount");
                    Startdate = _reader.GetDateTime("startdate");
                    if (_reader["enddate"] != DBNull.Value)
                        Enddate = _reader.GetDateTime("enddate");
                    Status = _reader.GetInt32("status");
                    Login = _reader.GetString("login");
                    AccountName = _reader.GetString("accountname");
                    Password = _reader.GetString("password");
                    if (_reader["email"] != DBNull.Value)
                        Email = _reader.GetString("email");
                    else
                        Email = "";
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

        public Boolean hasProfiles()
        {
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " SELECT COUNT(idaccount) FROM profile WHERE idaccount = @idaccount ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", Idaccount));
                MySqlDataReader _reader = Cmd.ExecuteReader();
                if (_reader.Read())
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

        public Boolean insert()
        {
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " INSERT INTO account VALUES (NULL, @fname, @lname, @startdate, @enddate, @a_status, @birthdate, @localcountry, @localcity, @birthcountry, @birthcity, @email) ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@fname", user.FName));
                Cmd.Parameters.Add(new MySqlParameter("@lname", user.LName));
                Cmd.Parameters.Add(new MySqlParameter("@startdate", Startdate));
                Cmd.Parameters.Add(new MySqlParameter("@enddate", Enddate));
                Cmd.Parameters.Add(new MySqlParameter("@a_status", Status));
                Cmd.Parameters.Add(new MySqlParameter("@birthdate", user.BirthDate));
                Cmd.Parameters.Add(new MySqlParameter("@localcountry", 1));
                Cmd.Parameters.Add(new MySqlParameter("@localcity", 1));
                Cmd.Parameters.Add(new MySqlParameter("@birthcountry", 1));
                Cmd.Parameters.Add(new MySqlParameter("@birthcity", 1));
                Cmd.Parameters.Add(new MySqlParameter("@email", Email));

                Cmd.ExecuteNonQuery();

                Idaccount = (int)Cmd.LastInsertedId;

                Cmd.CommandText = " INSERT INTO account_login VALUES (@idaccount, @login, @activationcode, @senha) ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", Idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@login", Login));
                Cmd.Parameters.Add(new MySqlParameter("@activationcode", getActivationCode()));
                Cmd.Parameters.Add(new MySqlParameter("@senha", Password));
                Cmd.ExecuteNonQuery();

                Cmd.CommandText = " INSERT INTO account_name VALUES (@idaccount, @accountname) ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", Idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@accountname", AccountName));
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

        public Boolean insertAccountName()
        {
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " SELECT * FROM account_name WHERE idaccount = @idaccount ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", Idaccount));
                MySqlDataReader _reader = Cmd.ExecuteReader();
                if (!_reader.Read())
                {
                    _reader.Close();
                    Cmd.CommandText = " INSERT INTO account_name VALUES (@idaccount, @accountname) ";
                    Cmd.Parameters.Clear();
                    Cmd.Parameters.Add(new MySqlParameter("@idaccount", Idaccount));
                    Cmd.Parameters.Add(new MySqlParameter("@accountname", AccountName));
                    Cmd.ExecuteNonQuery();
                    return true;
                }
                else
                    return false;
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

        public Boolean sendWelcomeMail()
        {
            try
            {
                cMail _mail = new cMail();
                _mail.Message = "Welcome, please active your account <a href=\"http://localhost:53109/App_Folders/PortalPages/activeAccount.aspx?activationcode=" + getActivationCode() + "\">here</a>";
                _mail.Message.Replace("\n", "<br />");
                _mail.Subject = "Welcome to appProfiles";
                _mail.Sender = new cMailData("appProfiles", "lairjr@hotmail.com");
                _mail.Receiver = new cMailData(user.FName + " " + user.LName, Login);
                if (_mail.send())
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
        }

        public Boolean sendMessage(cMailData _sender, string _subject, string _message)
        {
            try
            {
                cMail _mail = new cMail();
                _mail.Message = _message;
                _mail.Message.Replace("\n", "<br />");
                _mail.Subject = _subject;
                _mail.Sender = _sender;
                if (Email != "")
                    _mail.Receiver = new cMailData(user.FName + " " + user.LName, Email);
                else
                    _mail.Receiver = new cMailData(user.FName + " " + user.LName, Login);
                if (_mail.send())
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
        }

        public Boolean update()
        {
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " UPDATE account SET fname = @fname, lname = @lname, startdate = @startdate, enddate = @enddate, status = @a_status, birthdate = @birthdate, localcountry = @localcounty, localcity = @localcity, birthcountry = @birthcounty, birthcity = @birthcity WHERE idaccount = @idaccount ";
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", Idaccount));
                Cmd.Parameters.Add(new MySqlParameter("@fname", user.FName));
                Cmd.Parameters.Add(new MySqlParameter("@lname", user.LName));
                Cmd.Parameters.Add(new MySqlParameter("@startdate", Startdate));
                Cmd.Parameters.Add(new MySqlParameter("@enddate", Enddate));
                Cmd.Parameters.Add(new MySqlParameter("@a_status", Status));
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

        public DataTable getProfilesLanguages()
        {
            DataTable _profiles = new DataTable();
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " SELECT profile.idlanguage, `language`.`name` FROM `language`, profile WHERE profile.idaccount = @idaccount AND profile.idlanguage = `language`.idlanguage ORDER BY `language`.name ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", Idaccount));

                MySqlDataReader _reader = Cmd.ExecuteReader();
                _profiles.Load(_reader);
                _reader.Close();
                return _profiles;
            }
            catch (Exception)
            {
                return _profiles;
            }
            finally
            {
                if (Connection.State == System.Data.ConnectionState.Open)
                    Connection.Close();
            }
        }

        public DataTable getNetworks()
        {
            DataTable _networks = new DataTable();
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " SELECT account_network.*, network.name, network.path_logo FROM account_network, network WHERE account_network.idaccount = @idaccount AND account_network.network = network.idnetwork ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", Idaccount));
                MySqlDataReader _reader = Cmd.ExecuteReader();
                _networks.Load(_reader);
                return _networks;
            }
            catch (Exception)
            {
                return _networks;
            }
            finally
            {
                if (Connection.State == System.Data.ConnectionState.Open)
                    Connection.Close();
            }
        }

        public int checkProfileByLanguage(string _language)
        {
            int _idprofile = -1;
            try
            {
                if (Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();

                Cmd.CommandText = " SELECT * FROM account_profile WHERE idaccount = @idaccount AND language = @language ";
                Cmd.Parameters.Clear();
                Cmd.Parameters.Add(new MySqlParameter("@language", _language));
                Cmd.Parameters.Add(new MySqlParameter("@idaccount", Idaccount));
                MySqlDataReader _reader = Cmd.ExecuteReader();
                if (_reader.Read())
                {
                    _idprofile = _reader.GetInt32("IDPROFILE");
                    _reader.Close();
                }
                else
                {
                    _reader.Close();
                    Cmd.CommandText = " SELECT * FROM account_profile WHERE idaccount = @idaccount AND main = 1 ";
                    Cmd.Parameters.Clear();
                    Cmd.Parameters.Add(new MySqlParameter("@idaccount", Idaccount));
                    _reader = Cmd.ExecuteReader();
                    if (_reader.Read())
                    {
                        _idprofile = _reader.GetInt32("IDPROFILE");
                    }
                    _reader.Close();
                }
                return _idprofile;
            }
            catch (Exception)
            {
                return _idprofile;
            }
            finally
            {
                if (Connection.State == System.Data.ConnectionState.Open)
                    Connection.Close();
            }
        }

        public string getActivationCode()
        {
            string _activationCode = "";
            _activationCode = Idaccount.ToString() + Login;
            return _activationCode;
        }
    }
}