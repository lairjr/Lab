using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using appProfiles.App_Folders.Classes;

namespace appProfiles.App_Folders.PortalUserControl
{
    public partial class bar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Boolean userLogged = false;
            if (Request.Cookies["userLogged"] != null)
            {
                userLogged = Boolean.Parse(Request.Cookies["userLogged"].Value);
                cAccount account = new cAccount();
                if (account.getAccountById(int.Parse(Request.Cookies["userAccount"].Value)))
                {
                    lnkMyProfile.HRef = "~\\" + account.AccountName;
                }
            }
            if (userLogged)
            {
                notLogged.Visible = false;
                logged.Visible = true;
            }
            else
            {
                notLogged.Visible = true;
                logged.Visible = false;
            }
        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            cAccount _account = new cAccount();
            if (_account.checkLogin(txtLogin.Text, txtPassword.Text))
            {
                HttpCookie _cookie = new HttpCookie("userAccount");
                _cookie.Value = _account.Idaccount.ToString();
                _cookie.Expires = DateTime.Now.AddMonths(1);
                Response.Cookies.Add(_cookie);

                _cookie = new HttpCookie("userLogged");
                _cookie.Value = "true";
                _cookie.Expires = DateTime.Now.AddMonths(1);
                Response.Cookies.Add(_cookie);

                if (!_account.hasProfiles())
                {
                    cProfile _profile = new cProfile();
                    _profile.Idaccount = _account.Idaccount;
                    cLanguage _language = new cLanguage();
                    if (_language.getLanguageByCode(HttpContext.Current.Request.UserLanguages[0].Substring(0, 2)))
                    {
                        _profile.Main = 1;
                        _profile.Title = "";
                        _profile.Updated = DateTime.Now;
                        _profile.insert(_account.Idaccount, _language.Idlanguage);
                    }
                }
                Response.Redirect("~\\" + _account.AccountName);
            }
        }

        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("userAccount");
            cookie.Value = "-1";
            cookie.Expires = DateTime.Now.AddMonths(1);
            Response.Cookies.Add(cookie);

            cookie = new HttpCookie("userLogged");
            cookie.Value = "false";
            cookie.Expires = DateTime.Now.AddMonths(1);
            Response.Cookies.Add(cookie);

            Response.Redirect(Request.RawUrl);
        }
    }
}