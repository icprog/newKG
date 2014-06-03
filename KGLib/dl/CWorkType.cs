using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tw.com.kg.lib
{
    public class CWorkType
    {
        public string f_typeid洗車種類代碼 { get; set; }
        public string f_typename洗車種類名稱 { get; set; }
        public int f_money價錢 { get; set; }
        public int f_moneyBySmid員工價 { get; set; }
        public int f_moneyByIn內部員工薪資 { get; set; }
        public int f_moneyByOut外部員工薪資 { get; set; }
        public double f_boundByService服務獎金數 { get; set; }
        public double f_boundBySmid業代獎金數 { get; set; }
    }
}
