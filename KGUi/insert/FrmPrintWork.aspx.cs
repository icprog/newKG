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

namespace KGUi.insert
{
    public partial class FrmPrintWork : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);

            string l_strworkid = Request["id"];

            CWork l_work = Session[l_strworkid] as CWork;

            display工單(l_work);
        }

        private void display工單(CWork p_work)
        {
            _lbl工單種類.Text = p_work.f_type工單種類;
            _lbl工單種類1.Text = p_work.f_type工單種類;

            _lbl工單單號.Text = p_work.f_workid工單單號;
            _lbl工單單號1.Text = p_work.f_workid工單單號;
            _lbl引擎號碼.Text = p_work.f_engo引擎號碼;
            _lbl引擎號碼1.Text = p_work.f_engo引擎號碼;

            CUser l_user顧客名稱 = _context.CFactoryManager.CUserFactory.get高都員工檔(p_work.f_customerid顧客名稱);

            if (l_user顧客名稱 == null)
            {
                _lbl顧客名稱.Text = p_work.f_customerid顧客名稱;
                _lbl顧客名稱1.Text = p_work.f_customerid顧客名稱;
            }
            else
            {
                _lbl顧客名稱.Text = p_work.f_customerid顧客名稱 + "(" + l_user顧客名稱.f_username姓名 + ")";
                _lbl顧客名稱1.Text = p_work.f_customerid顧客名稱 + "(" + l_user顧客名稱.f_username姓名 + ")"; ;
            }
           
            
            _lbl洗車種類.Text = p_work.f_workType洗車種類 +"("+
                _context.CFactoryManager.CWorkTypeFactory.
                getCWorkTypeBy代碼(p_work.f_workType洗車種類).f_typename洗車種類名稱+")";
            _lbl洗車種類1.Text = _lbl洗車種類.Text;
            _lbl金額.Text = p_work.f_money金額.ToString();
            _lbl金額1.Text = p_work.f_money金額.ToString();
            _lbl備註.Text = p_work.f_memo備註;
            _lbl備註1.Text = p_work.f_memo備註;

            if ("F1000".Equals(p_work.f_edituser開單人員))
            {
                p_work.f_edituser開單人員 = "F1001";
            }
            CUser l_user = _context.CFactoryManager.CUserFactory.get高都員工檔(p_work.f_edituser開單人員);
            if (!"".Equals(p_work.f_seruser服務專員))
            {
                _lbl開單人員.Text = p_work.f_edituser開單人員 + "(" + l_user.f_username姓名 + ")" + " 專員:" + p_work.f_seruser服務專員;
                _lbl開單人員1.Text = p_work.f_edituser開單人員 + "(" + l_user.f_username姓名 + ")" + " 專員:" + p_work.f_seruser服務專員;
            }
            else
            {
                _lbl開單人員.Text = p_work.f_edituser開單人員 + "(" + l_user.f_username姓名 + ")";
                _lbl開單人員1.Text = p_work.f_edituser開單人員 + "(" + l_user.f_username姓名 + ")"; 
            }
                _lbl開單日期.Text = p_work.f_editdate開單日期;
            _lbl開單日期1.Text = p_work.f_editdate開單日期;
            _lbl介紹人.Text = p_work.f_introducer介紹人;
            _lbl介紹人1.Text = p_work.f_introducer介紹人;
            _lbl保險代碼.Text = p_work.f_insuranceid保險代碼;
            _lbl保險代碼1.Text = p_work.f_insuranceid保險代碼;
            _lbl工單所別.Text = p_work.f_branchid工單所別;
            _lbl工單所別1.Text = p_work.f_branchid工單所別;
        }
    }
}
