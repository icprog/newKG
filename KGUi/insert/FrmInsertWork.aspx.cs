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


namespace KGUi.insert
{
    public partial class FrmInsertWork : System.Web.UI.Page 
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);
            string l_strBranchid = (Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser).f_branchid所別;
            string l_strType = Request["type"];
            if (!Page.IsPostBack)
            {
                //保險介紹只有幾間特定公司 20130411 way
                if (l_strType.Equals("24"))
                {
                    CTools.get保險公司介紹(_rdo保險公司, _context);
                }
                else
                {
                    CTools.get保險公司(_rdo保險公司, _context);
                }
              
                _txt工單號碼.Text = CTools.get工單號碼(l_strBranchid);

                //把前端FrmWorkType.aspx?type= ??? 數字表示變成中文顯示
                顯示工單種類中文名稱(l_strType);
                初始化();
            }  
        }

        private void 初始化()
        {
            //保險才能能選取保險公司
            if ("保險".Equals(_lbl工單種類.Text) || "保險公司介紹".Equals(_lbl工單種類.Text))
            {
                _rdo保險公司.Enabled = true;
            }
            //新車,員工車,試乘不得選招攬
            if ("新車".Equals(_lbl工單種類.Text) || "員工".Equals(_lbl工單種類.Text) || "試乘".Equals(_lbl工單種類.Text) || "購車周年".Equals(_lbl工單種類.Text))
            {
                _rdo是否招攬.Enabled = false;
                if ("新車".Equals(_lbl工單種類.Text))
                {
                    _ddl洗車種類0.Items.Clear();
                    _ddl洗車種類0.Items.Add(new ListItem("R_精緻洗車", "R"));
                    _ddl洗車種類0.Items.Add(new ListItem("M_磁土美容", "M"));
                    _ddl洗車種類0.Items.Add(new ListItem("S_超值美容", "S"));
                    _ddl洗車種類0.Items.Add(new ListItem("A_小美容", "A"));
                    _ddl洗車種類0.Items.Add(new ListItem("B_覆膜專案", "B"));
                    _ddl洗車種類0.Items.Add(new ListItem("L_亮新專案", "L"));
                    _ddl洗車種類0.Items.Add(new ListItem("N_亮新專案Ⅱ", "N"));
                    _ddl洗車種類0.Items.Add(new ListItem("I_內裝美容", "I"));
                    _ddl洗車種類0.Items.Add(new ListItem("E_引擎室深度清潔", "E"));
                    _ddl洗車種類0.Items.Add(new ListItem("G_玻璃油膜處理", "G"));
                    _ddl洗車種類0.Items.Add(new ListItem("C_速霸陸/馬自達 磁土美容", "C"));
                    _ddl洗車種類0.Items.Add(new ListItem("J_速霸陸/馬自達 小美容", "J"));
                    _ddl洗車種類0.Items.Add(new ListItem("P_速霸陸/馬自達 覆膜處理", "P"));
                    _ddl洗車種類0.Items.Add(new ListItem("T_速霸陸/馬自達 新車覆膜", "T"));
                    _ddl洗車種類0.Items.Add(new ListItem("K_速霸陸/馬自達 大美容", "K"));
                    _ddl洗車種類0.Items.Add(new ListItem("H_速霸陸/馬自達 內裝美容", "H"));
                    _ddl洗車種類0.Items.Add(new ListItem("F_速霸陸/馬自達 引擎室深度清潔", "F"));
                    _ddl洗車種類0.Items.Add(new ListItem("D_和榮", "D00"));
                }
                
            }
            if (!"新車".Equals(_lbl工單種類.Text) )
            {
                _lbl引擎號碼和車牌.Text = "車牌號碼";
                _txt顧客名稱.Enabled = false;
            }
            if ("新車".Equals(_lbl工單種類.Text) || "試乘".Equals(_lbl工單種類.Text))
            {
                _txt服務專員.Enabled = false;
            }
            if ("新車保值計畫(TN覆膜)".Equals(_lbl工單種類.Text))
            {
                _rdo是否招攬.Enabled = false;
                _rdo是否招攬.SelectedValue = "是";
                _txt介紹人.Visible = true;

                _ddl洗車種類0.Items.Clear();

                _ddl洗車種類0.Items.Add(new ListItem("W_保值(新車,TN腹膜)", "W"));
                _ddl洗車種類0.Items.Add(new ListItem("Y_保值(需拋光,TN腹膜)", "Y"));
            }

        }

        private void 顯示工單種類中文名稱(string p_type)
        {
            switch (p_type)
            {
                case "1": _lbl工單種類.Text = "新車"; return;
                case "2": _lbl工單種類.Text = "保險"; return;
                case "24": _lbl工單種類.Text = "保險公司介紹"; return;
                case "3": _lbl工單種類.Text = "一般"; return;
                case "4": _lbl工單種類.Text = "員工"; return;
                case "5": _lbl工單種類.Text = "試乘"; return;
                case "6": _lbl工單種類.Text = "購車周年"; return;
                case "7": _lbl工單種類.Text = "新車保值計畫(TN覆膜)"; return;
            }

        }

        protected void _rdo是否招攬_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ("是".Equals(_rdo是否招攬.SelectedValue))
            {
                _txt介紹人.Visible = true;
            }
            else
            {
                _txt介紹人.Visible = false;
            }
        }

        protected void _ddl洗車種類_SelectedIndexChanged(object sender, EventArgs e)
        {
             CWorkType l_worktype = _context.CFactoryManager.CWorkTypeFactory.getCWorkTypeBy代碼(_ddl洗車種類.SelectedValue);
            
             if ("新車".Equals(_lbl工單種類.Text) || "員工".Equals(_lbl工單種類.Text) 
                 || "試乘".Equals(_lbl工單種類.Text) || "購車周年".Equals(_lbl工單種類.Text)
                 || "保險公司介紹".Equals(_lbl工單種類.Text))
             {
                 _txt金額.Text = l_worktype.f_moneyBySmid員工價.ToString();
             }
             else
             {
                 _txt金額.Text = l_worktype.f_money價錢.ToString();
             }
        }

        protected void _btn取消_Click(object sender, EventArgs e)
        {
            Response.Redirect("./FrmIndex.aspx");
        }

        private bool 使用者輸入資訊()
        {
            if ("新車".Equals(_lbl工單種類.Text) || "一般".Equals(_lbl工單種類.Text) || "試乘".Equals(_lbl工單種類.Text) || "購車周年".Equals(_lbl工單種類.Text))
            {
                if (!"".Equals(_rdo保險公司.SelectedValue))
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('非保險件不得挑選保險公司');", true);
                    return false;
                }
            }
            if ("新車".Equals(_lbl工單種類.Text))
            {
                if (_txt顧客名稱.Text.Trim().Length != 5)
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('新車必需要輸入顧客姓名(員工編號為五碼)');", true);
                    _txt顧客名稱.Focus();
                    return false;
                }
            }
            if ("試乘".Equals(_lbl工單種類.Text))
            {
                if (_lbl引擎號碼.Text.Equals(" *此車不是試乘車輛"))
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('試乘工單必需為試乘車才能開立');", true);
                    _txt引擎號碼.Focus();
                    return false;
                }
                
            }
            if ("保險".Equals(_lbl工單種類.Text) || "保險公司介紹".Equals(_lbl工單種類.Text))
            {
                if ("保險".Equals(_lbl工單種類.Text))
                {
                    //2011-05-05 新增保險件無法選擇小美容or覆膜 way
                    if ("A".Equals(_ddl洗車種類0.SelectedValue) || "B".Equals(_ddl洗車種類0.SelectedValue))
                    {
                        ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('保險件無法選擇小美容or覆膜');", true);
                        _ddl洗車種類0.Focus();
                        return false;
                    }
                }
                if ("".Equals(_rdo保險公司.SelectedValue))
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('保險件須挑選保險公司');", true);
                    _rdo保險公司.Focus();
                    return false;
                }
            }
            if ("".Equals(_txt引擎號碼.Text.Trim()))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('請輸入引擎號碼');", true);
                _txt引擎號碼.Focus();
                return false;
            }

            if ("".Equals(_ddl洗車種類.SelectedValue))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('請挑選洗車種類');", true);
                _txt引擎號碼.Focus();
                return false;
            }
            if ("是".Equals(_rdo是否招攬.SelectedValue))
            {
                if (_txt介紹人.Text.Trim().Length != 5)
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('招攬件請輸入介紹人員工編號為五碼');", true);
                    return false;
                }
            }

            //同一天不得開立兩次單
            CWork l_work = _context.CFactoryManager.CWorkFactory.get判斷是否有同一天重複開單(_txt引擎號碼.Text.Trim(), DateTime.Today.ToString("yyyy/MM/dd"));
            if (l_work != null)
            {
                CUser l_user = _context.CFactoryManager.CUserFactory.get高都員工檔(l_work.f_edituser開單人員);
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('此引擎號碼今日已開過一次單!請重新確認!開單人員:" + l_work.f_edituser開單人員 + "_" + l_user.f_username姓名 + "');", true);
                return false;
            }

            //201311114 只有高至助理能開速霸陸/馬自達的車
            //if (!"B1201".Equals(l_work.f_edituser開單人員))
            //{
            //    if ("C".Equals(_ddl洗車種類.SelectedValue) ||
            //        "J".Equals(_ddl洗車種類.SelectedValue) ||
            //        "P".Equals(_ddl洗車種類.SelectedValue) ||
            //        "T".Equals(_ddl洗車種類.SelectedValue) ||
            //        "K".Equals(_ddl洗車種類.SelectedValue) ||
            //        "H".Equals(_ddl洗車種類.SelectedValue) ||
            //        "F".Equals(_ddl洗車種類.SelectedValue))
            //    {
            //        ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('只有高輊助理能開速霸陸/馬自達的車');", true);
            //        return false;
            //    }
            //}
            return true;
        }

        private CUser get高都員工(string p_smid)
        {
            CUser l_user = _context.CFactoryManager.CUserFactory.get高都員工檔(p_smid);

            if (l_user == null)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('無此員工!請重新確認');", true);
                return null;
            }
            return l_user;
        }
        protected void _txt顧客名稱_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if ("新車".Equals(_lbl工單種類.Text) || "試乘".Equals(_lbl工單種類.Text))
                {
                    CUser l_user = get高都員工(_txt顧客名稱.Text.Trim());
                    _lbl新車員工.Text = l_user.f_branchid所別 + " / " + l_user.f_username姓名;
                }
            }
            catch
            {
                _txt顧客名稱.Text = "";
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('無此員工!請重新確認');", true);
                return;
            }
        }

        protected void _txt介紹人_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CUser l_user = get高都員工(_txt介紹人.Text.Trim());
                _lbl新車員工1.Text = l_user.f_branchid所別 + " / " + l_user.f_username姓名;
            }
            catch
            {
                _txt介紹人.Text = "";
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('無此員工!請重新確認');", true);
                return;
            }
        }

        protected void _btn開立_Click(object sender, ImageClickEventArgs e)
        {

            //try
            //{
                //使用者輸入的資料無誤再執行新增code
                if (使用者輸入資訊())
                {
                    CWork l_work = _context.CFactoryManager.CWorkFactory.createCWork();

                    l_work.f_workid工單單號 = _txt工單號碼.Text.Trim();
                    l_work.f_engo引擎號碼 = _txt引擎號碼.Text.ToUpper().Trim();
                    l_work.f_customerid顧客名稱 = _txt顧客名稱.Text.ToUpper();
                    l_work.f_workType洗車種類 = _ddl洗車種類.SelectedValue;

                    l_work.f_money金額 = Convert.ToInt32(_txt金額.Text);

                    l_work.f_memo備註 = _txt備註.Text.Trim(); ;
                    l_work.f_edituser開單人員 = (Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser).f_userid帳號;
                    l_work.f_editdate開單日期 = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    l_work.f_closeDate完工日 = "";
                    l_work.f_introducer介紹人 = _txt介紹人.Text.ToUpper();
                    l_work.f_type工單種類 = _lbl工單種類.Text;
                    l_work.f_insuranceid保險代碼 = _rdo保險公司.SelectedValue;
                    if ("保險".Equals(_lbl工單種類.Text))
                    {
                        l_work.f_insurancetype保險型態 = _rdo保險型態.SelectedValue;
                    }
                    else { l_work.f_insurancetype保險型態 = ""; }
                    l_work.f_staus狀態 = "待處理";
                    l_work.f_branchid工單所別 = (Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser).f_branchid所別;
                    l_work.f_seruser服務專員 = _lbl服務專員.Text;

                    _context.CFactoryManager.CWorkFactory.insert(l_work);
                   
                    //新車才需要新增應收帳款
                    if ("新車".Equals(_lbl工單種類.Text))
                    {
                        新增應收帳款(l_work);
                    }
                    ScriptManager.RegisterClientScriptBlock(this, typeof(FrmInsertWork), "OK", "alert('開立完成!請列印工單留底');", true);
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "window.location.href='./FrmIndex.aspx';", true);
                }
            //}
            //catch { ScriptManager.RegisterClientScriptBlock(this, typeof(FrmInsertWork), "OK", "alert('開立失敗!請檢察網路是否正常');", true); return; }
        }
        private void 新增應收帳款(CWork p_work)
        {
            CInMoney l_InMoney = _context.CFactoryManager.CInMoneyFactory.createCInMoney();
            l_InMoney.f_editdate帳款日期 = DateTime.Now.ToString("yyyy/MM/dd");
            l_InMoney.f_isclose是否關帳 = "N";
            l_InMoney.f_memo備註 = "";
            l_InMoney.f_moneyid應收單號 = "";
            l_InMoney.f_money應收金額 = p_work.f_money金額;
            l_InMoney.f_smid帳款人 = p_work.f_customerid顧客名稱;
            l_InMoney.f_type種類 = "洗車";
            l_InMoney.f_workid工單單號 = p_work.f_workid工單單號;
            l_InMoney.f_yesmoney已沖金額 = 0;

            _context.CFactoryManager.CInMoneyFactory.insert(l_InMoney);
        }
        protected void _rdo保險公司_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!"".Equals(_rdo保險公司.SelectedValue))
            {
                if ("保險".Equals(_lbl工單種類.Text))
                {
                    _rdo保險型態.Enabled = true;
                }
                else
                {
                    _rdo保險型態.Enabled = false;
                }
            }
            else
            {
                _rdo保險型態.Enabled = false;
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
            Response.Redirect("../FrmLogin.aspx");
        }

        protected void _txt引擎號碼_TextChanged(object sender, EventArgs e)
        {
            _lblTip.Text = "";
            if ("新車".Equals(_lbl工單種類.Text))
            {
                CEngno l_Engno = _context.CFactoryManager.CEngnoFactory.
                    get高都引擎號碼檔(_txt引擎號碼.Text);

                if (l_Engno == null)
                {
                    _lbl引擎號碼.Text = " *此車不是高都販賣車輛";
                    //_txt引擎號碼.Text = "";
                    //ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('無此引擎號碼!請重新確認');", true);
                    //return;
                }
                else
                {
                    //if ("".Equals(l_Engno.f_license車牌))
                    //{
                    //    _lbl引擎號碼.Text = l_Engno.f_carcod車種 + " / 尚無車牌號碼";
                    //}
                    //else
                    //{
                        _lbl引擎號碼.Text = l_Engno.f_carcod車種 + " / " + l_Engno.f_orpm訂單顧客;
                    //}
                }

                //判斷一個月內新車是否從復開洗車單  Fix By Fox
                CWork[] l_workarray = _context.CFactoryManager.CWorkFactory.get工單資訊By管理者("", "", "", "", "", "", "", false, _txt引擎號碼.Text, false);
                if ("新車".Equals(_lbl工單種類.Text) && l_workarray.Count() != 0)
                {
                    _lblTip.Text = "提醒此新車引擎號碼已開過同類型的單子  請再次確認，以免重覆收款，務必留意";
                    //ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", 
                    //    "alert('提醒此新車引擎號碼已開過同類型的單子  請再次確認，以免重覆收款，務必留意!');", true);
                    //UpdatePanel1.Update();
                }

            }
            else if ("試乘".Equals(_lbl工單種類.Text))
            {
                CTestDrive l_CTestDrive = _context.CFactoryManager.CTestDriveFactory.
                    getCTestDriveBySearch(_txt引擎號碼.Text);


                if (l_CTestDrive == null)
                {
                    _lbl引擎號碼.Text = " *此車不是試乘車輛";
                }
                else
                {
                    _lbl引擎號碼.Text = l_CTestDrive.f_engo引擎號碼+"/"+ l_CTestDrive.f_carno車牌;
                }

            }
            else
            {
                if (_txt引擎號碼.Text.IndexOf("-") < 0)
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('車牌請加上-號');", true);
                }
            }
        }

        protected void _txt服務專員_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CUser l_user = get高都員工(_txt服務專員.Text.Trim());
                _lbl服務專員.Text =l_user.f_username姓名;
            }
            catch
            {
                _txt服務專員.Text = "";
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('無此員工!請重新確認');", true);
                return;
            }
        }


        protected void _ddl洗車種類0_SelectedIndexChanged(object sender, EventArgs e)
        {
            _txt金額.Text = "";
            _ddl洗車種類.SelectedValue = "";
            CTools.get洗車種類(_ddl洗車種類, _context, this, _ddl洗車種類0.SelectedValue);
        }
    }
}
