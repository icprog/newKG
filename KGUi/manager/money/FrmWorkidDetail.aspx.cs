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
    public partial class FrmWorkidDetail : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);
            string l_workid = Request["workid"];
            CWork l_work = _context.CFactoryManager.CWorkFactory.get工單資訊By單號(l_workid);
            display明細(l_work);
           
        }

        private void display明細(CWork p_work)
        {
            GridView1.DataSource = getDataTableByDisplay明細(p_work);
            GridView1.DataBind();
        }

        private DataTable getDataTableByDisplay明細(CWork p_work)
        {

            string[] l_Msg = new string[] { "項次", "單號", "引擎號碼", "金額", "洗車總類" };
            DataTable l_dt = CTools.getFilledColumnsDataTable(l_Msg);

            //for (int i = 0; i < p_欠款紀錄.Length; i++)
            //{
            DataRow l_row = l_dt.NewRow();
            l_row["項次"] = "1";
            l_row["單號"] = p_work.f_workid工單單號;
            l_row["引擎號碼"] = p_work.f_engo引擎號碼;
            l_row["金額"] = p_work.f_money金額;
            l_row["洗車總類"] = p_work.f_workType洗車種類;
            l_dt.Rows.Add(l_row);
            //}
            return l_dt;
        }
        
    }
}
