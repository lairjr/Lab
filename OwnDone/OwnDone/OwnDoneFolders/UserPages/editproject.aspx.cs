using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OwnDone.OwnDoneFolders.Classes;
using System.IO;

namespace OwnDone.OwnDoneFolders.UserPages
{
    public partial class editproject : System.Web.UI.Page
    {
        cUsuario usuario = new cUsuario();
        static int idcategoria, idprojeto;

        protected void Page_Load(object sender, EventArgs e)
        {
            btnEnviarImagens.Attributes.Add("OnClick", "javascript:document.forms[0].encoding = \"multipart/form-data\";");
            btnEnviarVideo.Attributes.Add("OnClick", "javascript:document.forms[0].encoding = \"multipart/form-data\";");

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
                        carregaLinks();
                    }

                    carregaCategorias();
                }
            }
        }

        protected void carregaCategorias()
        {
            cmbCategoria.DataSource = usuario.carregaCategorias();
            cmbCategoria.DataTextField = "nome";
            cmbCategoria.DataValueField = "id";
            cmbCategoria.DataBind();
            cmbCategoria.SelectedValue = idcategoria.ToString();
        }

        protected void carregaProjeto()
        {
            if (usuario.carregaUmProjeto(idcategoria, idprojeto))
            {
                txtNome.Text = usuario.Projeto_nome;
                txtDescricao.Text = usuario.Projeto_desc;
            }
        }

        protected void carregaImagens()
        {
            if (usuario.carregaImagensProjeto(idcategoria, idprojeto) != null)
            {
                imagens.DataSource = usuario.carregaImagensProjeto(idcategoria, idprojeto);
                imagens.DataBind();
                imagens.Visible = true;
            }
            else
            {
                imagens.Visible = false;
            }
        }

        protected void carregaLinks()
        {
            if (usuario.carregaLinksProjeto(idcategoria, idprojeto) != null)
            {
                links.DataSource = usuario.carregaLinksProjeto(idcategoria, idprojeto);
                links.DataBind();
                links.Visible = true;
            }
            else
            {
                links.Visible = false;
            }
        }

        protected void btnSalvarCategoria_Click(object sender, EventArgs e)
        {
            idcategoria = int.Parse(cmbCategoria.SelectedValue);
            usuario.Projeto_nome = txtNome.Text;
            usuario.Projeto_desc = txtDescricao.Text;
            if (idprojeto < 0)
            {
                idprojeto = usuario.insereProjeto(idcategoria);
            }
            else 
            {
                usuario.atualizaProjeto(idcategoria, idprojeto);
            }
        }

        protected void btnEnviarImagens_Click(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(200);

                // Get the HttpFileCollection
                HttpFileCollection hfc = Request.Files;
                for (int i = 0; i < hfc.Count; i++)
                {
                    HttpPostedFile hpf = hfc[i];
                    if (hpf.ContentLength > 0)
                    {
                        usuario.Imagem_file = Path.GetExtension(hpf.FileName);
                        usuario.Imagem_nome = hpf.FileName;
                        int idimagem = usuario.insereImagem(idcategoria, idprojeto);
                        if (criaPastas())
                        {
                            hpf.SaveAs(usuario.Path_categoria + "\\" + idcategoria + "\\" + idprojeto + "\\Imagens\\" + idimagem + Path.GetExtension(hpf.FileName));
                        }
                    }
                }

                usuario.carregaDadosGerais();
                Response.Redirect("~/" + usuario.Id_own_done + "/Category/" + idcategoria + "/EditProject/" + idprojeto, true);
            }
            catch (Exception)
            {
                lblEnviaImagens.Text = "Ops... Erro ao enviar fotos!";
            }
        }

        protected void imagens_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            HiddenField fileName = (HiddenField)e.Item.FindControl("fileName");
            Image imagem = (Image)e.Item.FindControl("imagem");
            String imagemUrl = "~/OwnDoneFolders/UserDados/" + usuario.Id + "/Categorias/" + idcategoria + "/" + idprojeto + "/Imagens/" + fileName.Value;
            imagem.ImageUrl = "~/OwnDoneFolders/FunctionsPages/imagemMiniatura.aspx?img=" + imagemUrl + "&MaxW=140&MaxH=100";
        }

        protected void imagens_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            int idImagem = Convert.ToInt32(imagens.DataKeys[e.Item.ItemIndex]);
            
            if (usuario.carregaImagemProjeto(idcategoria, idprojeto, idImagem))
            {
                if (usuario.deletaImagemProjeto(idcategoria, idprojeto, idImagem))
                {
                    imagens.EditItemIndex = -1;
                    File.Delete(usuario.Path_categoria + "\\" + idcategoria + "\\" + idprojeto + "\\" + usuario.Imagem_file);

                    carregaImagens();
                }
            }
        }

        protected void btnExcluirProjeto_Click(object sender, EventArgs e)
        {
            if (usuario.deletaProjeto(idcategoria, idprojeto))
            {
                Directory.Delete(usuario.Path_categoria + "\\" + idcategoria + "\\" + idprojeto + "\\", true);
                usuario.carregaDadosGerais();
                Response.Redirect("~/" + usuario.Id_own_done + "/Category/" + idcategoria);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                usuario.Video_nome = txtVideoTitulo.Text;
                usuario.Video_desc = txtVideoDesc.Text;
                usuario.Video_file = ".flv";
                int idvideo = usuario.insereVideo(idcategoria, idprojeto);
                if (idvideo > 0)
                {
                    if (File.Exists(usuario.Path_categoria + "\\" + idcategoria + "\\" + idprojeto + "\\Videos\\" + fuVideo.FileName))
                        File.Delete(usuario.Path_categoria + "\\" + idcategoria + "\\" + idprojeto + "\\Videos\\" + fuVideo.FileName);
                    fuVideo.SaveAs(usuario.Path_categoria + "\\" + idcategoria + "\\" + idprojeto + "\\Videos\\" + fuVideo.FileName);
                    String ffmpegPath = Server.MapPath("\\OwnDoneFolders\\FFMpeg\\");
                    String originalPath = usuario.Path_categoria + "\\" + idcategoria + "\\" + idprojeto + "\\Videos\\" + fuVideo.FileName;
                    String detinadoPath = usuario.Path_categoria + "\\" + idcategoria + "\\" + idprojeto + "\\Videos\\" + idvideo + ".flv";
                    cFuncoesDiversas funcoes = new cFuncoesDiversas();
                    if (funcoes.converteVideo(ffmpegPath, originalPath, detinadoPath))
                    {
                        File.Delete(originalPath);
                    }
                }
            }
            catch (Exception) 
            { 
            }
        }

        public Boolean criaPastas()
        {
            try
            {
                if (!Directory.Exists(usuario.Path_categoria))
                    Directory.CreateDirectory(usuario.Path_categoria);
                if (!Directory.Exists(usuario.Path_categoria + "\\" + idcategoria))
                    Directory.CreateDirectory(usuario.Path_categoria + "\\" + idcategoria);
                if (!Directory.Exists(usuario.Path_categoria + "\\" + idcategoria + "\\" + idprojeto))
                    Directory.CreateDirectory(usuario.Path_categoria + "\\" + idcategoria + "\\" + idprojeto);
                if (!Directory.Exists(usuario.Path_categoria + "\\" + idcategoria + "\\" + idprojeto + "\\Imagens"))
                    Directory.CreateDirectory(usuario.Path_categoria + "\\" + idcategoria + "\\" + idprojeto + "\\Imagens");
                if (!Directory.Exists(usuario.Path_categoria + "\\" + idcategoria + "\\" + idprojeto + "\\Videos"))
                    Directory.CreateDirectory(usuario.Path_categoria + "\\" + idcategoria + "\\" + idprojeto + "\\Videos");
                if (!Directory.Exists(usuario.Path_categoria + "\\" + idcategoria + "\\" + idprojeto + "\\Audio"))
                    Directory.CreateDirectory(usuario.Path_categoria + "\\" + idcategoria + "\\" + idprojeto + "\\Audios");
                if (!Directory.Exists(usuario.Path_categoria + "\\" + idcategoria + "\\" + idprojeto + "\\Arquivos"))
                    Directory.CreateDirectory(usuario.Path_categoria + "\\" + idcategoria + "\\" + idprojeto + "\\Arquivos");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected void btnSalvarLink_Click(object sender, EventArgs e)
        {
            usuario.Link_link = txtLink.Text;
            usuario.Link_desc = txtLinkDesc.Text;
            if (usuario.insereLink(idcategoria, idprojeto))
            {
                txtLink.Text = "";
                txtLinkDesc.Text = "";
            }
            carregaLinks();
        }

        protected void links_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            int idLink = Convert.ToInt32(links.DataKeys[e.Item.ItemIndex]);

            if (usuario.deletaLinkProjeto(idcategoria, idprojeto, idLink))
            {
                links.EditItemIndex = -1;

                carregaLinks();
            }
        }
    }
}