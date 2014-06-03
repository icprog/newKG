using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tw.com.kg.lib
{
    public class C欠款紀錄
    {
        public string 據點 { get; set; }
        public string 業編 { get; set; }
        public string 名稱 { get; set; }
        public string 金額 { get; set; }
        public string 剩餘點數 { get; set; }


        //明細
        public string 單號 { get; set; }
        public string 帳款日期 { get; set; }
        public string 備註 { get; set; }
        public string 總類 { get; set; }

        //2013/05/20 新增顧客姓名欄位
        public string 顧客姓名 { get; set; }


    }
}
