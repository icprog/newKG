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
    public partial class FrmSearchCarSale : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);

            if (!this.IsPostBack)
            {
                setYear();
                setMonth();
            }
        }

        private void setYear()
        {
            _cbo年.Items.Add(new ListItem(DateTime.Today.Year + "", DateTime.Today.Year + ""));
            _cbo年.Items.Add(new ListItem(DateTime.Today.Year - 1 + "", DateTime.Today.Year - 1 + ""));
        }
        private void setMonth()
        {
            for (int i = 1; i <= 12; i++)
            {
                _cbo月.Items.Add(new ListItem(i.ToString("00"), i.ToString("00")));
            }

            _cbo月.SelectedValue = DateTime.Today.Month.ToString("00");
        }

        protected void _btn查詢_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void Search()
        {
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA_CARSALE] as CUser;

            if (l_user == null)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK",
                    "alert('請重新登入');", true);
                Response.Redirect("./FrmLogin.aspx");
            }
            string l_strMonth = _cbo月.SelectedValue;
            string l_strYear = _cbo年.SelectedValue;
            string l_strBranch = _cbo所別.SelectedValue;
            string l_strChief = _cbo報備對象.SelectedValue;
            特販審核[] l_code = _context.CFactoryManager.特販審核Factory.
                getAll特販審核(l_strYear, l_strMonth, l_user, _cbo狀態.SelectedValue, l_strBranch, l_strChief);
            display特販審核(l_code);

            Panel1.Visible = false;
        }

        private void display特販審核(特販審核[] p_code)
        {
            string[] l_Msg = new string[] { "項次", "身分證字號", "客戶姓名", "狀態", "審核" };
            //string[] l_Msg = new string[] { "項次", "身分證字號", "客戶姓名", "審核" };
            DataTable l_dt = CTools.getFilledColumnsDataTable(l_Msg);

            if (p_code.Length <= 0)
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

                if ("0".Equals(p_code[i].Status))
                {
                    l_row["狀態"] = "未審核";
                }
                else if ("1".Equals(p_code[i].Status))
                {
                    l_row["狀態"] = "所長未核准";
                }
                else if ("2".Equals(p_code[i].Status))
                {
                    l_row["狀態"] = "所長核准";
                }
                else if ("3".Equals(p_code[i].Status))
                {
                    l_row["狀態"] = "車輛部未核准";
                }
                else if ("4".Equals(p_code[i].Status))
                {
                    l_row["狀態"] = "車輛部核准";
                }
                else
                {
                    l_row["狀態"] = "";
                }
                l_row["審核"] = p_code[i].custid;
                l_dt.Rows.Add(l_row);
            }

            _gvOrder.DataSource = l_dt;
            _gvOrder.DataBind();
        }

        protected void _btn審核_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Button l_btn = (Button)sender;
            GridViewRow l_row = (GridViewRow)l_btn.Parent.Parent;
            string l_custid = ((Label)l_row.Cells[4].Controls[1]).Text;

            Session.Add("custidBySearch", l_custid);
            特販審核 l_code = _context.CFactoryManager.特販審核Factory.
                get特販審核Bycustid(l_custid);
            //CWork l_work = _context.CFactoryManager.CWorkFactory.get工單資訊By單號(l_workid);
            display明細(l_code);
            加入顯示棒(l_row.RowIndex);
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
            try
            {
                _chklist批示.SelectedValue = p_code.Status;
            }
            catch { }
            if ("3".Equals(p_code.Status) || "4".Equals(p_code.Status))
            {
                _btn取消.Visible = true;
               
            }
            else
            {
                _btn取消.Visible = false;
            }
            Session.Add("StatusBySearch", p_code.Status);
            _txtDate.Text =p_code.RecordDate;
            _txt支援金額.Text = p_code.SupportAmt.ToString();
            try
            {
                _chklist非一般申請種類.SelectedValue = p_code.saletype;
                _chklist特別獎勵.SelectedValue = p_code.otherprize;
            }
            catch { }
            _txt車輛部說明.Text = p_code.CarCenterMemo;

            _lbl申請日.Text = p_code.OrderDate;
            _lbl對象.Text = p_code.sendman;

        }
        protected void _btn取消_Click(object sender, EventArgs e)
        {
            string l_strSearch = Session["StatusBySearch"].ToString();
            string l_strId = Session["custidBySearch"].ToString();
            //if (!"3".Equals(l_strSearch) || !"4".Equals(l_strSearch))
            //{
            //    _btn取消.Visible = false;
            //}
            //else
            //{
            //    _btn取消.Visible = true;
            //}
            try
            {
                _context.CFactoryManager.特販審核Factory.取消特販審核Bycustid(l_strId);
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK",
                       "alert('取消成功!!請重新審核!!');", true);
                Panel1.Visible = false;
                Search();
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK",
                    "alert('取消失敗!!請檢查網路是否正常!!');", true);
            }
        }

    }
}
