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

namespace KGUi.manager
{
    public partial class FrmPlantReprot : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;

            if (l_user == null)
            {
                Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
                Response.Redirect("../FrmLogin.aspx");
            }

        }

        protected void _btn查詢_Click(object sender, EventArgs e)
        {
            string l_BDate = _txtBDate.Text.Trim();
            string l_EDate = _txtEDate.Text.Trim();

            C各廠介紹獎金[] l_各廠介紹獎金 = _context.CFactoryManager.C各廠介紹獎金Factory.
                get各廠介紹獎金(l_BDate, l_EDate);

            display(l_各廠介紹獎金);
        }

        private void display(C各廠介紹獎金[] p_各廠介紹獎金)
        {
            if (p_各廠介紹獎金.Length <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('無符合資料!請重新確認');", true);
                _gvAmt.DataSource = null;
                _gvAmt.DataBind();
                return;
            }
            _gvAmt.DataSource = getDataTableBydisplay(p_各廠介紹獎金); ;
            _gvAmt.DataBind();
        }

        private DataTable getDataTableBydisplay(C各廠介紹獎金[] p_各廠介紹獎金)
        {
            string[] l_Msg = new string[] { "廠別", "一般", "一般獎金", "保險", "保險獎金", "明細" };
            DataTable l_dt = CTools.getFilledColumnsDataTable(l_Msg);


            for (int i = 0; i < p_各廠介紹獎金.Length; i++)
            {
                DataRow l_row = l_dt.NewRow();

                l_row["廠別"] =CTools.get轉換據點中英文( p_各廠介紹獎金[i].據點 );
                l_row["一般"] = p_各廠介紹獎金[i].一般業績;
                l_row["一般獎金"] = p_各廠介紹獎金[i].一般獎金;
                l_row["保險"] = p_各廠介紹獎金[i].保險業績;
                l_row["保險獎金"] = p_各廠介紹獎金[i].保險獎金;
                l_row["明細"] = "./FrmPlantReprotDetail.aspx?Branchid=" + p_各廠介紹獎金[i].據點
                    + "&BDate=" + _txtBDate.Text.Trim() + "&EDate=" + _txtEDate.Text.Trim();

                l_dt.Rows.Add(l_row);
            }
            Session.Add("FrmPlantReprot", l_dt);
            return l_dt;
        }
        protected void _btn匯出_Click(object sender, EventArgs e)
        {
            DataTable l_table = Session["FrmPlantReprot"] as DataTable;
            if (l_table == null)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('無匯出資料!請先執行查詢');", true);
                return;

            }
            string l_strPath = "../report/" + DateTime.Today.ToString("yyyyMMdd") + "FrmPlantReprot.xls";
            CTools.toExcelByDataView(new DataView(l_table), Server.MapPath(l_strPath), DateTime.Today.ToString("yyyyMMdd") + "各廠介紹獎金");
            Response.Redirect(l_strPath);
        }
    }
}
