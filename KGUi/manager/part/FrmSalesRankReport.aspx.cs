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

namespace KGUi.manager.part
{
    public partial class FrmSalesRankReport : System.Web.UI.Page
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
            }
        }

        protected void _btn查詢_Click(object sender, EventArgs e)
        {

            string l_strBDate = _txtBDate.Text.Trim();
            string l_strEDate = _txtEDate.Text.Trim();

            C小百貨產品銷售排行[] l_C小百貨產品銷售排行 = _context.CFactoryManager.
                C小百貨產品銷售排行Factory.get產品排行(l_strBDate, l_strEDate);

            display(l_C小百貨產品銷售排行);
        }


        private void display(C小百貨產品銷售排行[] p_小百貨產品銷售排行)
        {
            string[] l_Msg = new string[] { "項次", "產品編號", "產品名稱", "銷售次數", "總銷售金額" };
            DataTable l_dt = CTools.getFilledColumnsDataTable(l_Msg);

            if (p_小百貨產品銷售排行.Length <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('無符合資料!請重新確認');", true);

                _gvAmt.DataSource = l_dt;
                _gvAmt.DataBind();
                return;
            }

            for (int i = 0; i < p_小百貨產品銷售排行.Length; i++)
            {
                DataRow l_row = l_dt.NewRow();
                l_row["項次"] = (i + 1).ToString();
                l_row["產品編號"] = p_小百貨產品銷售排行[i].編號;
                l_row["產品名稱"] = p_小百貨產品銷售排行[i].名稱;
                l_row["銷售次數"] = p_小百貨產品銷售排行[i].銷售次數;
                l_row["總銷售金額"] = p_小百貨產品銷售排行[i].總銷售金額;
                l_dt.Rows.Add(l_row);
            }
            _gvAmt.DataSource = l_dt;
            _gvAmt.DataBind();
        }
    }
}
