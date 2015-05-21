using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using appProfiles.App_Folders.Classes;

namespace appProfiles
{
    public class Global : System.Web.HttpApplication
    {
        static String account_name = "";

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string _path = Context.Request.Path;

            // Removing last bar
            if (_path.EndsWith("/"))
                Response.Redirect(_path.Substring(0, _path.Length - 1));

            _path = _path.ToLower();

            if ((!_path.EndsWith(".aspx")) && (!_path.EndsWith(".css")) && (!_path.EndsWith(".png")) && (!_path.EndsWith(".gif")) && (!_path.EndsWith(".jpg")) && (!_path.EndsWith(".js")) && (!_path.EndsWith(".html")) && (!_path.EndsWith(".cs")) && (!_path.EndsWith(".xml")) && (!_path.EndsWith(".htc")) && (!_path.EndsWith(".asmx")) && (!_path.EndsWith(".axd")))
            {
                // Treating friendly URLs
                int _control_field = 0;
                int _idaccount = -1;
                account_name = "";
                string _page = "";
                for (int x = 0; x < _path.Length; x++)
                {
                    if (_path[x] == Char.Parse("/"))
                    {
                        _control_field++;
                        if ((_control_field % 2) == 0)
                            _page = "";
                    }
                    else
                    {
                        if (_control_field == 1)
                        {
                            account_name = account_name + _path[x].ToString();
                        }
                        if (_control_field == 2)
                        {
                            _page = _page + _path[x].ToString();
                        }
                        if (_control_field == 4)
                        {
                            _page = _page + _path[x].ToString();
                        }
                    }
                }

                #region appProfiles

                if (account_name == "appprofiles")
                {
                    if (_page.Length == 0)
                        Context.RewritePath("~/App_Folders/PortalPages/home1.aspx", false);
                    else
                    {
                        switch (_page)
                        {
                            case "signup":
                                Context.RewritePath("~/App_Folders/PortalPages/singup.aspx", false);
                                break;
                            case "edituser":
                                Context.RewritePath("~/App_Folders/PortalPages/editAccount.aspx", false);
                                break;
                            default:
                                Context.RewritePath("~/App_Folders/PortalPages/home1.aspx", false);
                                break;
                        }
                    }
                }

                #endregion

                #region User

                else
                {
                    cAccount account = new cAccount();
                    if (account.getAccountByAccountName(account_name))
                    {
                        _idaccount = account.Idaccount;
                    }
                    /*if (iduser_url == "lairjr")
                        iduser = 1;
                    if (iduser_url == "bt")
                        iduser = 2;*/
                    if (_page.Length == 0)
                        Context.RewritePath("~/App_Folders/UserPages/home1.aspx?idaccount=" + _idaccount, false);
                    else
                    {
                        switch (_page)
                        {
                            case "page":
                                Context.RewritePath("~/App_Folders/UserPages/page1.aspx?idaccount=" + _idaccount, false);
                                break;
                            case "contact":
                                Context.RewritePath("~/App_Folders/UserPages/contact1.aspx?idaccount=" + _idaccount, false);
                                break;
                            case "resume":
                                Context.RewritePath("~/App_Folders/UserPages/resume1.aspx?idaccount=" + _idaccount, false);
                                break;
                            case "section":
                                Context.RewritePath("~/App_Folders/UserPages/section1.aspx?idaccount=" + _idaccount, false);
                                break;
                            case "content":
                                Context.RewritePath("~/App_Folders/UserPages/content1.aspx?idaccount=" + _idaccount, false);
                                break;
                            default:
                                Context.RewritePath("~/App_Folders/PortalPages/home1.aspx", false);
                                break;
                        }
                    }
                }

                #endregion
            }
            else
            {
                if (account_name.Length != 0)
                {
                    if (_path.StartsWith("/" + account_name))
                        Response.Redirect(_path.Substring(account_name.Length + 1, _path.Length - account_name.Length - 1));
                }
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}