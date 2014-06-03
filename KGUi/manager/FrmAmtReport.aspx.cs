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
    public partial class FrmAmtReport : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;

            if (l_user == null)
            {
                Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
                Response.Redirect("../FrmLogin.aspx");
            }
        }

        protected void _btn查詢_Click(object sender, EventArgs e)
        {
            string l_strBDate = _txtBDate.Text.Trim();
            string l_strEDate = _txtEDate.Text.Trim();
            string l_strSmid = _txt員編.Text.Trim();

            C薪資計算[] l_薪資計算 = _context.CFactoryManager.C薪資計算Factory.get薪資(l_strBDate, l_strEDate, l_strSmid);

            display(l_薪資計算);
        }



        private void display(C薪資計算[] p_薪資計算)
        {
            string[] l_Msg = new string[] { "項次", "員編", "姓名", "業績", "薪資", "明細" };
            DataTable l_dt = CTools.getFilledColumnsDataTable(l_Msg);

            //if (p_薪資計算.Length <= 0)
            //{
            //    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('無符合資料!請重新確認');", true);

            //    _gvAmt.DataSource = l_dt;
            //    _gvAmt.DataBind();
            //    return;
            //}

            for (int i = 0; i < p_薪資計算.Length; i++)
            {
                DataRow l_row = l_dt.NewRow();
                l_row["項次"] = (i + 1).ToString();
                l_row["員編"] = p_薪資計算[i].編號;

                if (p_薪資計算[i].姓名.Equals("林崧源"))
                {
                    l_row["姓名"] = p_薪資計算[i].姓名 + "(外包)";
                    l_row["薪資"] = p_薪資計算[i].外部薪資;
                }
                else
                {
                    l_row["姓名"] = p_薪資計算[i].姓名;
                    l_row["薪資"] = p_薪資計算[i].薪資;
                }
                l_row["業績"] = _context.CFactoryManager.CWorkFactory.get工單資訊By業績(p_薪資計算[i].編號, _txtBDate.Text, _txtEDate.Text);

                l_row["明細"] = "./FrmAmtReportDetail.aspx?smid=" + p_薪資計算[i].編號+"&BDate="+_txtBDate.Text+"&EDate="+_txtEDate.Text ;

                l_dt.Rows.Add(l_row);
            }
            _gvAmt.DataSource = l_dt;
            _gvAmt.DataBind();
        }

        protected void _btn明細_Click(object sender, EventArgs e)
        {
            Button l_btn = (Button)sender;
            GridViewRow l_row = (GridViewRow)l_btn.Parent.Parent;
            string l_id = ((Label)l_row.Cells[1].Controls[1]).Text;
        }
    }
}
