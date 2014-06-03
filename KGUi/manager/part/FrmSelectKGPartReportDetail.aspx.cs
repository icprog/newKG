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
    public partial class FrmSelectKGPartReportDetail : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);

            if (!Page.IsPostBack)
            {
                //_txtBDate.Text = DateTime.Today.ToString("yyyy/MM/dd");
                //_txtEDate.Text = DateTime.Today.ToString("yyyy/MM/dd");
            }

        }

        protected void iv_btn報表查詢_Click(object sender, EventArgs e)
        {
            string l_str單號 = _txt單號.Text;
            string l_str員編 = _txt員編.Text;
            string l_str起始日期 = _txtBDate.Text.Trim();
            string l_str結束日期 = _txtEDate.Text.Trim();

            C小百貨銷售明細Factory l_factory = _context.CFactoryManager.C小百貨銷售明細Factory;
            C小百貨銷售明細[] l_小百貨銷售明細 = l_factory.get小百貨銷售明細(l_str起始日期, l_str結束日期, l_str員編, l_str單號);
            dispaly(l_小百貨銷售明細);
        }

        private void dispaly(C小百貨銷售明細[] p_codes)
        {
            GridView1.DataSource = getTableByDisplay(p_codes);
            GridView1.DataBind();
        }
        private DataTable getTableByDisplay(C小百貨銷售明細[] p_codes)
        {
            string[] l_str = { "單號", "所別", "日期", "員編", "姓名", "產品編號", "產品名稱", "數量", "單價", "販賣單價", "總計", "訂貨總計" };

            DataTable l_table = CTools.getFilledColumnsDataTable(l_str);

            if (p_codes == null)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('無符合資料!請重新確認');", true);
                return l_table;
            }

            string l_str營業所 = "";
            for (int i = 0; i < p_codes.Length; i++)
            {
                DataRow l_row = l_table.NewRow();

                if (!l_str營業所.Equals(p_codes[i].單號))
                {
                    l_row["單號"] = p_codes[i].單號;//
                }
                else
                {
                    l_row["單號"] = "";
                }
                string l_str所別 = CTools.get轉換據點中英文(p_codes[i].所別);//6
                l_row["所別"] = l_str所別;
                if (_rdoType.SelectedValue.Equals("服務廠"))
                {
                    if (l_str所別.IndexOf("廠") <= 0)
                    {
                        continue;
                    }
                }
                else if (_rdoType.SelectedValue.Equals("營業所"))
                {
                    if (l_str所別.IndexOf("廠") > 0)
                    {
                        continue;
                    }
                }
                l_row["日期"] = p_codes[i].日期;//6
                l_row["員編"] = p_codes[i].員編;//6
                l_row["姓名"] = p_codes[i].姓名;//6
                l_row["產品編號"] = p_codes[i].產品編號;//6
                l_row["產品名稱"] = p_codes[i].產品名稱;//6
                l_row["數量"] = p_codes[i].數量;//6
                l_row["單價"] = p_codes[i].單價;//6
                l_row["販賣單價"] = p_codes[i].販賣單價;//6
                l_row["總計"] = p_codes[i].總計;//6
                l_row["訂貨總計"] = p_codes[i].數量 * p_codes[i].單價;//6

                l_str營業所 = p_codes[i].單號;
                l_table.Rows.Add(l_row);
            }

            return l_table;
        }
        private int iv_intSumPrice { get; set; }
        private int iv_intSumPriceTotal { get; set; }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                iv_intSumPrice += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "總計"));
                iv_intSumPriceTotal += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "訂貨總計"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[7].Text = "總計";
                e.Row.Cells[10].Text = iv_intSumPriceTotal.ToString();
                e.Row.Cells[11].Text =iv_intSumPrice.ToString();
                e.Row.Font.Bold = true;
                e.Row.HorizontalAlign = HorizontalAlign.Center;
            }
        }
    }
}
