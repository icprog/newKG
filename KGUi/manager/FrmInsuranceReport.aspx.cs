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
    public partial class FrmInsuranceReport : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);

            if (!this.IsPostBack)
            {
                CTools.get保險公司(_rdo保險公司, _context);
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
            string l_BDate = _txtBDate.Text.Trim();
            string l_EDate = _txtEDate.Text.Trim();
            string l_str保險公司 = _rdo保險公司.SelectedValue;
            C保險實績統計[] l_C保險實績統計 = _context.CFactoryManager.C保險實績統計Factory.get保險實績(l_BDate,l_EDate,l_str保險公司);
            display(l_C保險實績統計);
        }


        private void display(C保險實績統計[] p_保險實績統計)
        {
            string[] l_Msg = new string[] { "所別", "保險公司", "實績" };
            DataTable l_dt = CTools.getFilledColumnsDataTable(l_Msg);

            //if (p_薪資計算.Length <= 0)
            //{
            //    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('無符合資料!請重新確認');", true);

            //    _gvAmt.DataSource = l_dt;
            //    _gvAmt.DataBind();
            //    return;
            //}

            for (int i = 0; i < p_保險實績統計.Length; i++)
            {
                DataRow l_row = l_dt.NewRow();

                l_row["所別"] =CTools.get轉換據點中英文( p_保險實績統計[i].所別 );
                //所別一樣只秀一次,第一次不判斷
                if (i > 0)
                {
                    if (p_保險實績統計[i - 1].所別.Equals(p_保險實績統計[i].所別))
                    {
                        l_row["所別"] = "";
                    }
                }
                l_row["保險公司"] = p_保險實績統計[i].代碼名稱;
                l_row["實績"] = p_保險實績統計[i].實績;

                l_dt.Rows.Add(l_row);
            }
            _gvAmt.DataSource = l_dt;
            _gvAmt.DataBind();
        }

    }
}
