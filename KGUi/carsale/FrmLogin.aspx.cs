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

namespace KGUi.carsale
{
    public partial class FrmLogin : System.Web.UI.Page
    {
        private CUIContext _context;

        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);
        }

        protected void _btn登入_Click(object sender, EventArgs e)
        {
            //共用洗車USER資料庫
            CUser l_user = _context.CFactoryManager.CUserFactory.get取得使用者by帳號(_txt帳號.Text);

            if (l_user == null)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('無此帳號!請重新確認');", true);
                return;
            }

            if (!_txt密碼.Text.Equals(l_user.f_password密碼))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('密碼錯誤!請重新確認');", true);
                return;
            }
            else
            {
                Session.Add(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA_CARSALE, l_user);

                Response.Redirect("./FrmMain.htm");
            }
        }
    }
}
