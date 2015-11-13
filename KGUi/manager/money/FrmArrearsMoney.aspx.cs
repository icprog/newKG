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

namespace KGUi.manager.money
{
    public partial class FrmArrearsMoney : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);
        }

        protected void _btn查詢_Click(object sender, EventArgs e)
        {
            C欠款紀錄[] l_C欠款紀錄;
            string l_strBDate = _txtBDate.Text;
            string l_strEDate = _txtEDate.Text;
            string l_strB帳款日期 = _txtB帳款日期.Text;
            string l_strE帳款日期 = _txtE帳款日期.Text;
            string l_strSmid = _txt員編.Text;
            if ("".Equals(l_strB帳款日期) && "".Equals(l_strE帳款日期))
            {
                if ("".Equals(l_strBDate))
                {
                    l_strBDate = "2010/01/01";
                }
                if ("".Equals(l_strEDate))
                {
                    l_strEDate = l_strBDate;
                }
                if ("".Equals(l_strEDate))
                {
                    l_strEDate = DateTime.Today.ToString("yyyy/MM/dd");
                }
            }



            if ("".Equals(l_strBDate) && "".Equals(l_strEDate))
            {
                if ("".Equals(l_strB帳款日期))
                {
                    l_strB帳款日期 = "2010/01/01";
                }
                if ("".Equals(l_strE帳款日期))
                {
                    l_strE帳款日期 = l_strB帳款日期;
                }
                if ("".Equals(l_strE帳款日期))
                {
                    l_strE帳款日期 = DateTime.Today.ToString("yyyy/MM/dd");
                }
            }

            if ("N".Equals(_rdolist.SelectedValue))
            {
                l_C欠款紀錄 = _context.CFactoryManager.C欠款紀錄Factory
                    .get欠款紀錄(l_strBDate, l_strEDate, l_strSmid, l_strB帳款日期, l_strE帳款日期);
            }
            else
            {
                l_C欠款紀錄 = _context.CFactoryManager.C欠款紀錄Factory
                    .get沖帳款紀錄(l_strBDate, l_strEDate, l_strSmid, l_strB帳款日期, l_strE帳款日期);
            }

            Session.Add("FrmArrearsMoney_BDATE", l_strB帳款日期);
            Session.Add("FrmArrearsMoney_EDATE", l_strE帳款日期);
            display(l_C欠款紀錄);
        }


        private void display(C欠款紀錄[] p_欠款紀錄)
        {
            if (p_欠款紀錄.Length <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('無符合資料!請重新確認');", true);

                _gvAmt.DataSource = null;
                _gvAmt.DataBind();
                return;
            }
            _gvAmt.DataSource = getDataTableByDisplay(p_欠款紀錄);
            _gvAmt.DataBind();
        }

        private DataTable getDataTableByDisplay(C欠款紀錄[] p_欠款紀錄)
        {

            string[] l_Msg = new string[] { "項次", "據點", "員編", "姓名", "應收金額", "洗車款項", "小百貨款項", "剩餘點數", "實收金額", "明細" };
            DataTable l_dt = CTools.getFilledColumnsDataTable(l_Msg);


            for (int i = 0; i < p_欠款紀錄.Length; i++)
            {
                DataRow l_row = l_dt.NewRow();
                l_row["項次"] = (i + 1).ToString();
                l_row["據點"] = p_欠款紀錄[i].據點;
                l_row["員編"] = p_欠款紀錄[i].業編;
                l_row["姓名"] = p_欠款紀錄[i].名稱;
                l_row["應收金額"] = p_欠款紀錄[i].金額;
                l_row["剩餘點數"] = p_欠款紀錄[i].剩餘點數;
                l_row["洗車款項"] = p_欠款紀錄[i].洗車款項;
                l_row["小百貨款項"] = p_欠款紀錄[i].小百貨款項;
                if (String.IsNullOrEmpty(p_欠款紀錄[i].剩餘點數))
                {
                    p_欠款紀錄[i].剩餘點數 = "0";
                }

                try
                {
                    l_row["實收金額"] = Convert.ToDouble(p_欠款紀錄[i].金額) - Convert.ToDouble(p_欠款紀錄[i].剩餘點數);
                }
                catch { l_row["實收金額"] = 0; }
                l_row["明細"] = "./FrmArrearsMoneyDetail.aspx?smid=" + p_欠款紀錄[i].業編;
                l_dt.Rows.Add(l_row);
            }

            Session.Add("FrmArrearsMoney", l_dt);
            return l_dt;
        }

        protected void _btn明細_Click(object sender, EventArgs e)
        {
            Button l_btn = (Button)sender;
            GridViewRow l_row = (GridViewRow)l_btn.Parent.Parent;
            string l_smid = ((Label)l_row.Cells[2].Controls[1]).Text;
            string l_strBDate = _txtB帳款日期.Text;
            string l_strEDate = _txtE帳款日期.Text;

            if ("".Equals(l_strBDate))
            {
                l_strBDate = "2010/01/01";
            }
            if ("".Equals(_txtEDate))
            {
                l_strEDate = DateTime.Today.ToString("yyyy/MM/dd");
            }


            Session.Add("FrmArrearsMoney_SMID", ((Label)l_row.Cells[2].Controls[1]).Text);
            Session.Add("FrmArrearsMoney_NAME", ((Label)l_row.Cells[3].Controls[1]).Text);

            ScriptManager.RegisterClientScriptBlock(this, typeof(FrmArrearsMoneyDetail), "OK", "window.open('./FrmArrearsMoneyDetail.aspx?smid=" + l_smid + "&type="+_rdolist.SelectedValue+"&BDate="+l_strBDate+"&EDate="+l_strEDate+"','my_window1','scrollbars=yes,menubar=no,height=600,width=800,resizable=yes,toolbar=no,location=no,status=no');", true);
           
            //CWork l_work = _context.CFactoryManager.CWorkFactory.get工單資訊By單號(l_workid);
            //display明細(l_work);
        }

        protected void _btn匯出_Click(object sender, EventArgs e)
        {
            DataTable l_table = Session["FrmArrearsMoney"] as DataTable;
            if (l_table == null)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('無匯出資料!請先執行查詢');", true);
                return;

            }
            string l_strPath = "../../report/" + DateTime.Today.ToString("yyyyMMdd") + "FrmArrearsMoney.xls";
            CTools.toExcelByDataView(new DataView(l_table), Server.MapPath(l_strPath), DateTime.Today.ToString("yyyyMMdd") + "欠款紀錄");
            Response.Redirect(l_strPath);
        }
    }
}
