using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OwnDone.OwnDoneFolders.Classes;

namespace OwnDone.OwnDoneFolders.UserPages
{
    public partial class contact : System.Web.UI.Page
    {
        cUsuario usuario = new cUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Session.Add("iduser", 2);
            try
            {
                int iduserLogado = int.Parse(Session["iduser"].ToString());
                usuario_nao_logado.Visible = false;
                usuario_logado.Visible = true;
            }
            catch (Exception)
            {
                usuario_nao_logado.Visible = true;
                usuario_logado.Visible = false;
            }
            finally
            {
                //Definindo usuário
                usuario.Id = int.Parse(Request.Params["iduser"]);
                usuario.Path_xml_dados = Server.MapPath("\\OwnDoneFolders\\UserDados\\");

                if (!IsPostBack)
                {
                    if (usuario.carregaEmails() != null)
                    {
                        gridEmail.DataSource = usuario.carregaEmails();
                        gridEmail.DataBind();
                        emails.Visible = true;
                    }
                    else
                        emails.Visible = false;
                    if (usuario.carregaMensageiros() != null)
                    {
                        gridMensageiros.DataSource = usuario.carregaMensageiros();
                        gridMensageiros.DataBind();
                        mensagerios.Visible = true;
                    }
                    else
                        mensagerios.Visible = false;
                    if (usuario.carregaTelefones() != null)
                    {
                        gridTelefones.DataSource = usuario.carregaTelefones();
                        gridTelefones.DataBind();
                        telefones.Visible = true;
                    }
                    else
                        telefones.Visible = false;
                }
            }
        }

        protected void gridEmail_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
        }

        protected void gridTelefones_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            cFuncoesDiversas funcoes = new cFuncoesDiversas();
            if (funcoes.enviaMensagemUsuario(usuario.emailPrincipal(), txtNome.Text, txtAssunto.Text, txtMensagem.Text))
            {
                lblStatus.Text = "Mensagem enviada com sucesso!";
            }
            else
            {
                lblStatus.Text = "Ops! Erro ao enviar mensagem!";
            }
        }
    }
}