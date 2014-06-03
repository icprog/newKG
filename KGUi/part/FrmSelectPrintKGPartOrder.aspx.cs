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
    public partial class FrmSelectPrintKGPartOrder : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);

            if (!Page.IsPostBack)
            {
                _txtBDate.Text = DateTime.Today.ToString("yyyy/MM/dd");
                _txtEDate.Text = DateTime.Today.ToString("yyyy/MM/dd");
            }
        }

        protected void iv_btn查詢請購單號_Click(object sender, EventArgs e)
        {
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;
            string l_str助理Smid = l_user.f_userid帳號;//"H9503";//
            string l_str請購單號 = _txt請購編號.Text.Trim();
            string l_str起始日期 = _txtBDate.Text.Trim();
            string l_str結束日期 = _txtEDate.Text.Trim();
            string l_str廠商 = _cbo廠商.SelectedValue;

            CKGPartOrderFactory l_factory = _context.CFactoryManager.CKGPartOrderFactory;
            CKGPartOrder[] l_codes = l_factory.getKGPartOrderBy請購單號(l_str請購單號, l_str助理Smid, l_str廠商, l_str起始日期, l_str結束日期);

            display(l_codes);
        }

        private void display(CKGPartOrder[] p_codes)
        {

            if (p_codes == null)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('查無資料')", true);
               
                return;
            }

            GridView1.DataSource = getDataTableByGridView(p_codes);
            GridView1.DataBind();
        }
        private DataTable getDataTableByGridView(CKGPartOrder[] p_codes)
        {
            string[] l_str = { "EID", "廠商", "日期", "員編", "姓名", "單位", "總計金額", "備註" };

            DataTable l_table = CTools.getFilledColumnsDataTable(l_str);
            int l_intTotal = 0;
            int l_intTotalBy販賣 = 0;
            for (int i = 0; i < p_codes.Length; i++)
            {
                DataRow l_row = l_table.NewRow();

                l_row["EID"] = p_codes[i].f_ExchangeID請購單號;//1
                l_row["廠商"] = set轉換廠商代碼(p_codes[i].f_Vendor請購廠商);
                l_row["日期"] = p_codes[i].f_InsertDate請購日期;//6
                l_row["員編"] = p_codes[i].f_SalesSmid業代員編;//3
                l_row["姓名"] = p_codes[i].f_SalesName業代姓名;//4
                l_row["單位"] = p_codes[i].f_SalesBranch業代單位;//4
                CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;
                if (l_user == null)
                {
                    Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
                    Response.Redirect("../FrmLogin.aspx");
                }
                l_row["總計金額"] = p_codes[i].f_TotalPrice總計價格 + "(" + p_codes[i].f_TotalSale總販賣價 + ")";//4
                    l_intTotal += p_codes[i].f_TotalPrice總計價格;
                l_intTotalBy販賣 += p_codes[i].f_TotalSale總販賣價;
                //l_intTotal += p_codes[i].f_TotalPrice總計價格;
                l_row["備註"] = p_codes[i].f_Memo備註說明;//4
                l_table.Rows.Add(l_row);
            }
            _lblTotal.Text = l_intTotal.ToString() + "(" + l_intTotalBy販賣 + ")";
            return l_table;
        }

        private string set轉換廠商代碼(string p_strVendor)
        {
            switch (p_strVendor)
            {
                case "KC": return "亙長";
                case "LD": return "劦大";
                case "KG": return "高輊";
                default: return "";
                   
            }
        }


        private string get請購單號(object sender)
        {
            Button l_btn = (Button)sender;
            return ((Label)l_btn.FindControl("iv_lblEID")).Text;
        }

        protected void _btn列印_Click(object sender, EventArgs e)
        {
            string l_strURL = "FrmPrintKGPartOrder.aspx?EID=" + get請購單號(sender) + "&Type=Buy";
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "修改員工資料", "window.open(\"" + l_strURL + "\",null,\"menubar=1,toolbar=0,scrollbars=1 ,status=0\");", true);
        }
    }
}
