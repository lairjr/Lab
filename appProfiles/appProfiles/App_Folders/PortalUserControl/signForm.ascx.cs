using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using appProfiles.App_Folders.Classes;

namespace appProfiles.App_Folders.PortalUserControl
{
    public partial class signForm : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSendData_Click(object sender, EventArgs e)
        {
            cAccount account = new cAccount();
            account.User.FName = txtFName.Text;
            account.User.LName = txtLName.Text;
            account.AccountName = txtAccountName.Text;
            account.Email = txtEMail.Text;

            account.Login = txtEMail.Text;
            account.Password = txtPassword.Text;
            account.Startdate = DateTime.Now;
            account.Status = 0;
            if (account.insert())
            {
                account.sendWelcomeMail();
            }
            else
            { 
            }
        }
    }
}