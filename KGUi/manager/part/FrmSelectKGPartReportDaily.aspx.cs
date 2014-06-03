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
    public partial class FrmSelectKGPartReportDaily : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);

            if (!Page.IsPostBack)
            {
                CTools.get所別(iv_cbo營業所別,_context);
                _txtBDate.Text = DateTime.Today.ToString("yyyy/MM/dd");
                _txtEDate.Text = DateTime.Today.ToString("yyyy/MM/dd");
            }
        }

        protected void iv_btn報表查詢_Click(object sender, EventArgs e)
        {
            string l_str所別 = iv_cbo營業所別.SelectedValue;
            string l_str廠商 = iv_cbo廠商.SelectedValue;
            string l_str起始日期 = _txtBDate.Text.Trim();
            string l_str結束日期 = _txtEDate.Text.Trim();

            CKGPartOrderFactory l_factory主檔 = _context.CFactoryManager.CKGPartOrderFactory;
            CKGPartOrder[] l_codes主檔 = l_factory主檔.get各所日報的請購總金額(l_str所別, l_str廠商, l_str起始日期, l_str結束日期);
            dispaly各所Total(l_codes主檔);
        }
        private void dispaly各所Total(CKGPartOrder[] p_codes)
        {
            GridView1.DataSource = get各所TotalBydisplay(p_codes);
            GridView1.DataBind();
        }

        private DataTable get各所TotalBydisplay(CKGPartOrder[] p_codes)
        {
            int iv_intSumCost = 0;
            int iv_intSumPrice = 0;
            string[] l_str = { "營業所", "請購日期", "請購成本", "請購總金額", "總販賣金額" };

            DataTable l_table = CTools.getFilledColumnsDataTable(l_str);

            if (p_codes == null)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('無符合資料!請重新確認');", true);
                return l_table;
            }

            string l_str營業所 = "";
            int l_int所小記 = 0;
            int l_int總請購 = 0;
            int l_int總販賣 = 0;
            int l_int總請購Sum = 0;
            int l_int總販賣Sum = 0;
            for (int i = 0; i < p_codes.Length; i++)
            {
                DataRow l_row = l_table.NewRow();

                if (!l_str營業所.Equals(p_codes[i].f_SalesBranch業代單位))
                {
                    l_row["營業所"] =CTools.get轉換據點中英文( p_codes[i].f_SalesBranch業代單位 );//

                    if (i != 0 )
                    {
                        DataRow l_row小記 = l_table.NewRow();
                        l_row小記["請購日期"] = "小計:";
                        l_row小記["請購成本"] = l_int總請購;
                        l_row小記["請購總金額"] = l_int所小記;
                        l_row小記["總販賣金額"] = l_int總販賣;
                        l_table.Rows.Add(l_row小記);
                        l_int總請購 = 0;
                        l_int所小記 = 0;
                        l_int總販賣 = 0;
                    }
                }
                else
                {
                    l_row["營業所"] = "";
                  
                }
                l_row["請購日期"] = p_codes[i].f_InsertDate請購日期;//6
                l_row["請購成本"] = p_codes[i].f_TotalCost總成本價;//6
                l_row["請購總金額"] = p_codes[i].f_TotalPrice總計價格;//6
                l_int總請購 += p_codes[i].f_TotalCost總成本價;
                l_row["總販賣金額"] = p_codes[i].f_TotalSale總販賣價;//6
                l_int總販賣 += p_codes[i].f_TotalSale總販賣價;
                l_int所小記 += p_codes[i].f_TotalPrice總計價格;//6
                l_str營業所 = p_codes[i].f_SalesBranch業代單位;

                iv_intSumCost+=p_codes[i].f_TotalCost總成本價;
                iv_intSumPrice += p_codes[i].f_TotalPrice總計價格;
                l_int總販賣Sum += p_codes[i].f_TotalSale總販賣價;
                l_table.Rows.Add(l_row);
            }

            DataRow l_row總記 = l_table.NewRow();
            l_row總記["請購日期"] = "總計";
            l_row總記["請購成本"] = iv_intSumCost;
            l_row總記["請購總金額"] = iv_intSumPrice;
            l_row總記["總販賣金額"] = l_int總販賣Sum;
            l_table.Rows.Add(l_row總記);
            return l_table;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //try
            //{
            //    if (e.Row.RowType == DataControlRowType.DataRow)
            //    {
            //        iv_intSumCost += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "請購成本"));
            //        iv_intSumPrice += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "請購總金額"));
            //    }
            //    else if (e.Row.RowType == DataControlRowType.Footer)
            //    {
            //        e.Row.Cells[0].Text = "總計";
            //        e.Row.Cells[2].Text = iv_intSumCost.ToString();
            //        e.Row.Cells[3].Text = iv_intSumPrice.ToString();
            //        e.Row.Font.Bold = true;
            //        e.Row.HorizontalAlign = HorizontalAlign.Center;
            //    }
            //}
            //catch { }
        }
    
    }
}
