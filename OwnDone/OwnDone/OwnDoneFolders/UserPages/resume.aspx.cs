using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.XPath;
using System.Data;
using OwnDone.OwnDoneFolders.Classes;

namespace OwnDone.OwnDoneFolders.UserPages
{
    public partial class resume : System.Web.UI.Page
    {
        cUsuario usuario = new cUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario.Id = int.Parse(Request.Params["iduser"]);
            usuario.Path_xml_dados = Server.MapPath("\\OwnDoneFolders\\UserDados\\");

            if (!IsPostBack)
            {
                carregaObjProf();
                carregaInfAdic();
                carregaSkills();
                carregaAcad();
                carregaExpProfs();
                carregaCombosAnos();
            }
        }

        protected void carregaObjProf()
        {
            if (txtEditProfGoals.Text.Length == 0)
            {
                try
                {
                    txtEditProfGoals.Text = usuario.ObjetivoProfissional;
                    lblProfGoals.Text = usuario.ObjetivoProfissional.Replace("\n", "<br />");
                }
                catch
                {
                    txtEditProfGoals.Text = "";
                    lblProfGoals.Text = "Nenhum dado informado!";
                }
            }
        }

        protected void carregaInfAdic()
        {
            if (txtEditInfAdic.Text.Length == 0)
            {
                try
                {
                    txtEditInfAdic.Text = usuario.InfoAdic;
                    lblInfAdic.Text = usuario.InfoAdic.Replace("\n", "<br />");
                }
                catch
                {
                    txtEditInfAdic.Text = "";
                    lblInfAdic.Text = "Nenhum dado informado!";
                }
            }
        }

        protected void carregaSkills()
        {
            if (txtEditSkills.Text.Length == 0)
            {
                try
                {
                    txtEditSkills.Text = usuario.Habilidades;
                    lblSkills.Text = usuario.Habilidades.Replace("\n", "<br />");
                }
                catch
                {
                    txtEditSkills.Text = "";
                    lblSkills.Text = "Nenhum dado informado!";
                }
            }
        }

        protected void carregaAcad()
        {
            if (usuario.carregaEscolaridade() != null)
            {
                academicos.DataSource = usuario.carregaEscolaridade();
                academicos.DataBind();
            }
        }

        protected void carregaExpProfs()
        {
            if (usuario.carregaExpProfissionais() != null)
            {
                exp_profs.DataSource = usuario.carregaExpProfissionais();
                exp_profs.DataBind();
            }
        }

        protected void academicos_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            int idEdu = Convert.ToInt32(academicos.DataKeys[e.Item.ItemIndex]);

            if (usuario.deletaEscolaridade(idEdu))
            {
                academicos.EditItemIndex = -1;
                carregaAcad();
            }
        }

        protected void btnEduFechar_Click(object sender, EventArgs e)
        {
            edit_education.Visible = false;
            btnEduFechar.Visible = false;
            btnNovoEdu.Visible = true;
            btnSalvaEdu.Visible = false;
            lblEduValida.Visible = false;
        }

        protected void btnFecharExpProf_Click(object sender, EventArgs e)
        {
            edit_exp_profs.Visible = false;
            btnFecharExpProf.Visible = false;
            btnNovoExpProf.Visible = true;
            btnSalvaExpProf.Visible = false;
            lblExpProfValida.Visible = false;
        }

        protected void exp_profs_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            int idExpProf = Convert.ToInt32(exp_profs.DataKeys[e.Item.ItemIndex]);

            if (usuario.deletaExpProfissional(idExpProf)) {
                exp_profs.EditItemIndex = -1;
                carregaExpProfs();
            }
        }

        protected void btnEditarInfAdic_Click(object sender, EventArgs e)
        {
            edit_aditional_informations.Visible = true;
            btnEditarInfAdic.Visible = false;
            btnSalvaInfAdic.Visible = true;
        }

        protected void btnSalvaInfAdic_Click(object sender, EventArgs e)
        {
            usuario.InfoAdic = txtEditInfAdic.Text;
            edit_aditional_informations.Visible = false;
            btnEditarInfAdic.Visible = true;
            btnSalvaInfAdic.Visible = false;
        }

        protected void btnEditaHabilidades_Click(object sender, EventArgs e)
        {
            edit_skills.Visible = true;
            btnEditaHabilidades.Visible = false;
            btnSalvaHabilidades.Visible = true;
        }

        protected void btnSalvaHabilidades_Click(object sender, EventArgs e)
        {
            usuario.Habilidades = txtEditSkills.Text;
            edit_skills.Visible = false;
            btnEditaHabilidades.Visible = true;
            btnSalvaHabilidades.Visible = false;
        }

        protected void btnEditProfObj_Click(object sender, EventArgs e)
        {
            edit_professional_goals.Visible = true;
            btnEditProfObj.Visible = false;
            btnSalvaProfObj.Visible = true;
        }

        protected void btnSalvaProfObj_Click(object sender, EventArgs e)
        {
            usuario.ObjetivoProfissional = txtEditProfGoals.Text;
            carregaObjProf();
            edit_professional_goals.Visible = false;
            btnEditProfObj.Visible = true;
            btnSalvaProfObj.Visible = false;
        }

        protected void btnNovoExpProf_Click(object sender, EventArgs e)
        {
            edit_exp_profs.Visible = true;
            btnNovoExpProf.Visible = false;
            btnSalvaExpProf.Visible = true;
            btnFecharExpProf.Visible = true;
            lblExpProfValida.Visible = false;
        }

        protected void btnSalvaExpProf_Click(object sender, EventArgs e)
        {
            if (validaFormExpProf())
            {
                int mesIni = int.Parse(cmbExpProfMesIni.Text);
                int anoIni = int.Parse(cmbExpProfAnoIni.Text);
                int mesFim = 999999;
                int anoFim = 999999;
                if (!chkExpProfSemDataFim.Checked)
                {
                    mesFim = int.Parse(cmbExpProfMesFim.Text);
                    anoFim = int.Parse(cmbExpProfAnoFim.Text);
                }
                if (usuario.insereExpProfissional(txtExpProfProfissao.Text, txtExpProfEmpresa.Text, txtExpProfAtividades.Text, mesIni, anoIni, mesFim, anoFim))
                {
                    carregaExpProfs();
                    limpaFormExpProf();
                }
            }
        }

        protected void btnNovoEdu_Click(object sender, EventArgs e)
        {
            edit_education.Visible = true;
            btnNovoEdu.Visible = false;
            btnSalvaEdu.Visible = true;
            btnEduFechar.Visible = true;
            lblEduValida.Visible = false;

            limpaFormEdu();
        }

        protected void btnSalvaEdu_Click(object sender, EventArgs e)
        {
            if (validaFormEdu())
            {
                int mesIni = int.Parse(cmbEduMesIni.Text);
                int anoIni = int.Parse(cmbEduAnoIni.Text);
                int mesFim = 999999;
                int anoFim = 999999;
                if (!chkEduSemDataFim.Checked)
                {
                    mesFim = int.Parse(cmbEduMesFim.Text);
                    anoFim = int.Parse(cmbEduAnoFim.Text);
                }
                if (usuario.insereEscolaridade(cmbEduNivel.Text, txtEduInstituicao.Text, txtEduCurso.Text, txtEduPais.Text, txtEduCidade.Text, mesIni, anoIni, mesFim, anoFim))
                {
                    carregaAcad();
                    limpaFormEdu();
                }
            }
        }

        protected void carregaCombosAnos()
        {
            cFuncoesDiversas funcoes = new cFuncoesDiversas();
            cmbEduAnoIni.DataSource = funcoes.geraTableAnos(false);
            cmbEduAnoIni.DataTextField = "ano";
            cmbEduAnoIni.DataBind(); 
            cmbEduAnoIni.Items.Insert(0, "Ano");
            cmbEduAnoFim.DataSource = funcoes.geraTableAnos(true);
            cmbEduAnoFim.DataTextField = "ano";
            cmbEduAnoFim.DataBind();
            cmbEduAnoFim.Items.Insert(0, "Ano");
            cmbExpProfAnoIni.DataSource = funcoes.geraTableAnos(false);
            cmbExpProfAnoIni.DataTextField = "ano";
            cmbExpProfAnoIni.DataBind();
            cmbExpProfAnoIni.Items.Insert(0, "Ano");
            cmbExpProfAnoFim.DataSource = funcoes.geraTableAnos(true);
            cmbExpProfAnoFim.DataTextField = "ano";
            cmbExpProfAnoFim.DataBind();
            cmbExpProfAnoFim.Items.Insert(0, "Ano");
        }

        protected void academicos_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Label mesFim = (Label)e.Item.FindControl("lblMesFim");
            Label anoFim = (Label)e.Item.FindControl("lblAnoFim");
            if ((mesFim.Text == "999999") || (anoFim.Text == "999999"))
            {
                mesFim.Text = "em adamento";
                anoFim.Visible = false;
            }
            else
            {
                mesFim.Text = "até " + mesFim.Text + "/";
            }
        }

        protected void limpaFormEdu() {
            txtEduCidade.Text = "Cidade...";
            txtEduCurso.Text = "Curso...";
            txtEduInstituicao.Text = "Instituição...";
            txtEduPais.Text = "País...";
            cmbEduAnoFim.SelectedIndex = 0;
            cmbEduAnoIni.SelectedIndex = 0;
            cmbEduMesFim.SelectedIndex = 0;
            cmbEduMesIni.SelectedIndex = 0;
            cmbEduNivel.SelectedIndex = 0;
            chkEduSemDataFim.Checked = false;
        }

        protected void limpaFormExpProf()
        {
            txtExpProfEmpresa.Text = "Empresa...";
            txtExpProfProfissao.Text = "Profissão...";
            txtExpProfAtividades.Text = "Atividades...";
            cmbExpProfAnoFim.SelectedIndex = 0;
            cmbExpProfAnoIni.SelectedIndex = 0;
            cmbExpProfMesFim.SelectedIndex = 0;
            cmbExpProfMesIni.SelectedIndex = 0;
            chkExpProfSemDataFim.Checked = false;
        }

        protected Boolean validaFormEdu()
        {
            Boolean valido = true;
            if ((txtEduInstituicao.Text.Length <= 1) || (txtEduInstituicao.Text == "Instituição..."))
                valido = false;
            if ((txtEduCidade.Text.Length <= 1) || (txtEduCidade.Text == "Cidade..."))
                valido = false;
            if ((txtEduCurso.Text.Length <= 1) || (txtEduCurso.Text == "Curso..."))
                valido = false;
            if ((txtEduPais.Text.Length <= 1) || (txtEduPais.Text == "País..."))
                valido = false;
            if (cmbEduAnoIni.SelectedIndex == 0)
                valido = false;
            if (cmbEduMesIni.SelectedIndex == 0)
                valido = false;
            if (!chkEduSemDataFim.Checked)
            {
                if (cmbEduAnoFim.SelectedIndex == 0)
                    valido = false;
                if (cmbEduMesFim.SelectedIndex == 0)
                    valido = false;
            }
            if (!valido)
            {
                lblEduValida.Text = "Dados incorretos";
                lblEduValida.Visible = true;
            }
            else {
                lblEduValida.Visible = false;
            }
            return valido;
        }

        protected Boolean validaFormExpProf() {
            Boolean valido = true;
            if ((txtExpProfAtividades.Text.Length <= 1) || (txtExpProfAtividades.Text == "Atividades..."))
                valido = false;
            if ((txtExpProfEmpresa.Text.Length <= 1) || (txtExpProfEmpresa.Text == "Empresa..."))
                valido = false;
            if ((txtExpProfProfissao.Text.Length <= 1) || (txtExpProfProfissao.Text == "Profissão..."))
                valido = false;
            if (cmbExpProfAnoIni.SelectedIndex == 0)
                valido = false;
            if (cmbExpProfMesIni.SelectedIndex == 0)
                valido = false;
            if (!chkExpProfSemDataFim.Checked)
            {
                if (cmbExpProfAnoFim.SelectedIndex == 0)
                    valido = false;
                if (cmbExpProfMesFim.SelectedIndex == 0)
                    valido = false;
            }
            if (!valido)
            {
                lblExpProfValida.Text = "Dados incorretos";
                lblExpProfValida.Visible = true;
            }
            else
            {
                lblExpProfValida.Visible = false;
            }
            return valido;
        }

        protected void exp_profs_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Label mesFim = (Label)e.Item.FindControl("lblMesFim");
            Label anoFim = (Label)e.Item.FindControl("lblAnoFim");
            HiddenField hideAtividade = (HiddenField)e.Item.FindControl("hideAtividades");
            Label atividades = (Label)e.Item.FindControl("lblAtividades");
            atividades.Text = hideAtividade.Value.Replace("\n", "<br />");

            if ((mesFim.Text == "999999") || (anoFim.Text == "999999"))
            {
                mesFim.Text = " até Hoje";
                anoFim.Visible = false;
            }
            else
            {
                mesFim.Text = "até " + mesFim.Text + "/";
            }
        }

        protected void lnkImprimir_Click(object sender, EventArgs e)
        {
            CrystalDecisions.CrystalReports.Engine.ReportDocument report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            String reportPath = Server.MapPath("\\OwnDoneFolders\\Reports\\UserReports");
            report.Load(reportPath + "\\resume1.rpt");
            DataSet ds = new DataSet();
            ds.ReadXml(usuario.Path_xml_dados);
            report.SetDataSource(ds);
            System.IO.MemoryStream oStream;
            oStream = (System.IO.MemoryStream)report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            Response.BinaryWrite(oStream.ToArray());
            Response.End();
        }
    }
}