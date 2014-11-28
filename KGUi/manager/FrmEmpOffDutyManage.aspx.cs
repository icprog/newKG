using KGLib.dl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tw.com.kg.lib;

namespace KGUi.manager
{
    public partial class FrmEmpOffDutyManage : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {

            _context = SealedGlobalPage.getContext(this);
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;
            if (l_user == null)
            {
                Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
                Response.Redirect("../../FrmLogin.aspx");
                return;
            }
            if (!Page.IsPostBack)
            {
                GetData();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                OffDutyFactory l_factory紀錄 = _context.CFactoryManager.OffDutyFactory;
                l_factory紀錄.AddOffDuty(txtEmp.Text, txtName.Text);
                GetData();
                txtEmp.Text = "";
                txtName.Text = "";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('新增出錯可能是員工編號重複');", true);
            }
        }

        public void GetData()
        {
            OffDutyFactory l_factory紀錄 = _context.CFactoryManager.OffDutyFactory;

            DataTable dt = l_factory紀錄.GetData("");
            this.gvOffDuty.DataSource = dt;
            this.gvOffDuty.DataBind();
        }

        protected void gvOffDuty_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            OffDutyFactory l_factory紀錄 = _context.CFactoryManager.OffDutyFactory;
            if (e.CommandName == "Delete")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                string lKey = gvOffDuty.DataKeys[rowIndex]["EMPNO"].ToString();

                l_factory紀錄.RemoveData(lKey);
            }
            GetData();
        }

        protected void gvOffDuty_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvOffDuty.PageIndex = e.NewPageIndex;
            GetData();
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            GetData();
        }

        protected void gvOffDuty_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}