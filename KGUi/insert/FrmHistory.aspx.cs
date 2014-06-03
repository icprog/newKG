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

namespace KGUi.insert
{
    public partial class FrmHistory : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);

            if (!Page.IsPostBack)
            {
            }
        }

        protected void _btn查詢_Click(object sender, EventArgs e)
        {
            search();
        }

        private void search()
        {
            string l_strBDate = _txtBDate.Text.Trim();
            string l_strEDate = _txtEDate.Text.Trim();
            string l_str工單號碼 = _txt工單號碼.Text.Trim();
            string l_strUserId = (Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser).f_userid帳號;
            bool l_bool完工日 = false;
            //if (_chk完工日.Checked)
            //{
            //    l_bool完工日 = true;
            //}
            string l_str引擎號碼 = _txt引擎號碼.Text.Trim();
            CWork[] l_work = _context.CFactoryManager.CWorkFactory.get工單資訊By單號BySearch(l_strBDate, l_strEDate, l_str工單號碼, l_strUserId, l_bool完工日, l_str引擎號碼);
            display(l_work);
        }

        private void display(CWork[] p_CWork)
        {
            string[] l_Msg = new string[] { "項次", "狀態", "工單號碼", "引擎號碼", "顧客名稱", "洗車種類", "金額", "開單日期", "完工日", "是否完工", "介紹人" };
            DataTable l_dt = CTools.getFilledColumnsDataTable(l_Msg);

            if (p_CWork.Length <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('無符合資料!請重新確認');", true);

                _gvWork.DataSource = l_dt;
                _gvWork.DataBind();
                return;
            }

            for (int i = 0; i < p_CWork.Length; i++)
            {
                DataRow l_row = l_dt.NewRow();
                l_row["項次"] = (i + 1).ToString();
                l_row["狀態"] = p_CWork[i].f_staus狀態;
                l_row["工單號碼"] = p_CWork[i].f_workid工單單號;
                l_row["引擎號碼"] = p_CWork[i].f_engo引擎號碼;
                l_row["顧客名稱"] = p_CWork[i].f_customerid顧客名稱;
                l_row["洗車種類"] = p_CWork[i].f_workType洗車種類;
                l_row["金額"] = p_CWork[i].f_money金額;
                l_row["開單日期"] = p_CWork[i].f_editdate開單日期;
                l_row["完工日"] = p_CWork[i].f_closeDate完工日;

                if ("待處理".Equals(p_CWork[i].f_staus狀態))
                {
                    l_row["是否完工"] = true;
                }
                else
                {
                    l_row["是否完工"] = false;
                }
                CUser l_user = _context.CFactoryManager.CUserFactory.get高都員工檔(p_CWork[i].f_introducer介紹人);
                if (l_user != null)
                {
                    l_row["介紹人"] = p_CWork[i].f_introducer介紹人 + "( " + l_user.f_username姓名 + " )";
                }
                else
                {
                    l_row["介紹人"] = "";
                }
                l_dt.Rows.Add(l_row);
            }
            _gvWork.DataSource = l_dt;
            _gvWork.DataBind();
        }

        protected void _btn刪除_Click(object sender, EventArgs e)
        { 
            Button l_btn = (Button)sender;
            GridViewRow l_row = (GridViewRow)l_btn.Parent.Parent;
            string l_id = ((Label)l_row.Cells[2].Controls[1]).Text;
            _context.CFactoryManager.CWorkFactory.deleteBy單號(l_id);
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('刪除成功');", true);
            search();
          
        }

        protected void _btn離開_Click(object sender, EventArgs e)
        {
            Response.Redirect("./FrmIndex.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
            Response.Redirect("../FrmLogin.aspx");
        }

        protected void _btn查詢_Click(object sender, ImageClickEventArgs e)
        {
            search();
        }
    }
}
