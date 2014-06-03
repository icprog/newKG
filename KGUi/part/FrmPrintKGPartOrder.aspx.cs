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

namespace KGUi.part
{
    public partial class FrmPrintKGPartOrder : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);

            string l_strEID = Request["EID"];
            string l_strType = Request["Type"];
            if (!Page.IsPostBack)
            {
                if ("Buy".Equals(l_strType))
                {
                    Label1.Text = get列印領料單Html(l_strEID);
                }
                else
                {
                    Label1.Text = get退貨單Html(l_strEID);
                }
            }
        }

        private string get退貨單Html(string p_strEID)
        {
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;
            string l_str助理員編 = l_user.f_userid帳號;// "F9446";//

            CKGPartOrderDetailOutFactory l_factory退貨 = _context.CFactoryManager.
                CKGPartOrderDetailOutFactory;
            CKGPartOrderDetailOut[] l_codes退貨 = l_factory退貨.
                get退貨資料By請購單號(p_strEID, l_str助理員編);

            if (l_codes退貨 == null)
            {
                return "<font size=\"5\"><b>查無資料!!</b>";
            }

            CKGPartOrder l_code主檔 = _context.CFactoryManager.CKGPartOrderFactory.createCKGPartOrder();

            l_code主檔.f_ExchangeID請購單號 = l_codes退貨[0].f_ExchangeID請購單號;
            l_code主檔.f_SalesSmid業代員編 = l_codes退貨[0].f_SalesSmid業代員編;
            l_code主檔.f_SalesName業代姓名 = l_codes退貨[0].f_SalesName業代姓名;
            l_code主檔.f_SalesBranch業代單位 = l_codes退貨[0].f_SalesBranch業代單位;
            l_code主檔.f_InsertDate請購日期 = l_codes退貨[0].f_OutDate退貨日期;
            l_code主檔.f_Memo備註說明 = l_codes退貨[0].f_OutReasons退貨原因;

            l_code主檔.明細 = new CKGPartOrderDetail[l_codes退貨.Length];
            int l_int總計價格 = 0;
            for (int i = 0; i < l_codes退貨.Length; i++)
            {
                l_code主檔.明細[i] = _context.CFactoryManager.CKGPartOrderDetailFactory.createCKGPartOrderDetail();
                l_code主檔.明細[i].f_ProductID產品編號 = l_codes退貨[i].f_ProductID產品編號;
                l_code主檔.明細[i].f_ProductName產品名稱 = l_codes退貨[i].f_ProductName產品名稱;
                l_code主檔.明細[i].f_UnitPrice產品單價 = l_codes退貨[i].f_UnitPrice產品單價;
                l_code主檔.明細[i].f_Amount選購數量 = l_codes退貨[i].f_OutAmount退貨數量;
                l_code主檔.明細[i].f_Total總計價格 = l_codes退貨[i].f_OutTotal總計退貨價格;
                l_int總計價格 += l_codes退貨[i].f_OutTotal總計退貨價格;

            }
            l_code主檔.f_TotalPrice總計價格 = l_int總計價格;


            int l_intcount = (l_code主檔.明細.Length / 10);//一頁10筆，總列印頁整數數

            if (l_code主檔.明細.Length % 10 != 0)//最後一頁未滿10筆的，要再加1頁
            {
                l_intcount++;
            }
            return 組HTML(l_code主檔, l_intcount);
        }

        private string get列印領料單Html(string p_strEID)
        {
            string l_str助理員編 = (Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser).f_userid帳號;//"H9503";// 

            CKGPartOrderFactory l_factory主檔 = _context.CFactoryManager.CKGPartOrderFactory;
            CKGPartOrder l_code主檔 = l_factory主檔.getKGPartOrderBy請購單號(p_strEID, l_str助理員編);

            if (l_code主檔 != null)
            {
                l_code主檔.明細 = _context.CFactoryManager.CKGPartOrderDetailFactory.get請購明細ByExchangeID(p_strEID);

                int l_intcount = (l_code主檔.明細.Length / 10);//一頁10筆，總列印頁整數數

                if (l_code主檔.明細.Length % 10 != 0)//最後一頁未滿10筆的，要再加1頁
                {
                    l_intcount++;
                }

                return 組HTML(l_code主檔, l_intcount);
            }
            else
            {
                return "<font size=\"5\"><b>查無資料!!</b>";
            }
        }

        private string 組HTML(CKGPartOrder p_code主檔, int p_int總頁數)
        {
            if (p_int總頁數 < 1)
            {
                string l_str = set頁首資訊(p_code主檔);

                for (int i = 0; i < p_code主檔.明細.Length; i++)
                {
                    if (i == 0)
                    {
                        l_str += 組TR(p_code主檔.明細[i], p_code主檔.f_Memo備註說明);
                    }
                    else
                    {
                        l_str += 組TR(p_code主檔.明細[i], "");
                    }
                }

                //不足一頁10筆資料的剩餘空格用空白補完
                for (int i = p_code主檔.明細.Length; i < 10; i++)
                {
                    l_str += 組TR(new CKGPartOrderDetail(), "");
                }
                l_str += set頁尾資訊(p_code主檔.f_TotalPrice總計價格, p_code主檔.f_TotalSale總販賣價);
                return l_str;
            }
            else
            {
                string l_strSubstring = "";

                for (int i = 0; i < p_int總頁數; i++)
                {
                    string l_str = "";
                    l_str += set頁首資訊(p_code主檔);

                    //最後一頁
                    if (i == (p_int總頁數 - 1))
                    {
                        for (int j = i * 10; j < p_code主檔.明細.Length; j++)
                        {
                            if (j == i * 10)
                            {
                                l_str += 組TR(p_code主檔.明細[j], p_code主檔.f_Memo備註說明);
                            }
                            else
                            {
                                l_str += 組TR(p_code主檔.明細[j], "");
                            }
                        }

                        //不足一頁10筆資料的剩餘空格用空白補完
                        for (int a = (p_code主檔.明細.Length % 10); a < 10; a++)
                        {
                            l_str += 組TR(new CKGPartOrderDetail(), "");
                        }
                        CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;
                        if (l_user == null)
                        {
                            Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
                            Response.Redirect("../FrmLogin.aspx");
                        }
                        if (l_user.f_lvl等級 == 4)
                        {
                            l_str += set頁尾資訊(p_code主檔.f_TotalPrice總計價格,p_code主檔.f_TotalSale總販賣價);
                        }
                        else
                        {
                            l_str += set頁尾資訊(p_code主檔.f_TotalPrice總計價格, p_code主檔.f_TotalSale總販賣價);
                        }
                        l_str += "<hr>";
                        l_str += l_str;
                        l_strSubstring += l_str.Substring(0, l_str.LastIndexOf("<hr>"));
                        return l_strSubstring;
                    }

                    //用總頁數次數來判斷跑到第幾分頁
                    //k:明細檔的第k筆; i:第i分頁  乘10代表第i分頁的起始到第i分頁的結束(每次範圍都10筆)
                    for (int k = i * 10; k < i * 10 + 10; k++)
                    {
                        if (k == i * 10)
                        {
                            l_str += 組TR(p_code主檔.明細[k], p_code主檔.f_Memo備註說明);
                        }
                        else
                        {
                            l_str += 組TR(p_code主檔.明細[k], "");
                        }
                    }

                    CUser l_user1 = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;
                    if (l_user1 == null)
                    {
                        Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
                        Response.Redirect("../FrmLogin.aspx");
                    }
                    if (l_user1.f_lvl等級 == 4)
                    {
                        l_str += set頁尾資訊(p_code主檔.f_TotalPrice總計價格,p_code主檔.f_TotalSale總販賣價);
                    }
                    else
                    {
                        l_str += set頁尾資訊(p_code主檔.f_TotalPrice總計價格, p_code主檔.f_TotalSale總販賣價);
                    }

                   
                    l_str += "<hr>";
                    l_str += l_str;
                    l_str += "<div><P></P></div>";
                    l_strSubstring = l_str.Substring(0, l_str.LastIndexOf("<hr>"));

                }
                return l_strSubstring;
            }
        }

        private string 塞空白字串(string p_str)
        {
            if ("".Equals(p_str))
            {
                return "&nbsp;";
            }
            return p_str;
        }

        private string 組TR(CKGPartOrderDetail p_code明細, string p_strMemo)
        {
            string l_str = "  <tr>";
            l_str += "    <td colspan=\"2\" style=\"border-style:solid; border-width:1px; font-size: 10pt\" width=\"182\" bordercolor=\"#000000\" align=\"center\">";
            l_str += "        " + 塞空白字串(p_code明細.f_ProductID產品編號) + "</td>";
            l_str += "     <td colspan=\"4\" style=\"border-style:solid; border-width:1px; font-size: 10pt\" bordercolor=\"#000000\" align=\"center\">";
            l_str += "          " + 塞空白字串(p_code明細.f_ProductName產品名稱) + "</td>";
            l_str += "     <td style=\"border-style:solid; border-width:1px; font-size: 10pt; width: 36px\" bordercolor=\"#000000\" align=\"center\">";
            
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;
            if (l_user == null)
            {
                Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
                Response.Redirect("../FrmLogin.aspx");
            }
            if (l_user.f_lvl等級 == 4)
            {
                l_str += "          (" + 塞空白字串(p_code明細.f_SalePrice販賣價.ToString()) + ")" + p_code明細.f_UnitPrice產品單價.ToString() + "</td>";
            }
            else
            {
                l_str += "          " + 塞空白字串(p_code明細.f_UnitPrice產品單價.ToString()) + "(" + p_code明細.f_SalePrice販賣價.ToString() + ")" + "</td>";
            }
            
            l_str += "     <td style=\"border-style:solid; border-width:1px; font-size: 10pt; width: 42px\" bordercolor=\"#000000\" align=\"center\">";
            l_str += "         " + 塞空白字串(p_code明細.f_Amount選購數量.ToString()) + "</td>";
            l_str += "    <td style=\"border-style:solid; border-width:1px; font-size: 10pt; width: 36px\" bordercolor=\"#000000\" align=\"center\">";
            l_str += "         (" + 塞空白字串(p_code明細.f_Total總計價格.ToString()) + ")" + 塞空白字串((p_code明細.f_UnitPrice產品單價 * p_code明細.f_Amount選購數量).ToString()) + "</td>";
            if (!"".Equals(p_strMemo))
            {
                l_str += "     <td colspan=\"2\" style=\"border-style:solid; border-width:1px; font-size: 10pt\" rowspan=\"11\" bordercolor=\"#000000\" align=\"center\">";
                l_str += "          " + p_strMemo + "</td>";
            }
            l_str += "  </tr>";
            return l_str;
        }
        private string set頁首資訊(CKGPartOrder p_code)
        {
            string l_strTitle = "";
            string l_str退請購日期 = "";
            if ("Buy".Equals(Request["Type"]))
            {
                l_strTitle = "高輊公司小百貨領料單";
                l_str退請購日期 = "請購日期";
            }
            else
            {
                l_strTitle = "高輊公司小百貨退貨單";
                l_str退請購日期 = "退貨日期";
            }
            string l_str = "<body>";
            l_str += "<br />";
            l_str += "<br />";
            l_str += "<br />";
            l_str += "<br />";
            l_str += "<table border=\"1\" cellpadding=\"0\" cellspacing=\"0\" style=\"width: 720px; border-left-width:0px; border-right-width:0px; border-top-width:0px\">";
            l_str += "  <tr>";
            l_str += "       <td colspan=\"11\" style=\"border-style:none; border-width:medium; font-size: 24pt; text-align: center\">";
            l_str += "       " + l_strTitle + "</td>";
            l_str += "  </tr>";
            l_str += " <tr>";
            l_str += "     <td colspan=\"11\" style=\"border-style:none; border-width:medium; font-size: 14pt; text-align: center\">";
            l_str += "        　</td>";
            l_str += "      </tr>";
            l_str += "    <tr>";
            l_str += "        <td style=\"border-style:none; border-width:medium; font-size: 10pt\" width=\"85\" align=\"center\" bordercolor=\"#000000\">";
            l_str += "            <font size=\"3\">請購單號：</font></td>";
            l_str += "        <td style=\"border-style:none; border-width:medium; font-size: 10pt\" width=\"100\" align=\"center\" bordercolor=\"#000000\">";
            l_str += "           <font size=\"3\">" + p_code.f_ExchangeID請購單號 + "</font></td>";
            l_str += "       <td style=\"border-style:none; border-width:medium; font-size: 10pt\" width=\"52\" align=\"center\" bordercolor=\"#000000\">";
            l_str += "           <font size=\"3\">單位：</font></td>";
            CUser l_user = _context.CFactoryManager.CUserFactory.get高都員工檔(p_code.f_SalesSmid業代員編);
            l_str += "      <td colspan=\"2\" style=\"border-style:none; border-width:medium; font-size: 10pt\" align=\"center\" bordercolor=\"#000000\">";
            l_str += "          <font size=\"3\">" + l_user.f_branchid所別 + "</font></td>";
            l_str += "      <td style=\"border-style:none; border-width:medium; font-size: 10pt\" width=\"82\" align=\"center\" bordercolor=\"#000000\">";
            l_str += "           <font size=\"3\">業代員編：</font></td>";
            l_str += "       <td style=\"border-style:none; border-width:medium; font-size: 10pt\" colspan=\"3\" align=\"center\" bordercolor=\"#000000\">";
            l_str += "          <font size=\"3\">" + p_code.f_SalesSmid業代員編 + "</font></td>";
            l_str += "      <td style=\"border-style:none; border-width:medium; font-size: 10pt\" width=\"81\" align=\"center\" bordercolor=\"#000000\">";
            l_str += "           <font size=\"3\">姓名：</font></td>";
        
            l_str += "      <td style=\"border-style:none; border-width:medium; font-size: 10pt\" width=\"78\" align=\"center\" bordercolor=\"#000000\">";
            l_str += "          <font size=\"3\">" + l_user.f_username姓名 + "</font></td>";
            l_str += "  </tr>";
            l_str += "  <tr>";
            l_str += "      <td style=\"font-size: 10pt; border-left-style:none; border-left-width:medium; border-right-style:none; border-right-width:medium; border-top-style:none; border-top-width:medium\" width=\"85\" align=\"center\" bordercolor=\"#000000\">";
            l_str += "         <font size=\"3\">引擎號碼：</font></td>";
            l_str += "      <td style=\"font-size: 10pt; border-left-style:none; border-left-width:medium; border-right-style:none; border-right-width:medium; border-top-style:none; border-top-width:medium\" width=\"100\" align=\"center\" bordercolor=\"#000000\">";
            l_str += "         <font size=\"3\">" + 塞空白字串(p_code.f_EngineNo引擎號碼) + "</font></td>";
            l_str += "     <td style=\"font-size: 10pt; border-left-style:none; border-left-width:medium; border-right-style:none; border-right-width:medium; border-top-style:none; border-top-width:medium\" width=\"52\" align=\"center\" bordercolor=\"#000000\">";
            l_str += "         <font size=\"3\">車型：</font></td>";
            l_str += "     <td style=\"font-size: 10pt; border-left-style:none; border-left-width:medium; border-right-style:none; border-right-width:medium; border-top-style:none; border-top-width:medium\" width=\"106\" align=\"center\" bordercolor=\"#000000\">";
            l_str += "　</td>";
            l_str += "   <td colspan=\"2\" style=\"font-size: 10pt; border-left-style:none; border-left-width:medium; border-right-style:none; border-right-width:medium; border-top-style:none; border-top-width:medium\" align=\"center\" bordercolor=\"#000000\">";
            l_str += "        <font size=\"3\">SFX：</font></td>";
            l_str += "    <td style=\"font-size: 10pt; border-left-style:none; border-left-width:medium; border-right-style:none; border-right-width:medium; border-top-style:none; border-top-width:medium; border-bottom-style:solid; border-bottom-width:1px\" colspan=\"3\" align=\"center\" bordercolor=\"#000000\">";
            l_str += "       　</td>";
            l_str += "    <td style=\"font-size: 10pt; border-left-style:none; border-left-width:medium; border-right-style:none; border-right-width:medium; border-top-style:none; border-top-width:medium\" width=\"81\" align=\"center\" bordercolor=\"#000000\">";
            l_str += "        <font size=\"3\">" + l_str退請購日期 + "：</font></td>";
            l_str += "     <td style=\"font-size: 10pt; border-left-style:none; border-left-width:medium; border-right-style:none; border-right-width:medium; border-top-style:none; border-top-width:medium\" width=\"78\" align=\"center\" bordercolor=\"#000000\">";
            l_str += "          <font size=\"3\">" + p_code.f_InsertDate請購日期 + "</font></td>";
            l_str += "   </tr>";
            l_str += "    <tr>";
            l_str += "     <td colspan=\"2\" style=\"border-style:solid; border-width:1px; font-size: 10pt\" width=\"182\" align=\"center\" bordercolor=\"#000000\">";
            l_str += "         <font size=\"3\">產品編號</font></td>";
            l_str += "      <td colspan=\"4\" style=\"border-style:solid; border-width:1px; font-size: 10pt\" align=\"center\" bordercolor=\"#000000\">";
            l_str += "        <font size=\"3\">產品名稱</font></td>";
            l_str += "   <td style=\"border-style:solid; border-width:1px; width: 36px; text-align: center\" bordercolor=\"#000000\">";
            l_str += "        單價</td>";
            l_str += "     <td style=\"border-style:solid; border-width:1px; width: 42px; text-align: center\" bordercolor=\"#000000\">";
            l_str += "        數量</td>";
            l_str += "     <td style=\"border-style:solid; border-width:1px; width: 36px; text-align: center\" bordercolor=\"#000000\">";
            l_str += "        金額</td>";
            l_str += "      <td colspan=\"2\" style=\"border-style:solid; border-width:1px; font-size: 10pt\" align=\"center\" bordercolor=\"#000000\">";
            l_str += "         <font size=\"3\">備註</font></td>";
            l_str += "  </tr>";

            return l_str;
        }
        private string set頁尾資訊(int p_int總計,int p_int販賣價總計)
        {
            string l_str = "  <tr>";
            l_str += "     <td colspan=\"8\" style=\"border-style:solid; border-width:1px; font-size: 10pt\" height=\"17\" bordercolor=\"#000000\">";
            l_str += "        &nbsp;  總計</td>";
            l_str += "     <td style=\"font-size: 10pt; width: 36px; border-left-style:solid; border-left-width:1px; border-top-style:solid; border-top-width:1px; border-bottom-style:solid; border-bottom-width:1px\" height=\"17\" bordercolor=\"#000000\" align=\"center\">";
            l_str += "        (" + p_int販賣價總計 + ")" + p_int總計 + "</td>";
            l_str += "  </tr>";
            l_str += " </table>";
            l_str += " <br />";
            l_str += " 業代簽名：<u>&nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp; &nbsp;  &nbsp;</u> &nbsp; &nbsp; &nbsp; &nbsp;";
            l_str += " 營業所助理：<u>&nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp; &nbsp;  &nbsp;</u> &nbsp; &nbsp; &nbsp; &nbsp;";
            l_str += " 主管審核：<u>&nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp; &nbsp;  &nbsp;</u> &nbsp; &nbsp; &nbsp; &nbsp;";
            l_str += "<br />";
            l_str += "<br />";
            l_str += "<br />";
            l_str += "<br />";
            l_str += "</body>";
            return l_str;
        }
    }
}
