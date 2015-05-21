using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OwnDone.OwnDoneFolders.Classes;

namespace OwnDone.OwnDoneFolders.UserPages
{
    public partial class usermenu : System.Web.UI.UserControl
    {
        cUsuario usuario = new cUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Definindo usuário
            usuario.Id = int.Parse(Request.Params["iduser"]);
            usuario.Path_xml_dados = Server.MapPath("\\OwnDoneFolders\\UserDados\\");
            usuario.carregaDadosGerais();

            //Definindo Links
            homeLink.Attributes["href"] = "/" + usuario.Id_own_done;
            resumeLink.Attributes["href"] = "/" + usuario.Id_own_done + "/Resume";
            contactLink.Attributes["href"] = "/" + usuario.Id_own_done + "/Contact";
            carregaCategorias();

            txtNovaCategoria.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('btnInsereCategoria').click();return false;}} else {return true}; ");
        }

        protected void carregaCategorias()
        {
            if (usuario.carregaCategorias() != null)
            {
                categorias.DataSource = usuario.carregaCategorias();
                categorias.DataBind();
                categorias.Visible = true;
            }
            else
            {
                categorias.Visible = false;
            }
        }

        protected void categorias_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HiddenField id = (HiddenField)e.Item.FindControl("idCategoria");
            System.Web.UI.HtmlControls.HtmlAnchor categoriaLink = (System.Web.UI.HtmlControls.HtmlAnchor)e.Item.FindControl("categoryLink");
            categoriaLink.HRef = "/" + usuario.Id_own_done + "/Category/" + id.Value;
        }

        protected void btnInsereCategoria_Click(object sender, EventArgs e)
        {
            usuario.Categoria_nome = txtNovaCategoria.Text;
            if (usuario.insereCategoria())
            {
                carregaCategorias();
                txtNovaCategoria.Text = "";
            }
        }
    }
}