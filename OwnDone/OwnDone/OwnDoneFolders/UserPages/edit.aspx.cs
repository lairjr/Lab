using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OwnDone.OwnDoneFolders.Classes;
using System.IO;
using ThoughtWorks.QRCode.Codec;
using System.Data;

namespace OwnDone.OwnDoneFolders.UserPages
{
    public partial class edit : System.Web.UI.Page
    {
        cUsuario usuario = new cUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            btnEnviaNovaFoto.Attributes.Add("OnClick", "javascript:document.forms[0].encoding = \"multipart/form-data\";");

            Session.Add("iduser", 2);
            try
            {
                int iduserLogado = int.Parse(Session["iduser"].ToString());
                if (iduserLogado == int.Parse(Request.Params["iduser"])) // Verifica se usário logado é o mesmo que acessou
                {
                    //Definindo usuário
                    usuario.Id = int.Parse(Request.Params["iduser"]);
                    usuario.Path_xml_dados = Server.MapPath("\\OwnDoneFolders\\UserDados\\");

                    if (usuario.carregaDadosGerais())
                    {
                        if (!IsPostBack)
                        {
                            lnkDados_Click(sender, e);
                        }
                    }
                }
                else // Tira o usuário dessa página
                {
                    String url = Request.RawUrl;
                    url = url.Remove(url.IndexOf("/EditUser"));
                    Response.Redirect(url);
                }
            }
            catch (Exception)
            {
                String url = Request.RawUrl;
                url = url.Remove(url.IndexOf("/EditUser"));
                Response.Redirect(url);
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (validaForm())
            {
                lblValidacao.Visible = false;
                usuario.Pnome = txtPNome.Text;
                usuario.Snome = txtSNome.Text;
                usuario.Pais = txtPaisAtual.Text;
                usuario.Cidade = txtCidadeAtual.Text;
                usuario.Cidade_nat = txtNascCid.Text;
                usuario.Pais_nat = txtNascPais.Text;
                usuario.AnoNasc = int.Parse(cmbNascAno.Text);
                usuario.MesNasc = int.Parse(cmbNascMes.Text);
                usuario.DiaNasc = int.Parse(cmbNascDia.Text);
                usuario.Sexo = cmbSexo.SelectedIndex;
                usuario.Estado_civil = cmbEstadoCivil.Text;
                usuario.Interesse = txtInteresse.Text;

                if (usuario.atualizaDadosGerais())
                {
                    lblValidacao.Visible = true;
                    lblValidacao.Text = "Salvo com sucesso!";
                }
                else
                {
                    lblValidacao.Visible = true;
                    lblValidacao.Text = "Ops... ocorreu um erro!";
                }
            }
            else
            {
                lblValidacao.Visible = true;
                lblValidacao.Text = "Ops... ocorreu um erro!";
            }
        }

        protected Boolean validaForm()
        {
            return true;
        }

        protected void carregaDadosGerais()
        {
            txtPNome.Text = usuario.Pnome;
            txtSNome.Text = usuario.Snome;
            txtPaisAtual.Text = usuario.Pais;
            txtCidadeAtual.Text = usuario.Cidade;
            txtNascCid.Text = usuario.Cidade_nat;
            txtNascPais.Text = usuario.Pais_nat;
            cmbNascAno.Text = usuario.AnoNasc.ToString();
            cmbNascMes.Text = usuario.MesNasc.ToString();
            cmbNascDia.Text = usuario.DiaNasc.ToString();
            cmbSexo.SelectedIndex = usuario.Sexo;
            cmbEstadoCivil.Text = usuario.Estado_civil;
            txtInteresse.Text = usuario.Interesse;
        }

        protected void carregaEmails()
        {
            gridEmails.DataSource = usuario.carregaEmails();
            gridEmails.DataBind();
        }

        protected void carregaTelefones()
        {
            gridTelefones.DataSource = usuario.carregaTelefones();
            gridTelefones.DataBind();
        }

        protected void carregaMensageiros()
        {
            gridMensageiros.DataSource = usuario.carregaMensageiros();
            gridMensageiros.DataBind();
        }

        protected void carregaRedes()
        {
            gridRedes.DataSource = usuario.carregaRedes();
            gridRedes.DataBind();
        }

        protected void carregaIdiomas()
        {
            gridIdiomas.DataSource = usuario.carregaIdiomas();
            gridIdiomas.DataBind();
        }

        protected void lnkContato_Click(object sender, EventArgs e)
        {
            dados.Visible = false;
            foto.Visible = false;
            contatos.Visible = true;
            cartao.Visible = false;
            carregaEmails();
            carregaTelefones();
            carregaMensageiros();
            carregaRedes();
            carregaIdiomas();
        }

        protected void gridEmails_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
        }

        protected void btnNovoEmail_Click(object sender, ImageClickEventArgs e)
        {
            Boolean principal;
            if (cmbEmail.SelectedIndex == 0)
                principal = true;
            else
                principal = false;

            if (usuario.insereEmail(txtEmailNovo.Text, principal)) {
                carregaEmails();
                txtEmailNovo.Text = "";
                cmbEmail.SelectedIndex = 0;
            }
        }

        protected void gridEmails_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(Server.HtmlDecode(gridEmails.SelectedRow.Cells[1].Text));

            if (usuario.deletaEmail(id))
            {
                carregaEmails();
            }
        }

        protected void gridTelefones_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
        }

        protected void btnNovoTelefone_Click(object sender, ImageClickEventArgs e)
        {
            Boolean principal;
            if (cmbTelefone.SelectedIndex == 0)
                principal = true;
            else
                principal = false;

            if (usuario.insereTelefone(txtTelefoneNovo.Text, principal))
            {
                carregaTelefones();
                txtTelefoneNovo.Text = "";
                cmbTelefone.SelectedIndex = 0;
            }
        }

        protected void gridTelefones_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(Server.HtmlDecode(gridTelefones.SelectedRow.Cells[1].Text));

            if (usuario.deletaTelefone(id))
            {
                carregaTelefones();
            }
        }

        protected void btnNovoMenssageiro_Click(object sender, ImageClickEventArgs e)
        {
            if (usuario.insereMensageiro(txtMensageiroNovo.Text, cmbMensageiro.Text))
            {
                carregaMensageiros();
                txtMensageiroNovo.Text = "";
                cmbMensageiro.SelectedIndex = 0;
            }
        }

        protected void gridMensageiros_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(Server.HtmlDecode(gridMensageiros.SelectedRow.Cells[1].Text));

            if (usuario.deletaMensageiro(id))
            {
                carregaMensageiros();
            }
        }

        protected void gridMensageiros_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Width = 80;
            e.Row.Cells[4].Visible = false;
        }

        protected void gridRedes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(Server.HtmlDecode(gridRedes.SelectedRow.Cells[1].Text));

            if (usuario.deletaRede(id))
            {
                carregaRedes();
            }
        }

        protected void gridRedes_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
        }

        protected void btnNovoRede_Click(object sender, ImageClickEventArgs e)
        {
            if (usuario.insereRede(txtRedesNovo.Text, cmbRedes.Text))
            {
                carregaRedes();
                txtRedesNovo.Text = "";
                cmbRedes.SelectedIndex = 0;
            }
        }

        protected void lnkDados_Click(object sender, EventArgs e)
        {
            dados.Visible = true;
            contatos.Visible = false;
            foto.Visible = false;
            cartao.Visible = false;
            carregaDadosGerais();
        }

        protected void lnkFoto_Click(object sender, EventArgs e)
        {
            dados.Visible = false;
            foto.Visible = true;
            contatos.Visible = false;
            cartao.Visible = false;

            String path = Server.MapPath("~/OwnDoneFolders/UserDados/" + usuario.Id + "/");
            if (File.Exists(path + "//photo.jpg"))
                editImgFoto.ImageUrl = "~/OwnDoneFolders/UserDados/" + usuario.Id + "/photo.jpg"; 
        }

        protected void btnEnviaNovaFoto_Click(object sender, EventArgs e)
        {
            String path = Server.MapPath("~/OwnDoneFolders/UserDados/" + usuario.Id + "/");
            if (File.Exists(path + "//photo.jpg"))
                File.Delete(path + "//photo.jpg");
            fUploadUserPhoto.SaveAs(path + "//photo.jpg");

            lnkFoto_Click(sender, e);
        }

        protected void lnkTirarFoto_Click(object sender, EventArgs e)
        {
            String path = Server.MapPath("~/OwnDoneFolders/UserDados/" + usuario.Id + "/");
            if (File.Exists(path + "//photo.jpg"))
                File.Delete(path + "//photo.jpg");

            lnkFoto_Click(sender, e);
        }

        protected void gridIdiomas_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Width = 80;
            e.Row.Cells[4].Visible = false;
        }

        protected void gridIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(Server.HtmlDecode(gridIdiomas.SelectedRow.Cells[1].Text));

            if (usuario.deletaIdioma(id))
            {
                carregaIdiomas();
            }
        }

        protected void btnNovoIdioma_Click(object sender, ImageClickEventArgs e)
        {
            if (usuario.insereIdioma(txtIdiomaNovo.Text, cmbIdioma.Text))
            {
                carregaIdiomas();
                txtIdiomaNovo.Text = "";
                cmbIdioma.SelectedIndex = 0;
            }
        }

        protected void btnGerarQRCode_Click(object sender, EventArgs e)
        {
            usuario.Path_qr_code = Server.MapPath("\\OwnDoneFolders\\UserDados\\");
            usuario.geraQRCode("http://www." + Request.Url.Authority + "/" + usuario.Id_own_done, usuario.Path_qr_code);
        }

        protected void btnGerarCartao_Click(object sender, EventArgs e)
        {
            CrystalDecisions.CrystalReports.Engine.ReportDocument report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            String reportPath = Server.MapPath("\\OwnDoneFolders\\Reports\\UserReports");
            report.Load(reportPath + "\\card1.rpt");

            usuario.Path_qr_code = Server.MapPath("OwnDoneFolders\\UserDados\\");

            DataSet ds = new DataSet();
            ds.ReadXml(usuario.Path_xml_dados);
            report.SetDataSource(ds);

            CrystalDecisions.CrystalReports.Engine.ParameterFieldDefinitions crParameterFieldDefinitions;
            CrystalDecisions.CrystalReports.Engine.ParameterFieldDefinition crParameterFieldDefinition;
            CrystalDecisions.Shared.ParameterValues crParameterValues = new CrystalDecisions.Shared.ParameterValues();
            CrystalDecisions.Shared.ParameterDiscreteValue crParameterDiscreteValue = new CrystalDecisions.Shared.ParameterDiscreteValue();

            crParameterDiscreteValue.Value = usuario.Path_qr_code;
            crParameterFieldDefinitions = report.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["path_qrcode"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            System.IO.MemoryStream oStream;
            oStream = (System.IO.MemoryStream)report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            Response.BinaryWrite(oStream.ToArray());
            Response.End();
        }

        protected void lnkCartoes_Click(object sender, EventArgs e)
        {
            dados.Visible = false;
            foto.Visible = false;
            contatos.Visible = false;
            cartao.Visible = true;
        }
    }
}