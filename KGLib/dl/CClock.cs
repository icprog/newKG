using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tw.com.kg.lib
{
    public class CClock
    {
        public int ID流水號 { get; set; }
        public string EMPLOYEE_ID員編 { get; set; }
        public string EMPLOYEE_EIP轉碼員編 { get; set; }
        public DateTime DATE_TIME出勤時間 { get; set; }
        public string TERMINAL_ID卡鐘號碼 { get; set; }
        public string VERIFICATION_SOURCE進出方式 { get; set; }
    }
}
