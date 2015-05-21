using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OwnDone.OwnDoneFolders.Classes;
using System.IO;

namespace OwnDone.OwnDoneFolders.MasterPages
{
    public partial class user : System.Web.UI.MasterPage
    {
        cUsuario usuario = new cUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (int.Parse(Request.Params["iduser"]) > 0)
            {
                //Definindo usuário
                usuario.Id = int.Parse(Request.Params["iduser"]);
                usuario.Path_xml_dados = Server.MapPath("\\OwnDoneFolders\\UserDados\\");

                if (usuario.carregaDadosGerais())
                {
                    //Fazendo invisíveis coisas para edição
                    //Page.ClientScript.RegisterStartupScript(typeof(object), "OK", "$(\"*[id='cabecalho_manutencao']\").style.visibility = 'hidden';", true);

                    Page.Title = usuario.Pnome + " " + usuario.Snome + " | Own Done";

                    //Definindo Dados de Cabeçalho
                    lblUserName.Text = usuario.Pnome + " " + usuario.Snome;
                    lblIdade.Text = usuario.calculaIdade().ToString() + " anos";
                    lblPais.Text = usuario.Pais;
                    lblCidade.Text = usuario.Cidade;
                    lblInteresse.Text = usuario.Interesse;
                    redes.DataSource = usuario.carregaRedes();
                    redes.DataBind();

                    //Botando foto de perfil
                    if (File.Exists(Server.MapPath("~/OwnDoneFolders/UserDados/" + usuario.Id + "/") + "//photo.jpg"))
                    {
                        String imagemUrl = "~/OwnDoneFolders/UserDados/" + usuario.Id + "/photo.jpg";
                        imgFoto.ImageUrl = "~/OwnDoneFolders/FunctionsPages/imagemMiniatura.aspx?img=" + imagemUrl + "&MaxW=100&MaxH=120";
                    }
                    else
                        imgFoto.ImageUrl = "~/OwnDoneFolders/Imagens/usuarioSemFoto.png";

                    //Definindo CSS do usuário
                    System.Web.UI.HtmlControls.HtmlLink link = new System.Web.UI.HtmlControls.HtmlLink();
                    switch (usuario.Id_tema)
                    {
                        case 1:
                            link.Href = "~/OwnDoneFolders/StylesUsers/styleBasic1.css";
                            break;
                        case 2:
                            link.Href = "~/OwnDoneFolders/StylesUsers/styleBasic2.css";
                            break;
                        default:
                            link.Href = "~/OwnDoneFolders/StylesUsers/styleBasic1.css";
                            break;
                    }
                    link.Attributes["rel"] = "stylesheet";
                    link.Attributes["type"] = "text/css";
                    Page.Header.Controls.Add(link);
                }
            }
        }

        protected void btnEditarUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/" + usuario.Id_own_done + "/EditUser");
        }

        protected void redes_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            HiddenField tipo = (HiddenField)e.Item.FindControl("tipo");
            Image imgRede = (Image)e.Item.FindControl("imgRede");
            switch (tipo.Value.ToLower()) { 
                case "facebook":
                    imgRede.ImageUrl = "~/OwnDoneFolders/Imagens/facebook.png";
                    break;
                case "linkedin":
                    imgRede.ImageUrl = "~/OwnDoneFolders/Imagens/linkedin.png";
                    break;
                case "blogspot":
                    imgRede.ImageUrl = "~/OwnDoneFolders/Imagens/blogspot.png";
                    break;
                case "wordpress":
                    imgRede.ImageUrl = "~/OwnDoneFolders/Imagens/wordpress.png";
                    break;
                case "twitter":
                    imgRede.ImageUrl = "~/OwnDoneFolders/Imagens/twitter.png";
                    break;
                case "orkut":
                    imgRede.ImageUrl = "~/OwnDoneFolders/Imagens/orkut.png";
                    break;
            }
        }

        protected void categorias_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HiddenField id = (HiddenField)e.Item.FindControl("idCategoria");
            System.Web.UI.HtmlControls.HtmlAnchor categoriaLink = (System.Web.UI.HtmlControls.HtmlAnchor)e.Item.FindControl("categoryLink");
            categoriaLink.HRef = "/" + usuario.Id_own_done + "/Category/" + id.Value;
        }
    }
}