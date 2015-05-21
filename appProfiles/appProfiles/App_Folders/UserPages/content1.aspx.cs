using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using appProfiles.App_Folders.Classes;
using System.Data;
using System.Web.UI.HtmlControls;

namespace appProfiles.App_Folders.UserPages
{
    public partial class content1 : System.Web.UI.Page
    {
        static cContent content = new cContent();
        private static int idSection = 0; // this gonna define which kind of UserControl it's gonna be added in the end of the page to the user add a new section

        protected void Page_Load(object sender, EventArgs e)
        {
            txtContentName.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('btnSaveContent').click();return false;}} else {return true}; ");

            if (!IsPostBack)
            {
                string _url = Request.RawUrl;

                if (content.getContent(((UserMasterPages.ImPage1)this.Page.Master).Profile.Idaccount, ((UserMasterPages.ImPage1)this.Page.Master).Profile.Language.Idlanguage, cURLFunctions.getPageId(_url), cURLFunctions.getContentId(_url)))
                {
                    lblContentName.Text = content.Title;
                    loadSection();
                }
            }
            else
            {
             //   createControls();
            }
        }

        protected void btnSaveContent_Click(object sender, EventArgs e)
        {
            content.Title = txtContentName.Text;
            if (content.update())
            {
                lblContentName.Text = content.Title;
            }
        }

        protected void loadSection()
        {
            cContentSection _contentSection = new cContentSection();
            sections.DataSource = _contentSection.getContentSections(content.Idaccount, content.Idlanguage, content.Idpage, content.Idcontent);
            sections.DataBind();
        }

        protected void sections_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) && (e.Item.DataItem != null))
            {
                DataRowView _row = (DataRowView)e.Item.DataItem;
                int _idsection = int.Parse(_row[6].ToString());
                int _idcontentSection = int.Parse(_row[4].ToString());
                HtmlGenericControl _divHolder = (HtmlGenericControl)e.Item.FindControl("holder");
                switch (_idsection)
                {
                    case 1: // Text
                        UserControl _userControlText = (UserControl)LoadControl("~\\App_Folders\\UserUserControl\\userText1.ascx");
                        _userControlText.Attributes.Add("idaccount", content.Idaccount.ToString());
                        _userControlText.Attributes.Add("idlanguage", content.Idlanguage.ToString());
                        _userControlText.Attributes.Add("idpage", content.Idpage.ToString());
                        _userControlText.Attributes.Add("idcontent", content.Idcontent.ToString());
                        _userControlText.Attributes.Add("idcontent_section", _idcontentSection.ToString());
                        _divHolder.Controls.Add(_userControlText);
                        break;
                    case 2: // Sub Title
                        UserControl _userControlSubTitle = (UserControl)LoadControl("~\\App_Folders\\UserUserControl\\userSubTitle1.ascx");
                        _userControlSubTitle.Attributes.Add("idaccount", content.Idaccount.ToString());
                        _userControlSubTitle.Attributes.Add("idlanguage", content.Idlanguage.ToString());
                        _userControlSubTitle.Attributes.Add("idpage", content.Idpage.ToString());
                        _userControlSubTitle.Attributes.Add("idcontent", content.Idcontent.ToString());
                        _userControlSubTitle.Attributes.Add("idcontent_section", _idcontentSection.ToString());
                        _divHolder.Controls.Add(_userControlSubTitle);
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    default:
                        break;
                }
            } 
        }

        protected void createControls()
        {
            switch (idSection)
            {
                case 1: // Text
                    UserControl _userControlText = (UserControl)LoadControl("~\\App_Folders\\UserUserControl\\userText1.ascx");
                    _userControlText.Attributes.Add("idaccount", content.Idaccount.ToString());
                    _userControlText.Attributes.Add("idlanguage", content.Idlanguage.ToString());
                    _userControlText.Attributes.Add("idpage", content.Idpage.ToString());
                    _userControlText.Attributes.Add("idcontent", content.Idcontent.ToString());
                    _userControlText.Attributes.Add("idcontent_section", "new");
                    add_section_div.Controls.Add(_userControlText);
                    break;
                case 2: // Subtitle
                    UserControl _userControlSubTitle = (UserControl)LoadControl("~\\App_Folders\\UserUserControl\\userSubTitle1.ascx");
                    _userControlSubTitle.Attributes.Add("idaccount", content.Idaccount.ToString());
                    _userControlSubTitle.Attributes.Add("idlanguage", content.Idlanguage.ToString());
                    _userControlSubTitle.Attributes.Add("idpage", content.Idpage.ToString());
                    _userControlSubTitle.Attributes.Add("idcontent", content.Idcontent.ToString());
                    _userControlSubTitle.Attributes.Add("idcontent_section", "new");
                    add_section_div.Controls.Add(_userControlSubTitle);
                    break;
                default:
                    break;
            }
        }

        protected void lnkAddText_Click(object sender, EventArgs e)
        {
            idSection = 1;
        }

        protected void lnkAddSubTitle_Click(object sender, EventArgs e)
        {
            idSection = 2;
        }
    }
}