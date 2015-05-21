using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using appProfiles.App_Folders.Classes;

namespace appProfiles.App_Folders.PortalPages
{
    public partial class editAccount : System.Web.UI.Page
    {
        static cAccount account = new cAccount();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (account.getAccountById(int.Parse(Request.Params["idaccount"])))
                    {
                        txtFName.Text = account.User.FName;
                        txtLName.Text = account.User.LName;
                        if (account.User.BirthDate != null)
                        {
                            txtDBirh.Text = account.User.BirthDate.Day.ToString();
                            txtMBirh.Text = account.User.BirthDate.Month.ToString();
                            txtYBirh.Text = account.User.BirthDate.Year.ToString();
                        }
                    }
                }
            }
            catch (Exception)
            { 
            }
        }

        protected void btnSavePersonalInfo_Click(object sender, EventArgs e)
        {
            account.User.FName = txtFName.Text;
            account.User.LName = txtLName.Text;
            if ((txtDBirh.Text.Length > 0) && (txtMBirh.Text.Length > 0) && (txtYBirh.Text.Length > 0))
            {
                account.User.BirthDate = new DateTime(int.Parse(txtYBirh.Text), int.Parse(txtMBirh.Text), int.Parse(txtDBirh.Text));
            }
            if (account.update())
            { 
            }
        }
    }
}