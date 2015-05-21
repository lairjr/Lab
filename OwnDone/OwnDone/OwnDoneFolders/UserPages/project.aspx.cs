using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OwnDone.OwnDoneFolders.Classes;

namespace OwnDone.OwnDoneFolders.UserPages
{
    public partial class project : System.Web.UI.Page
    {
        cUsuario usuario = new cUsuario();
        static int idcategoria, idprojeto;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (int.Parse(Request.Params["iduser"]) > 0)
            {
                //Definindo usuário
                usuario.Id = int.Parse(Request.Params["iduser"]);
                usuario.Path_xml_dados = Server.MapPath("\\OwnDoneFolders\\UserDados\\");

                if (!IsPostBack)
                {
                    //Obtendo Categoria
                    String url = Request.RawUrl;
                    cFuncoesDiversas funcoes = new cFuncoesDiversas();
                    idcategoria = funcoes.obterCategoria(url);
                    idprojeto = funcoes.obterProjeto(url);

                    if (idprojeto > 0)
                    {
                        carregaProjeto();
                        carregaImagens();
                    }
                }
            }
        }

        protected void carregaProjeto()
        {
            if (usuario.carregaUmProjeto(idcategoria, idprojeto))
            {
                lblTitulo.Text = usuario.Projeto_nome;
                lblDescricao.Text = usuario.Projeto_desc.Replace("\n", "<br />");
            }
        }

        protected void carregaImagens()
        { 
        }
    }
}