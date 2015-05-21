using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using appProfiles.App_Folders.Classes;

namespace appProfiles.App_Folders.UserPages
{
    public partial class resume1 : System.Web.UI.Page
    {
        static cResume resume = new cResume();
        static cLanguage language = new cLanguage();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    lblResume.Text = cGlobalResourceObject.getGlobalResource("lblResume", Request.Cookies["userLanguage"].Value);
                    lblGoals.Text = cGlobalResourceObject.getGlobalResource("lblGoals", Request.Cookies["userLanguage"].Value);
                    lblProfessionalExpiriences.Text = cGlobalResourceObject.getGlobalResource("lblProfessionalExpiriences", Request.Cookies["userLanguage"].Value);
                    lblEducation.Text = cGlobalResourceObject.getGlobalResource("lblEducation", Request.Cookies["userLanguage"].Value);
                    lblAdditionalInformation.Text = cGlobalResourceObject.getGlobalResource("lblAdditionalInformation", Request.Cookies["userLanguage"].Value);
                    loadResume();
                }
            }
            catch (Exception)
            { 
            }
        }

        protected void loadResume()
        {
            if (resume.getResume(((UserMasterPages.ImPage1)this.Page.Master).Profile.Idaccount, ((UserMasterPages.ImPage1)this.Page.Master).Profile.Language.Idlanguage))
            {
                lblResumeGoals.Text = resume.Goals.Replace(Environment.NewLine, "<br />");
                lblResumeAddInfo.Text = resume.AddInfo.Replace(Environment.NewLine, "<br />");
                txtResumeGoals.Text = resume.Goals;
                txtAddInfo.Text = resume.AddInfo;

                cEducation _education = new cEducation();
                education.DataSource = _education.GetEducations(resume.IdAccount, resume.IdLanguage);
                education.DataBind();

                cProfExp _profExp = new cProfExp();
                profExp.DataSource = _profExp.GetProfessionalExperiences(resume.IdAccount, resume.IdLanguage);
                profExp.DataBind();
            }
            else
            {
                resume.Goals = "";
                resume.AddInfo = "";
                if (resume.insert(((UserMasterPages.ImPage1)this.Page.Master).Profile.Idaccount, ((UserMasterPages.ImPage1)this.Page.Master).Profile.Language.Idlanguage))
                    loadResume();
                else
                { 
                }
            }
        }

        protected void btnSaveResumeGoals_Click(object sender, EventArgs e)
        {
            resume.Goals = txtResumeGoals.Text;
            resume.update();
            loadResume();
        }

        protected void btnSaveAditionalInfo_Click(object sender, EventArgs e)
        {
            resume.AddInfo = txtAddInfo.Text;
            resume.update();
            loadResume();
        }

        protected void education_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Label _lblDate = (Label)e.Item.FindControl("lblDate");
            HiddenField _hfStartM = (HiddenField)e.Item.FindControl("hfStartM");
            HiddenField _hfStartY = (HiddenField)e.Item.FindControl("hfStartY");
            HiddenField _hfEndM = (HiddenField)e.Item.FindControl("hfEndM");
            HiddenField _hfEndY = (HiddenField)e.Item.FindControl("hfEndY");
            int _month = int.Parse(_hfStartM.Value);
            if (_month < 10)
                _hfStartM.Value = "0" + _hfStartM.Value;
            if ((_hfEndM.Value == "") || (_hfEndY.Value == ""))
            {
                _lblDate.Text = " - (" + _hfStartM.Value + "/" + _hfStartY.Value + " - " + cGlobalResourceObject.getGlobalResource("lblCurrently", Request.Cookies["userLanguage"].Value) + ")";
            }
            else
            {
                _month = int.Parse(_hfEndM.Value);
                if (_month < 10)
                    _hfEndM.Value = "0" + _hfEndM.Value;
                _lblDate.Text = " - (" + _hfStartM.Value + "/" + _hfStartY.Value + " - " + _hfEndM.Value + "/" + _hfEndY.Value + ")";
            }
        }

        protected void profExp_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Label _lblDate = (Label)e.Item.FindControl("lblDate");
            HiddenField _hfStartM = (HiddenField)e.Item.FindControl("hfStartM");
            HiddenField _hfStartY = (HiddenField)e.Item.FindControl("hfStartY");
            HiddenField _hfEndM = (HiddenField)e.Item.FindControl("hfEndM");
            HiddenField _hfEndY = (HiddenField)e.Item.FindControl("hfEndY");
            int _month = int.Parse(_hfStartM.Value);
            if (_month < 10)
                _hfStartM.Value = "0" + _hfStartM.Value;
            if ((_hfEndM.Value == "") || (_hfEndY.Value == ""))
            {
                _lblDate.Text = " - (" + _hfStartM.Value + "/" + _hfStartY.Value + " - " + cGlobalResourceObject.getGlobalResource("lblCurrently", Request.Cookies["userLanguage"].Value) + ")";
            }
            else
            {
                _month = int.Parse(_hfEndM.Value);
                if (_month < 10)
                    _hfEndM.Value = "0" + _hfEndM.Value;
                _lblDate.Text = " - (" + _hfStartM.Value + "/" + _hfStartY.Value + " - " + _hfEndM.Value + "/" + _hfEndY.Value + ")";
            }
        }
    }
}