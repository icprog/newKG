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

namespace KGUi.part
{
    public partial class FrmInsertKGPartOrder : System.Web.UI.Page
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

            if (!this.IsPostBack)
            {
                set廠商(l_user);
            }
        }

        private void set廠商(CUser p_user)
        {
            _rbl廠商.Items.Clear();
            if (p_user.f_lvl等級 == 4)
            {
                _rbl廠商.Items.Add(new ListItem("惠明(HM)   聯絡電話：(07)359-5337", "HM"));
                _rbl廠商.Items.Add(new ListItem("亙長(服務廠)   聯絡電話：(07)222-9566", "KCF"));
                _rbl廠商.Items.Add(new ListItem("劦大(服務廠)   聯絡電話：(07)238-1541", "LDF"));
                _txt業代價.Visible = true;
                
            }
            else
            {
                _rbl廠商.Items.Add(new ListItem("亙長(KC)   聯絡電話：(07)222-9566", "KC"));
                _rbl廠商.Items.Add(new ListItem("劦大(LD)   聯絡電話：(07)238-1541", "LD"));
                _rbl廠商.Items.Add(new ListItem("PDS", "PDS"));
                _rbl廠商.Items.Add(new ListItem("高輊(KG)", "KG"));
                _txt業代價.Visible = false;
            }
        }

        protected void iv_btn選購作業_Click(object sender, EventArgs e)
        {
            string l_strSmid = _txt業代員編.Text.Trim();

            try
            {
                CUser l_user = _context.CFactoryManager.CUserFactory.get高都員工檔(l_strSmid);
                _lblSmid.Text = l_strSmid.ToUpper();
                DataTable dt = _context.CFactoryManager.OffDutyFactory.GetData(l_strSmid);

                if (dt.Rows.Count > 0)
                {
                    _txt業代員編.Text = "";
                    iv_lblErrorMsg.Text = "此員工已經離職";
                    _lblSmid.Text = "";
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('此員工已經離職');", true);
                }
                else
                {
                    _lbl業代資料.Text = l_user.f_branchid所別 + " / " + l_user.f_username姓名;
                    get下拉式選單內容("");
                    初始化();
                }
            }
            catch 
            {
                iv_lblErrorMsg.Text = "無此員工!!請重新確認";
                //清空原編
                _lblSmid.Text = "";
            }
        }

        private void get下拉式選單內容(string p_str)
        {
            CKGPartFactory l_factory = _context.CFactoryManager.CKGPartFactory;
            CKGPart[] l_codes = null;
            ListBox l_lbx = new ListBox();

            if ("get種類ListBox".Equals(p_str))
            {

                l_codes = l_factory.get種類By類別(_lbx類別名稱.SelectedValue);

                for (int i = 0; i < l_codes.Length; i++)
                {
                    _lbx種類名稱.Items.Add(new ListItem(l_codes[i].f_CategoryID種類編號 + "  >  " + l_codes[i].f_CategoryName種類名稱, l_codes[i].f_CategoryID種類編號));
                }

                _lbx百貨商品.Items.Clear();
            }
            else if ("get百貨ListBox".Equals(p_str))
            {
                string l_str廠商 = _rbl廠商.SelectedValue;

                if ("".Equals(l_str廠商))
                {
                    iv_lblErrorMsg.Text = "請先挑選廠商";
                    return;
                }
                CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;
                if (l_user.f_lvl等級 == 4)
                {
                    l_codes = l_factory.get百貨商品By種類(_lbx種類名稱.SelectedValue, l_str廠商);
                }
                else
                {
                    l_codes = l_factory.get百貨商品By種類By營業所(_lbx種類名稱.SelectedValue, l_str廠商);
                }
                if (l_codes != null)
                {
                    _lbx百貨商品.Enabled = true;
                    for (int i = 0; i < l_codes.Length; i++)
                    {
                        _lbx百貨商品.Items.Add(new ListItem(l_codes[i].f_ProductID產品編號 + "  >  " + l_codes[i].f_ProductName產品名稱, l_codes[i].f_ProductID產品編號));
                    }
                }
                else
                {
                    _lbx百貨商品.Items.Add(new ListItem("無產品"));
                    _lbx百貨商品.Enabled = false;
                }
            }
            else
            {
                _lbx類別名稱.Items.Clear();
                l_codes = l_factory.getCKGPart所有類別不含洗車();
                for (int i = 0; i < l_codes.Length; i++)
                {
                    _lbx類別名稱.Items.Add(new ListItem(l_codes[i].f_TypeID類別編號 + "  >  " + l_codes[i].f_TypeName類別名稱, l_codes[i].f_TypeID類別編號));
                }
            }
        }

        protected void _rbl廠商_SelectedIndexChanged(object sender, EventArgs e)
        {
             
            _lbx種類名稱_SelectedIndexChanged(null, null);
        }

        protected void _lbx類別名稱_SelectedIndexChanged(object sender, EventArgs e)
        {
            _lbx種類名稱.Items.Clear();
            get下拉式選單內容("get種類ListBox");
        }

        protected void _lbx種類名稱_SelectedIndexChanged(object sender, EventArgs e)
        {
            _lbx百貨商品.Items.Clear();
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;
            if (l_user.f_lvl等級 == 4)
            {
                if (!_rbl廠商.SelectedValue.Equals("KCF") && !_rbl廠商.SelectedValue.Equals("LDF") && !_rbl廠商.SelectedValue.Equals("HM"))
                {
                    iv_lblErrorMsg.Text = "服務廠人員只能選擇服務廠商";
                    return;
                }
                else
                {
                    iv_lblErrorMsg.Text = "";
                }
            }

            get下拉式選單內容("get百貨ListBox");
        }

        protected void _lbx百貨商品_SelectedIndexChanged(object sender, EventArgs e)
        {
            CKGPartFactory l_factory = _context.CFactoryManager.CKGPartFactory;
            CKGPart l_code = l_factory.get百貨商品ByProductID(_lbx百貨商品.SelectedValue);
            Session.Add("CKGPart", l_code);
            顯示產品資訊(l_code, "1");
        }

        private void 顯示產品資訊(CKGPart p_code, string p_str數量)
        {
            _lbl商品編號.Text = p_code.f_ProductID產品編號;
            _lbl商品名稱.Text = p_code.f_ProductName產品名稱;
            _lbl單位個數.Text = p_code.f_Qty單位;
            _lbl售價.Text = p_code.f_ListPrice售價.ToString();
            _lbl產品成本價.Text = p_code.f_Cost成本價.ToString();
            _lbl業代價.Text = p_code.f_SalePrice業代價.ToString();
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;
            if (l_user == null)
            {
                Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
                Response.Redirect("../FrmLogin.aspx");
            }
            if (l_user.f_lvl等級 == 4)
            {
                _txt業代價.Text = p_code.f_ListPrice售價.ToString();
            }
            else
            {
                _txt業代價.Text = p_code.f_SalePrice業代價.ToString();
            }
            _txt數量.Text = p_str數量;
        }

        protected void iv_btn加入選購清單_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(_lblSmid.Text))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "請選擇輸入正確的員工編號", true);
                return;
            }

            if ("".Equals(_txt數量.Text.Trim()))
            {
                //ScriptManager.RegisterClientScriptBlock(UpdatePanel2, typeof(UpdatePanel), "OK", "alert('請輸入數量!!')", true);
            }
            else
            {
                try
                {
                    double l_dou業代價 = Convert.ToDouble(_lbl業代價.Text);
                    double l_dou業代價修改 = Convert.ToDouble(_txt業代價.Text);

                    if (l_dou業代價修改 < l_dou業代價)
                    {
                        ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "實際販賣金額不能小於業代價", true);
                        return;
                    }
                }
                catch { ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "金額格式錯誤", true);return; }

                if (!String.IsNullOrEmpty(_lblSmid.Text))
                {
                    把請購的資料加入DataTable();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "請選擇正確的員工編號", true);
                }
            }
        }

        private void 初始化()
        {
            string[] l_str = { "ID", "單位編號", "單位名稱", "員編", "姓名", "產品編號", "產品名稱", "數量", "單位", "成本", "建議售價", "業代價", "販賣價", "總計", "日期", "總販賣" };
            
            DataTable l_table = CTools.getFilledColumnsDataTable(l_str);
            GridView1.DataSource = l_table;
            GridView1.DataBind();

            Session.Add(SealedGlobalPage.SESSIONKEY_KGPARTORDER_TEMPTABLE, l_table);
            get下拉式選單內容("");
            _txt備註.Text = "";
            iv_txt引擎號碼.Text = "";
        }

        private void 把請購的資料加入DataTable()
        {
            string l_strSmid = _lblSmid.Text;

            CKGPart l_code產品資料 = (CKGPart)Session["CKGPart"];
            DataTable l_table = (DataTable)Session[SealedGlobalPage.SESSIONKEY_KGPARTORDER_TEMPTABLE];

            int l_int數量 = Convert.ToInt32(_txt數量.Text);
          

            string l_strProductID = l_code產品資料.f_ProductID產品編號;

            //先判別是否點選產品已經在l_table裡面，有的話直接加上數量
            for (int i = 0; i < l_table.Rows.Count; i++)
            {
                if (l_strProductID.Equals(l_table.Rows[i]["產品編號"].ToString()))
                {
                    //string l_str = "alert('提醒：所選擇的產品已在清單內，系統將直接加上數量')";
                    //ScriptManager.RegisterClientScriptBlock(UpdatePanel2, typeof(UpdatePanel), "OK", l_str, true);
                    l_int數量 += Convert.ToInt32(l_table.Rows[i]["數量"].ToString());
                    l_table.Rows.RemoveAt(i);
                }
            }

            DataRow l_row = l_table.NewRow();

            l_row["產品編號"] = l_code產品資料.f_ProductID產品編號;
            l_row["產品名稱"] = l_code產品資料.f_ProductName產品名稱;
            l_row["數量"] = l_int數量;
            l_row["單位"] = l_code產品資料.f_Qty單位;
            l_row["建議售價"] = l_code產品資料.f_ListPrice售價;
            int l_int業代價 = Convert.ToInt32(_lbl業代價.Text);
            int l_int販賣價 = Convert.ToInt32(_txt業代價.Text);
            l_row["業代價"] = l_int業代價.ToString();
            l_row["販賣價"] = l_int販賣價.ToString();
            int l_int總計 = 0;
            l_int總計 = l_int數量 * l_int業代價;
            l_row["成本"] = l_code產品資料.f_Cost成本價;

            l_row["總計"] = l_int總計;
            l_row["總販賣"] = l_int數量 * l_int販賣價;
            
            l_table.Rows.InsertAt(l_row, 0);
            
            計算總金額(l_table);
          
            GridView1.DataSource = l_table;
            GridView1.DataBind();
        }

        private void 計算總金額(DataTable p_table)
        {
            int l_int總請購金額 = 0;
            int l_int總販賣金額 = 0;
            for (int i = 0; i < p_table.Rows.Count; i++)
            {
                l_int總請購金額 += Convert.ToInt32(p_table.Rows[i]["總計"].ToString());
                l_int總販賣金額 += Convert.ToInt32(p_table.Rows[i]["總販賣"].ToString());
            }
            _lblTotal.Text = l_int總請購金額.ToString();
            _lblSaleTotal.Text = l_int總販賣金額.ToString();
        }

        protected void _btn送出清單_Click(object sender, EventArgs e)
        {
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;
            if (l_user.f_lvl等級 != 4)
            {
                if (!_rbl廠商.SelectedValue.Equals("KG"))
                {
                    if ("".Equals(iv_txt引擎號碼.Text.Trim()))
                    {
                        string l_str = "alert('引擎號碼不能空白');";
                        ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", l_str, true);
                        return;
                    }
                    else
                    {
                        CKGPartOrder l_code = _context.CFactoryManager.CKGPartOrderFactory.
                              get顧客姓名ByEngo(iv_txt引擎號碼.Text.Trim());
                        if (l_code == null)
                        {
                            string l_str = "alert('引擎號碼錯誤，請重新確認 ex:注意大小寫');";
                            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", l_str, true);
                            return;
                        }
                    }
                }
            }
            送出請購清單();
        }

        private void 送出請購清單()
        {

            DataTable l_dt = (DataTable)Session[SealedGlobalPage.SESSIONKEY_KGPARTORDER_TEMPTABLE];
            if (l_dt.Rows.Count == 0)
            {
                string l_str = "alert('清單內無任何資料，請加入請購產品至清單內');";
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", l_str, true);
                return;
            }
            else
            {
                CKGPartOrderFactory l_factory主檔 = _context.CFactoryManager.CKGPartOrderFactory;
                CKGPartOrder l_code主檔 = l_factory主檔.createCKGPartOrder();
 
                string l_str請購單號 = "";
                CUser l_User = (Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser);

                l_str請購單號 = CTools.get訂單號碼(l_User.f_branchid所別);
                
                l_code主檔.f_ExchangeID請購單號 = l_str請購單號;

                l_code主檔.f_EngineNo引擎號碼 = iv_txt引擎號碼.Text.Trim();
                l_code主檔.f_Vendor請購廠商 = _rbl廠商.SelectedValue;
                l_code主檔.f_AssistantSmid助理員編 = l_User.f_userid帳號;//"F9446";//
                l_code主檔.f_AssistantBranchid助理單位編號 = l_User.f_branchid所別;
                l_code主檔.f_TotalPrice總計價格 =Convert.ToInt32( _lblTotal.Text );
                l_code主檔.f_SalesSmid業代員編 = _lblSmid.Text;

                l_code主檔.f_TotalSale總販賣價 = Convert.ToInt32(_lblSaleTotal.Text);
                l_code主檔.f_IsSend是否發送 = "False";
                l_code主檔.f_Memo備註說明 = _txt備註.Text.Replace("'", "");
                l_code主檔.f_InsertDate請購日期 = DateTime.Now.ToString("yyyy/MM/dd");
                l_code主檔.f_InsertIP輸入電腦IP = Request.UserHostAddress;
                l_code主檔.f_EditDate編輯日期 = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
                CKGPartOrderDetailFactory l_factory = _context.CFactoryManager.CKGPartOrderDetailFactory;

                CKGPartOrderDetail[] l_codes明細 = new CKGPartOrderDetail[l_dt.Rows.Count];
                int l_int主檔總計成本 = 0;

                for (int i = 0; i < l_dt.Rows.Count; i++)
                {
                    l_codes明細[i] = l_factory.createCKGPartOrderDetail();
                    l_codes明細[i].f_ExchangeID請購單號 = l_str請購單號;
                    l_codes明細[i].f_ProductID產品編號 = l_dt.Rows[i]["產品編號"].ToString();
                    l_codes明細[i].f_ProductName產品名稱 = l_dt.Rows[i]["產品名稱"].ToString();
                    l_codes明細[i].f_Amount選購數量 = Convert.ToInt32(l_dt.Rows[i]["數量"].ToString());
                    l_codes明細[i].f_Qty產品單位 = l_dt.Rows[i]["單位"].ToString();
                    l_codes明細[i].f_Cost產品成本價 = Convert.ToInt32(l_dt.Rows[i]["成本"].ToString());
                    l_codes明細[i].f_UnitPrice產品單價 = Convert.ToInt32(l_dt.Rows[i]["業代價"].ToString());
                    l_codes明細[i].f_SalePrice販賣價 = Convert.ToInt32(l_dt.Rows[i]["販賣價"].ToString());
                    l_codes明細[i].f_ListPrice建議售價 = Convert.ToInt32(l_dt.Rows[i]["建議售價"].ToString());

                    CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;
                    if (l_user == null)
                    {
                        Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
                        Response.Redirect("../FrmLogin.aspx");
                    }
                    if (l_user.f_lvl等級 == 4)
                    {
                        l_codes明細[i].f_Total總計價格 = Convert.ToInt32(l_dt.Rows[i]["總販賣"].ToString());
                    }
                    else
                    {
                        l_codes明細[i].f_Total總計價格 = Convert.ToInt32(l_dt.Rows[i]["總計"].ToString());
                    }

                    l_codes明細[i].f_EditDate編輯日期 = l_code主檔.f_EditDate編輯日期;
                    l_int主檔總計成本 += (l_codes明細[i].f_Cost產品成本價 * l_codes明細[i].f_Amount選購數量);
                }

                l_code主檔.f_TotalCost總成本價 = l_int主檔總計成本;
                l_code主檔.明細 = l_codes明細;
                string l_str = "alert('選購作業完成，請購單號為: " + l_str請購單號 + "');";
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", l_str, true);

                l_factory主檔.insertCKGPartOrder(l_code主檔);
                新增應收帳款(l_code主檔);
                初始化();
            }
        }

        private void 新增應收帳款(CKGPartOrder p_Order)
        {
            CInMoney l_InMoney = _context.CFactoryManager.CInMoneyFactory.createCInMoney();
            l_InMoney.f_editdate帳款日期 = p_Order.f_InsertDate請購日期;
            l_InMoney.f_isclose是否關帳 = "N";
            l_InMoney.f_memo備註 = "";
            l_InMoney.f_moneyid應收單號 = "";
            l_InMoney.f_money應收金額 = p_Order.f_TotalPrice總計價格;
            l_InMoney.f_smid帳款人 = p_Order.f_SalesSmid業代員編;
            l_InMoney.f_type種類 = "百貨";
            l_InMoney.f_workid工單單號 = p_Order.f_ExchangeID請購單號;
            l_InMoney.f_yesmoney已沖金額 = 0;

            _context.CFactoryManager.CInMoneyFactory.insert(l_InMoney);
        }

        protected void _btn刪除_Click(object sender, EventArgs e)
        {
            Button l_btn = (Button)sender;
            GridViewRow l_row = (GridViewRow)l_btn.Parent.Parent;

            DataTable l_dt = (DataTable)Session[SealedGlobalPage.SESSIONKEY_KGPARTORDER_TEMPTABLE];
            l_dt.Rows.RemoveAt(l_row.RowIndex);

            計算總金額(l_dt);
            Session.Add(SealedGlobalPage.SESSIONKEY_KGPARTORDER_TEMPTABLE, l_dt);

            GridView1.DataSource = l_dt;
            GridView1.DataBind();
        }
    }
}
