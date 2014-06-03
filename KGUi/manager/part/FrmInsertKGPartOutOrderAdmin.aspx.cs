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
    public partial class FrmInsertKGPartOutOrderAdmin : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);

            if (!Page.IsPostBack)
            {
                CTools.get所別(iv_cbo請購所別, _context);
            }
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;

            if (l_user == null)
            {
                Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
                Response.Redirect("../../FrmLogin.aspx");
            }
        }

        private void get請購清單()
        {
            string l_str廠商 = iv_cbo廠商.SelectedValue;
            string l_str所別 = iv_cbo請購所別.SelectedValue;
            if ("".Equals(l_str廠商))
            {
                return;
            }

            CKGPartOrderFactory l_factory = _context.CFactoryManager.CKGPartOrderFactory;
            CKGPartOrder[] l_codes = l_factory.getGroupBy未訂購所別筆數(l_str廠商, l_str所別);
            display請購單(l_codes);
        }

        private void display請購單(CKGPartOrder[] p_codes)
        {
            GridView1.DataSource = getDataTableBydisplay請購單(p_codes);
            GridView1.DataBind();
        }

        private DataTable getDataTableBydisplay請購單(CKGPartOrder[] p_codes)
        {
            string[] l_str = { "請購名細", "請購所別", "對象廠商", "請購筆數", "請購所別id" };


            DataTable l_table = CTools.getFilledColumnsDataTable(l_str);

            if (p_codes == null)
            {
                return l_table;
            }

            for (int i = 0; i < p_codes.Length; i++)
            {
                DataRow l_row = l_table.NewRow();

                l_row["請購名細"] = "";//0
                l_row["請購所別"] = CTools.get轉換據點中英文(p_codes[i].f_SalesBranch業代單位);//1
                l_row["請購所別id"] = p_codes[i].f_SalesBranch業代單位;//1
                l_row["對象廠商"] = p_codes[i].f_Vendor請購廠商;//2
                l_row["請購筆數"] = p_codes[i].NonSendCount未發送的請購筆數;//3

                l_table.Rows.Add(l_row);
            }

            return l_table;
        }
        protected void iv_cbo請購所別_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ("".Equals(iv_cbo廠商.SelectedValue) && iv_cbo請購所別.SelectedIndex != -1)
            {
                //ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('請先選擇廠商');", true);
                return;
            }
            get請購清單();
            //iv_lbx請購單號.Items.Clear();
            //iv_lbx要訂購的請購單號.Items.Clear();
            //iv_lblTitle請購單號.Text = "";
            //CUtility.清空GridView(GridView2);
        }

        protected void iv_btn請購明細_Click(object sender, EventArgs e)
        {
            iv_lbx請購單號.Items.Clear();
            iv_lbx要訂購的請購單號.Items.Clear();
            iv_lblTitle請購單號.Text = "";
            string l_str請購所別 = get請購所別(sender);
            string l_str對象廠商 = get對象廠商(sender);

            CKGPartOrderFactory l_factory = _context.CFactoryManager.CKGPartOrderFactory;
            CKGPartOrder[] l_codes = l_factory.get所別未定購的請購明細(l_str對象廠商, l_str請購所別);

            add請購單號到ListBox(l_codes);
        }

        private void add請購單號到ListBox(CKGPartOrder[] p_codes)
        {
            for (int i = 0; i < p_codes.Length; i++)
            {
                CUser l_user = _context.CFactoryManager.CUserFactory.get高都員工檔(p_codes[i].f_SalesSmid業代員編);
                p_codes[i].f_SalesName業代姓名 = l_user.f_username姓名;
                string l_str顯示字串 = p_codes[i].f_ExchangeID請購單號 + " " + p_codes[i].f_Branchid請購單位 + " " + p_codes[i].f_SalesName業代姓名;
                iv_lbx請購單號.Items.Add(new ListItem(l_str顯示字串, p_codes[i].f_ExchangeID請購單號));
            }
        }
        private string get請購所別(object sender)
        {
            Button l_btn = (Button)sender;
            return ((Label)l_btn.FindControl("iv_lbl請購所別id")).Text;
        }
        private string get對象廠商(object sender)
        {
            Button l_btn = (Button)sender;
            return ((Label)l_btn.FindControl("iv_lbl對象廠商")).Text;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            CTools.ItemsChange(iv_lbx請購單號.Items, iv_lbx要訂購的請購單號.Items,
               CTools.Items移動格式.搬移, CTools.Item移動項目.選取);
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            CTools.ItemsChange(iv_lbx請購單號.Items, iv_lbx要訂購的請購單號.Items,
                CTools.Items移動格式.搬移, CTools.Item移動項目.全部);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            CTools.ItemsChange(iv_lbx要訂購的請購單號.Items, iv_lbx請購單號.Items,
                CTools.Items移動格式.搬移, CTools.Item移動項目.選取);
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            CTools.ItemsChange(iv_lbx要訂購的請購單號.Items, iv_lbx請購單號.Items,
               CTools.Items移動格式.搬移, CTools.Item移動項目.全部);
        }
        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
        }

        protected void iv_lbx請購單號_SelectedIndexChanged(object sender, EventArgs e)
        {
            string l_str請購單號 = iv_lbx請購單號.SelectedValue;

            iv_lblTitle請購單號.Text = l_str請購單號;
            CKGPartOrderDetailFactory l_factory = _context.CFactoryManager.CKGPartOrderDetailFactory;
            CKGPartOrderDetail[] l_codes = l_factory.get請購明細ByExchangeID(l_str請購單號);

            displayDetail(l_codes);
        }
        private void displayDetail(CKGPartOrderDetail[] p_codes)
        {
            GridView2.DataSource = getDataTableBydisplay(p_codes);
            GridView2.DataBind();
        }
        private DataTable getDataTableBydisplay(CKGPartOrderDetail[] p_codes)
        {
            string[] l_str = { "產品編號", "產品名稱", "數量", "單價", "成本總計", "總計" };

            DataTable l_table = CTools.getFilledColumnsDataTable(l_str);

            if (p_codes == null)
            {
                return l_table;
            }

            for (int i = 0; i < p_codes.Length; i++)
            {
                DataRow l_row = l_table.NewRow();

                l_row["產品編號"] = p_codes[i].f_ProductID產品編號;//0
                l_row["產品名稱"] = p_codes[i].f_ProductName產品名稱;//1
                l_row["數量"] = p_codes[i].f_Amount選購數量;//2
                l_row["單價"] = p_codes[i].f_UnitPrice產品單價;//3
                l_row["成本總計"] = p_codes[i].f_Amount選購數量 * p_codes[i].f_UnitPrice產品單價;//3
                l_row["總計"] = p_codes[i].f_Total總計價格;//3

                l_table.Rows.Add(l_row);
            }

            return l_table;
        }
        protected void iv_btn送出清單_Click(object sender, EventArgs e)
        {
            if (iv_lbx要訂購的請購單號.Items.Count > 0)
            {
                ArrayList l_al = new ArrayList();
                for (int i = 0; i < iv_lbx要訂購的請購單號.Items.Count; i++)
                {
                    l_al.Add(iv_lbx要訂購的請購單號.Items[i].Value);
                }

                送出訂購單(l_al);
                iv_lbx要訂購的請購單號.Items.Clear();
                get請購清單();
                iv_txt備註.Text = "";
            }
            else
            {
                string l_str = "alert('無請購單，請選擇');";
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", l_str, true);
            }
        }

        private void 送出訂購單(ArrayList p_al)
        {
            string l_Msg = "";
            CKGPartOrder[] l_code選擇 = new CKGPartOrder[p_al.Count];
            CKGPartOrderFactory l_factory = _context.CFactoryManager.CKGPartOrderFactory;
            for (int i = 0; i < l_code選擇.Length; i++)
            {
                try
                {
                    l_code選擇[i] = l_factory.getKGPartOrderBy請購單號((string)p_al[i]);
                    確認訂購並發送Email(l_code選擇[i]);
                }
                catch
                {
                    l_Msg = "alert('訂購作業失敗，訂購單號為: " + l_code選擇[i].f_ExchangeID請購單號 + "，訂購郵件發送失敗!";
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", l_Msg, true);
                }     
            }
            l_Msg = "alert('訂購作業完成，訂購郵件發送成功');";
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", l_Msg, true);
            //寫入KGPartInMoney(l_code選擇);
        }

        private void 確認訂購並發送Email(CKGPartOrder p_codes)
        {
            if (!"KG".Equals(p_codes.f_Vendor請購廠商))//廠商不是高輊時都要發送Email
            {
                發送Email(p_codes.f_Branchid請購單位, p_codes);            
            }

            _context.CFactoryManager.CKGPartOrderFactory.update訂購或點收後請購單的狀態(p_codes);
        }
        private void 發送Email(string p_str請購單位, CKGPartOrder p_codes)
        {
            CKGPartOrderMail l_mail = new CKGPartOrderMail(_context);

            l_mail.設定Mail(p_str請購單位, p_codes);
            l_mail.發送Mail();//發送Mail*********測試期間先拿掉**************
        }
        protected void iv_cbo廠商_SelectedIndexChanged1(object sender, EventArgs e)
        {
            
            get請購清單();
            iv_lbx請購單號.Items.Clear();
            iv_lbx要訂購的請購單號.Items.Clear();
            iv_cbo請購所別.SelectedIndex = -1;
            iv_lblTitle請購單號.Text = "";
       
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }    
    }
}
