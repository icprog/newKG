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
    public partial class FrmSetUser : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);

            if (!this.IsPostBack)
            {
                CTools.get所別(_ddl所別,_context);
                CTools.get使用者等級(_ddl等級);
            }
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;

            if (l_user == null)
            {
                Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
                Response.Redirect("../FrmLogin.aspx");
            }
        }


        protected void _btn設定_Click(object sender, EventArgs e)
        {
            if (使用者輸入條件())
            {
                CUser l_user = _context.CFactoryManager.CUserFactory.createCUser();
                l_user.f_userid帳號 = _txt帳號.Text.Trim();
                l_user.f_password密碼 = _txt密碼.Text.Trim();
                l_user.f_username姓名 = _txt姓名.Text.Trim();
                l_user.f_branchid所別 = _ddl所別.SelectedValue;
                l_user.f_lvl等級 = Convert.ToInt32(_ddl等級.SelectedValue);

                _context.CFactoryManager.CUserFactory.insert(l_user);
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('新增成功');", true);
                ClearUI();
            }
        }

        private bool 使用者輸入條件()
        {
            if ("".Equals(_txt帳號.Text.Trim()))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('帳號不得空白');", true);
                return false;
            }
            if ("".Equals(_txt密碼.Text.Trim()))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('密碼不得空白');", true);
                return false;
            }
            if ("".Equals(_txt姓名.Text.Trim()))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('姓名不得空白');", true);
                return false;
            }
            if ("".Equals(_ddl所別.SelectedValue))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('所別不得空白');", true);
                return false;
            }
            if ("".Equals(_ddl等級.SelectedValue))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('等級不得空白');", true);
                return false;
            }
            return true;
        }

        private void ClearUI()
        {
            _txt帳號.Text = "";
            _txt密碼.Text = "";
            _txt姓名.Text = "";
            _ddl所別.SelectedValue = "";
            _ddl等級.SelectedValue = "";
        }

        protected void _btn查詢_Click(object sender, EventArgs e)
        {
            Response.Redirect("./FrmSearchUser.aspx");
        }

    }
}
