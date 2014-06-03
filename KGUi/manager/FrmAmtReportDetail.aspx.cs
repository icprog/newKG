using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using tw.com.kg.lib;
using KGUi.tools;

namespace KGUi.manager
{
    public partial class FrmAmtReportDetail : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);

            string l_strSmid = Request["smid"];
            string l_strBDate = Request["BDate"];
            string l_strEDate = Request["EDate"];

            CWork[] l_Work = _context.CFactoryManager.CWorkFactory.
                get工單資訊By薪資(l_strSmid, l_strBDate, l_strEDate);

            display(l_Work);
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;

            if (l_user == null)
            {
                Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
                Response.Redirect("../FrmLogin.aspx");
            }
        }

        private void display(CWork[] p_CWork)
        {
            string[] l_Msg = new string[] { "項次", "工單號碼", "引擎號碼", "顧客名稱", "洗車種類", "金額", "開單日期", "完工日" };
            DataTable l_dt = CTools.getFilledColumnsDataTable(l_Msg);


            for (int i = 0; i < p_CWork.Length; i++)
            {
                DataRow l_row = l_dt.NewRow();
                l_row["項次"] = (i + 1).ToString();
                l_row["工單號碼"] = p_CWork[i].f_workid工單單號;
                l_row["引擎號碼"] = p_CWork[i].f_engo引擎號碼;
                l_row["顧客名稱"] = p_CWork[i].f_customerid顧客名稱;
                l_row["洗車種類"] = p_CWork[i].f_workType洗車種類;
                l_row["金額"] = p_CWork[i].f_money金額;
                l_row["開單日期"] = p_CWork[i].f_editdate開單日期;
                l_row["完工日"] = p_CWork[i].f_closeDate完工日;

                l_dt.Rows.Add(l_row);
            }
            _gvWork.DataSource = l_dt;
            _gvWork.DataBind();
        }
    }
}
