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

namespace KGUi.manager.money
{
    public partial class FrmInMoney : System.Web.UI.Page
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

        protected void _btn查詢_Click(object sender, EventArgs e)
        {
            clearSession();
            查詢應收帳款(true);
        }

        private void 查詢應收帳款(bool p_是否存入session)
        {
            string l_strSmid = _txt員編.Text.Trim();
            string l_strBDate = _txtBDate.Text;
            string l_strEDate = _txtEDate.Text;

            if ("".Equals(l_strSmid))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('請輸入員編');", true);
                return;
            }

            if ("".Equals(l_strBDate))
            {
                l_strBDate = "2010/01/01";
            }
            if ("".Equals(_txtEDate))
            {
                l_strEDate = DateTime.Today.ToString("yyyy/MM/dd");
            }
            //查詢點數資訊
            CKGPointFactory l_factory點數資料 = _context.CFactoryManager.CKGPointFactory;
            CKGPoint l_code點數資料 = l_factory點數資料.get業代點數資料(l_strSmid);
            _lbl目前點數.Text = l_code點數資料.f_Point現有點數.ToString();
            if (l_code點數資料 == null)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('無此員工點數資料，進行新增個人點數資料作業')", true);
                return;
            }

            //查詢應收帳款資訊
            CInMoney[] l_inmoney = _context.CFactoryManager.CInMoneyFactory.
                get查詢應收帳款(l_strSmid, l_strBDate,l_strEDate);

            display(l_inmoney, p_是否存入session);


        }

        private void display(CInMoney[] p_CInMoney,bool p_是否存入session)
        {
            string[] l_Msg = new string[] { "項次", "工單號碼", "員工編號", "名稱", "應收帳款", "帳款日期" };
            DataTable l_dt = CTools.getFilledColumnsDataTable(l_Msg);

            int l_int應收 = 0;
            for (int i = 0; i < p_CInMoney.Length; i++)
            {
                DataRow l_row = l_dt.NewRow();
                l_row["項次"] = (i + 1).ToString();
                l_row["工單號碼"] = p_CInMoney[i].f_workid工單單號;
                l_row["員工編號"] = p_CInMoney[i].f_smid帳款人;
                l_row["名稱"] = p_CInMoney[i].f_smid員工名稱;
                l_row["應收帳款"] = p_CInMoney[i].f_money應收金額;
                l_row["帳款日期"] = p_CInMoney[i].f_editdate帳款日期;
                l_int應收 += p_CInMoney[i].f_money應收金額;
                l_dt.Rows.Add(l_row);
            }
            //2011-01-04 拿掉此功能
            //if (p_是否存入session)//沖帳後的重新查詢不濟session
            //{
            //    // 存入 session 中 方便列印
            //    Session.Add(SealedGlobalPage.VIEWSTATE_INMONEY, l_dt);
            //}

            _lbl應收金額.Text = l_int應收.ToString();
            _lbl已收金額.Text = "0";

            _gvAmt.DataSource = l_dt;
            _gvAmt.DataBind();
        }

        protected void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox l_chk = (CheckBox)sender;
            GridViewRow l_row = (GridViewRow)l_chk.Parent.Parent;
            ArrayList l_al工單號碼 = Session[SealedGlobalPage.SESSIONKEY_INMONEY_WORKID] as ArrayList;
            if (l_al工單號碼 == null)
            {
                l_al工單號碼 = new ArrayList();
                Session.Add(SealedGlobalPage.SESSIONKEY_INMONEY_WORKID, l_al工單號碼);
            }

            int l_int已沖 = Convert.ToInt32(_lbl已收金額.Text);
            string l_str工單號碼 = "";

            //打勾則將工單+入session方便一起更動~反之哲否
            if (l_chk.Checked)
            {
                l_int已沖 += Convert.ToInt32(((Label)l_row.Cells[5].Controls[1]).Text);
                l_str工單號碼 = ((Label)l_row.Cells[2].Controls[1]).Text;
                l_al工單號碼.Add(l_str工單號碼);
            }
            else
            {
                l_int已沖 -= Convert.ToInt32(((Label)l_row.Cells[5].Controls[1]).Text);

                l_str工單號碼 = ((Label)l_row.Cells[2].Controls[1]).Text;
                l_al工單號碼.Remove(l_str工單號碼);
            }

            _lbl已收金額.Text = l_int已沖.ToString();
        }

        protected void _btn沖帳_Click(object sender, EventArgs e)
        {

            //判斷點數是否足夠沖帳
            int l_int目前點數 = Convert.ToInt32(_lbl目前點數.Text);
            int l_int已收金額 = Convert.ToInt32(_lbl已收金額.Text);
            if (l_int已收金額 > l_int目前點數)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('點數不足!');", true);
                return;
            }

            //將要沖帳的工單一起更動
            ArrayList l_al工單號碼 = Session[SealedGlobalPage.SESSIONKEY_INMONEY_WORKID] as ArrayList;
            CUser l_User = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;
            if (l_al工單號碼 == null || l_al工單號碼.Count <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('請挑選資料');", true);
                return;
            }

            string l_strIP = Request.UserHostAddress;
            _context.CFactoryManager.CInMoneyFactory.update多筆沖帳(l_al工單號碼, l_User, l_strIP);

            int l_int剩餘點數 = l_int目前點數 - l_int已收金額;
            _context.CFactoryManager.CKGPointFactory
                .update業代點數(_txt員編.Text, l_int剩餘點數);//修改現有點數


            ////更動完成後再重新查詢資料
            查詢應收帳款(false);


            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('沖帳成功');", true);
            //2011-01-04 拿掉此功能
            //ScriptManager.RegisterClientScriptBlock(this, typeof(FrmInMoney), "print", "window.open('./FrmInMoneyPrint.aspx?smid=" + _txt員編.Text + "&count=" + l_int已收金額 + "&point=" + l_int剩餘點數
            //+"','my_window1','scrollbars=yes,menubar=no,height=600,width=800,resizable=yes,toolbar=no,location=no,status=no');", true);

            clearSession();
        }

        /// <summary>
        /// 清除沖帳紀錄session，避免錯誤
        /// </summary>
        private void clearSession()
        {
            Session.Remove(SealedGlobalPage.SESSIONKEY_INMONEY_WORKID);
        }
    }
}
