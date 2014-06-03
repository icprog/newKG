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
    public partial class FrmInsertKGPart : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;

            if (l_user == null)
            {
                Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
                Response.Redirect("../../FrmLogin.aspx");
            }
        }

        protected void _btn新增_Click(object sender, EventArgs e)
        {
            try
            {
                if (使用者輸入())
                {
                    CKGPart l_part = _context.CFactoryManager.CKGPartFactory.createCKGPart();
                    l_part.f_TypeID類別編號 = _txt類別編號.Text.Trim();
                    l_part.f_TypeName類別名稱 = _txt類別名稱.Text.Trim();
                    l_part.f_CategoryID種類編號 = _txt種類編號.Text.Trim();
                    l_part.f_CategoryName種類名稱 = _txt種類名稱.Text.Trim();
                    l_part.f_ProductID產品編號 = _txt產品編號.Text.Trim();
                    l_part.f_ProductName產品名稱 = _txt產品名稱.Text.Trim();
                    l_part.f_Qty單位 = _txt單位.Text.Trim();
                    l_part.f_SalePrice業代價 = Convert.ToInt32(_txt業代價.Text.Trim());
                    l_part.f_ListPrice售價 = Convert.ToInt32(_txt售價.Text.Trim());
                    l_part.f_Cost成本價 = Convert.ToInt32(_txt成本.Text.Trim());

                    _context.CFactoryManager.CKGPartFactory.insertCKGPart(l_part);
                    clearUI();

                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('新增成功');", true);
                }
            }
            catch { ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('新增失敗!請檢察網路是否正常');", true); return; }
        }

        private bool 使用者輸入()
        {
            if ("".Equals(_txt類別編號.Text))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('類別編號不得空白');", true);
                return false;
            }
            if ("".Equals(_txt類別名稱.Text))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('類別名稱不得空白');", true);
                return false;
            }
            if ("".Equals(_txt種類編號.Text))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('種類編號不得空白');", true);
                return false;
            }
            if ("".Equals(_txt種類名稱.Text))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('種類名稱不得空白');", true);
                return false;
            }
            if ("".Equals(_txt產品編號.Text))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('產品編號不得空白');", true);
                return false;
            }
            if ("".Equals(_txt產品名稱.Text))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('產品名稱不得空白');", true);
                return false;
            }
            if ("".Equals(_txt單位.Text))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('單位不得空白');", true);
                return false;
            }
            if ("".Equals(_txt業代價.Text))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('業代價不得空白');", true);
                return false;
            }
            if ("".Equals(_txt售價.Text))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('售價不得空白');", true);
                return false;
            }
            if ("".Equals(_txt成本.Text))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('成本不得空白');", true);
                return false;
            }
            return true;
        }
        private void clearUI()
        {
            _txt類別編號.Text = "";
            _txt類別名稱.Text = "";
            _txt種類編號.Text = "";
            _txt種類名稱.Text = "";
            _txt產品編號.Text = "";
            _txt產品名稱.Text = "";
            _txt單位.Text = "";
            _txt業代價.Text = "";
            _txt售價.Text = "";
            _txt成本.Text = "";

        }
    }
}
