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
    public partial class FrmSelectWorkDetail : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);
            string l_strWorkid = Request["workid"];
            CConstruction[] l_Construction = _context.CFactoryManager.CConstructionFactory.get施工人員明細By單號(l_strWorkid);
            display(l_Construction);
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;

            if (l_user == null)
            {
                Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
                Response.Redirect("../FrmLogin.aspx");
            }
        }


        private void display(CConstruction[] p_Construction)
        {
            string[] l_Msg = new string[] { "項次", "員編", "姓名" };
            DataTable l_dt = CTools.getFilledColumnsDataTable(l_Msg);

            for (int i = 0; i < p_Construction.Length; i++)
            {
                DataRow l_row = l_dt.NewRow();
                l_row["項次"] = (i + 1).ToString();
                l_row["員編"] = p_Construction[i].f_smid施工人員;
                l_row["姓名"] = p_Construction[i].f_smid施工人員名稱;
                l_dt.Rows.Add(l_row);
            }
            _gvWork.DataSource = l_dt;
            _gvWork.DataBind();
        }
    }
}
