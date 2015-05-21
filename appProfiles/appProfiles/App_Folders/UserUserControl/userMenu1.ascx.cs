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
    public partial class userMenu1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                txtNewPage.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('btnInsertPage').click();return false;}} else {return true}; ");

                if (!IsPostBack)
                {
                    lblResume.Text = cGlobalResourceObject.getGlobalResource("lblResume", Request.Cookies["userLanguage"].Value);
                    lblContact.Text = cGlobalResourceObject.getGlobalResource("lblContact", Request.Cookies["userLanguage"].Value);

                    lnkContact.HRef = "~\\" + ((UserMasterPages.ImPage1)this.Page.Master).Account.AccountName + "\\Contact";
                    lnkResume.HRef = "~\\" + ((UserMasterPages.ImPage1)this.Page.Master).Account.AccountName + "\\Resume";
                    lnkHome.HRef = "~\\" + ((UserMasterPages.ImPage1)this.Page.Master).Account.AccountName;

                    loadPages();
                }
            }
            catch (Exception)
            {
            }
        }

        protected void loadPages()
        {
            pages.DataSource = ((UserMasterPages.ImPage1)this.Page.Master).Profile.getPages();
            pages.DataBind();
        }

        protected void btnInsertPage_Click(object sender, EventArgs e)
        {
            cPage page = new cPage();
            page.Name = txtNewPage.Text;
            page.insert(((UserMasterPages.ImPage1)this.Page.Master).Profile.Idaccount, ((UserMasterPages.ImPage1)this.Page.Master).Profile.Language.Idlanguage);

            loadPages();
            txtNewPage.Text = "";

            Page.ClientScript.RegisterStartupScript(this.GetType(), "setTransparence", "setTransparence();", true);
        }

        protected void pages_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HiddenField id = (HiddenField)e.Item.FindControl("idPage");
            System.Web.UI.HtmlControls.HtmlAnchor pageLink = (System.Web.UI.HtmlControls.HtmlAnchor)e.Item.FindControl("pageLink");
            pageLink.HRef = "/" + ((UserMasterPages.ImPage1)this.Page.Master).Account.AccountName + "/Page/" + id.Value;
        }
    }
}