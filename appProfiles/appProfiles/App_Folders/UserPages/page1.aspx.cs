using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using appProfiles.App_Folders.Classes;
using appProfiles.App_Folders.UserMasterPages;

namespace appProfiles.App_Folders.UserPages
{
    public partial class page1 : System.Web.UI.Page
    {
        static cPage page = new cPage();

        protected void Page_Load(object sender, EventArgs e)
        {
            txtPageName.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('btnSavePage').click();return false;}} else {return true}; ");

            if (!IsPostBack)
            {
                string _url = Request.RawUrl;

                if (page.getPage(((UserMasterPages.ImPage1)this.Page.Master).Profile.Idaccount, ((UserMasterPages.ImPage1)this.Page.Master).Profile.Language.Idlanguage, cURLFunctions.getPageId(_url)))
                {
                    lblPageName.Text = page.Name;
                    loadContents();
                }
            }
        }

        protected void loadContents()
        {
            cContent content = new cContent();
            contents.DataSource = content.getContents(page.Idaccount, page.Idlanguage, page.Idpage);
            contents.DataBind();
        }

        protected void btnDeletePage_Click(object sender, ImageClickEventArgs e)
        {
            if (page.delete())
            {
                Response.Redirect("\\" + ((UserMasterPages.ImPage1)this.Page.Master).Account.AccountName);
            }
        }

        protected void btnSavePage_Click(object sender, EventArgs e)
        {
            page.Name = txtPageName.Text;
            if (page.update())
            {
                lblPageName.Text = page.Name;
            }
        }

        protected void contents_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            HiddenField _idContent = (HiddenField)e.Item.FindControl("idContent");
            HiddenField _idPage = (HiddenField)e.Item.FindControl("idPage");
            System.Web.UI.HtmlControls.HtmlAnchor _contentLink = (System.Web.UI.HtmlControls.HtmlAnchor)e.Item.FindControl("contentLink");
            _contentLink.HRef = "/" + ((UserMasterPages.ImPage1)this.Page.Master).Account.AccountName + "/Page/" + _idPage.Value + "/Content/" + _idContent.Value;
        }

        protected void btnNewContent_Click(object sender, EventArgs e)
        {
            cContent content = new cContent();
            content.Title = "New Content";
            if (content.insert(page.Idaccount, page.Idlanguage, page.Idpage))
            { 
                Response.Redirect("/" + ((UserMasterPages.ImPage1)this.Page.Master).Account.AccountName + "/Page/" + page.Idpage + "/Content/" + content.Idcontent);
            }
        }
    }
}