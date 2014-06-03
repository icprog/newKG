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
    public partial class FrmLNProjectReport : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);

            if (!this.IsPostBack)
            {
                CTools.get所別(_ddl據點, _context);
            }
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;

            if (l_user == null)
            {
                Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
                Response.Redirect("../FrmLogin.aspx");
            }
        }

        protected void _btn查詢_Click(object sender, EventArgs e)
        {
            string l_strBDate = _txtBDate.Text.Trim();
            string l_strEDate = _txtEDate.Text.Trim();
            string l_strBCloseDate = _txtBClose.Text.Trim();
            string l_strECloseDate = _txtEClose.Text.Trim();
            string l_strBranchid = _ddl據點.SelectedValue;
            string l_str是否招攬 = _rdo是否招攬.SelectedValue;
            string l_str洗車別 = _rdo洗車別.SelectedValue;
            string l_str是否完工 = _rdoisClose.SelectedValue;

            C亮新專案招攬[] l_亮新專案招攬 = _context.CFactoryManager.C亮新專案招攬Factory.get亮新專案招攬明細(l_strBDate, l_strEDate, l_strBCloseDate, l_strECloseDate, l_strBranchid, l_str是否招攬, l_str洗車別, l_str是否完工);

            display(l_亮新專案招攬);
        }


        private void display(C亮新專案招攬[] p_亮新專案招攬)
        {

            if (p_亮新專案招攬.Length <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('無符合資料!請重新確認');", true);
                _gvAmt.DataSource = null;
                _gvAmt.DataBind();
                return;
            }
            _gvAmt.DataSource = getDataTableBydisplay(p_亮新專案招攬);
            _gvAmt.DataBind();
        }
        private DataTable getDataTableBydisplay(C亮新專案招攬[] p_亮新專案招攬)
        {
            string[] l_Msg = new string[] { "項次", "完工日期", "引擎號碼", "工單單號", "施工代號"
            , "金額", "招攬單位", "招攬人員", "員編", "獎金", "開單據點", "開單人員", "保險公司"};
            DataTable l_dt = CTools.getFilledColumnsDataTable(l_Msg);


            for (int i = 0; i < p_亮新專案招攬.Length; i++)
            {
                DataRow l_row = l_dt.NewRow();

                l_row["項次"] = (i + 1).ToString();
                l_row["完工日期"] = p_亮新專案招攬[i].完工日期;
                l_row["引擎號碼"] = p_亮新專案招攬[i].引擎號碼;
                l_row["工單單號"] = p_亮新專案招攬[i].工單單號;
                l_row["施工代號"] = p_亮新專案招攬[i].施工代號;
                l_row["金額"] = p_亮新專案招攬[i].金額;
                l_row["招攬單位"] = p_亮新專案招攬[i].招攬單位;
                l_row["招攬人員"] = p_亮新專案招攬[i].招攬人員名稱;
                l_row["員編"] = p_亮新專案招攬[i].招攬人員員編;
                if (String.IsNullOrEmpty(p_亮新專案招攬[i].完工日期))
                {
                    l_row["獎金"] = 0;
                }
                else
                {
                    l_row["獎金"] = p_亮新專案招攬[i].獎金;
                }
                l_row["開單據點"] =CTools.get轉換據點中英文( p_亮新專案招攬[i].開單據點 );
                l_row["開單人員"] = p_亮新專案招攬[i].開單人員;
                l_row["保險公司"] = p_亮新專案招攬[i].保險公司;

                l_dt.Rows.Add(l_row);
            }
            Session.Add("FrmLNProjectReport", l_dt);
            return l_dt;
        }

        protected void _btn匯出_Click(object sender, EventArgs e)
        {
            DataTable l_table = Session["FrmLNProjectReport"] as DataTable;
            if (l_table==null)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('無匯出資料!請先執行查詢');", true);
                return;

            }
            string l_strPath = "../report/" + DateTime.Today.ToString("yyyyMMdd") + "FrmLNProjectReport.xls";
            CTools.toExcelByDataView(new DataView(l_table), Server.MapPath(l_strPath), DateTime.Today.ToString("yyyyMMdd") + "亮新專案招攬");
            Response.Redirect(l_strPath);
        }

    }
}
