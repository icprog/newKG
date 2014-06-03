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

namespace KGUi
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
        }

        protected void _btn登入_Click(object sender, ImageClickEventArgs e)
        {

            string l_strID = _txt帳號.Text.Trim();
            string l_strPassWord = _txt密碼.Text.Trim();


            CUser l_test = _context.CFactoryManager.CUserFactory.getUserByUserName(l_strID, l_strPassWord);

            CUser l_user = _context.CFactoryManager.CUserFactory.get取得使用者by帳號(l_strID);

            if (l_user == null)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('無此帳號!請重新確認');", true);
                return;
            }

            if (!l_strPassWord.Equals(l_user.f_password密碼))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('密碼錯誤!請重新確認');", true);
                return;
            }
            else
            {
                CUser l_user已登入 = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;

                if (l_user已登入 != null)
                {
                    //string l_msg = "alert('已有另外身分者(" + l_user已登入.f_userid帳號 + "_" + l_user已登入.f_username姓名 + ")登入,請先關閉之前作業視窗');";
                    //ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", l_msg, true);
                    //return;
                    Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
                    Session.Add(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA, l_user);
                }
                else
                {
                    //記錄登入者資訊
                    Session.Add(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA, l_user);
                }

                if (0 == l_user.f_lvl等級)//洗車人員導到維護工單
                {
                    Response.Redirect("./update/FrmUpdateIndex.aspx");
                }
                else if (1 == l_user.f_lvl等級)//助理和專員導到開立工單
                {
                    Response.Redirect("./insert/FrmIndex.aspx");
                }
                else if (2 == l_user.f_lvl等級)//所廠長導到業績查詢
                {
                    Response.Redirect("");
                }
                else if (3 == l_user.f_lvl等級)//管理者
                {
                    Response.Redirect("./manager/WfrmMain.htm");
                }
                else if (4 == l_user.f_lvl等級)//管理者
                {
                    Response.Redirect("./part/WfrmMain.htm");
                }
            }
        }
    }
}
