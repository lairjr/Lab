using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using appProfiles.App_Folders.Classes;

namespace appProfiles.App_Folders.UserUserControl
{
    public partial class userSubTitle1 : System.Web.UI.UserControl
    {
        cSubTitle subTitle = new cSubTitle();

        protected void Page_Load(object sender, EventArgs e)
        {
            int _idaccount = int.Parse(this.Attributes["idaccount"]);
            int _idlanguage = int.Parse(this.Attributes["idlanguage"]);
            int _idpage = int.Parse(this.Attributes["idpage"]);
            int _idcontent = int.Parse(this.Attributes["idcontent"]);
            int _idcontentSection = int.Parse(this.Attributes["idcontent_section"]);
            if (subTitle.getSubTitle(_idaccount, _idlanguage, _idpage, _idcontent, _idcontentSection))
            {
                lblSubtitle.Text = subTitle.SubTitle;
            }
        }

        protected void loadSubTitle()
        {
            if (subTitle.getSubTitle(subTitle.Idaccount, subTitle.Idlanguage, subTitle.Idpage, subTitle.Idcontent, subTitle.IdcontentSection))
            {
                lblSubtitle.Text = subTitle.SubTitle;
            }
        }
    }
}