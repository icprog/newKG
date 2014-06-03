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
    public partial class FrmSelectKGPartOrderDetailOutAdmin : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);

            if (!Page.IsPostBack)
            {
                CTools.get所別(iv_cbo退貨所別, _context);
            }
        }

        protected void iv_btn查詢_Click(object sender, EventArgs e)
        {
            get退貨記錄("NonCheck");
        }

        private void get退貨記錄(string p_type)
        {
            string l_str請購單號 = iv_txt請購單號.Text.Trim().ToUpper();
            string l_str退貨所別 = iv_cbo退貨所別.SelectedValue;
            string l_str退貨日期起 = _txtBDate.Text.Trim();
            string l_str退貨日期止 = _txtEDate.Text.Trim();

            CKGPartOrderDetailOutFactory l_factory = _context.CFactoryManager.CKGPartOrderDetailOutFactory;
            CKGPartOrderDetailOut[] l_codes = null;
            if ("NonCheck".Equals(p_type))
            {
                l_codes = l_factory.getAll退貨資料By條件("", l_str請購單號, l_str退貨所別, "", "False", l_str退貨日期起, l_str退貨日期止);
                
                if (l_codes == null)
                {
                    iv_pnl查詢結果.Visible = false;
                    iv_lblErrorMessage.Text = "無退貨記錄!!";
                }
                else
                {
                    iv_pnl查詢結果.Visible = true;
                    display退貨記錄(l_codes);
                }
            }
            else
            {
                l_codes = l_factory.getAll退貨資料By條件("", l_str請購單號, l_str退貨所別, "", "True", l_str退貨日期起, l_str退貨日期止);

                if (l_codes == null)
                {
                    iv_lblErrorMessage.Text = "無退貨歷史記錄!!";
                }
                else
                {
                    display退貨歷史記錄(l_codes);
                }
            }

        }

        private void display退貨歷史記錄(CKGPartOrderDetailOut[] p_codes)
        {
            GridView2.DataSource = getDataTableBydisplay退貨歷史記錄(p_codes);
            GridView2.DataBind();
        }
        private DataTable getDataTableBydisplay退貨歷史記錄(CKGPartOrderDetailOut[] p_codes)
        {
            string[] l_str = { "請購單號", "退貨日期", "員編", "姓名", "單位", "產品編號", "產品名稱", "成本價", "單價", "數量", "總計", "退貨原因" };
            DataTable l_table = CTools.getFilledColumnsDataTable(l_str);

            if (p_codes == null)
            {
                return l_table;
            }

            for (int i = 0; i < p_codes.Length; i++)
            {
                DataRow l_row = l_table.NewRow();

                l_row["請購單號"] = p_codes[i].f_ExchangeID請購單號;//1
                l_row["退貨日期"] = p_codes[i].f_OutDate退貨日期;//2
                l_row["員編"] = p_codes[i].f_SalesSmid業代員編;//3
                l_row["姓名"] = p_codes[i].f_SalesName業代姓名;//4
                l_row["單位"] =CTools.get轉換據點中英文( p_codes[i].f_SalesBranch業代單位 );//5
                l_row["產品編號"] = p_codes[i].f_ProductID產品編號;//6
                l_row["產品名稱"] = p_codes[i].f_ProductName產品名稱;//7
                l_row["成本價"] = p_codes[i].f_Cost產品成本;//8
                l_row["單價"] = p_codes[i].f_UnitPrice產品單價;//8
                l_row["數量"] = p_codes[i].f_OutAmount退貨數量;//9
                l_row["總計"] = p_codes[i].f_OutTotal總計退貨價格;//10
                l_row["退貨原因"] = p_codes[i].f_OutReasons退貨原因;//11
                l_table.Rows.Add(l_row);
            }

            return l_table;
        }

        private void display退貨記錄(CKGPartOrderDetailOut[] p_codes)
        {
            GridView1.DataSource = getDataTableBydisplay退貨記錄(p_codes);
            GridView1.DataBind();
        }
        private DataTable getDataTableBydisplay退貨記錄(CKGPartOrderDetailOut[] p_codes)
        {
            string[] l_str = { "確認", "請購單號", "退貨日期", "業代員編", "業代姓名", "業代單位", "產品編號", "產品名稱", "單價", "退貨數量", "總計", "退貨原因", "Visible" };
            DataTable l_table = CTools.getFilledColumnsDataTable(l_str);

            if (p_codes == null)
            {
                return l_table;
            }

            string l_str請購單號 = "";
            for (int i = 0; i < p_codes.Length; i++)
            {
                DataRow l_row = l_table.NewRow();

                l_row["確認"] = p_codes[i].f_id;//0

                if (!l_str請購單號.Equals(p_codes[i].f_ExchangeID請購單號))
                {
                    l_row["Visible"] = "True";
                }
                else
                {
                    l_row["Visible"] = "False";
                }
                l_row["請購單號"] = p_codes[i].f_ExchangeID請購單號;//1
                l_row["退貨日期"] = p_codes[i].f_OutDate退貨日期;//2
                l_row["業代員編"] = p_codes[i].f_SalesSmid業代員編;//3
                l_row["業代姓名"] = p_codes[i].f_SalesName業代姓名;//4
                l_row["業代單位"] =CTools.get轉換據點中英文( p_codes[i].f_SalesBranch業代單位 );//5
                l_row["產品編號"] = p_codes[i].f_ProductID產品編號;//6
                l_row["產品名稱"] = p_codes[i].f_ProductName產品名稱;//7
                l_row["單價"] = p_codes[i].f_UnitPrice產品單價;//8
                l_row["退貨數量"] = p_codes[i].f_OutAmount退貨數量;//9
                l_row["總計"] = p_codes[i].f_OutTotal總計退貨價格;//10
                l_row["退貨原因"] = p_codes[i].f_OutReasons退貨原因;//11

                l_str請購單號 = p_codes[i].f_ExchangeID請購單號;
                l_table.Rows.Add(l_row);
            }

            return l_table;
        }

        protected void iv_btn確認退貨_Click(object sender, EventArgs e)
        {
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;

            if (l_user == null)
            {
                Response.Redirect("../../FrmLogin.aspx");
                return;
            }
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox l_chk取消 = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("iv_chk確認");

                if (l_chk取消.Checked)
                {
                    string l_str取消Id = ((Label)GridView1.Rows[i].Cells[0].FindControl("iv_lblID")).Text;
                    確認退貨記錄(l_str取消Id);
                }
            }

            get退貨記錄("NonCheck");
        }

        private void 確認退貨記錄(string p_strId)
        {
            CKGPartOrderDetailOutFactory l_factory退貨記錄 = _context.CFactoryManager.CKGPartOrderDetailOutFactory;
            CKGPartOrderDetailOut l_code退貨記錄 = l_factory退貨記錄.get退貨資料ById(p_strId);

            CKGPointFactory l_factory點數資料 = _context.CFactoryManager.CKGPointFactory;
            CKGPoint l_code點數資料 = l_factory點數資料.get業代點數資料(l_code退貨記錄.f_SalesSmid業代員編);

            CUser l_user業代 = _context.CFactoryManager.CUserFactory.get高都員工檔(l_code退貨記錄.f_SalesSmid業代員編);
            
            if (l_code點數資料 == null)
            {
                l_code點數資料 = l_factory點數資料.createCKGPoint();
               
                l_code點數資料.f_Smid業代員編 = l_code退貨記錄.f_SalesSmid業代員編;
                l_code點數資料.f_Name業代姓名 = l_user業代.f_username姓名;
                l_code點數資料.f_Point現有點數 = 0;
                l_factory點數資料.insertCKGPoint(l_code點數資料);
            }

            string l_str現在時間 = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            //
            l_factory退貨記錄.update確認退貨By管理者(p_strId, l_str現在時間);
            
            //把錢存回業代的點數
            l_factory點數資料.update沖帳取消或退貨成功後點數歸回(l_code退貨記錄.f_SalesSmid業代員編, l_code退貨記錄.f_OutTotal總計退貨價格);

            CKGPointDetailFactory l_factory點數紀錄 = _context.CFactoryManager.CKGPointDetailFactory;
            CKGPointDetail l_code點數紀錄 = l_factory點數紀錄.createCKGPointDetail();

            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;

            l_code點數紀錄.f_ImportSmid匯入人員員編 = l_user.f_userid帳號;//"F9446";//
            l_code點數紀錄.f_ImportName匯入人員姓名 = l_user.f_username姓名;//"黃敏惠";//
            l_code點數紀錄.f_Smid業代員編 = l_code退貨記錄.f_SalesSmid業代員編;
            l_code點數紀錄.f_Name業代姓名 = l_user業代.f_username姓名;
            l_code點數紀錄.f_ImportPoint匯入點數 = l_code退貨記錄.f_OutTotal總計退貨價格;
            l_code點數紀錄.f_ImportDate匯入日期 = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            l_code點數紀錄.f_ImportType匯入方式 = "退貨加回";

            l_factory點數紀錄.insertCKGPointDetail(l_code點數紀錄);

        }

        protected void iv_btn完成退貨記錄查詢_Click(object sender, EventArgs e)
        {
            get退貨記錄("");
        }
    }
}
