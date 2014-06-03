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

namespace KGUi.manager.money
{
    public partial class WfrmInsertKGPoint : System.Web.UI.Page
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
                 return;
             }

        }

        protected void iv_btn查詢_Click(object sender, EventArgs e)
        {
            try
            {
                string l_str業代員編 = iv_txt業代員編.Text.Trim().ToUpper();
                if ("".Equals(l_str業代員編))
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('請輸入員工編號')", true);
                }
                else
                {
                    查詢業代資料(l_str業代員編);
                }
            }
            catch { }
        }

        private void 查詢業代資料(string p_strSmid)
        {
            string l_str業代員編 = iv_txt業代員編.Text.Trim().ToUpper();

            CKGPointFactory l_factory點數資料 = _context.CFactoryManager.CKGPointFactory;
            CKGPoint l_code點數資料 = l_factory點數資料.get業代點數資料(p_strSmid);

            if (l_code點數資料 == null)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('無此員工點數資料，進行新增個人點數資料作業')", true); 
                return;
            }

            開啟儲值畫面(l_code點數資料);
        }
        private void 開啟儲值畫面(CKGPoint p_code點數資料)
        {
            iv_lblSmid.Text = p_code點數資料.f_Smid業代員編;
            iv_lbl業代姓名.Text = p_code點數資料.f_Name業代姓名;
            iv_lbl現有點數.Text = p_code點數資料.f_Point現有點數.ToString();
        }

        protected void iv_cbo刷卡銀行_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if ("".Equals(iv_cbo刷卡銀行.SelectedValue))
                {
                    iv_txt手續費.Text = "0";
                    return;
                }

                if (iv_cbo刷卡銀行.SelectedValue.Equals("中國信託"))
                {
                    int l_int = Convert.ToInt32(iv_txt儲值點數.Text);
                    double l_double = (l_int * 0.0169) + 0.5;

                    l_int = (int)l_double;
                    iv_txt手續費.Text = l_int.ToString();
                }
                else if (iv_cbo刷卡銀行.SelectedValue.Equals("台新銀行"))
                {
                    int l_int = Convert.ToInt32(iv_txt儲值點數.Text);
                    double l_double = (l_int * 0.0173) + 0.5;

                    l_int = (int)l_double;
                    iv_txt手續費.Text = l_int.ToString();
                }
                
            }
            catch { iv_txt手續費.Text = "0"; }
        }

        protected void iv_btn儲值_Click(object sender, EventArgs e)
        {
            if ("".Equals(iv_lbl業代姓名.Text.Trim()))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('請先查詢儲值人員');", true);
                return;
            }

            if ("".Equals(iv_txt儲值點數.Text.Trim()))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('請輸入儲值點數');", true);
                return;
            }


            if ("刷卡儲值".Equals(iv_cbo儲值方式.SelectedValue) && "".Equals(iv_cbo刷卡銀行.SelectedValue))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('使用刷卡儲值方式，請選擇一家刷卡銀行');", true);
                return;
            }

            if (!"刷卡儲值".Equals(iv_cbo儲值方式.SelectedValue) && !"".Equals(iv_cbo刷卡銀行.SelectedValue))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('非使用刷卡儲值方式，刷卡銀行無須選擇');", true);
                return;
            }

            if ("".Equals(iv_txt發票號碼.Text.Trim()))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('請輸入發票號碼');", true);
                return;
            }
            try
            {
                if ("作廢扣回".Equals(iv_cbo儲值方式.SelectedValue) && Convert.ToInt32(iv_txt儲值點數.Text) > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('作廢扣回應輸入負數金額');", true);
                    return;
                }
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('作廢扣回應輸入負數金額');", true);
                return;
            }
            try
            {
                儲值點數();
            }
            catch (Exception ex) { ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('錯誤:" + ex.ToString() + "');", true); return; }
        }
        private void 儲值點數()
        {
            string l_str業代員編 = iv_lblSmid.Text;
            string l_str業代姓名 = iv_lbl業代姓名.Text;

            CKGPointFactory l_factory點數資料 = _context.CFactoryManager.CKGPointFactory;
            CKGPoint l_code點數資料 = l_factory點數資料.get業代點數資料(l_str業代員編);

            int l_int總點數 = 0;
            int l_int儲值點數 = Convert.ToInt32(iv_txt儲值點數.Text.Trim());
            l_int總點數 += l_code點數資料.f_Point現有點數;
            l_int總點數 += l_int儲值點數;
            l_factory點數資料.update業代點數(l_str業代員編, l_int總點數);//修改現有點數


            CKGPointDetailFactory l_factory紀錄 = _context.CFactoryManager.CKGPointDetailFactory;
            CKGPointDetail l_code紀錄 = l_factory紀錄.createCKGPointDetail();

            l_code紀錄.f_Smid業代員編 = l_str業代員編;
            l_code紀錄.f_Name業代姓名 = l_str業代姓名;
            l_code紀錄.f_ImportPoint匯入點數 = l_int儲值點數;
            l_code紀錄.f_ImportDate匯入日期 = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;

            l_code紀錄.f_ImportSmid匯入人員員編 = l_user.f_userid帳號;//"F9446";//
            l_code紀錄.f_ImportName匯入人員姓名 = l_user.f_username姓名;//"黃敏惠";//
            l_code紀錄.f_ImportType匯入方式 = iv_cbo儲值方式.SelectedValue;
            l_code紀錄.f_InvoiceNo發票號碼 = iv_txt發票號碼.Text.Trim();
            l_code紀錄.f_PayBank刷卡銀行 = iv_cbo刷卡銀行.SelectedValue;
            l_code紀錄.f_InMoneyBank入帳銀行 = iv_cbo入帳銀行.SelectedValue;
            try
            {
                if ("刷卡儲值".Equals(iv_cbo儲值方式.SelectedValue))
                {
                    l_code紀錄.f_BankCharge手續費 = Convert.ToInt32(iv_txt手續費.Text.Trim());
                }
                else
                {
                    l_code紀錄.f_BankCharge手續費 = 0;
                }
            }
            catch
            {
                l_code紀錄.f_BankCharge手續費 = 0;
            }

            l_factory紀錄.insertCKGPointDetail(l_code紀錄);
            iv_lbl現有點數.Text = l_int總點數.ToString();

            iv_txt儲值點數.Text = "";
            iv_txt發票號碼.Text = "";

            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('儲值成功')", true);
        }
        protected void iv_btn儲值取消_Click(object sender, EventArgs e)
        {

        }
    }
}
