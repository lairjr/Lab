using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using appProfiles.App_Folders.Classes;

namespace appProfiles.App_Folders.UserUserControl
{
    public partial class userText1 : System.Web.UI.UserControl
    {
        cText text = new cText();
        private static string controlNew;
        private static int idaccount, idlanguage, idpage, idcontent, idcontentSection;

        protected void Page_Load(object sender, EventArgs e)
        {
            idaccount = int.Parse(this.Attributes["idaccount"]);
            idlanguage = int.Parse(this.Attributes["idlanguage"]);
            idpage = int.Parse(this.Attributes["idpage"]);
            idcontent = int.Parse(this.Attributes["idcontent"]);

            controlNew = this.Attributes["idcontent_section"];
            if (controlNew == "new")
            {
                lblText.Visible = false;
                txtText.Visible = true;
                btnSaveText.Visible = true;
            }
            else
            {
                lblText.Visible = true;
                //txtText.Visible = false;
                //btnSaveText.Visible = false;
                idcontentSection = int.Parse(this.Attributes["idcontent_section"]);
                if (text.getText(idaccount, idlanguage, idpage, idcontent, idcontentSection))
                {
                    lblText.Text = text.Text;
                }
            }
        }

        protected void loadText()
        {
            if (text.getText(text.Idaccount, text.Idlanguage, text.Idpage, text.Idcontent, text.IdcontentSection))
            {
                lblText.Text = text.Text; 
            }
        }

        protected void btnSaveText_Click(object sender, EventArgs e)
        {
            text.Text = txtText.Text;
            if (controlNew == "new")
            {
                if (text.insert(idaccount, idlanguage, idpage, idcontent))
                {
                    controlNew = "";
                }
            }
            else
            {
                if (text.update())
                { 
                }
            }
        }
    }
}