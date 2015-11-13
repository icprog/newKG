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
    public partial class FrmOrderidDetail : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);
            string l_orderid = Request["orderid"];
            CKGPartOrderDetail[] l_detail = _context.CFactoryManager.
                CKGPartOrderDetailFactory.get請購明細ByExchangeID(l_orderid);
            display明細(l_detail);
        }
        private void display明細(CKGPartOrderDetail[] p_detail)
        {
            GridView1.DataSource = getDataTableByDisplay明細(p_detail);
            GridView1.DataBind();
        }

        private DataTable getDataTableByDisplay明細(CKGPartOrderDetail[] p_detail)
        {

            string[] l_Msg = new string[] { "項次", "單號", "產品編號", "產品名稱", "數量" };
            DataTable l_dt = CTools.getFilledColumnsDataTable(l_Msg);

            for (int i = 0; i < p_detail.Length; i++)
            {
            DataRow l_row = l_dt.NewRow();
            l_row["項次"] = "1";
            l_row["單號"] = p_detail[i].f_ExchangeID請購單號;
            l_row["產品編號"] = p_detail[i].f_ProductID產品編號;
            l_row["產品名稱"] = p_detail[i].f_ProductName產品名稱;
            l_row["數量"] = p_detail[i].f_Amount選購數量;
            l_dt.Rows.Add(l_row);
            }
            return l_dt;
        }
    }
}
