using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using appProfiles.App_Folders.Classes;

namespace appProfiles.App_Folders.PortalPages
{
    public partial class activeAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cAccount account = new cAccount();
            if (account.activeAccount(Request.Params["activationcode"].ToString()))
            {
                lblActive.Text = "Sucesso!";
            }
            else
                lblActive.Text = "Erro ao ativar";
        }
    }
}