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

namespace KGUi.insert
{
    public partial class FrmWorkType : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);

            if (!Page.IsPostBack)
            {
               
            }
        }

        protected void _btn新車_Click(object sender, EventArgs e)
        {
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;
            if (l_user.f_branch所別名稱.IndexOf("廠") > 0)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('沒有開立新車工單權限!!');", true);
                return;
            }
            Response.Redirect("./FrmInsertWork.aspx?type=1");
        }

        protected void _btn保險_Click(object sender, EventArgs e)
        {
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;
            if (l_user.f_branch所別名稱.IndexOf("所") > 0)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('沒有開立保險工單權限!!');", true);
                return;
            }
            Response.Redirect("./FrmInsertWork.aspx?type=2");
        }

        protected void _btn一般_Click(object sender, EventArgs e)
        {
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;
            if (l_user.f_branch所別名稱.Equals("中古車室/中古車明誠營業所")
                || l_user.f_branch所別名稱.Equals("中古車室/中古車澄清營業所"))
            {
                Response.Redirect("./FrmInsertWork.aspx?type=3");
            }

            if (l_user.f_branch所別名稱.IndexOf("所") > 0)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('沒有開立一般工單權限!!');", true);
                return;
            }
            Response.Redirect("./FrmInsertWork.aspx?type=3");
        }
        protected void _btn員工_Click(object sender, EventArgs e)
        {
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
            Response.Redirect("../FrmLogin.aspx");
        }

        protected void _btn員工_Click(object sender, ImageClickEventArgs e)
        {

            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;
            if (l_user.f_branch所別名稱.IndexOf("所") > 0)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('沒有開立員工工單權限!!');", true);
                return;
            }
            Response.Redirect("./FrmInsertWork.aspx?type=4");
        }

        protected void _btn試乘_Click(object sender, ImageClickEventArgs e)
        {
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;
            if (l_user.f_branch所別名稱.IndexOf("廠") > 0)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('沒有開立試乘車工單權限!!');", true);
                return;
            }
            Response.Redirect("./FrmInsertWork.aspx?type=5");

        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;
            if (l_user.f_branch所別名稱.IndexOf("所") > 0)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('沒有開立員工工單權限!!');", true);
                return;
            }
            Response.Redirect("./FrmInsertWork.aspx?type=6");
        }

        protected void _btn保險公司介紹_Click(object sender, EventArgs e)
        {
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;
            if (l_user.f_branch所別名稱.IndexOf("所") > 0)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('沒有開立保險工單權限!!');", true);
                return;
            }
            Response.Redirect("./FrmInsertWork.aspx?type=24");
        }

        protected void _btn新車保值計畫_Click(object sender, ImageClickEventArgs e)
        {
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;
            if (l_user.f_branch所別名稱.IndexOf("所") > 0)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('沒有開立新車保值計畫!!');", true);
                return;
            }
            Response.Redirect("./FrmInsertWork.aspx?type=7");
        }
    }
}
