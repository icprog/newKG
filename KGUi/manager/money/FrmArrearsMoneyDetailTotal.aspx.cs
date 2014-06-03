using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tw.com.kg.lib;
using System.Data;
using KGUi.tools;

namespace KGUi.manager.money
{
    public partial class FrmArrearsMoneyDetailTotal : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);
            getTotalDatas();
        }

        private void getTotalDatas()
        {
            C欠款紀錄[] l_code = Session["FrmArrearsMoneyDetail"] as C欠款紀錄[];

            List<string> l_list = new List<string>();
            List<string> l_list洗車 = new List<string>();
            int l_intTotal = 0;
            for (int i = 0; i < l_code.Length; i++)
            {
                l_intTotal += Convert.ToInt32(l_code[i].金額); 
                if (!"洗車".Equals(l_code[i].總類))
                {
                    l_list.Add(l_code[i].單號);
                }
                else
                {
                    l_list洗車.Add(l_code[i].單號);
                }
            }
            CKGPartOrderDetail[] l_detail = _context.CFactoryManager.
                CKGPartOrderDetailFactory.get請購明細ByExchangeID(l_list);
            CWork[] l_work = _context.CFactoryManager.CWorkFactory.get工單資訊By單號s(l_list洗車);


            GridView2.DataSource = getDataTableByDisplay(l_detail, l_work);
            GridView2.DataBind();

            _lblTotal.Text = l_intTotal.ToString("N0");
            
            _txtB帳款日期.Text = Session["FrmArrearsMoney_BDATE"].ToString();
            _txtE帳款日期.Text = Session["FrmArrearsMoney_EDATE"].ToString();
            _lblSmid.Text = Session["FrmArrearsMoney_SMID"].ToString();
            _lblName.Text = Session["FrmArrearsMoney_NAME"].ToString();
        }

        private DataTable getDataTableByDisplay(CKGPartOrderDetail[] p_detail, CWork[] p_work)
        {

            string[] l_Msg = new string[] { "日期", "單號", "產品編號/洗車總類", "產品名稱/引擎號碼", "數量", "金額", "開單人員", "顧客姓名" };

            DataTable l_dt = CTools.getFilledColumnsDataTable(l_Msg);
            if (p_detail != null)
            {
                for (int i = 0; i < p_detail.Length; i++)
                {
                    DataRow l_row = l_dt.NewRow();
                    l_row["日期"] = p_detail[i].f_EditDate編輯日期;
                    l_row["單號"] = p_detail[i].f_ExchangeID請購單號;
                    l_row["產品編號/洗車總類"] = p_detail[i].f_ProductID產品編號;
                    l_row["產品名稱/引擎號碼"] = p_detail[i].f_ProductName產品名稱;
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
            }
            if (p_work != null)
            {
                for (int i = 0; i < p_work.Length; i++)
                {
                    DataRow l_row = l_dt.NewRow();
                    l_row["日期"] = p_work[i].f_editdate開單日期;
                    l_row["單號"] = p_work[i].f_workid工單單號;
                    l_row["產品名稱/引擎號碼"] = p_work[i].f_engo引擎號碼;
                    l_row["顧客姓名"] = _context.CFactoryManager.CKGPartOrderFactory.
                            get顧客姓名ByEngo(p_work[i].f_engo引擎號碼).f_customername顧客姓名;

                    l_row["金額"] = p_work[i].f_money金額;
                    l_row["產品編號/洗車總類"] = p_work[i].f_workType洗車種類;
                    l_row["開單人員"] = _context.CFactoryManager.CUserFactory.get高都員工檔(
                        p_work[i].f_edituser開單人員).f_username姓名;
                    l_dt.Rows.Add(l_row);
                }
            }
            return l_dt;
        }
    }
}
