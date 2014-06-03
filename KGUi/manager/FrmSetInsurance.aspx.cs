using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using tw.com.kg.lib;
using KGUi.tools;

namespace KGUi.manager
{
    public partial class FrmSetInsurance : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);

            if (!this.IsPostBack)
            {
                search();
            }
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;

            if (l_user == null)
            {
                Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
                Response.Redirect("../FrmLogin.aspx");
            }
        }

        private void search()
        {

            CInsurance[] l_Insurance = _context.CFactoryManager.CInsuranceFactory.getAll保險公司();

            if (l_Insurance.Length <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('尚未設定保險公司資料');", true);
                return;
            }
            display(l_Insurance);
        }

        private void display(CInsurance[] l_Insurance)
        {
            string[] l_Msg = new string[] { "項次", "代號", "名稱" };
            DataTable l_dt = CTools.getFilledColumnsDataTable(l_Msg);


            for (int i = 0; i < l_Insurance.Length; i++)
            {
                DataRow l_row = l_dt.NewRow();
                l_row["項次"] = (i + 1).ToString();
                l_row["代號"] = l_Insurance[i].f_id代碼;
                l_row["名稱"] = l_Insurance[i].f_f_name名稱;

                l_dt.Rows.Add(l_row);
            }
            GridView1.DataSource = l_dt;
            GridView1.DataBind();
        }
        protected void _btn設定_Click(object sender, EventArgs e)
        {
            if ("".Equals(_txt代號.Text.Trim()))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "ERROR", "alert('代號不得空白');", true);
                return;
            }
            if ("".Equals(_txt名稱.Text.Trim()))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "ERROR", "alert('名稱不得空白');", true);
                return;
            }

            CInsurance l_Insurance = _context.CFactoryManager.CInsuranceFactory.createCInsurance();

            l_Insurance.f_id代碼 = _txt代號.Text.Trim();
            l_Insurance.f_f_name名稱 = _txt名稱.Text.Trim();

            _context.CFactoryManager.CInsuranceFactory.insert(l_Insurance);

            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('設定成功');", true);
            clearUI();
            search();
        }

        private void clearUI()
        {
            _txt代號.Text = "";
            _txt名稱.Text = "";
        }


        protected void _btn刪除_Click(object sender, EventArgs e)
        {
            Button l_btn = (Button)sender;
            GridViewRow l_row = (GridViewRow)l_btn.Parent.Parent;
            string l_id = ((Label)l_row.Cells[1].Controls[1]).Text;
            _context.CFactoryManager.CInsuranceFactory.deleteByID(l_id);
            search();
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('刪除成功');", true);    
        }
    }
}
