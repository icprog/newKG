using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tw.com.kg.lib;
using KGUi.tools;
using System.Data;

namespace KGUi.manager
{
    public partial class FrmInsuranceComReport : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);
            if (!this.IsPostBack)
            {
                CTools.get保險公司介紹(_rdo保險公司, _context);
            }
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;

            if (l_user == null)
            {
                Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
                Response.Redirect("../FrmLogin.aspx");
            }

        }

        protected void _btn查詢_Click(object sender, EventArgs e)
        {
            string l_BDate = _txtBDate.Text.Trim();
            string l_EDate = _txtEDate.Text.Trim();
            string l_str保險公司 = _rdo保險公司.SelectedValue;
            C保險實績統計[] l_C保險實績統計 = _context.CFactoryManager.C保險實績統計Factory.get保險公司介紹實績(l_BDate, l_EDate, l_str保險公司);
            display(l_C保險實績統計);
        }

        private void display(C保險實績統計[] p_保險實績統計)
        {
            string[] l_Msg = new string[] { "保險公司", "施工項目", "台數", "實績" };
            DataTable l_dt = CTools.getFilledColumnsDataTable(l_Msg);

            //if (p_薪資計算.Length <= 0)
            //{
            //    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('無符合資料!請重新確認');", true);

            //    _gvAmt.DataSource = l_dt;
            //    _gvAmt.DataBind();
            //    return;
            //}
            double l_dousum = 0;
            for (int i = 0; i < p_保險實績統計.Length; i++)
            {
                DataRow l_row = l_dt.NewRow();

                l_row["保險公司"] = p_保險實績統計[i].代碼名稱;
                //所別一樣只秀一次,第一次不判斷
                if (i > 0)
                {
                    if (p_保險實績統計[i - 1].代碼名稱.Equals(p_保險實績統計[i].代碼名稱))
                    {
                        l_row["保險公司"] = "";
                    }
                    else
                    {
                        DataRow l_rowsum = l_dt.NewRow();
                        l_rowsum["台數"] = "合計:";
                        l_rowsum["實績"] = l_dousum.ToString();
                        l_dt.Rows.Add(l_rowsum);
                        l_dousum = 0;
                    }
                }

                l_row["施工項目"] = p_保險實績統計[i].施工項目;
                l_row["台數"] = p_保險實績統計[i].台數;
                l_row["實績"] = p_保險實績統計[i].實績;
                l_dousum += Convert.ToDouble(l_row["實績"]);
                l_dt.Rows.Add(l_row);
            }
            DataRow l_rowsumover = l_dt.NewRow();
            l_rowsumover["台數"] = "合計:";
            l_rowsumover["實績"] = l_dousum.ToString();
            l_dt.Rows.Add(l_rowsumover);
            _gvAmt.DataSource = l_dt;
            _gvAmt.DataBind();
        }
    }
}
