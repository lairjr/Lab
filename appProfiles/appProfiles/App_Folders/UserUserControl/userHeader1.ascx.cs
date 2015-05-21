using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using appProfiles.App_Folders.Classes;
using appProfiles.App_Folders.UserMasterPages;

namespace appProfiles.App_Folders.UserUserControl
{
    public partial class userHeader1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    lblUserName.Text = ((UserMasterPages.ImPage1)this.Page.Master).Account.User.FName + " " + ((UserMasterPages.ImPage1)this.Page.Master).Account.User.LName;
                    if (((UserMasterPages.ImPage1)this.Page.Master).Account.User.getAge() > 0)
                        lblAge.Text = ((UserMasterPages.ImPage1)this.Page.Master).Account.User.getAge().ToString() + " ";
                    else
                        lblAge.Text = "";
                    lblYaers.Text = cGlobalResourceObject.getGlobalResource("lblYears", Request.Cookies["userLanguage"].Value).ToLower();
                    lblTitle.Text = ((UserMasterPages.ImPage1)this.Page.Master).Profile.Title;

                    profileLanguages.DataSource = ((UserMasterPages.ImPage1)this.Page.Master).Account.getProfilesLanguages();
                    profileLanguages.DataBind();

                    if (((UserMasterPages.ImPage1)this.Page.Master).Profile.Language.getLanguageById(((UserMasterPages.ImPage1)this.Page.Master).Profile.Language.Idlanguage))
                    {
                        lblLanguage.Text = ((UserMasterPages.ImPage1)this.Page.Master).Profile.Language.Name;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void profileLanguages_ItemCommand(object source, DataListCommandEventArgs e)
        {
            cLanguage language = new cLanguage();
            if (language.getLanguageById(Convert.ToInt32(profileLanguages.DataKeys[e.Item.ItemIndex])))
            {
                HttpCookie cookie = new HttpCookie("userLanguage");
                cookie.Value = language.Code;
                cookie.Expires = DateTime.Now.AddMonths(1);
                Response.Cookies.Add(cookie);
            }

            Response.Redirect("\\" + ((UserMasterPages.ImPage1)this.Page.Master).Account.AccountName);
        }
    }
}