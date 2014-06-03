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
    public partial class FrmSearchUser : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);

            if (!this.IsPostBack)
            {
                CTools.get所別(_ddl所別, _context);
                CTools.get使用者等級(_ddl等級);
            }
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;

            if (l_user == null)
            {
                Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
                Response.Redirect("../FrmLogin.aspx");
            }
        }

        private void search()
        {
            string l_str帳號 = _txt帳號.Text;
            string l_str所別 = _ddl所別.SelectedValue;
            string l_str等級 = _ddl等級.SelectedValue;

            CUser[] l_User = _context.CFactoryManager.CUserFactory.getAllUserBySearch(l_str帳號, l_str所別, l_str等級);

            display(l_User);
        }

        private void display(CUser[] p_User)
        {
            string[] l_Msg = new string[] { "項次", "所別", "帳號", "密碼", "姓名", "等級" };
            DataTable l_dt = CTools.getFilledColumnsDataTable(l_Msg);


            if (p_User.Length <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('查無資料!請重新確認');", true);
                GridView1.DataSource = l_dt;
                GridView1.DataBind();
                return;
            }
            for (int i = 0; i < p_User.Length; i++)
            {
                DataRow l_row = l_dt.NewRow();
                l_row["項次"] = (i + 1).ToString();
                l_row["所別"] = p_User[i].f_branchid所別;
                l_row["姓名"] = p_User[i].f_username姓名;
                l_row["帳號"] = p_User[i].f_userid帳號;
                l_row["密碼"] = p_User[i].f_password密碼;
                l_row["等級"] = CTools.get使用者等級中文顯示(p_User[i].f_lvl等級);

                l_dt.Rows.Add(l_row);
            }
            GridView1.DataSource = l_dt;
            GridView1.DataBind();
        }
        protected void _btn取消_Click(object sender, EventArgs e)
        {
            Response.Redirect("./FrmSetUser.aspx");
        }

        protected void _btn刪除_Click(object sender, EventArgs e)
        {
            Button l_btn = (Button)sender;
            GridViewRow l_row = (GridViewRow)l_btn.Parent.Parent;
            string l_id = ((Label)l_row.Cells[2].Controls[1]).Text;
            _context.CFactoryManager.CUserFactory.deleteByID(l_id);
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('刪除成功');", true);
            search();
        }

        protected void _btn查詢_Click(object sender, EventArgs e)
        {
            search();
        }
        protected void _btn修改_Click(object sender, EventArgs e)
        {
            Button l_btn = (Button)sender;
            GridViewRow l_row = (GridViewRow)l_btn.Parent.Parent;
            string l_id = ((Label)l_row.Cells[2].Controls[1]).Text;

            Response.Redirect("./FrmUpdateUser.aspx?smid=" + l_id);
        }
    }
}
