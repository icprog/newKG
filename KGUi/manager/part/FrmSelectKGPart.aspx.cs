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
using KGUi.tools;

namespace KGUi.manager.part
{
    public partial class FrmSelectKGPart : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);

            if (!Page.IsPostBack)
            {
                CTools.加入高輊小百貨產品類別(iv_cbo類別名稱, _context);
            }
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;

            if (l_user == null)
            {
                Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
                Response.Redirect("../../FrmLogin.aspx");
            }
        }

        protected void iv_btn查詢_Click(object sender, EventArgs e)
        {
            查詢資料("按查詢");
        }

        private void 查詢資料(string p_strType)
        {
            CKGPartFactory l_factory = _context.CFactoryManager.CKGPartFactory;
            CKGPart l_code產品檔 = l_factory.createCKGPart();

            l_code產品檔.f_TypeID類別編號 = iv_cbo類別名稱.SelectedValue;
            l_code產品檔.f_CategoryID種類編號 = iv_cbo種類名稱.SelectedValue;
            l_code產品檔.f_ProductID產品編號 = iv_txt產品編號.Text.Trim();
            l_code產品檔.f_ProductName產品名稱 = iv_txt產品名稱.Text.Trim();

            CKGPart[] l_codes查詢 = l_factory.get產品By查詢(l_code產品檔);

            if ("按查詢".Equals(p_strType) && l_codes查詢 == null)
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('查無資料');", true);
                return;
            }

            display(l_codes查詢);
        }

        private string getID(object sender)
        {
            Button l_btn = (Button)sender;
            return ((Label)l_btn.FindControl("iv_lblID")).Text;
        }

        protected void iv_btn刪除_Click(object sender, EventArgs e)
        {
            string l_ID = getID(sender);
            _context.CFactoryManager.CKGPartFactory.deleteCKGPart(l_ID);

            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('刪除成功!!');", true);

            查詢資料("畫面重整");
        }

        private void display(CKGPart[] p_codes)
        {
            GridView1.DataSource = getDataTableBydisplay(p_codes);
            GridView1.DataBind();
        }

        private DataTable getDataTableBydisplay(CKGPart[] p_codes)
        {
            string[] l_str = { "ID", "項次", "類別編號", "類別名稱", "種類編號", "種類名稱", "產品編號", "產品名稱", "單位", "成本價", "業代價", "售價", "修改" };

            DataTable l_dt = CTools.getFilledColumnsDataTable(l_str);

            int l_int項次 = 1;
            for (int i = 0; i < p_codes.Length; i++)
            {
                DataRow l_row = l_dt.NewRow();
                l_row["ID"] = p_codes[i].f_id;
                l_row["項次"] = l_int項次++;
                l_row["類別編號"] = p_codes[i].f_TypeID類別編號;
                l_row["類別名稱"] = p_codes[i].f_TypeName類別名稱;
                l_row["種類編號"] = p_codes[i].f_CategoryID種類編號;
                l_row["種類名稱"] = p_codes[i].f_CategoryName種類名稱;
                l_row["產品編號"] = p_codes[i].f_ProductID產品編號;
                l_row["產品名稱"] = p_codes[i].f_ProductName產品名稱;
                l_row["單位"] = p_codes[i].f_Qty單位;
                l_row["成本價"] = p_codes[i].f_Cost成本價;
                l_row["業代價"] = p_codes[i].f_SalePrice業代價;
                l_row["售價"] = p_codes[i].f_ListPrice售價;
                l_row["修改"] = "FrmUpdateKGPart.aspx?id=" + p_codes[i].f_id;

                l_dt.Rows.Add(l_row);
            }
            Session.Add(SealedGlobalPage.SESSIONKEY_PARTS, l_dt);
            
            return l_dt;
        }

        protected void iv_cbo類別名稱_SelectedIndexChanged(object sender, EventArgs e)
        {
            CKGPartFactory l_factory = _context.CFactoryManager.CKGPartFactory;
            CKGPart[] l_codes = l_factory.get種類By類別(iv_cbo類別名稱.SelectedValue);

            iv_cbo種類名稱.Items.Clear();
            iv_cbo種類名稱.Items.Insert(0, "");
            if (l_codes != null)
            {
                for (int i = 0; i < l_codes.Length; i++)
                {
                    iv_cbo種類名稱.Items.Add(new ListItem(l_codes[i].f_CategoryID種類編號 + " " + l_codes[i].f_CategoryName種類名稱, l_codes[i].f_CategoryID種類編號));
                }
            }
        }

        protected void _btn匯出_Click(object sender, EventArgs e)
        {
            DataTable l_table = Session[SealedGlobalPage.SESSIONKEY_PARTS] as DataTable;

            if (l_table == null)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('無匯出資料!請先執行查詢');", true);
                return;
            }

            string l_strPath = "../../report/" + DateTime.Today.ToString("yyyyMMdd") + "PartsReport.xls";
            CTools.toExcelByDataView(new DataView(l_table), Server.MapPath(l_strPath), DateTime.Today.ToString("yyyyMMdd") + "PartsReport");
            Response.Redirect(l_strPath);
        }
    }
}
