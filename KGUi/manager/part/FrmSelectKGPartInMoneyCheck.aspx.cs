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
    public partial class FrmSelectKGPartInMoneyCheck : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);

            if (!Page.IsPostBack)
            {
                CTools.get所別(iv_cbo所別, _context);
                _txtBDate.Text = DateTime.Today.AddMonths(-1).ToString("yyyy/MM/01");
                _txtEDate.Text = DateTime.Today.ToString("yyyy/MM/dd");
            }
        }

        protected void iv_btn查詢_Click(object sender, EventArgs e)
        {
            查詢資料();
        }
        private void 查詢資料()
        {
            //iv_lblShow訂購單號.Text = "";
            //iv_lblShow請購單號.Text = "";

            string l_str所別 = iv_cbo所別.SelectedValue;
            string l_str廠商 = iv_cbo廠商.SelectedValue;
            string l_str起始日 = _txtBDate.Text.Trim();
            string l_str結束日 = _txtEDate.Text.Trim();

            CKGPartOrder[] l_codes = _context.CFactoryManager.CKGPartOrderFactory.
                get小百貨對帳單資訊(l_str起始日, l_str結束日, l_str所別, l_str廠商);
            if (l_codes == null)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('查無訂購資料');", true);
            }
            else
            {
                display訂購清單(l_codes);
            }

            //退貨資料
            CKGPartOrderDetailOutFactory l_factory退貨 = _context.CFactoryManager.CKGPartOrderDetailOutFactory;
            CKGPartOrderDetailOut[] l_codes退貨 = l_factory退貨.getAll退貨資料By條件("", "", l_str所別, "", "True", l_str起始日, l_str結束日);

            if (l_codes退貨 == null)
            {
                iv_lbl退貨明細.Text = "查詢區間內無退貨記錄";
            }
            else
            {
                iv_lbl退貨明細.Text = "退貨明細：";
                display退貨歷史記錄(l_codes退貨);
            }
        }

        private void display訂購清單(CKGPartOrder[] p_codes)
        {
            GridView1.DataSource = getDataTableBydisplay訂購清單(p_codes);
            GridView1.DataBind();
        }
        private DataTable getDataTableBydisplay訂購清單(CKGPartOrder[] p_codes)
        {
            string[] l_str = { "訂購單號", "廠商代號", "廠商", "訂購日期", "請購單位", "成本總計", "訂購總計", "販賣總計" };

            DataTable l_table = CTools.getFilledColumnsDataTable(l_str);

            if (p_codes == null)
            {
                return l_table;
            }

            for (int i = 0; i < p_codes.Length; i++)
            {
                DataRow l_row = l_table.NewRow();
                l_row["訂購單號"] = p_codes[i].f_ExchangeID請購單號;//1
                l_row["廠商代號"] = p_codes[i].f_Vendor請購廠商;//2
                l_row["廠商"] = set廠商名稱(p_codes[i].f_Vendor請購廠商);//2
                l_row["訂購日期"] = p_codes[i].f_InsertDate請購日期;//2
                l_row["請購單位"] =CTools.get轉換據點中英文( p_codes[i].f_Branchid請購單位 );//2
                l_row["成本總計"] = p_codes[i].f_TotalCost總成本價;//3
                l_row["訂購總計"] = p_codes[i].f_TotalPrice總計價格;//4
                l_row["販賣總計"] = p_codes[i].f_TotalSale總販賣價;//4

                l_table.Rows.Add(l_row);
            }

            return l_table;
        }

        private void display退貨歷史記錄(CKGPartOrderDetailOut[] p_codes)
        {
            GridView4.DataSource = getDataTableBydisplay退貨歷史記錄(p_codes);
            GridView4.DataBind();
        }
        private DataTable getDataTableBydisplay退貨歷史記錄(CKGPartOrderDetailOut[] p_codes)
        {
            string[] l_str = { "請購單號", "退貨日期", "員編", "姓名", "單位", "成本", "總計" };

            DataTable l_table = CTools.getFilledColumnsDataTable(l_str);

            if (p_codes == null)
            {
                return l_table;
            }

            for (int i = 0; i < p_codes.Length; i++)
            {
                DataRow l_row = l_table.NewRow();

                l_row["請購單號"] = p_codes[i].f_ExchangeID請購單號;//1
                l_row["退貨日期"] = p_codes[i].f_OutDate退貨日期;//2
                l_row["員編"] = p_codes[i].f_SalesSmid業代員編;//3

                CUser l_user = _context.CFactoryManager.CUserFactory.get高都員工檔(p_codes[i].f_SalesSmid業代員編);
                l_row["姓名"] = l_user.f_username姓名;//4
                l_row["單位"] = p_codes[i].f_SalesBranch業代單位;//5
                l_row["成本"] = p_codes[i].f_Cost產品成本 * p_codes[i].f_OutAmount退貨數量;//8
                //l_row["單價"] = p_codes[i].f_UnitPrice產品單價;//8
                l_row["總計"] = p_codes[i].f_OutTotal總計退貨價格;//10
                //l_row["退貨原因"] = p_codes[i].f_OutReasons退貨原因;//1
                l_table.Rows.Add(l_row);
            }

            return l_table;
        }

        int iv_int退貨SumCost = 0;
        int iv_int退貨SumPrice = 0;
        protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                iv_int退貨SumCost += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "成本"));
                iv_int退貨SumPrice += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "總計"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "總計";
                e.Row.Cells[5].Text = iv_int退貨SumCost.ToString();
                e.Row.Cells[6].Text = iv_int退貨SumPrice.ToString();
                e.Row.Font.Bold = true;
                e.Row.HorizontalAlign = HorizontalAlign.Center;
            }
        }

        private string set廠商名稱(string p_str廠商代號)
        {
            switch (p_str廠商代號)
            {
                case "KC": return "亙長";
                case "LD": return "劦大";
                case "KG": return "高輊";
                case "HM": return "惠明";
                case "KCF": return "亙長(服務廠)";
                case "LDF": return "劦大(服務廠)";
                default: return "";
            }
        }

        protected void _btn明細_Click(object sender, EventArgs e)
        {
            Button l_btn = (Button)sender;
            GridViewRow l_row = (GridViewRow)l_btn.Parent.Parent;
            string l_workid = ((Label)l_row.Cells[0].Controls[1]).Text;


            CKGPartOrderDetail[] l_detail = _context.CFactoryManager.
             CKGPartOrderDetailFactory.get請購明細ByExchangeID(l_workid);
            display小百貨明細(l_detail);


        }

        private void display小百貨明細(CKGPartOrderDetail[] p_detail)
        {
            GridView2.DataSource = getDataTableByDisplay小百貨明細(p_detail);
            GridView2.DataBind();
        }

        private DataTable getDataTableByDisplay小百貨明細(CKGPartOrderDetail[] p_detail)
        {

            string[] l_Msg = new string[] { "項次", "單號", "產品編號", "產品名稱", "數量", "金額", "販賣價", "開單人員" };
            DataTable l_dt = CTools.getFilledColumnsDataTable(l_Msg);

            for (int i = 0; i < p_detail.Length; i++)
            {
                DataRow l_row = l_dt.NewRow();
                l_row["項次"] = "1";
                l_row["單號"] = p_detail[i].f_ExchangeID請購單號;
                l_row["產品編號"] = p_detail[i].f_ProductID產品編號;
                l_row["產品名稱"] = p_detail[i].f_ProductName產品名稱;
                l_row["數量"] = p_detail[i].f_Amount選購數量;
                l_row["金額"] = p_detail[i].f_Cost產品成本價;
                l_row["販賣價"] = p_detail[i].f_SalePrice販賣價;

                CKGPartOrder l_order = _context.CFactoryManager.CKGPartOrderFactory.
                    getKGPartOrderBy請購單號(p_detail[i].f_ExchangeID請購單號);
                try
                {
                    l_row["開單人員"] = _context.CFactoryManager.CUserFactory.get高都員工檔(
                        l_order.f_AssistantSmid助理員編).f_username姓名;
                }
                catch { l_row["開單人員"] = "無此員編(" + l_order.f_AssistantSmid助理員編 + ")"; }
                l_dt.Rows.Add(l_row);
            }
            return l_dt;
        }
    }
}
