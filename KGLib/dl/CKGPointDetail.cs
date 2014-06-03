using System;
using System.Collections.Generic;
using System.Text;

namespace tw.com.kg.lib
{
    public class CKGPointDetail
    {
        public static string TypeName
        {
            get { return "tw.com.yyt.epaper.lib.dl.CKGPointDetail"; }
        }
        private int iv_intf_id = 0;
        public int f_id
        {
            get { return iv_intf_id; }
            set { iv_intf_id = value; }
        }

        private string iv_strf_Smid業代員編 = "";
        public string f_Smid業代員編
        {
            get { return iv_strf_Smid業代員編; }
            set { iv_strf_Smid業代員編 = value; }
        }

        private string iv_strf_Name業代姓名 = "";
        public string f_Name業代姓名
        {
            get { return iv_strf_Name業代姓名; }
            set { iv_strf_Name業代姓名 = value; }
        }

        private int iv_intf_ImportPoint匯入點數 = 0;
        public int f_ImportPoint匯入點數
        {
            get { return iv_intf_ImportPoint匯入點數; }
            set { iv_intf_ImportPoint匯入點數 = value; }
        }

        private string iv_strf_ImportDate匯入日期 = "";
        public string f_ImportDate匯入日期
        {
            get { return iv_strf_ImportDate匯入日期; }
            set { iv_strf_ImportDate匯入日期 = value; }
        }

        private string iv_strf_ImportSmid匯入人員員編 = "";
        public string f_ImportSmid匯入人員員編
        {
            get { return iv_strf_ImportSmid匯入人員員編; }
            set { iv_strf_ImportSmid匯入人員員編 = value; }
        }

        private string iv_strf_ImportName匯入人員姓名 = "";
        public string f_ImportName匯入人員姓名
        {
            get { return iv_strf_ImportName匯入人員姓名; }
            set { iv_strf_ImportName匯入人員姓名 = value; }
        }

        private string iv_strf_ImportType匯入方式 = "";
        public string f_ImportType匯入方式
        {
            get { return iv_strf_ImportType匯入方式; }
            set { iv_strf_ImportType匯入方式 = value; }
        }

        private string iv_strf_InvoiceNo發票號碼 = "";
        public string f_InvoiceNo發票號碼
        {
            get { return iv_strf_InvoiceNo發票號碼; }
            set { iv_strf_InvoiceNo發票號碼 = value; }
        }

        private string iv_strf_PayBank刷卡銀行 = "";
        public string f_PayBank刷卡銀行
        {
            get { return iv_strf_PayBank刷卡銀行; }
            set { iv_strf_PayBank刷卡銀行 = value; }
        }

        private int iv_intf_BankCharge手續費 = 0;
        public int f_BankCharge手續費
        {
            get { return iv_intf_BankCharge手續費; }
            set { iv_intf_BankCharge手續費 = value; }
        }
        private string iv_strf_InMoneyBank入帳銀行 = "";
        public string f_InMoneyBank入帳銀行
        {
            get { return iv_strf_InMoneyBank入帳銀行; }
            set { iv_strf_InMoneyBank入帳銀行 = value; }
        }


        //查詢使用
        private string iv_strBranch所別 = "";
        public string Branch所別
        {
            get { return iv_strBranch所別; }
            set { iv_strBranch所別 = value; }
        }

    }
}