using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace OwnDone
{
    public class Global : System.Web.HttpApplication
    {
        static String iduser_url = "";

        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            String path = Context.Request.Path;

            // Removendo última barra
            if (path.EndsWith("/"))
                Response.Redirect(path.Substring(0, path.Length - 1));

            path = path.ToLower();

            if ((!path.EndsWith(".aspx")) && (!path.EndsWith(".css")) && (!path.EndsWith(".png")) && (!path.EndsWith(".gif")) && (!path.EndsWith(".jpg")) && (!path.EndsWith(".js")) && (!path.EndsWith(".html")) && (!path.EndsWith(".cs")) && (!path.EndsWith(".xml")) && (!path.EndsWith(".htc")) && (!path.EndsWith(".asmx")) && (!path.EndsWith(".axd")))
            {
                // Tratando URL amigáveis
                int controle_campos = 0;
                int iduser = -1;
                iduser_url = "";
                String pagina = "";
                for (int x = 0; x < path.Length; x++)
                {
                    if (path[x] == Char.Parse("/"))
                    {
                        controle_campos++;
                        if ((controle_campos % 2) == 0)
                            pagina = "";
                    }
                    else
                    {
                        if (controle_campos == 1)
                        {
                            iduser_url = iduser_url + path[x].ToString();
                        }
                        if (controle_campos == 2)
                        {
                            pagina = pagina + path[x].ToString();
                        }
                        if (controle_campos == 4)
                        {
                            pagina = pagina + path[x].ToString();
                        }
                    }
                }
                if (iduser_url == "lairjr")
                    iduser = 1;
                if (iduser_url == "bt")
                    iduser = 2;
                if (pagina.Length == 0)
                    Context.RewritePath("~/OwnDoneFolders/UserPages/home.aspx?iduser=" + iduser, false);
                else
                {
                    switch (pagina)
                    {
                        case "category":
                            Context.RewritePath("~/OwnDoneFolders/UserPages/category.aspx?iduser=" + iduser, false);
                            break;
                        case "done":
                            Context.RewritePath("~/OwnDoneFolders/UserPages/done.aspx?iduser=" + iduser, false);
                            break;
                        case "contact":
                            Context.RewritePath("~/OwnDoneFolders/UserPages/contact.aspx?iduser=" + iduser, false);
                            break;
                        case "resume":
                            Context.RewritePath("~/OwnDoneFolders/UserPages/resume.aspx?iduser=" + iduser, false);
                            break;
                        case "edituser":
                            Context.RewritePath("~/OwnDoneFolders/UserPages/edit.aspx?iduser=" + iduser, false);
                            break;
                        case "editproject":
                            Context.RewritePath("~/OwnDoneFolders/UserPages/editproject.aspx?iduser=" + iduser, false);
                            break;
                        case "project":
                            Context.RewritePath("~/OwnDoneFolders/UserPages/project.aspx?iduser=" + iduser, false);
                            break;
                        default:
                            Context.RewritePath("~/OwnDoneFolders/UserPages/home.aspx?iduser=" + iduser, false);
                            break;
                    }
                }
            }
            else {
                if (iduser_url.Length != 0)
                {
                    if (path.StartsWith("/" + iduser_url))
                        Response.Redirect(path.Substring(iduser_url.Length + 1, path.Length - iduser_url.Length - 1));
                }
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}