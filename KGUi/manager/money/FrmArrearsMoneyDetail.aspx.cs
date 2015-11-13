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
using System.Collections.Generic;

namespace KGUi.manager.money
{
    public partial class FrmArrearsMoneyDetail : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);
            string l_smid = Request["smid"];
            string l_type = Request["type"];
            string l_strBDate = Request["BDate"];
            string l_strEDate = Request["EDate"];

            if (!this.IsPostBack)
            {
                C欠款紀錄[] l_C欠款紀錄 = _context.CFactoryManager.C欠款紀錄Factory.
                    get欠款紀錄明細(l_smid, l_type, l_strBDate, l_strEDate);
                display(l_C欠款紀錄);
            }
        }

        private void display(C欠款紀錄[] p_欠款紀錄)
        {
            _gvAmt.DataSource = getDataTableByDisplay(p_欠款紀錄);
            _gvAmt.DataBind();

            _lblSmid.Text = Session["FrmArrearsMoney_SMID"].ToString();
            _lblName.Text = Session["FrmArrearsMoney_NAME"].ToString();
        }

        private DataTable getDataTableByDisplay(C欠款紀錄[] p_欠款紀錄)
        {

            string[] l_Msg = new string[] { "項次", "單號", "金額", "帳款日期", "備註", "顧客姓名", "總類", "明細" };
            DataTable l_dt = CTools.getFilledColumnsDataTable(l_Msg);

            int l_int洗車 = 0;
            int l_int小百貨 = 0;
            for (int i = 0; i < p_欠款紀錄.Length; i++)
            {
                DataRow l_row = l_dt.NewRow();
                l_row["項次"] = (i + 1).ToString();
                l_row["單號"] = p_欠款紀錄[i].單號;

                int l_int金額 = Convert.ToInt32(p_欠款紀錄[i].金額); 
                if ("洗車".Equals(p_欠款紀錄[i].總類))
                {
                    l_int洗車 += l_int金額;   
                }
                else
                {
                    l_int小百貨 += l_int金額;
                }
                l_row["金額"] = p_欠款紀錄[i].金額;
                l_row["帳款日期"] = p_欠款紀錄[i].帳款日期;
                l_row["備註"] = p_欠款紀錄[i].備註;
                l_row["顧客姓名"] = p_欠款紀錄[i].顧客姓名;

                l_row["總類"] = p_欠款紀錄[i].總類;
                l_row["明細"] = "./FrmArrearsMoneyDetail.aspx?workid=" + p_欠款紀錄[i].單號;
                l_dt.Rows.Add(l_row);
            }
            _lbl洗車.Text = l_int洗車.ToString();
            _lbl小百貨.Text = l_int小百貨.ToString();

            //新增給彈跳視窗用 20130520 way
            Session.Add("FrmArrearsMoneyDetail", p_欠款紀錄);
            return l_dt;
        }


        protected void _btn明細_Click(object sender, EventArgs e)
        {
            Button l_btn = (Button)sender;
            GridViewRow l_row = (GridViewRow)l_btn.Parent.Parent;
            string l_workid = ((Label)l_row.Cells[1].Controls[1]).Text;

            
            if ("F".Equals(l_workid.Substring(0, 1)))
            {
                CWork l_work = _context.CFactoryManager.CWorkFactory.get工單資訊By單號(l_workid);
                display明細(l_work);
            }
            else
            {
                CKGPartOrderDetail[] l_detail = _context.CFactoryManager.
                 CKGPartOrderDetailFactory.get請購明細ByExchangeID(l_workid);
                display小百貨明細(l_detail);
            }
           
        }

        private void display小百貨明細(CKGPartOrderDetail[] p_detail)
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            GridView2.DataSource = getDataTableByDisplay小百貨明細(p_detail);
            GridView2.DataBind();
        }

        private DataTable getDataTableByDisplay小百貨明細(CKGPartOrderDetail[] p_detail)
        {

            string[] l_Msg = new string[] { "項次", "單號", "產品編號", "產品名稱", "數量", "金額", "開單人員", "顧客姓名" };
            DataTable l_dt = CTools.getFilledColumnsDataTable(l_Msg);

            for (int i = 0; i < p_detail.Length; i++)
            {
                DataRow l_row = l_dt.NewRow();
                l_row["項次"] = "1";
                l_row["單號"] = p_detail[i].f_ExchangeID請購單號;
                l_row["產品編號"] = p_detail[i].f_ProductID產品編號;
                l_row["產品名稱"] = p_detail[i].f_ProductName產品名稱;
                l_row["數量"] = p_detail[i].f_Amount選購數量;
                l_row["金額"] = p_detail[i].f_UnitPrice產品單價;

                CKGPartOrder l_order = _context.CFactoryManager.CKGPartOrderFactory.
                    getKGPartOrderBy請購單號(p_detail[i].f_ExchangeID請購單號);
                try
                {
                    l_row["開單人員"] = _context.CFactoryManager.CUserFactory.get高都員工檔(
                        l_order.f_AssistantSmid助理員編).f_username姓名;
                }
                catch { l_row["開單人員"] = "無此員編(" + l_order.f_AssistantSmid助理員編 + ")"; }
                l_dt.Rows.Add(l_row);

                l_row["顧客姓名"] = p_detail[i].顧客姓名;
                
            }
            return l_dt;
        }
        private void display明細(CWork p_work)
        {
            GridView2.DataSource = null;
            GridView2.DataBind();
            GridView1.DataSource = getDataTableByDisplay明細(p_work);
            GridView1.DataBind();
        }

        private DataTable getDataTableByDisplay明細(CWork p_work)
        {

            string[] l_Msg = new string[] { "項次", "單號", "金額", "引擎號碼", "顧客姓名", "洗車總類", "開單人員" };
            DataTable l_dt = CTools.getFilledColumnsDataTable(l_Msg);

            //fix by fox
            CKGPartOrder lCustomerName = _context.CFactoryManager.CKGPartOrderFactory.
                                            get顧客姓名ByEngo(p_work.f_engo引擎號碼);

            DataRow l_row = l_dt.NewRow();
            l_row["項次"] = "1";
            l_row["單號"] = p_work.f_workid工單單號;
            l_row["引擎號碼"] = p_work.f_engo引擎號碼;
            l_row["顧客姓名"] = (lCustomerName == null) ? "" : lCustomerName.f_customername顧客姓名;

            l_row["金額"] = p_work.f_money金額;
            l_row["洗車總類"] = p_work.f_workType洗車種類;
            l_row["開單人員"] =_context.CFactoryManager.CUserFactory.get高都員工檔(
                p_work.f_edituser開單人員 ).f_username姓名;
            l_dt.Rows.Add(l_row);

            return l_dt;
        }

        protected void _btn明細總覽_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(FrmArrearsMoneyDetail), "OK", "window.open('./FrmArrearsMoneyDetailTotal.aspx','my_window2','scrollbars=yes,menubar=no,height=600,width=800,resizable=yes,toolbar=no,location=no,status=no');", true);
        }
    }
}
