using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using tw.com.kg.lib;
using KGUi.tools;

namespace KGUi.manager
{
    public partial class FrmSetWorkType : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);

            if (!this.IsPostBack)
            {
                search();
            }
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;

            if (l_user == null)
            {
                Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
                Response.Redirect("../FrmLogin.aspx");
            }
        }

        private void search()
        {

            CWorkType[] l_WorkType = _context.CFactoryManager.CWorkTypeFactory.getAllWorkType();

            if (l_WorkType.Length <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('尚未設定洗車種類');", true);
                return;
            }
            display(l_WorkType);
        }

        private void display(CWorkType[] p_WorkType)
        {
            string[] l_Msg = new string[] { "項次", "代號", "名稱", "價錢", "員工價", "內部薪資", "外部薪資", "服務獎金", "業代獎金" };
            DataTable l_dt = CTools.getFilledColumnsDataTable(l_Msg);


            for (int i = 0; i < p_WorkType.Length; i++)
            {
                DataRow l_row = l_dt.NewRow();
                l_row["項次"] = (i + 1).ToString();
                l_row["代號"] = p_WorkType[i].f_typeid洗車種類代碼;
                l_row["名稱"] = p_WorkType[i].f_typename洗車種類名稱;
                l_row["價錢"] = p_WorkType[i].f_money價錢;
                l_row["員工價"] = p_WorkType[i].f_moneyBySmid員工價;
                l_row["內部薪資"] = p_WorkType[i].f_moneyByIn內部員工薪資;
                l_row["外部薪資"] = p_WorkType[i].f_moneyByOut外部員工薪資;
                l_row["服務獎金"] = p_WorkType[i].f_boundByService服務獎金數;
                l_row["業代獎金"] = p_WorkType[i].f_boundBySmid業代獎金數;

                l_dt.Rows.Add(l_row);
            }
            GridView1.DataSource = l_dt;
            GridView1.DataBind();
        }

        private void clearUI()
        {
            _txt代碼.Text = "";
            _txt名稱.Text = "";
            _txt價錢.Text = "";
            _txt員工價.Text = "";
            _txt內部薪資.Text = "";
            _txt外部薪資.Text = "";
            _txt服務獎金.Text = "";
            _txt業代獎金.Text = "";
        }
        protected void _btn設定_Click(object sender, EventArgs e)
        {
            if (使用者輸入條件())
            {
                CWorkType l_WorkType = _context.CFactoryManager.CWorkTypeFactory.createCWorkType();
                l_WorkType.f_typeid洗車種類代碼 = _txt代碼.Text.Trim();
                l_WorkType.f_typename洗車種類名稱 = _txt名稱.Text.Trim();
                l_WorkType.f_money價錢 = Convert.ToInt32(_txt價錢.Text.Trim());
                l_WorkType.f_moneyBySmid員工價 = Convert.ToInt32(_txt員工價.Text.Trim());
                l_WorkType.f_moneyByIn內部員工薪資 = Convert.ToInt32(_txt內部薪資.Text.Trim());
                l_WorkType.f_moneyByOut外部員工薪資 = Convert.ToInt32(_txt外部薪資.Text.Trim());
                l_WorkType.f_boundByService服務獎金數 = Convert.ToDouble(_txt服務獎金.Text.Trim());
                l_WorkType.f_boundBySmid業代獎金數 = Convert.ToDouble(_txt業代獎金.Text.Trim());

                _context.CFactoryManager.CWorkTypeFactory.insert(l_WorkType);
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('設定成功');", true);

                clearUI();
                search();
            }
        }

        private bool 使用者輸入條件()
        {
            if ("".Equals(_txt代碼.Text.Trim()))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('代碼不得空白');", true);
                return false;
            }
            if ("".Equals(_txt名稱.Text.Trim()))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('名稱不得空白');", true);
                return false;
            }
            try
            {
                Convert.ToInt32(_txt價錢.Text.Trim());
                Convert.ToInt32(_txt員工價.Text.Trim());
                Convert.ToInt32(_txt內部薪資.Text.Trim());
                Convert.ToInt32(_txt外部薪資.Text.Trim());
                Convert.ToDouble(_txt服務獎金.Text.Trim());
                Convert.ToDouble(_txt業代獎金.Text.Trim());
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "ERROR", "alert('價錢,薪資,獎金需為數字');", true);
                return false;
            }
            return true;
        }
        protected void _btn刪除_Click(object sender, EventArgs e)
        {
            Button l_btn = (Button)sender;
            GridViewRow l_row = (GridViewRow)l_btn.Parent.Parent;
            string l_id = ((Label)l_row.Cells[1].Controls[1]).Text;
            _context.CFactoryManager.CWorkTypeFactory.deleteByID(l_id);
            search();
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('刪除成功');", true);
        }
    }
}
