using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tw.com.kg.lib;

namespace KGUi
{
    public partial class FrmTestWebForm1 : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {

            _context = SealedGlobalPage.getContext(this);


            CUser l_user = _context.CFactoryManager.CUserFactory.getTestEIP討論區();

            Label l_lb = new Label();
            l_lb.Text = l_user.f_userid帳號;

            PlaceHolder1.Controls.Add(l_lb);


        }
    }
}
