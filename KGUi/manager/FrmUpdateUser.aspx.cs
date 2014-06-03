using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tw.com.kg.lib;
using KGUi.tools;

namespace KGUi.manager
{
    public partial class FrmUpdateUser : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);

            if (!this.IsPostBack)
            {
                CTools.get所別(_ddl所別, _context);
                CTools.get使用者等級(_ddl等級);

                string l_id = Request["smid"];

                CUser l_user = _context.CFactoryManager.CUserFactory.get取得使用者by帳號(l_id);

                display(l_user);
            }

        }

        private void display(CUser p_user)
        {
            _txt帳號.Text = p_user.f_userid帳號;
            _txt密碼.Text = p_user.f_password密碼;
            _txt姓名.Text = p_user.f_username姓名;
            _ddl所別.SelectedValue = p_user.f_branchid所別;
            _ddl等級.SelectedValue = p_user.f_lvl等級.ToString();
        }
        protected void _btn修改_Click(object sender, EventArgs e)
        {
            if (使用者輸入條件())
            {
                CUser l_user = _context.CFactoryManager.CUserFactory.createCUser();
                l_user.f_userid帳號 = _txt帳號.Text.Trim();
                l_user.f_password密碼 = _txt密碼.Text.Trim();
                l_user.f_username姓名 = _txt姓名.Text.Trim();
                l_user.f_branchid所別 = _ddl所別.SelectedValue;
                l_user.f_lvl等級 = Convert.ToInt32(_ddl等級.SelectedValue);

                _context.CFactoryManager.CUserFactory.update(l_user);
                ScriptManager.RegisterClientScriptBlock(this, typeof(FrmUpdateUser), "OK", "alert('修改成功');", true); 
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "window.location= 'FrmSearchUser.aspx';", true);
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
    }
}
