using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Text;
using System.Collections;
using tw.com.yj.CommonLib;
using System.Net;

namespace tw.com.kg.lib
{
    
    /// <summary>
    /// CKGPartOrderMail 的摘要描述
    /// </summary>
    public class CKGPartOrderMail : YJCCommonFactory
    {
        public CKGPartOrderMail(YJCommonContext p_context)
        {
            setContext(p_context);
        }
        /// <summary>
        /// MailServer的名稱
        /// </summary>
        private string iv_strMailServer = "10.16.99.26";
        /// <summary>
        /// 寄件者
        /// </summary>
        private string iv_strMailFrom = "96002@toyota-kd.com.tw";
        /// <summary>
        /// 寄件者發送名稱
        /// </summary>
        private string iv_MailToDisplayName = "高輊汽車";
        
        public string iv_strMailTo收件者 = "";
        
        public MailMessage l_mail;
        public void 設定Mail(string p_str請購單位, CKGPartOrder p_codes)
        {

            iv_strMailTo收件者 = "";
            string iv_strMailTo收件者_備份 = "";
            l_mail = new MailMessage();
            if ("KC".Equals(p_codes.f_Vendor請購廠商) || "KCF".Equals(p_codes.f_Vendor請購廠商) || "KCF".Equals(p_codes.f_Vendor請購廠商) || "亙長".Equals(p_codes.f_Vendor請購廠商))
            {
                iv_strMailTo收件者 = "kcd.k4337@msa.hinet.net";
                iv_strMailTo收件者_備份 = "kengchang4337@gmail.com";
            }
            else if ("PDS".Equals(p_codes.f_Vendor請購廠商) || "PDS".Equals(p_codes.f_Vendor請購廠商))
            {
                //iv_strMailTo收件者 = "kdp07@toyota-kd.com.tw";
                //l_mail.To.Add("kdp032@toyota-kd.com.tw");
                //l_mail.To.Add("kdp12@toyota-kd.com.tw");
                //l_mail.To.Add("kdp122@toyota-kd.com.tw");
                //l_mail.To.Add("kdp121@toyota-kd.com.tw");
            }
            else if ("HM".Equals(p_codes.f_Vendor請購廠商) || "惠明".Equals(p_codes.f_Vendor請購廠商))
            {
                iv_strMailTo收件者 = "hui.mi@msa.hinet.net";
            }
            else
            {
                iv_strMailTo收件者 = "hsieh.ta@msa.hinet.net";
                iv_strMailTo收件者_備份 = "hsiehta291@gmail.com";
            }

            l_mail.From = new MailAddress(this.iv_strMailFrom, this.iv_MailToDisplayName);
            l_mail.To.Add(iv_strMailTo收件者);
            l_mail.Bcc.Add(iv_strMailTo收件者_備份);
            l_mail.Bcc.Add("afb1201@toyota.com.tw");
            l_mail.Subject = "小百貨訂貨單(" + DateTime.Today.ToString("yyyy/MM/dd") + ")由 " + get轉換據點中英文(p_str請購單位) + " 傳來，訂單編號：" + p_codes.f_ExchangeID請購單號 + " ，引擎號碼：" + p_codes.f_EngineNo引擎號碼;
            l_mail.SubjectEncoding = Encoding.Default;
            l_mail.IsBodyHtml = true;
            l_mail.BodyEncoding = Encoding.Default;
            l_mail.Body = set訂單內容(p_codes);
        }

        public void 發送Mail()
        {
            SmtpClient sc = new SmtpClient(this.iv_strMailServer);
            sc.Send(l_mail);
        }

        private string set訂單內容(CKGPartOrder p_codes)
        {
            //CKGPartOutOrderFactory l_factory訂單主檔 = new CKGPartOutOrderFactory(iv_context);
            //CKGPartOutOrder l_code訂單主檔 = l_factory訂單主檔.get訂單資料By編號(p_strBID);

            //CKGPartOutOrderDetailFactory l_factory訂單明細檔 = new CKGPartOutOrderDetailFactory(iv_context);
            //CKGPartOutOrderDetail[] l_codes = l_factory訂單明細檔.get明細By訂單編號(p_strBID);

            CKGPartOrderFactory l_factory主檔 = new CKGPartOrderFactory(ivContext);
            CKGPartOrder l_code主檔 = new CKGPartOrder();
            string l_strHtml = "";

            l_code主檔 = p_codes;
            l_code主檔.明細 = new CKGPartOrderDetailFactory(ivContext).get請購明細ByExchangeID(l_code主檔.f_ExchangeID請購單號);
           
                l_strHtml += set頁首(l_code主檔.f_Vendor請購廠商, l_code主檔.f_Branchid請購單位, l_code主檔.f_Memo備註說明);
           
            l_strHtml += 組Html(l_code主檔);
          

            return l_strHtml;
        }

        private string 組Html(CKGPartOrder p_code請購主檔)
        {
            string l_str = set表頭資訊(p_code請購主檔);

            for (int i = 0; i < p_code請購主檔.明細.Length; i++)
            {
                if (i == 0)
                {
                    l_str += 組TR(p_code請購主檔.明細[i], p_code請購主檔.f_Memo備註說明, i + 1);
                }
                else
                {
                    l_str += 組TR(p_code請購主檔.明細[i], "", i + 1);
                }
            }
            l_str += "</table>";
            l_str += "<br />";
            l_str += "<br />";
            l_str += "<br />";
            l_str += "<br />";
            l_str += " </body>";
            return l_str;
        }

        private string 塞空白字串(string p_str)
        {
            if ("".Equals(p_str))
            {
                return "&nbsp;";
            }
            return p_str;
        }

        private string 組TR(CKGPartOrderDetail p_code明細, string p_strMemo,int l_int項次)
        {
            string l_str = "  <tr>";

            l_str += " <td style=\"width: 50px\" align=\"center\">";
            l_str += "     " + l_int項次.ToString() + "</td>";
            l_str += "  <td style=\"width: 225px\">";
            l_str += "      " + 塞空白字串(p_code明細.f_ProductID產品編號) + "</td>";
            l_str += "  <td style=\"width: 355px\">";
            l_str += "   " + 塞空白字串(p_code明細.f_ProductName產品名稱) + "</td>";
            l_str += "  <td style=\"width: 56px\" align=\"center\">";
            l_str += "     " + 塞空白字串(p_code明細.f_Amount選購數量.ToString()) + "</td>";
            if (!"".Equals(p_strMemo))
            {
                l_str += "  <td rowspan=\"30\" style=\"width: 100px\" valign=\"top\">";
                l_str += "     " + 塞空白字串(p_strMemo) + "</td>";
            }
            l_str += "  </tr>";

            return l_str;
        }
        private string set表頭資訊(CKGPartOrder p_code)
        {
            string l_str廠商 = "";
            if ("KC".Equals(p_code.f_Vendor請購廠商) || "KCS".Equals(p_code.f_Vendor請購廠商) || "KCF".Equals(p_code.f_Vendor請購廠商))
                l_str廠商 = "亙長企業有限公司";
            else if ("LD".Equals(p_code.f_Vendor請購廠商) || "LDS".Equals(p_code.f_Vendor請購廠商) || "LDF".Equals(p_code.f_Vendor請購廠商))
                l_str廠商 = "劦大企業有限公司";
            else if ("HM".Equals(p_code.f_Vendor請購廠商))
                l_str廠商 = "惠明企業有限公司";
            else
                l_str廠商 = "";

            string l_str = "";
            l_str += " <table style=\"width: 720px\" cellspacing=\"0\" >";
            l_str += "   <tr>";
            l_str += "        <td colspan=\"6\" style=\"font-weight: bold; font-size: 24pt;\" align=\"center\">";
            l_str += "            高輊汽車小百貨訂貨單</td>";
            l_str += "   </tr>";
            l_str += "   <tr>";
            l_str += "       <td colspan=\"6\">&nbsp;";
            l_str += "       </td>";
            l_str += "   </tr>";
            l_str += "   <tr>";
            l_str += "       <td style=\"width: 85px; font-size: 11pt;\" align=\"center\">";
            l_str += "          訂購單號：</td>";
            l_str += "      <td style=\"width: 121px\">";
            l_str += "      " + p_code.f_ExchangeID請購單號 + "</td>";
            l_str += "      <td style=\"width: 85px; font-size: 11pt;\" align=\"center\">";
            l_str += "         訂購日期：</td>";
            l_str += "     <td style=\"width: 100px; font-size: 11pt;\">";
            l_str += "    " + p_code.f_InsertDate請購日期 + "</td>";
            l_str += "    <td style=\"width: 75px; font-size: 11pt;\"align=\"center\">";
            l_str += "         經辦人：</td>";
            l_str += "     <td style=\"width: 100px\">";
            CUser l_user = new CUserFactory(ivContext).get高都員工檔(p_code.f_AssistantSmid助理員編);
            //l_str += "      " + p_code.f_AssistantName助理姓名 + "</td>";
            if (l_user != null)
            {
                l_str += "      " + l_user.f_username姓名 + "</td>";
            }
            else
            {
                l_str += "      </td>";
            }

            l_str += "  </tr>";
            l_str += "  <tr>";
            l_str += "  <td align=\"center\" style=\"font-size: 11pt; width: 85px\">";
            l_str += "     請購編號：</td>";
            l_str += "  <td style=\"width: 121px\">";
            l_str += "    " + p_code.f_ExchangeID請購單號 + "  </td>";
            l_str += "  <td align=\"center\" style=\"width: 85px\">";
            l_str += "  </td>";
            l_str += "  <td style=\"width: 100px\">";
            l_str += "  </td>";
            l_str += "  <td style=\"width: 75px; font-size: 11pt;\"align=\"center\">";
            l_str += "     請購者：</td>";
            l_str += "<td style=\"width: 100px\">";
            CUser l_user業代 = new CUserFactory(ivContext).get高都員工檔(p_code.f_SalesSmid業代員編);
            if (l_user業代 == null)
            {
                l_str += "   </td>";
            }
            else
            {
                l_str += "   " + l_user業代.f_username姓名 + "  </td>";
            }
            
            //l_str += "   " + p_code.f_SalesName業代姓名 + "  </td>";
            l_str += "  </tr>";


            l_str += "  <tr>";
            l_str += "      <td style=\"width: 85px; font-size: 11pt;\" align=\"center\">";
            l_str += "          廠商對象：</td>";
            l_str += "     <td colspan=\"2\">";
            l_str += "     " + l_str廠商 + "</td>";
            l_str += "   <td style=\"width: 100px; font-size: 11pt;\" align=\"center\">";
            l_str += "      傳送時間：</td>";
            l_str += "   <td colspan=\"2\">";
            l_str += "   " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "</td>";
            l_str += "  </tr>";
            l_str += " </table>";
            l_str += "  <table style=\"width: 720px;\" border=\"1\" bordercolor=\"black\" cellspacing=\"0\">";
            l_str += "  <tr>";
            l_str += "   <td style=\"width: 50px\" align=\"center\">";
            l_str += "       項次</td>";
            l_str += "   <td style=\"width: 200px\" align=\"center\">";
            l_str += "       產品編號</td>";
            l_str += "    <td style=\"width: 320px\" align=\"center\">";
            l_str += "        產品名稱</td>";
            l_str += "    <td style=\"width: 50px\" align=\"center\">";
            l_str += "       數量</td>";
            l_str += "   <td style=\"width: 100px\" align=\"center\">";
            l_str += "        備註</td>";
            l_str += "   </tr>";

            return l_str;
        }

        private string set頁首(string p_str廠商,string p_str訂購單位,string p_str訂單備註)
        {
            string l_str廠商 = "";
            if ("KC".Equals(p_str廠商) || "KCS".Equals(p_str廠商) || "KCF".Equals(p_str廠商))
                l_str廠商 = "亙長企業有限公司";
            else if ("LD".Equals(p_str廠商) || "LDS".Equals(p_str廠商) || "LDF".Equals(p_str廠商))
                l_str廠商 = "劦大企業有限公司";
            else if ("HM".Equals(p_str廠商))
                l_str廠商 = "惠明企業有限公司";
            else
                l_str廠商 = "";
            
            string l_str = "<body>";
            l_str += l_str廠商 + "  &nbsp;您好：<br />";
            l_str += " &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;以下是高輊汽車公司， <font color=\"blue\"><b>" + get轉換據點中英文( p_str訂購單位) + "</b></font> 向貴公司所訂購的小百貨明細，請在收到訂貨單時，<br />";
            l_str += " &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; 儘速派員配送至本公司進行點收完成訂貨程序。如有問題請聯絡經辦人員<br />";
            l_str += " &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; <font color=\"red\">※本信件為高輊小百貨訂貨系統發送自動信件，請勿直接回覆※</font><br />";
            l_str += "<br />";
            l_str += "本次訂購單備註為：<font color=\"blue\">" + p_str訂單備註 + "</font>";
            l_str += "<hr>";
            l_str += "<br />";
            l_str += "<br />";
            
            return l_str;
        }
        public string get轉換據點中英文(string p_strBranchid)
        {

            switch (p_strBranchid)
            {
                case "F03": return "岡山";
                case "F03S": return "岡山廠";
                case "F04": return "屏東";
                case "F04S": return "屏東廠";
                case "F07": return "北高";
                case "F07S": return "北高廠";
                case "F08": return "旗山";
                case "F08S": return "旗山廠";
                case "F09": return "潮州";
                case "F09S": return "潮州廠";
                case "F10": return "小港";
                case "F10S": return "小港廠";
                case "F11": return "九如";
                case "F11S": return "九如廠";
                case "F12": return "鳳山";
                case "F12S": return "鳳山廠";
                case "F13": return "湖內";
                case "F13S": return "湖內廠";
                case "F14": return "北屏";
                case "F14S": return "北屏廠";
                case "F15": return "青年";
                case "F15S": return "青年廠";
                case "F16": return "楠梓";
                case "F16S": return "楠梓廠";
                case "F17": return "瑞豐";
                case "F17S": return "瑞豐廠";
                case "F19": return "麟洛";
                case "F19S": return "麟洛廠";
                case "F18": return "右昌";
                case "F18S": return "右昌廠";
                case "F20": return "東港";
                case "F20S": return "東港廠";
                case "F21S": return "里港廠";
                case "F22": return "鳳林";
                case "F22S": return "鳳林廠";
                case "F24S": return "恆春廠";
                case "F27": return "三多";
                case "F27S": return "三多廠";
                case "F51": return "中華";
                case "F51S": return "中華廠";
                case "F52": return "民族";
                case "F52S": return "民族廠";
                case "F53": return "建國";
                case "F53S": return "建國廠";
                case "F71": return "明誠";
                case "F72": return "澄清";
                case "KG": return "高輊";
                default: return "";
            }
        }
    }
}
