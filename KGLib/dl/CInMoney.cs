using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tw.com.kg.lib
{
    public class CInMoney
    {
        public string f_moneyid應收單號 { get; set; }
        public string f_workid工單單號 { get; set; }
        public int f_money應收金額 { get; set; }
        public string f_editdate帳款日期 { get; set; }

        /// <summary>
        /// Y:已沖,N:未沖
        /// </summary>
        public string f_isclose是否關帳 { get; set; }

        public int f_yesmoney已沖金額 { get; set; }
        public string f_smid帳款人 { get; set; }
        public string f_memo備註 { get; set; }

        /// <summary>
        /// 洗車,小百貨
        /// </summary>
        public string f_type種類 { get; set; }


        public string f_smid員工名稱 { get; set; }
    }
}
