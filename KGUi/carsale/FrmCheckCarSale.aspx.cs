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
using System.Drawing;

namespace KGUi.carsale
{
    public partial class FrmCheckCarSale : System.Web.UI.Page
    {
        private CUIContext _context;
 
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);
            if (!this.IsPostBack)
            {
                Search();
            }

        }

        private void Search()
        {
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA_CARSALE] as CUser;

            if (l_user==null)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK",
                    "alert('請重新登入');", true);
                Response.Redirect("./FrmLogin.aspx");
            }
            string l_strMonth = DateTime.Now.Month.ToString("00");
            特販審核[] l_code = _context.CFactoryManager.特販審核Factory.getAll特販審核(l_strMonth, l_user);
            display特販審核(l_code);
            Panel1.Visible = false;
        }
        private void display特販審核(特販審核[] p_code)
        {
            //string[] l_Msg = new string[] { "項次", "身分證字號", "客戶姓名", "狀態", "審核" };
            string[] l_Msg = new string[] { "項次", "身分證字號", "客戶姓名", "審核" };
            DataTable l_dt = CTools.getFilledColumnsDataTable(l_Msg);

            if (p_code.Length<=0)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK",
                    "alert('尚無需審核資料');", true);
                return;
            }
            for (int i = 0; i < p_code.Length; i++)
            {
                DataRow l_row = l_dt.NewRow();
                l_row["項次"] = (i + 1).ToString();
                l_row["身分證字號"] = p_code[i].CustomerId;
                l_row["客戶姓名"] = p_code[i].Name;

                //if ("0".Equals(p_code[i].Status))
                //{
                //    l_row["狀態"] = "未審核";
                //}
                //else if ("1".Equals(p_code[i].Status))
                //{
                //    l_row["狀態"] = "所長未核准";
                //}
                //else if ("2".Equals(p_code[i].Status))
                //{
                //    l_row["狀態"] = "所長核准";
                //}
                //else if ("3".Equals(p_code[i].Status))
                //{
                //    l_row["狀態"] = "車輛部未核准";
                //}
                //else if ("4".Equals(p_code[i].Status))
                //{
                //    l_row["狀態"] = "車輛部核准";
                //}
                //else
                //{
                //    l_row["狀態"] = "";
                //}
                l_row["審核"] = p_code[i].custid;
                l_dt.Rows.Add(l_row);
            }

            _gvOrder.DataSource = l_dt;
            _gvOrder.DataBind();

        }


        protected void _btn審核_Click(object sender, EventArgs e)
        {
            clearUI();
            Panel1.Visible = true;
            Button l_btn = (Button)sender;
            GridViewRow l_row = (GridViewRow)l_btn.Parent.Parent;
            string l_custid = ((Label)l_row.Cells[3].Controls[1]).Text;

            Session.Add("custid", l_custid);
            特販審核 l_code =  _context.CFactoryManager.特販審核Factory.
                get特販審核Bycustid(l_custid);
            //CWork l_work = _context.CFactoryManager.CWorkFactory.get工單資訊By單號(l_workid);
            display明細(l_code);
            加入顯示棒(l_row.RowIndex);
            Session.Add("_btn審核_Click", l_row.RowIndex);
        }

        private void 加入顯示棒(int p_intindex)
        {
            for (int i = 0; i < _gvOrder.Rows.Count; i++)
            {
                if (p_intindex == _gvOrder.Rows[i].RowIndex)
                {
                    _gvOrder.Rows[i].BackColor = Color.Aqua;
                    break;
                }
            }
        }
        private void display明細(特販審核 p_code)
        {
            _txt業代說明.Text = p_code.SalesMemo;
            //_txt課長說明.Text = p_code.ChiefMemo;
            _txt所長說明.Text = p_code.ManagerMemo;
            _txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            _lbl對象.Text = p_code.ChiefMemo;
            _lbl申請日.Text = p_code.OrderDate;

             CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA_CARSALE] as CUser;

            if (l_user==null)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK",
                    "alert('請重新登入');", true);
                Response.Redirect("./FrmLogin.aspx");
            }
            if (l_user.f_lvl等級 == 3)
            {
                _lbl部長.Visible = true;
                _chklist是否到部長.Visible = false;
            }
            else
            {
                _lbl部長.Visible = false;
                _chklist是否到部長.Visible = true;
            }
        }

        private string _strCustid { get; set; }
        protected void _btn儲存_Click(object sender, EventArgs e)
        {
            try
            {
                if (使用者輸入())
                {
                    特販審核 l_code = _context.CFactoryManager.特販審核Factory.create特販審核();

                    l_code.custid = Convert.ToInt32(Session["custid"].ToString());
                    l_code.CarCenterMemo = _txt車輛部說明.Text.Trim();
                    l_code.RecordDate = _txtDate.Text.Trim();
                    l_code.SupportAmt = Convert.ToDouble(_txt支援金額.Text.Trim());
                    l_code.saletype = _chklist非一般申請種類.SelectedValue;
                    l_code.Status = _chklist批示.SelectedValue;
                    l_code.otherprize = _chklist特別獎勵.SelectedValue;
                    l_code.f_issend = _chklist是否到部長.SelectedValue;

                    CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA_CARSALE] as CUser;

                    if (l_user == null)
                    {
                        ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK",
                            "alert('請重新登入');", true);
                        Response.Redirect("./FrmLogin.aspx");
                    }

                    if ("Y".Equals(l_code.f_issend) && l_user.f_lvl等級 != 3)
                    {
                        _context.CFactoryManager.特販審核Factory.insertInto特販(l_code.custid, l_user.f_username姓名);
                        l_code.Status = "3";
                        _context.CFactoryManager.特販審核Factory.update部長審核Bycustid(l_code);
                    }
                    else
                    {
                        if (l_user.f_lvl等級 == 3)
                        {
                            l_code.ChiefMemo = "部長";
                        }
                        else
                        {
                            l_code.ChiefMemo = _lbl對象.Text;
                        }
                        _context.CFactoryManager.特販審核Factory.update特販審核Bycustid(l_code);
                    }
                   
                    clearUI();

                    Panel1.Visible = false;
                    Search();

                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK",
                        "alert('審核完成');", true);
                }
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "ERROR",
                    "alert('審核失敗!請檢查網路是否正常!或洽資訊室');", true);
                return;
            }

        }
        private void clearUI()
        {
            _txt車輛部說明.Text = "";
            _txtDate.Text = "";
            _txt支援金額.Text = "";
            _chklist非一般申請種類.SelectedValue = null;
            _chklist批示.SelectedValue = null;
            _chklist特別獎勵.SelectedValue = null;

        }
        private bool 使用者輸入()
        {
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA_CARSALE] as CUser;

            if (l_user == null)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK",
                    "alert('請重新登入');", true);
                Response.Redirect("./FrmLogin.aspx");
            }

            if ("N".Equals(_chklist是否到部長.SelectedValue))
            {
                if ("".Equals(_chklist批示.SelectedValue))
                {

                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error",
                        "alert('請選擇批示');", true);
                    return false;
                }
                if ("".Equals(_chklist非一般申請種類.SelectedValue))
                {

                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error",
                        "alert('請選擇申請種類');", true);
                    return false;
                }
                if ("".Equals(_chklist特別獎勵.SelectedValue))
                {

                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error",
                        "alert('請選擇特別獎勵');", true);
                    return false;
                }
                if ("".Equals(_txt車輛部說明.Text.Trim()))
                {

                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error",
                        "alert('車輛部說明不得空白');", true);
                    return false;
                }
                if ("".Equals(_txtDate.Text.Trim()))
                {

                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error",
                        "alert('批示日期不得空白');", true);
                    return false;
                }
            }
            if (l_user.f_lvl等級 != 3)
            {
                if ("".Equals(_chklist是否到部長.SelectedValue))
                {

                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error",
                        "alert('請選擇是否到部長');", true);
                    return false;
                }
            }
            try
            {
                Convert.ToDouble(_txt支援金額.Text.Trim());
                
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error",
                "alert('支援金額必須為數字,例:1500');", true); return false;
            }
            return true;
        }

        protected void _btn1500_Click(object sender, EventArgs e)
        {
            Button l_btn = sender as Button;

            _txt支援金額.Text = l_btn.ID.Replace("_btn", "");

           int l_int =  Convert.ToInt32( Session["_btn審核_Click"] );
           加入顯示棒(l_int);
        }

        protected void _btn詳細資料_Click(object sender, EventArgs e)
        {
            string l_strId = Session["custid"].ToString();

            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "window.open('./FrmCheckCarSaleDetail.aspx?id=" + l_strId + "','my_window1','scrollbars=yes,menubar=no,height=400,width=400,resizable=yes,toolbar=no,location=no,status=no');", true);
           
        }

        protected void _btn查詢_Click(object sender, EventArgs e)
        {
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA_CARSALE] as CUser;

            if (l_user == null)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK",
                    "alert('請重新登入');", true);
                Response.Redirect("./FrmLogin.aspx");
            }
            string l_strMonth = DateTime.Now.Month.ToString("00");
            string l_strBranchid = _cbo所別.SelectedValue;
            特販審核[] l_code = _context.CFactoryManager.特販審核Factory.getAll特販審核s(l_strMonth, l_user, l_strBranchid);
            display特販審核(l_code);
            Panel1.Visible = false;
        }
    }
}
