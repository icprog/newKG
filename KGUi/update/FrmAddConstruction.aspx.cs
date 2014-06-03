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
using System.Collections.Generic;

namespace KGUi.update
{
    public partial class FrmAddConstruction : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);

            CWork l_work = get工單();

            if (!Page.IsPostBack)
            {
                display工單(l_work);
                加入所有施工人員檔();
            }
        }

        private CWork get工單()
        {
            return  Session[SealedGlobalPage.SESSIONKEY_WORK_SERACH] as CWork;
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
        }

        private void 加入所有施工人員檔()
        {
            //因施工人員不固定所別,故一次撈出方便新增
            CUser[] l_users = _context.CFactoryManager.CUserFactory.getAll洗車人員();

            for (int i = 0; i < l_users.Length; i++)
            {
                _check.Items.Add(new ListItem("("+l_users[i].f_userid帳號+") "+l_users[i].f_username姓名,l_users[i].f_userid帳號));
            }
        }

        protected void _btn加入選取人員_Click(object sender, EventArgs e)
        {
            List<CConstruction> l_listCConstruction = new List<CConstruction>();
            //try
            //{
                for (int i = 0; i < _check.Items.Count; i++)
                {
                    if (_check.Items[i].Selected)
                    {
                        CConstruction l_construction = _context.CFactoryManager.CConstructionFactory.createCConstruction();

                        l_construction.f_workid工單單號 = _lbl工單號碼.Text;
                        l_construction.f_smid施工人員 = _check.Items[i].Value;

                        l_listCConstruction.Add(l_construction);
                    }
                }

                //施工者通常都超過一名,直接一次insert效率比較好
                _context.CFactoryManager.CConstructionFactory.insert_s(l_listCConstruction);

                CWork l_work = get工單();
                l_work.f_staus狀態 = "施工中";
                //加入施工人員後狀態更改狀態為[施工中]
                _context.CFactoryManager.CWorkFactory.update(l_work);
            //}
            //catch
            //{
            //    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('加入失敗!請洽系統管理者');", true);
            //    return;
            //}

            ScriptManager.RegisterClientScriptBlock(this, typeof(FrmAddConstruction), "OK", "alert('加入施工人員完成!作業完成後,請記得維護完工');", true);
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "window.location.href='./FrmUpdateIndex.aspx';", true);
            
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
            Response.Redirect("../FrmLogin.aspx");
        }

    }
}
