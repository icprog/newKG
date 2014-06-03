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

namespace KGUi.update
{
    public partial class FrmSearchWork : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);
        }

        protected void _btn實績查詢_Click(object sender, EventArgs e)
        {
            Response.Redirect("./FrmHistory.aspx");
            
        }

        protected void _btn查詢_Click(object sender, ImageClickEventArgs e)
        {
            CWork l_work;
            try
            {
                l_work = _context.CFactoryManager.CWorkFactory.get工單資訊By單號(_txt工單號碼.Text.Trim());
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('無此工單!請重新確認');", true);
                return;
            }
            if (l_work == null)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('無此工單!請重新確認');", true);
                return;
            }

            if (!"".Equals(l_work.f_closeDate完工日))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('工單已完工!不得異動!謝謝');", true);
                return;
            }
            Session.Add(SealedGlobalPage.SESSIONKEY_WORK_SERACH, l_work);

            //判斷施工還是完工
            string l_strType = Request["type"];

            if ("edit".Equals(l_strType))
            {
                Response.Redirect("./FrmAddConstruction.aspx");
            }
            else if ("close".Equals(l_strType))
            {
                //未施工的工單不能完工
                if ("待處理".Equals(l_work.f_staus狀態))
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(FrmSearchWork), "OK", "alert('此工單尚未施工!請重新確認!');", true);
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "window.location.href='./FrmUpdateIndex.aspx';", true);
                    return;
                }
                
                Response.Redirect("./FrmCloseWork.aspx");
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

            Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
            Response.Redirect("../FrmLogin.aspx");
        }
    }
}
