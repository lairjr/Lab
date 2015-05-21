using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using appProfiles.App_Folders.Classes;

namespace appProfiles.App_Folders.UserMasterPages
{
    public partial class mPage1 : System.Web.UI.MasterPage, appProfiles.App_Folders.UserMasterPages.ImPage1
    {
        private static cAccount account = new cAccount();
        private static cProfile profile = new cProfile();

        public cAccount Account
        {
            get { return mPage1.account; }
            set { mPage1.account = value; }
        }

        public cProfile Profile
        {
            get { return mPage1.profile; }
            set { mPage1.profile = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (account.getAccountById(int.Parse(Request.Params["idaccount"])))
                    {
                        #region set language

                        if (Request.Cookies["userLanguage"] == null)
                        {
                            HttpCookie cookie = new HttpCookie("userLanguage");
                            cookie.Value = HttpContext.Current.Request.UserLanguages[0];
                            cookie.Expires = DateTime.Now.AddMonths(1);
                            Response.Cookies.Add(cookie);
                        }

                        if (profile.getProfileByLanguage(account.Idaccount, Request.Cookies["userLanguage"].Value))
                        {
                            Page.Title = account.User.FName + " " + account.User.LName + " | Perfil";

                            if (profile.Language.getLanguageById(profile.Language.Idlanguage))
                            {
                                Request.Cookies["userLanguage"].Value = profile.Language.Code;
                            }
                        }

                        #endregion

                        #region setBackground

                        String pathBg = "../../../App_Folders/UserData/" + account.Idaccount + "/bg.jpg";

                        body.Style["background"] = " url(" + pathBg + ") repeat top fixed";

                        Page.ClientScript.RegisterStartupScript(this.GetType(), "setTransparence", "setTransparence();", true);

                        #endregion
                    }
                    else
                    {
                        Response.Redirect("~\\appProfiles\\SingUp");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public bool closeSuperbox()
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alertMe()", true);
            return true;
        }
    }
}