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

namespace KGUi.manager
{
    public partial class WfrmMenu : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);

        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
            Response.Redirect("../FrmLogin.aspx");
        }
    }
}
