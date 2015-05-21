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
    public partial class contact1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    lblContactMe.Text = cGlobalResourceObject.getGlobalResource("lblContactMe", Request.Cookies["userLanguage"].Value);
                    lblEmail.Text = cGlobalResourceObject.getGlobalResource("lblEMail", Request.Cookies["userLanguage"].Value);
                    lblMessage.Text = cGlobalResourceObject.getGlobalResource("lblMessage", Request.Cookies["userLanguage"].Value);
                    lblName.Text = cGlobalResourceObject.getGlobalResource("lblName", Request.Cookies["userLanguage"].Value);
                    lblSubject.Text = cGlobalResourceObject.getGlobalResource("lblSubject", Request.Cookies["userLanguage"].Value);

                    Boolean userLogged = false;
                    if (Request.Cookies["userLogged"] != null)
                    {
                        userLogged = Boolean.Parse(Request.Cookies["userLogged"].Value);
                        cAccount userAccount = new cAccount();

                        if (userAccount.getAccountById(int.Parse(Request.Cookies["userAccount"].Value)))
                        {
                            txtName.Text = userAccount.User.FName + " " + userAccount.User.LName;
                            txtEmail.Text = userAccount.Email;
                        }
                    }
                    if (userLogged == false)
                    {
                        txtEmail.Text = "";
                        txtName.Text = "";
                    }
                    txtMessage.Text = "";
                    txtSubject.Text = "";
                    lblResult.Text = "";
                }
            }
            catch (Exception)
            { 
            }
        }

        protected void btnSendMsg_Click(object sender, EventArgs e)
        {
            cMailData mailData = new cMailData(txtName.Text, txtEmail.Text);
            if (((UserMasterPages.ImPage1)this.Page.Master).Account.sendMessage(mailData, txtSubject.Text, txtMessage.Text))
            {
                lblResult.Text = cGlobalResourceObject.getGlobalResource("lblMailSuccess", Request.Cookies["userLanguage"].Value);
            }
            else
            {
                lblResult.Text = cGlobalResourceObject.getGlobalResource("lblMailNotSuccess", Request.Cookies["userLanguage"].Value);
            }
        }
    }
}