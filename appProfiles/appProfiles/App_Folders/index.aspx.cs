using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appProfiles.App_Folders
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("\\LairJr");
            //Response.Redirect("\\LairJr\\Page\\1\\Content\\1");
        }
    }
}