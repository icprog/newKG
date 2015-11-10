using System;
using System.Collections.Generic;
using System.Text;

namespace tw.com.kg.lib
{
    public class CKGPoint
    {
        public static string TypeName
        {
            get { return "tw.com.yyt.epaper.lib.dl.CKGPoint"; }
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


        private int iv_intf_Point現有點數 = 0;
        public int f_Point現有點數
        {
            get { return iv_intf_Point現有點數; }
            set { iv_intf_Point現有點數 = value; }
        }
    }
}