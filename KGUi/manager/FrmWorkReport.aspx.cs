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
    public partial class FrmWorkReport : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);

            if (!this.IsPostBack)
            {
            }
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;

            if (l_user == null)
            {
                Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
                Response.Redirect("../FrmLogin.aspx");
            }
        }

        private void display(C工單實績[] p_C工單實績)
        {
            string[] l_Msg = new string[] { "所別", "工單類型", "金額", "台數" };
            DataTable l_dt = CTools.getFilledColumnsDataTable(l_Msg);

            int l_total = 0;

            for (int i = 0; i < p_C工單實績.Length; i++)
            {
                DataRow l_row = l_dt.NewRow();

                l_row["所別"] =CTools.get轉換據點中英文( p_C工單實績[i].所別 );

                //所別一樣只秀一次,第一次不判斷
                if (i > 0)
                {
                    if (p_C工單實績[i - 1].所別.Equals(p_C工單實績[i].所別))
                    {
                        l_row["所別"] = "";
                    }
                }
                l_row["工單類型"] = p_C工單實績[i].工單類型;
                l_total += p_C工單實績[i].金額;
                l_row["金額"] = p_C工單實績[i].金額.ToString();
                l_row["台數"] = p_C工單實績[i].台數.ToString();

                l_dt.Rows.Add(l_row);
            }

            //最後計算總計
            DataRow l_row總計 = l_dt.NewRow();
            l_row總計["所別"] = "總計:";
            l_row總計["金額"] = l_total.ToString();
            l_dt.Rows.Add(l_row總計);

            _gvWork.DataSource = l_dt;
            _gvWork.DataBind();
        }
        protected void _btn查詢_Click(object sender, EventArgs e)
        {
            string l_strBDate = _txtBDate.Text.Trim();
            string l_strEDate = _txtEDate.Text.Trim();
            string l_str工單類型 = _ddl工單類型.SelectedValue;
            C工單實績[] l_C工單實績 = _context.CFactoryManager.C工單實績Factory.get工單實績(l_strBDate, l_strEDate, l_str工單類型);

            display(l_C工單實績);

        }
    }
}
