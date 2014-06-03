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

namespace KGUi.part
{
    public partial class FrmInsertKGPartOrderDetailOut : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;

            if (l_user == null)
            {
                Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
                Response.Redirect("../FrmLogin.aspx");
            }

        }

        protected void iv_btn查詢_Click(object sender, EventArgs e)
        {
            CUser l_user = (Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser);
            string l_str業代員編 = iv_txt業代員編.Text.Trim().ToUpper();
            string l_str請購單號 = iv_txt請購單號.Text.Trim().ToUpper();
            string l_str起始日期 = _txtBDate.Text.Trim();
            string l_str結束日期 = _txtEDate.Text.Trim();
            string l_str助理員編 = l_user.f_userid帳號;//"F9446";//

            CKGPartOrderFactory l_factory = _context.CFactoryManager.CKGPartOrderFactory;
            CKGPartOrder[] l_codes = l_factory.getAll請購單號By條件(l_str助理員編, l_str業代員編, l_str請購單號, "", l_str起始日期, l_str結束日期);

            if (l_codes == null)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('查無資料');", true);
              
                //iv_pnl退貨畫面.Visible = false;
                return;
            }

            display請購記錄(l_codes);
        }

        private void display請購記錄(CKGPartOrder[] p_codes)
        {
            GridView1.DataSource = getDataTableBydisplay請購記錄(p_codes);
            GridView1.DataBind();
        }
        private DataTable getDataTableBydisplay請購記錄(CKGPartOrder[] p_codes)
        {
            string[] l_str = { "退貨", "請購單號", "請購廠商", "請購日期", "引擎號碼", "業代員編", "業代姓名", "業代單位", "總計價格", "備註" };
            DataTable l_table = CTools.getFilledColumnsDataTable(l_str);

            if (p_codes == null)
            {
                return l_table;
            }

            for (int i = 0; i < p_codes.Length; i++)
            {
                DataRow l_row = l_table.NewRow();

                l_row["退貨"] = "";//0
                l_row["請購單號"] = p_codes[i].f_ExchangeID請購單號;//1
                l_row["請購廠商"] = set廠商名稱(p_codes[i].f_Vendor請購廠商);//2
                l_row["請購日期"] = p_codes[i].f_InsertDate請購日期;//3
                l_row["引擎號碼"] = p_codes[i].f_EngineNo引擎號碼;//4
                l_row["業代員編"] = p_codes[i].f_SalesSmid業代員編;//5
                l_row["業代姓名"] = p_codes[i].f_SalesName業代姓名;//6
                l_row["業代單位"] = p_codes[i].f_SalesBranch業代單位;//7
                l_row["總計價格"] = p_codes[i].f_TotalPrice總計價格;//8
                l_row["備註"] = p_codes[i].f_Memo備註說明;//9

                l_table.Rows.Add(l_row);
            }

            return l_table;
        }

        private string set廠商名稱(string p_str廠商代號)
        {
            switch (p_str廠商代號)
            {
                case "KC": return "亙長";
                case "LD": return "劦大";
                case "KG": return "高輊";
                default: return "";
            }
        }


        protected void iv_btn退貨_Click(object sender, EventArgs e)
        {
            iv_pnl退貨畫面.Visible = true;
            iv_lbx請購產品清單.Items.Clear();
            iv_lbx退貨產品清單.Items.Clear();

            iv_lbl請購單號2.Text = get請購編號(sender);

            CKGPartOrderDetailFactory l_factory請購 = _context.CFactoryManager.CKGPartOrderDetailFactory;
            CKGPartOrderDetail[] l_codes請購 = l_factory請購.get請購明細ByExchangeID(iv_lbl請購單號2.Text);

            addinListBox(iv_lbx請購產品清單, l_codes請購);

            Hashtable l_ht = new Hashtable();
            Session.Add(SealedGlobalPage.SESSIONKEY_KGPARTORDERDETAIL_HASHTABLE, l_ht);
        }

        private string get請購編號(object sender)
        {
            Button l_btn = (Button)sender;
            return ((Label)l_btn.FindControl("iv_lbl請購單號")).Text;
        }

        private void addinListBox(ListBox p_lbx請購, CKGPartOrderDetail[] p_codes請購)
        {
            for (int i = 0; i < p_codes請購.Length; i++)
            {
                if (p_codes請購[i].f_Amount選購數量 != 0)
                {
                    string l_str顯示名稱 = p_codes請購[i].f_ProductName產品名稱;
                    p_lbx請購.Items.Add(new ListItem(l_str顯示名稱, p_codes請購[i].f_ProductID產品編號));
                }
            }
        }

        protected void iv_btn確認退貨_Click(object sender, EventArgs e)
        {
            if ("".Equals(iv_txt退貨原因.Text.Trim()))
            {
                string l_str = "alert('請輸入退貨原因');";
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", l_str, true);
                return;
            }

            Hashtable l_ht = (Hashtable)Session[SealedGlobalPage.SESSIONKEY_KGPARTORDERDETAIL_HASHTABLE];
            if (l_ht == null || l_ht.Count <= 0)
            {
                string l_str = "alert('退貨失敗，退貨清單內無任何產品');";
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", l_str, true);
                return;
            }

            string l_str請購單號 = iv_lbl請購單號2.Text;
            foreach (string productid in l_ht.Keys)
            {
                int l_int退貨數量 = (int)l_ht[productid];
                insertTo退貨記錄(l_str請購單號, productid, l_int退貨數量);
            }

            string l_str1 = "alert('退貨成功，請列印退貨單貼至產品上寄回總公司進行退貨程序');";
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", l_str1, true);
            iv_pnl退貨畫面.Visible = false;
            GridView1.DataSource = null;
            GridView1.DataBind();
            
        }
        private void insertTo退貨記錄(string p_str請購單號, string p_str產品編號, int p_int退貨數量)
        {
            CKGPartOrderFactory l_factory請購主檔 = _context.CFactoryManager.CKGPartOrderFactory;
            CKGPartOrder l_code請購主檔 = l_factory請購主檔.getKGPartOrderBy請購單號(p_str請購單號);

            CKGPartOrderDetailFactory l_factory請購明細 = _context.CFactoryManager.CKGPartOrderDetailFactory;
            CKGPartOrderDetail l_code請購明細 = l_factory請購明細.get請購單內的單一產品明細(p_str請購單號, p_str產品編號);


            CKGPartOrderDetailOutFactory l_factroy退貨記錄 = _context.CFactoryManager.CKGPartOrderDetailOutFactory;
            CKGPartOrderDetailOut l_code退貨記錄 = l_factroy退貨記錄.createCKGPartOrderDetailOut();           
            
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;

            l_code退貨記錄.f_ExchangeID請購單號 = p_str請購單號;
            l_code退貨記錄.f_SalesSmid業代員編 = l_code請購主檔.f_SalesSmid業代員編;
            l_code退貨記錄.f_SalesBranch業代單位 = l_user.f_branchid所別;
            l_code退貨記錄.f_AssistantSmid退貨助理員編 = l_user.f_userid帳號; //"F9446";//
            l_code退貨記錄.f_ProductID產品編號 = l_code請購明細.f_ProductID產品編號;
            l_code退貨記錄.f_ProductName產品名稱 = l_code請購明細.f_ProductName產品名稱;
            l_code退貨記錄.f_OutAmount退貨數量 = p_int退貨數量;
            l_code退貨記錄.f_OutDate退貨日期 = DateTime.Today.ToString("yyyy/MM/dd");
            l_code退貨記錄.f_Qty產品單位 = l_code請購明細.f_Qty產品單位;
            l_code退貨記錄.f_Cost產品成本 = l_code請購明細.f_Cost產品成本價;
            l_code退貨記錄.f_UnitPrice產品單價 = l_code請購明細.f_UnitPrice產品單價;
            l_code退貨記錄.f_ListPrice建議售價 = l_code請購明細.f_ListPrice建議售價;
            l_code退貨記錄.f_OutTotal總計退貨價格 = l_code請購明細.f_UnitPrice產品單價 * p_int退貨數量;
            l_code退貨記錄.f_OutReasons退貨原因 = iv_txt退貨原因.Text.Replace("'", "");
            l_code退貨記錄.f_Check管理者確認退貨 = "False";
            l_code退貨記錄.f_EditDate編輯日期 = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            l_factroy退貨記錄.insertCKGPartOrderDetailOut(l_code退貨記錄);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if ("0".Equals(iv_txt數量.Text.Trim()))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('請輸入退貨數量再將產品移轉至退貨清單');", true);
                return;
            }

            Hashtable l_ht = (Hashtable)Session[SealedGlobalPage.SESSIONKEY_KGPARTORDERDETAIL_HASHTABLE];
            l_ht.Add(iv_lbx請購產品清單.SelectedValue, Convert.ToInt32(iv_txt數量.Text.Trim()));

            CTools.ItemsChange(iv_lbx請購產品清單.Items, iv_lbx退貨產品清單.Items,
               CTools.Items移動格式.搬移, CTools.Item移動項目.選取);

            Session.Add(SealedGlobalPage.SESSIONKEY_KGPARTORDERDETAIL_HASHTABLE, l_ht);
            轉移數量恢復初始值();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Hashtable l_ht = (Hashtable)Session[SealedGlobalPage.SESSIONKEY_KGPARTORDERDETAIL_HASHTABLE];
            l_ht.Remove(iv_lbx退貨產品清單.SelectedValue);

            CTools.ItemsChange(iv_lbx退貨產品清單.Items, iv_lbx請購產品清單.Items,
                CTools.Items移動格式.搬移, CTools.Item移動項目.選取);

            Session.Add(SealedGlobalPage.SESSIONKEY_KGPARTORDERDETAIL_HASHTABLE, l_ht);
            轉移數量恢復初始值();
        }
        private void 轉移數量恢復初始值()
        {
            iv_txt數量.Text = "0";
        }
    }
}
