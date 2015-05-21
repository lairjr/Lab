using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;
using OwnDone.OwnDoneFolders.Classes;

namespace OwnDone.OwnDoneFolders.UserPages
{
    public partial class category : System.Web.UI.Page
    {
        cUsuario usuario = new cUsuario();

        static int idcategoria;
        static String path;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (int.Parse(Request.Params["iduser"]) > 0)
            {
                //Definindo usuário
                usuario.Id = int.Parse(Request.Params["iduser"]);
                usuario.Path_xml_dados = Server.MapPath("\\OwnDoneFolders\\UserDados\\");
                // Para pegar o ID Own Done
                usuario.carregaDadosGerais();

                if (!IsPostBack)
                {
                    String url = Request.RawUrl;
                    cFuncoesDiversas funcoes = new cFuncoesDiversas();
                    idcategoria = funcoes.obterCategoria(url);
                    if (idcategoria > 0)
                    {
                        categoria.Visible = true;
                        usuario.carregaUmaCategoria(idcategoria);
                        lblCategoriaNome.Text = usuario.Categoria_nome;

                        carregaProjetosDaCategoria();
                    }
                    else
                    {
                        url = url.Remove(url.IndexOf("/Category"));
                        Response.Redirect(url);
                    }
                }
            }
        }

        protected void carregaProjetosDaCategoria()
        {
            if (usuario.carregaProjetos(idcategoria) != null)
            {
                projetos.DataSource = usuario.carregaProjetos(idcategoria);
                projetos.DataBind();
            }
        }

        protected void btnNovoProjeto_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/" + usuario.Id_own_done + "/Category/" + idcategoria + "/EditProject");
        }

        protected void btnDeletaCategoria_Click(object sender, EventArgs e)
        {
            usuario.deletaCategoria(idcategoria);
            Response.Redirect("~/" + usuario.Id_own_done);
        }

        protected void projetos_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            System.Web.UI.HtmlControls.HtmlAnchor editarLink = (System.Web.UI.HtmlControls.HtmlAnchor)e.Item.FindControl("editarProjetoLink");
            System.Web.UI.HtmlControls.HtmlAnchor projetoLink = (System.Web.UI.HtmlControls.HtmlAnchor)e.Item.FindControl("projetoLink");
            HiddenField idProject = (HiddenField)e.Item.FindControl("idProjeto");
            editarLink.HRef = "/" + usuario.Id_own_done + "/Category/" + idcategoria + "/EditProject/" + idProject.Value;
            projetoLink.HRef = "/" + usuario.Id_own_done + "/Category/" + idcategoria + "/Project/" + idProject.Value;
            Label descricao = (Label)e.Item.FindControl("lblProjetoDescricao");
            descricao.Text = descricao.Text.Replace("\n", "<br />");
        }
    }
}