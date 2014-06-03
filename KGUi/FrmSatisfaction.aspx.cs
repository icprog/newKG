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

namespace KGUi
{
    public partial class FrmSatisfaction : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);
        }

        protected void _btn送出_Click(object sender, EventArgs e)
        {
            try
            {
                if (使用者輸入())
                {
                    CSatisfaction l_CSatisfaction = _context.CFactoryManager.CSatisfactionFactory.
                        createCSatisfaction();

                    l_CSatisfaction.f_branchid施工地點 = _cbo施工地點.SelectedValue;
                    l_CSatisfaction.f_car車牌 = _txt車牌.Text.ToUpper();
                    l_CSatisfaction.f_smid業代 = _txt員編.Text.ToUpper();
                    l_CSatisfaction.f_date時間 = DateTime.Today.ToString("yyyy/MM/dd");


                    //外觀清潔
                    l_CSatisfaction.f_glassclean玻璃清潔 = Convert.ToInt32(_rdo玻璃清潔良好.SelectedValue);
                    l_CSatisfaction.f_dirtpaint漆面髒汙 = Convert.ToInt32(_rdo漆面髒汙清潔良好.SelectedValue);
                    l_CSatisfaction.f_waxfinish漆面打蠟 = Convert.ToInt32(_rdo漆面打蠟良好.SelectedValue);
                    l_CSatisfaction.f_engineroom引擎室 = Convert.ToInt32(_rdo引擎室周圍擦拭.SelectedValue);
                    l_CSatisfaction.f_tirerims輪胎鋼圈 = Convert.ToInt32(_rdo輪胎鋼圈清潔.SelectedValue);

                    //內庄清潔
                    l_CSatisfaction.f_leather皮椅 = Convert.ToInt32(_rdo皮椅及門飾板清水擦拭.SelectedValue);
                    l_CSatisfaction.f_dashboard儀錶板 = Convert.ToInt32(_rdo儀錶板清潔.SelectedValue);
                    l_CSatisfaction.f_carpet地毯清潔 = Convert.ToInt32(_rdo地毯清潔.SelectedValue);

                    //小百貨裝置
                    l_CSatisfaction.f_gadget小配件 = Convert.ToInt32(_rdo小配件裝置.SelectedValue);
                    l_CSatisfaction.f_deliverytime交車時間 = Convert.ToInt32(_rdo交車時間及人員互動.SelectedValue);

                    l_CSatisfaction.f_memo備註 = _txtMemo.Text;

                    _context.CFactoryManager.CSatisfactionFactory.insert(l_CSatisfaction);
                    ClearUI();

                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('填寫完成!謝謝你寶貴的意見');", true);
                }
            }
            catch { ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "ERROR", "alert('填寫失敗!請檢察網路是否正常或輸入資料是否有異常');", true); return; }
          
        }

        private void ClearUI()
        {
            _cbo施工地點.SelectedValue = "";
            _txt車牌.Text = "";
            _txt員編.Text = "";
            _txtMemo.Text = "";
            _rdo玻璃清潔良好.SelectedValue = null;
            _rdo漆面髒汙清潔良好.SelectedValue = null;
            _rdo漆面打蠟良好.SelectedValue = null;
            _rdo引擎室周圍擦拭.SelectedValue = null;
            _rdo輪胎鋼圈清潔.SelectedValue = null;
            _rdo皮椅及門飾板清水擦拭.SelectedValue = null;
            _rdo儀錶板清潔.SelectedValue = null;
            _rdo地毯清潔.SelectedValue = null;
            _rdo小配件裝置.SelectedValue = null;
            _rdo交車時間及人員互動.SelectedValue = null;

        }

        private bool 使用者輸入()
        {
            if ("".Equals(_cbo施工地點.SelectedValue))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "ERROR", "alert('請選擇施工地點');", true);
                return false ;
            }
            if ("".Equals(_txt車牌.Text))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "ERROR", "alert('請輸入車牌');", true);
                return false;
            }
            if ("".Equals(_txt員編.Text))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "ERROR", "alert('請輸入員編');", true);
                return false;
            }
            if (_txt員編.Text.Length != 5)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "ERROR", "alert('員編格式為五碼');", true);
                return false;
            }
            if (_txt車牌.Text.IndexOf("-") < 0)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "ERROR", "alert('車牌格式請輸入XXXX-XX OR XX-XXXX');", true);
                return false;
            }
            return true;
        }
    }
}
