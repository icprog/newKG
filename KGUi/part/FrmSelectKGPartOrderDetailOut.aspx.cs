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

namespace KGUi.part
{
    public partial class FrmSelectKGPartOrderDetailOut : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);
        }

        protected void iv_btn查詢_Click(object sender, EventArgs e)
        {
            get退貨記錄();
        }

        private void get退貨記錄()
        {
            string l_str業代員編 = iv_txt業代員編.Text.Trim().ToUpper();
            string l_str請購單號 = iv_txt請購單號.Text.Trim().ToUpper();
            string l_str起始日期 = _txtBDate.Text.Trim();
            string l_str結束日期 = _txtEDate.Text.Trim();
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;

            if (l_user == null)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('閒置過久，請重新登入')", true);
                return;
            }
            string l_str助理員編 = l_user.f_userid帳號;//"F9446";//

            CKGPartOrderDetailOutFactory l_factory = _context.CFactoryManager.
                CKGPartOrderDetailOutFactory;
            CKGPartOrderDetailOut[] l_codes = l_factory.getAll退貨資料By條件(l_str助理員編, l_str請購單號, "", l_str業代員編, "False", l_str起始日期, l_str結束日期);

            if (l_codes == null)
            {
                iv_pnl查詢結果.Visible = false;
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('無退貨記錄')", true);
            }
            else
            {
                iv_pnl查詢結果.Visible = true;
                display退貨記錄(l_codes);
            }
        }

        private void display退貨記錄(CKGPartOrderDetailOut[] p_codes)
        {
            GridView1.DataSource = getDataTableBydisplay退貨記錄(p_codes);
            GridView1.DataBind();
        }
        private DataTable getDataTableBydisplay退貨記錄(CKGPartOrderDetailOut[] p_codes)
        {
            string[] l_str = { "id", "EID", "請購單號", "退貨日期", "業代員編", "業代姓名", "產品編號", "產品名稱", "單價", "退貨數量", "總計", "退貨原因", "Visible" };

            DataTable l_table = CTools.getFilledColumnsDataTable(l_str);

            if (p_codes == null)
            {
                return l_table;
            }

            string l_str請購單號 = "";
            for (int i = 0; i < p_codes.Length; i++)
            {
                DataRow l_row = l_table.NewRow();

                l_row["id"] = "" + p_codes[i].f_id;//1
                l_row["EID"] = "" + p_codes[i].f_ExchangeID請購單號;//1

                if (!l_str請購單號.Equals(p_codes[i].f_ExchangeID請購單號))
                {
                    l_row["Visible"] = "True";
                }
                else
                {
                    l_row["Visible"] = "False";
                }

                l_row["請購單號"] = p_codes[i].f_ExchangeID請購單號;//2
                l_row["退貨日期"] = p_codes[i].f_OutDate退貨日期;//3
                l_row["業代員編"] = p_codes[i].f_SalesSmid業代員編;//4
                l_row["業代姓名"] = p_codes[i].f_SalesName業代姓名;//5
                //l_row["業代單位"] = p_codes[i].f_SalesBranch業代單位;//6
                l_row["產品編號"] = p_codes[i].f_ProductID產品編號;//7
                l_row["產品名稱"] = p_codes[i].f_ProductName產品名稱;//8
                l_row["單價"] = p_codes[i].f_UnitPrice產品單價;//9
                l_row["退貨數量"] = p_codes[i].f_OutAmount退貨數量;//10
                l_row["總計"] = p_codes[i].f_OutTotal總計退貨價格;//11
                l_row["退貨原因"] = p_codes[i].f_OutReasons退貨原因;//12

                l_str請購單號 = p_codes[i].f_ExchangeID請購單號;

                l_table.Rows.Add(l_row);
            }

            return l_table;
        }

        private string getEID(object sender)
        {
            Button l_btn = (Button)sender;
            return ((Label)l_btn.FindControl("iv_lblEID")).Text;
        }
        protected void iv_btn列印_Click(object sender, EventArgs e)
        {
            string l_strURL = "FrmPrintKGPartOrder.aspx?EID=" + getEID(sender) + "&Type=Out";
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "修改員工資料", "window.open(\"" + l_strURL + "\",null,\"menubar=1,toolbar=0,scrollbars=1 ,status=0\");", true);
        }

        protected void iv_btn取消退貨_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox l_chk取消 = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("iv_chk取消");

                if (l_chk取消.Checked)
                {
                    string l_str取消Id = ((Label)GridView1.Rows[i].Cells[0].FindControl("iv_lblID")).Text;
                    _context.CFactoryManager.CKGPartOrderDetailOutFactory.deleteCKGPartOrderDetailOut(l_str取消Id);
                }
            }

            get退貨記錄();
        }
    }
}
