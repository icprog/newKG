using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tw.com.kg.lib
{
    public class CSatisfaction
    {
        public int f_id { get; set; }
        public string f_branchid施工地點 { get; set; }
        public string f_car車牌 { get; set; }
        public string f_smid業代 { get; set; }
        public string f_date時間 { get; set; }


        public int f_glassclean玻璃清潔 { get; set; }
        public int f_dirtpaint漆面髒汙 { get; set; }
        public int f_waxfinish漆面打蠟 { get; set; }
        public int f_engineroom引擎室 { get; set; }
        public int f_tirerims輪胎鋼圈 { get; set; }
        public int f_leather皮椅 { get; set; }
        public int f_dashboard儀錶板 { get; set; }
        public int f_carpet地毯清潔 { get; set; }
        public int f_gadget小配件 { get; set; }
        public int f_deliverytime交車時間 { get; set; }
        public string f_memo備註 { get; set; }
    }
}
