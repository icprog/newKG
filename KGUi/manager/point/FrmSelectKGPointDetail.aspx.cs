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

namespace KGUi.manager.point
{
    public partial class FrmSelectKGPointDetail : System.Web.UI.Page
    {
        private CUIContext iv_context;
        protected void Page_Load(object sender, EventArgs e)
        {
            iv_context = SealedGlobalPage.getContext(this);
           
            if (!Page.IsPostBack)
            {
                CTools.get所別(iv_cbo所別,iv_context);
                add匯入模式(iv_cbo匯入方式);
            }
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;

            if (l_user == null)
            {
                Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
                Response.Redirect("../../FrmLogin.aspx");
            }

        }

        private void add匯入模式(DropDownList p_cbo)
        {
            CKGPointDetailFactory l_factory = iv_context.CFactoryManager.CKGPointDetailFactory;
            CKGPointDetail[] l_codes = l_factory.get匯入模式();

            p_cbo.Items.Insert(0, "");

            if (l_codes != null)
            {
                for (int i = 0; i < l_codes.Length; i++)
                {
                    p_cbo.Items.Add(new ListItem(l_codes[i].f_ImportType匯入方式));
                }
            }
        }
        protected void iv_btn查詢_Click(object sender, EventArgs e)
        {
            查詢資料();
        }

        private void 查詢資料()
        {
            string l_str所別 = "";
            if (!"".Equals(iv_cbo所別.SelectedValue))
            {
                l_str所別 = iv_cbo所別.SelectedValue.Substring(0, 3);
            }

            string l_str業代員編 = iv_txt業代員編.Text.Trim().ToUpper();
            string l_str匯入方式 = iv_cbo匯入方式.SelectedValue;
            string l_str入帳銀行 = iv_cbo入帳銀行.SelectedValue;
            string l_str匯入日期起 = iv_txt匯入日期起.Text.Trim();
            string l_str匯入日期止 = iv_txt匯入日期止.Text.Trim();

            CKGPointDetailFactory l_factory = iv_context.CFactoryManager.CKGPointDetailFactory;
            CKGPointDetail[] l_codes = l_factory.getCKGPointDetailBy條件(l_str所別, l_str業代員編, l_str匯入方式, l_str入帳銀行, l_str匯入日期起, l_str匯入日期止);

            if (l_codes != null)
            {
                display(l_codes);
            }
            else
            {

                GridView1.DataSource = null;
                GridView1.DataBind();
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('查無資料');", true);
                
            }
            //Session.Add(SealedGlobalPage.SESSIONKEY_KGPOINTDETIAL_REPORTEXCEL, l_codes);
        }
        private void display(CKGPointDetail[] p_codes)
        {
            GridView1.DataSource = p_codes.ToList();
            GridView1.DataBind();
        }

        private DataTable getDataTableBydisplay(CKGPointDetail[] p_codes)
        {
            string[] l_str = { "項次", "所別", "員編", "姓名", "匯入點數", "匯入日期", "匯入者員編", "匯入者姓名", "匯入方式", "刷卡銀行", "手續費", "發票號碼", "入帳銀行", "備註" };

            DataTable l_table = CTools.getFilledColumnsDataTable(l_str);

            if (p_codes == null)
            {
                return l_table;
            }

            int l_int項次 = 1;
            for (int i = 0; i < p_codes.Length; i++)
            {
                DataRow l_row = l_table.NewRow();

                l_row["項次"] = l_int項次++;
                l_row["所別"] =CTools.get轉換據點中英文( p_codes[i].Branch所別 );
                l_row["員編"] = p_codes[i].f_Smid業代員編;
                l_row["姓名"] = p_codes[i].f_Name業代姓名;
                l_row["匯入點數"] = p_codes[i].f_ImportPoint匯入點數;
                l_row["匯入日期"] = p_codes[i].f_ImportDate匯入日期;
                l_row["匯入者員編"] = p_codes[i].f_ImportSmid匯入人員員編;
                l_row["匯入者姓名"] = p_codes[i].f_ImportName匯入人員姓名;
                l_row["匯入方式"] = p_codes[i].f_ImportType匯入方式;
                l_row["刷卡銀行"] = p_codes[i].f_PayBank刷卡銀行;
                l_row["手續費"] = p_codes[i].f_BankCharge手續費;
                l_row["發票號碼"] = p_codes[i].f_InvoiceNo發票號碼;
                l_row["入帳銀行"] = p_codes[i].f_InMoneyBank入帳銀行;
                l_row["備註"] = p_codes[i].f_Memo;
                l_table.Rows.Add(l_row);
            }

            return l_table;
        }

        int iv_intSumTotal = 0;
        int iv_intSum手續費 = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                iv_intSumTotal += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "f_ImportPoint匯入點數"));
                iv_intSum手續費 += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "f_BankCharge手續費"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "總計";
                e.Row.Cells[4].Text = iv_intSumTotal.ToString();
                e.Row.Cells[10].Text = iv_intSum手續費.ToString();
                e.Row.Font.Bold = true;
                e.Row.HorizontalAlign = HorizontalAlign.Center;
            }
        }
        protected void iv_btn匯出_Click(object sender, EventArgs e)
        {
            //CKGPointDetail[] l_codes = (CKGPointDetail[])Session[SealedGlobalPage.SESSIONKEY_KGPOINTDETIAL_REPORTEXCEL];

            //if (l_codes != null)
            //{
            //    DataTable l_table = getDataTableBydisplay(l_codes);

            //    l_table.Columns.RemoveAt(0);//項次


            //    string l_strPath = "../report/upload/KGPointDetail/各業代點數儲值使用記錄.xls";
            //    CUtility.toExcelByDataView(new DataView(l_table), Server.MapPath(l_strPath), "各業代點數儲值使用記錄");
            //    Response.Redirect(l_strPath);
            //}
            //else
            //{
            //    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('匯出失敗，請先查詢資料後再進行匯出作業');", true);
            //}
        }

        protected void txtMemo_TextChanged(object sender, EventArgs e)
        {
            TextBox ltxtMemo = (TextBox)sender;

            GridViewRow lR = (GridViewRow)ltxtMemo.Parent.Parent;

            var lKeys = this.GridView1.DataKeys[lR.RowIndex].Value.ToString();
            CKGPointDetailFactory l_factory = iv_context.CFactoryManager.CKGPointDetailFactory;

            l_factory.SetMemo(ltxtMemo.Text, lKeys.ToString());
        }

    }
}
