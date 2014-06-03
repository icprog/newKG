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
    public partial class FrmPlantReprotDetail : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);
            string l_strBDate = Request["BDate"];
            string l_strEDate = Request["EDate"];
            string l_strBranchid = Request["Branchid"];
            C各廠介紹獎金[] l_各廠介紹獎金 = _context.CFactoryManager.C各廠介紹獎金Factory.
               get各廠介紹獎金By明細(l_strBDate, l_strEDate, l_strBranchid);

            display(l_各廠介紹獎金);
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;

            if (l_user == null)
            {
                Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
                Response.Redirect("../FrmLogin.aspx");
            }
        }


        private void display(C各廠介紹獎金[] p_各廠介紹獎金)
        {
         
            string[] l_Msg = new string[] { "開單日期", "工單號碼", "引擎號碼", "洗車種類"
                , "開單人員", "名稱", "金額", "工單類型", "保險公司"};
            DataTable l_dt = CTools.getFilledColumnsDataTable(l_Msg);

            if (p_各廠介紹獎金.Length <= 0)
            {
                return;
            }

            int l_int一般 = 0;
            int l_int保險 = 0;
            for (int i = 0; i < p_各廠介紹獎金.Length; i++)
            {
                DataRow l_row = l_dt.NewRow();

                l_row["開單日期"] = p_各廠介紹獎金[i].開單日期;
                l_row["工單號碼"] = p_各廠介紹獎金[i].工單號碼;
                l_row["引擎號碼"] = p_各廠介紹獎金[i].引擎號碼;
                l_row["洗車種類"] = p_各廠介紹獎金[i].洗車種類;
                l_row["開單人員"] = p_各廠介紹獎金[i].開單人員;
                l_row["名稱"] = p_各廠介紹獎金[i].名稱;
                if ("一般".Equals(p_各廠介紹獎金[i].工單類型) || "員工".Equals(p_各廠介紹獎金[i].工單類型))
                {
                    l_int一般 += p_各廠介紹獎金[i].金額;
                }
                else if ("保險".Equals(p_各廠介紹獎金[i].工單類型))
                {
                    l_int保險 += p_各廠介紹獎金[i].金額;
                }
                l_row["金額"] = p_各廠介紹獎金[i].金額;
                l_row["工單類型"] = p_各廠介紹獎金[i].工單類型;
                l_row["保險公司"] = p_各廠介紹獎金[i].保險公司;
                l_dt.Rows.Add(l_row);
            }

            _lbl一般.Text =l_int一般.ToString() ;
            _lbl保險.Text =l_int保險.ToString();
            _gvAmt.DataSource = l_dt;
            _gvAmt.DataBind();
        }
    }
}
