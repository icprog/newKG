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

namespace KGUi.update
{
    public partial class FrmCloseWork : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);

            CWork l_work = get登入的工單();

            if (!Page.IsPostBack)
            {
                display工單(l_work);
            }
        }

        private CWork get登入的工單()
        {
            return Session[SealedGlobalPage.SESSIONKEY_WORK_SERACH] as CWork;
        }
        private void display工單(CWork p_work)
        {
            _lbl工單號碼.Text = p_work.f_workid工單單號;
            _lbl引擎號碼.Text = p_work.f_engo引擎號碼;
            _lbl顧客名稱.Text = p_work.f_customerid顧客名稱;
            _lbl洗車種類.Text = p_work.f_workType洗車種類;
            _lbl金額.Text = p_work.f_money金額.ToString();
            _lbl備註.Text = p_work.f_memo備註;
            _lbl開單人員.Text = p_work.f_edituser開單人員;
            //_lbl開單日期.Text = p_work.f_editdate開單日期;

            display施工人員(p_work.f_workid工單單號);
        }

        private void display施工人員(string p_strWorkid)
        {
            CConstruction[] l_Construction = _context.CFactoryManager.CConstructionFactory.get施工人員By單號(p_strWorkid);

            for (int i = 0; i < l_Construction.Length; i++)
            {
                _bll施工人員.Items.Add(l_Construction[i].f_smid施工人員);
            }
        }

        protected void _完工_Click(object sender, EventArgs e)
        {
            CWork l_work = get登入的工單();

            l_work.f_closeDate完工日 = DateTime.Today.ToString("yyyy/MM/dd");
            l_work.f_staus狀態 = "完工";
            _context.CFactoryManager.CWorkFactory.update(l_work);


            ScriptManager.RegisterClientScriptBlock(this, typeof(FrmCloseWork), "OK", "alert('完工成功!');", true);
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "window.location.href='./FrmUpdateIndex.aspx';", true);
            
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

            Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
            Response.Redirect("../FrmLogin.aspx");
        }
    }
}
