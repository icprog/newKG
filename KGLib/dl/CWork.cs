using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tw.com.kg.lib
{
    public class CWork
    {
        public string f_workid工單單號 { get; set; }
        public string f_engo引擎號碼 { get; set; }

        /// <summary>
        /// 新車是輸入員編
        /// </summary>
        public string f_customerid顧客名稱 { get; set; }

        public string f_workType洗車種類 { get; set; }
        public int f_money金額 { get; set; }
        public string f_memo備註 { get; set; }
        public string f_edituser開單人員 { get; set; }
        public string f_editdate開單日期 { get; set; }

        /// <summary>
        /// Y:是,N:否
        /// </summary>
        public string f_closeDate完工日 { get; set; }

        /// <summary>
        /// 員編
        /// </summary>
        public string f_introducer介紹人 { get; set; }

        /// <summary>
        /// 所,廠
        /// </summary>
        public string f_type工單種類 { get; set; }

        public string f_insuranceid保險代碼 { get; set; }
        public string f_insurancetype保險型態 { get; set; }

        public string f_staus狀態 { get; set; }
        public string f_branchid工單所別 { get; set; }


        public CConstruction[] tb施工人員業績 { get; set; }

        public string f_seruser服務專員 { get; set; }
    }
}
