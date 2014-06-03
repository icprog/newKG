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

namespace KGUi.update
{
    public partial class FrmHistory : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);
        }

        private void search()
        {
            string l_strBDate = _txtBDate.Text.Trim();
            string l_strEDate = _txtEDate.Text.Trim();
            string l_strUserId = (Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser).f_userid帳號;
            
            //2011-08-31 增加完工日查詢
            bool l_bool完工日 = false;
            if (_chk完工日.Checked)
            {
                l_bool完工日 = true;
            }
            //先查詢該人員所有業績單號
            CConstruction[] l_CConstruction = _context.CFactoryManager.CConstructionFactory.get業績By施工人員(l_strUserId, l_strBDate, l_strEDate, l_bool完工日);

            if (l_CConstruction.Length <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('無任何實績資料!請重新確認');", true);
                return;
            }
            CWork l_work = _context.CFactoryManager.CWorkFactory.createCWork();
            l_work.tb施工人員業績 = l_CConstruction;

            //查詢所有單號資料
            CWork[] l_works = _context.CFactoryManager.CWorkFactory.get工單資訊By施工人員檔(l_work);
            display(l_works);
        }

        private void display(CWork[] p_CWork)
        {
            string[] l_Msg = new string[] { "項次", "工單號碼", "引擎號碼", "顧客名稱", "洗車種類", "金額", "開單日期", "完工日", "施工人員" };
            DataTable l_dt = CTools.getFilledColumnsDataTable(l_Msg);


            for (int i = 0; i < p_CWork.Length; i++)
            {
                DataRow l_row = l_dt.NewRow();
                l_row["項次"] = (i + 1).ToString();
                l_row["工單號碼"] = p_CWork[i].f_workid工單單號;
                l_row["引擎號碼"] = p_CWork[i].f_engo引擎號碼;
                l_row["顧客名稱"] = p_CWork[i].f_customerid顧客名稱;
                l_row["洗車種類"] = p_CWork[i].f_workType洗車種類;
                l_row["金額"] = p_CWork[i].f_money金額;
                l_row["開單日期"] = p_CWork[i].f_editdate開單日期;
                l_row["完工日"] = p_CWork[i].f_closeDate完工日;

                l_row["施工人員"] = "../manager/FrmSelectWorkDetail.aspx?workid=" + p_CWork[i].f_workid工單單號;
                l_dt.Rows.Add(l_row);
            }
            _gvWork.DataSource = l_dt;
            _gvWork.DataBind();
        }

        protected void _btn查詢_Click(object sender, EventArgs e)
        {
            search();
        }

        protected void _btn取消_Click(object sender, EventArgs e)
        {
            Response.Redirect("./FrmUpdateIndex.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
            Response.Redirect("../FrmLogin.aspx");
        }
    }
}
