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
    public partial class FrmInMoneyPrint : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);
            display();
        }

        private void display()
        {
            CUser l_user = _context.CFactoryManager.CUserFactory.get高都員工檔(Request["smid"]);
            _lbl員編.Text = l_user.f_branchid所別 + "/" + l_user.f_userid帳號 + "/" + l_user.f_username姓名;
            _lbl員編1.Text = _lbl員編.Text;
            _lbl付款日期.Text = DateTime.Today.ToString("yyyy/MM/dd");
            _lbl付款日期1.Text = DateTime.Today.ToString("yyyy/MM/dd");
            _lbl尚餘點數.Text = Request["point"];
            _lbl尚餘點數1.Text = Request["point"];
            _lbl總計.Text = Request["count"];
            _lbl總計1.Text = Request["count"];
            
            ArrayList l_al工單號碼 = Session[SealedGlobalPage.SESSIONKEY_INMONEY_WORKID] as ArrayList;
            DataTable l_dt =  Session[SealedGlobalPage.VIEWSTATE_INMONEY] as DataTable;
         
            string[] l_Msg = new string[] { "項次", "工單號碼", "員工編號", "名稱", "應收帳款", "帳款日期" };
            DataTable l_dt沖帳列印 = CTools.getFilledColumnsDataTable(l_Msg);

            for (int i = 0; i < l_dt.Rows.Count; i++)
            {
                bool l_bool是否沖帳 = false;
                for (int j = 0;j< l_al工單號碼.Count; j++)
                {
                    string l_workid = l_al工單號碼[j].ToString();
                    if (l_workid.Equals(l_dt.Rows[i]["工單號碼"]))
                    {
                        l_bool是否沖帳 = true;

                        DataRow l_row = l_dt沖帳列印.NewRow();

                        l_row["項次"] = l_dt.Rows[i]["項次"];
                        l_row["工單號碼"] = l_dt.Rows[i]["工單號碼"];
                        l_row["員工編號"] = l_dt.Rows[i]["員工編號"];
                        l_row["名稱"] = l_dt.Rows[i]["名稱"];
                        l_row["應收帳款"] = l_dt.Rows[i]["應收帳款"];
                        l_row["帳款日期"] = l_dt.Rows[i]["帳款日期"];
                        l_dt沖帳列印.Rows.Add(l_row);
                    }
                }
                if (!l_bool是否沖帳)
                {
                    l_dt.Rows[i].Delete();
                }
            }
            GridView1.DataSource = l_dt沖帳列印;
            GridView2.DataSource = l_dt沖帳列印;
            GridView1.DataBind();
            GridView2.DataBind();


            //清空session紀錄
            Session.Remove(SealedGlobalPage.SESSIONKEY_INMONEY_WORKID);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
