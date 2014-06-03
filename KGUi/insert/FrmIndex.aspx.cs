using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using tw.com.kg.lib;
using KGUi.tools;

namespace KGUi.insert
{
    public partial class FrmIndex : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);

            if (!Page.IsPostBack)
            {
                CUser l_user = getUser();

                if (l_user != null)
                {
                    if (l_user.f_branch所別名稱.IndexOf("廠") > 0)
                    {
                        _btn小百貨.Visible = false;
                    }
                    else
                    {
                        _btn小百貨.Visible = true;
                    }
                }
                else
                {
                    Response.Redirect("../FrmLogin.aspx");
                }
                秀出該單位所有未處理工單();
            }
        }

        private CUser getUser()
        {
            return Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;
        }
        private void 秀出該單位所有未處理工單()
        {
            CWork[] l_works = _context.CFactoryManager.CWorkFactory.get所別待處理工單(getUser().f_branchid所別);
            display(l_works);
        }

        private void display(CWork[] p_CWork)
        {
            string[] l_Msg = new string[] { "項次", "工單號碼", "引擎號碼", "顧客名稱", "洗車種類", "金額", "開單日期", "開單人員"};
            DataTable l_dt = CTools.getFilledColumnsDataTable(l_Msg);

            if (p_CWork.Length <= 0)
            {
                return;
            }

            for (int i = 0; i < p_CWork.Length; i++)
            {
                DataRow l_row = l_dt.NewRow();
                l_row["項次"] = (i + 1).ToString();
                l_row["工單號碼"] = p_CWork[i].f_workid工單單號;
                l_row["引擎號碼"] = p_CWork[i].f_engo引擎號碼;
                
                l_row["顧客名稱"] = p_CWork[i].f_customerid顧客名稱;
                l_row["洗車種類"] = p_CWork[i].f_workType洗車種類;
                l_row["金額"] = p_CWork[i].f_money金額;
                l_row["開單日期"] = p_CWork[i].f_editdate開單日期;
                l_row["開單人員"] = p_CWork[i].f_edituser開單人員;

                l_dt.Rows.Add(l_row);
                Session.Add(p_CWork[i].f_workid工單單號, p_CWork[i]);
            }
            _gvWork.DataSource = l_dt;
            _gvWork.DataBind();
        }

        protected void _btn列印_Click(object sender, EventArgs e)
        {
            ImageButton l_btn = (ImageButton)sender;
            GridViewRow l_row = (GridViewRow)l_btn.Parent.Parent;
            string l_id = ((Label)l_row.Cells[1].Controls[1]).Text;
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "window.open('./FrmPrintWork.aspx?id=" + l_id + "','my_window','scrollbars=yes,menubar=no,height=600,width=800,resizable=yes,toolbar=no,location=no,status=no');", true);

        }

        protected void _btn開立工單_Click(object sender, EventArgs e)
        {
            Response.Redirect("./FrmWorkType.aspx");
        }

        protected void _btn歷史查詢_Click(object sender, EventArgs e)
        {
            Response.Redirect("./FrmHistory.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../part/FrmInsertKGPartOrder.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
            Response.Redirect("../FrmLogin.aspx");
        }

        protected void _btn小百貨_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../part/WfrmMain.htm");       
        }

    }
}
