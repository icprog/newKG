using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tw.com.kg.lib
{
    public class C各廠介紹獎金
    {

        public string 據點 { get; set; }
        public int 一般業績 { get; set; }
        public int 保險業績 { get; set; }
        public double 一般獎金 { get; set; }
        public double 保險獎金 { get; set; }


        //明細
        public string 開單日期 { get; set; }
        public string 工單號碼 { get; set; }
        public string 引擎號碼 { get; set; }
        public string 洗車種類 { get; set; }
        public int 金額 { get; set; }
        public string 介紹人 { get; set; }
        public string 工單類型 { get; set; }
        public string 保險公司 { get; set; }
        public string 開單人員 { get; set; }
        public string 名稱 { get; set; }

    }
}
