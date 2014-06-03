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

namespace KGUi.manager.part
{
    public partial class FrmUpdateKGPart : System.Web.UI.Page
    {
        private CUIContext iv_context;
        protected void Page_Load(object sender, EventArgs e)
        {
            iv_context = SealedGlobalPage.getContext(this);
            
            if (!Page.IsPostBack)
            {
                string l_strid = Request["id"];
                if (l_strid == null || "".Equals(l_strid))
                {
                    string l_str = "alert('請先查詢後再進行修改作業');";
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", l_str, true);
                    return;
                }
                顯示資訊(l_strid);
            }
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;

            if (l_user == null)
            {
                Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
                Response.Redirect("../../FrmLogin.aspx");
            }

        }
        private void 顯示資訊(string p_strId)
        {
            CKGPartFactory l_factory = iv_context.CFactoryManager.CKGPartFactory;
            CKGPart l_code = l_factory.getCKGPartById(p_strId);

            iv_txt類別編號.Text = l_code.f_TypeID類別編號;
            iv_txt類別名稱.Text = l_code.f_TypeName類別名稱;
            iv_txt種類編號.Text = l_code.f_CategoryID種類編號;
            iv_txt種類名稱.Text = l_code.f_CategoryName種類名稱;
            iv_txt產品編號.Text = l_code.f_ProductID產品編號;
            iv_txt產品名稱.Text = l_code.f_ProductName產品名稱;
            iv_txt產品單位.Text = l_code.f_Qty單位;
            iv_txt成本價.Text = l_code.f_Cost成本價.ToString();
            iv_txt業代價.Text = l_code.f_SalePrice業代價.ToString();
            iv_txt建議售價.Text = l_code.f_ListPrice售價.ToString();
        }
        protected void iv_btn修改_Click(object sender, EventArgs e)
        {
            if ("".Equals(iv_txt類別編號.Text.Trim()))
            {
                string l_str = "alert('請先查詢後再進行修改作業');";
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", l_str, true);
                return;
            }

            修改產品檔(Request["id"]);
        }
        private void 修改產品檔(string p_strId)
        {
            CKGPartFactory l_factory = iv_context.CFactoryManager.CKGPartFactory;
            CKGPart l_code產品檔 = l_factory.createCKGPart();

            l_code產品檔.f_id = Convert.ToInt32(p_strId);
            l_code產品檔.f_ProductName產品名稱 = iv_txt產品名稱.Text.Trim();
            l_code產品檔.f_Qty單位 = iv_txt產品單位.Text.Trim();
            l_code產品檔.f_Cost成本價 = Convert.ToInt32("0" + iv_txt成本價.Text.Trim());
            l_code產品檔.f_SalePrice業代價 = Convert.ToInt32("0" + iv_txt業代價.Text.Trim());
            l_code產品檔.f_ListPrice售價 = Convert.ToInt32("0" + iv_txt建議售價.Text.Trim());

            l_factory.updateCKGPart單位and價位(l_code產品檔);

            string l_strShow = "alert('修改成功');";
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", l_strShow, true);
        }
    
    }
}
