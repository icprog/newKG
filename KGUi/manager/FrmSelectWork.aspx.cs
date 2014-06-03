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
    public partial class FrmSelectWork : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);

            if (!this.IsPostBack)
            {
                CTools.get所別(_ddl所別, _context);
                _txtBDate.Text = DateTime.Today.ToString("yyyy/MM/dd");
                _txtEDate.Text = _txtBDate.Text;
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

            string l_strBDate = _txtBDate.Text.Trim();
            string l_strEDate = _txtEDate.Text.Trim();
            string l_str工單號碼 = _txt工單號碼.Text.Trim();
            string l_str所別 = _ddl所別.SelectedValue;
            string l_str是否完工 = _rdo是否完工.SelectedValue;
            string l_str工單類型 = _ddl工單類型.SelectedValue;
            string l_str是否招攬 = _rdo是否招攬.SelectedValue;
            bool l_bool服務廠 = _chk服務廠.Checked;
            bool l_bool和榮 = _chkD00.Checked;
            string l_str車牌或引擎 = _txt車牌或引擎.Text;

            CWork[] l_work = _context.CFactoryManager.CWorkFactory.
                get工單資訊By管理者(l_strBDate, l_strEDate, l_str工單號碼, l_str所別, l_str是否完工, l_str工單類型, l_str是否招攬, l_bool服務廠, l_str車牌或引擎, l_bool和榮);

            display(l_work);
        }

        private void display(CWork[] p_CWork)
        {
            if (p_CWork.Length <=0 )
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('無符合資料!請重新確認');", true);
                _gvWork.DataSource = null;
                _gvWork.DataBind();
                return;

            }
            _gvWork.DataSource = getDataTableBydisplay(p_CWork);
            _gvWork.DataBind();
        }
        private DataTable getDataTableBydisplay(CWork[] p_CWork)
        {
            string[] l_Msg = new string[] { "項次", "所別", "工單號碼", "引擎號碼", "顧客名稱", 
                "洗車種類", "金額", "開單日期", "完工日", "工單類型","招攬人員", "施工人員","開單人員" };
            DataTable l_dt = CTools.getFilledColumnsDataTable(l_Msg);


            for (int i = 0; i < p_CWork.Length; i++)
            {
                DataRow l_row = l_dt.NewRow();
                l_row["項次"] = (i + 1).ToString();
                l_row["所別"] =CTools.get轉換據點中英文( p_CWork[i].f_branchid工單所別 );
                l_row["工單號碼"] = p_CWork[i].f_workid工單單號;
                l_row["引擎號碼"] = p_CWork[i].f_engo引擎號碼;

                CUser l_user顧客名稱 = _context.CFactoryManager.CUserFactory.get高都員工檔(p_CWork[i].f_customerid顧客名稱);
                if (l_user顧客名稱 == null)
                {
                    l_row["顧客名稱"] = p_CWork[i].f_customerid顧客名稱;
                }
                else
                {
                    l_row["顧客名稱"] = p_CWork[i].f_customerid顧客名稱 + "(" + l_user顧客名稱.f_username姓名 + ")";
                }
                l_row["洗車種類"] = p_CWork[i].f_workType洗車種類;
                l_row["金額"] = p_CWork[i].f_money金額;
                l_row["開單日期"] = p_CWork[i].f_editdate開單日期;
                l_row["完工日"] = p_CWork[i].f_closeDate完工日;
                l_row["工單類型"] = p_CWork[i].f_type工單種類;

                CUser l_user招攬人員 = _context.CFactoryManager.CUserFactory.get高都員工檔(p_CWork[i].f_introducer介紹人);
                if (l_user招攬人員 == null)
                {
                    l_row["招攬人員"] = p_CWork[i].f_introducer介紹人;
                }
                else
                {
                    l_row["招攬人員"] = p_CWork[i].f_introducer介紹人 + "(" + l_user招攬人員.f_username姓名 + ")";
                }
                l_row["施工人員"] = "./FrmSelectWorkDetail.aspx?workid=" + p_CWork[i].f_workid工單單號;
                l_row["開單人員"] = p_CWork[i].f_edituser開單人員;

                l_dt.Rows.Add(l_row);
            }
            Session.Add("FrmSelectWork", l_dt);
            return l_dt;
        }

        protected void _btn查詢_Click(object sender, EventArgs e)
        {
            search();
        }


        protected void _btn刪除_Click(object sender, EventArgs e)
        {
            Button l_btn = (Button)sender;
            GridViewRow l_row = (GridViewRow)l_btn.Parent.Parent;
            string l_id = ((Label)l_row.Cells[2].Controls[1]).Text;
            _context.CFactoryManager.CWorkFactory.deleteBy單號(l_id);
            search();
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('刪除成功');", true);

        }
        protected void _btn施工人員_Click(object sender, EventArgs e)
        {
            
        }

        protected void _btn匯出_Click(object sender, EventArgs e)
        {
            DataTable l_table = Session["FrmSelectWork"] as DataTable;
            if (l_table == null)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('無匯出資料!請先執行查詢');", true);
                return;

            }
            string l_strPath = "../report/" + DateTime.Today.ToString("yyyyMMdd") + "FrmSelectWork.xls";
            CTools.toExcelByDataView(new DataView(l_table), Server.MapPath(l_strPath), DateTime.Today.ToString("yyyyMMdd") + "工單明細");
            Response.Redirect(l_strPath);
        }
    }
}
