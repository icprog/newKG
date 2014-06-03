using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tw.com.yj.CommonLib;
using tw.com.kg.lib;
using System.Data;

namespace tw.com.kg.lib
{
    public class CClockFactory : YJCCommonFactory
    {
        public CClockFactory(YJCommonContext p_context)
        {
            setContext(p_context);
        }
        public CClock createCClock()
        {
            return new CClock();
        }

        //design by fox
        class temp {
           public  int ID;
           public string EIP;
        }

        class temp2 {
            public int ID;
            public string EID;

        }

        public void tempfun2() {
            string l_conn = @"server=172.26.100.8;Connection Lifetime=100;Connection Timeout=600;uid=sa;pwd=hp1020.;dataBase=UOF";
            ivContext.資料管理員 = new YJDbManager(l_conn);
            DataView l_dv = ivContext.資料管理員.getDataViewBySql(" select * from dbo.TB_HR_CLOCKTIME where EMPLOYEE_ID like 'U%' ");
            temp2[] tt2 = new temp2[l_dv.Count];

            if (l_dv != null)
            {
                for (int i = 0; i < l_dv.Count; i++)
                {
                    tt2[i] = new temp2();
                    tt2[i].ID = Convert.ToInt32(l_dv[i]["ID"].ToString());
                    tt2[i].EID = l_dv[i]["EMPLOYEE_ID"].ToString();
                }
            }

            foreach (var item in tt2)
            {
                string l_Sql = " ";
                l_Sql += " update TB_HR_CLOCKTIME set EMPLOYEE_ID = '" + item.EID.Substring(1, item.EID.Length-1) + "' ";
                l_Sql += " where ID = '" + item.ID + "' ";
                ivContext.資料管理員.excuteSqlNonquery(l_Sql);
            }
        }


        //design by fox
        public void tempFun() {
            string l_conn = @"server=172.26.100.8;Connection Lifetime=100;Connection Timeout=600;uid=sa;pwd=hp1020.;dataBase=UOF";
            ivContext.資料管理員 = new YJDbManager(l_conn);
            DataView l_dv = ivContext.資料管理員.getDataViewBySql(" select * from dbo.TB_HR_CLOCKTIME where EMPLOYEE_ID like 'U%' ");

            temp[] tt = new temp[l_dv.Count];

            if (l_dv != null)
	        {
                for (int i = 0; i < l_dv.Count; i++)
                {
                    tt[i] = new temp();
                    tt[i].ID = Convert.ToInt32(l_dv[i]["ID"].ToString());
                    tt[i].EIP = l_dv[i]["EMPLOYEE_EIP"].ToString();
                }
	        }

            foreach (var item in tt)
            {
                string l_Sql = " ";
                l_Sql += " update TB_HR_CLOCKTIME set EMPLOYEE_EIP = '" + 轉換員編(item.EIP) + "' ";
                l_Sql += " where ID = '" + item.ID + "' ";
                ivContext.資料管理員.excuteSqlNonquery(l_Sql);
            }
            

            

            

        }

        public CClock[] get原始卡鐘記錄()
        {
            string l_Sql = "";
            string l_BDate = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
            string l_EDate = (DateTime.Today.AddDays(1).AddMinutes(-1)).ToString("yyyy-MM-dd HH:mm:ss");

            l_Sql += " select * from  DoorLog where UserID <> '0' ";
            l_Sql += " and DateTime >= '" + l_BDate + "' and DateTime <= '" + l_EDate + "'";

            string l_conn = @"server=SOFTFW_SYSLOG\SQLEXPRESS;Connection Lifetime=100;Connection Timeout=600;uid=sa;pwd=hp1020.;dataBase=chiyu";
            ivContext.資料管理員 = new YJDbManager(l_conn);
            return queryBySql(l_Sql);
        }

        public void insert_同步資料到EIP主機(CClock[] p_CClock)
        {
            string l_conn = @"server=172.26.100.8;Connection Lifetime=100;Connection Timeout=600;uid=sa;pwd=hp1020.;dataBase=UOF";
            ivContext.資料管理員 = new YJDbManager(l_conn);

            string l_Sql = " ";
            //insert前先刪除之前的使用者
            for (int i = 0; i < p_CClock.Length; i++)
            {
                l_Sql += "INSERT INTO TB_HR_CLOCKTIME(ID,EMPLOYEE_ID,EMPLOYEE_EIP,DATE_TIME,TERMINAL_ID,VERIFICATION_SOURCE) VALUES (";
                l_Sql += " " + p_CClock[i].ID流水號 + "";
                l_Sql += ", '" + p_CClock[i].EMPLOYEE_ID員編 + "'";
                l_Sql += ", '" + p_CClock[i].EMPLOYEE_EIP轉碼員編 + "'";
                l_Sql += ", '" + p_CClock[i].DATE_TIME出勤時間.ToString("yyyy/MM/dd HH:mm:ss") + "'";
                l_Sql += ", '" + p_CClock[i].TERMINAL_ID卡鐘號碼 + "'";
                l_Sql += ", '" + p_CClock[i].VERIFICATION_SOURCE進出方式 + "'";
                l_Sql += "); ";

                try
                {
                    ivContext.資料管理員.excuteSqlNonquery(l_Sql);
                }
                catch { continue; }
            }

        }
        private CClock[] queryBySql(string p_sql)
        {
            DataView l_dv = ivContext.資料管理員.getDataViewBySql(p_sql);
            CClock[] l_datas = new CClock[l_dv.Count];

            if (l_dv != null)
            {
                for (int i = 0; i < l_datas.Length; i++)
                {
                    l_datas[i] = createCClock();
                    l_datas[i].ID流水號 =Convert.ToInt32( l_dv[i]["ID"].ToString() );
                    l_datas[i].EMPLOYEE_ID員編 = l_dv[i]["UserID"].ToString();
                    l_datas[i].EMPLOYEE_EIP轉碼員編 = 轉換員編(l_datas[i].EMPLOYEE_ID員編);
                    l_datas[i].DATE_TIME出勤時間 =Convert.ToDateTime( l_dv[i]["DateTime"].ToString() );
                    l_datas[i].TERMINAL_ID卡鐘號碼 = l_dv[i]["TerminalID"].ToString();
                    l_datas[i].VERIFICATION_SOURCE進出方式 = l_dv[i]["VerificationSource"].ToString();
                }
                return l_datas;
            }
            return null;
        }

        private string 轉換員編(string p_EmployeeID)
        {
            string l_strNumBer = "";
            string l_strChar = "";
            if (p_EmployeeID.Length == 5)//員編五碼者不變
            {
                return p_EmployeeID.Trim();
            }
            else if (p_EmployeeID.Length == 6)//員編五碼者轉換成英文 990465 > A9904
            {
                l_strNumBer = p_EmployeeID.Substring(0, 4);
                l_strChar = p_EmployeeID.Substring(4, 2);
                l_strChar = 數字轉英文(l_strChar, p_EmployeeID.Length);

            }
            else if (p_EmployeeID.Length == 7)//員編五碼者轉換成英文 990465 > A9904
            {
                l_strNumBer = p_EmployeeID.Substring(2, 3);
                l_strChar = p_EmployeeID.Substring(5, 2);
                l_strChar = 數字轉英文(l_strChar, p_EmployeeID.Length);

            }
            p_EmployeeID = l_strChar + l_strNumBer;
            return p_EmployeeID;
        }

        private string 數字轉英文(string p_str,int p_strLenth)
        {
            if (p_strLenth == 6)
            {
                switch (p_str)
                {
                    case "65": return "A";
                    case "66": return "B";
                    case "67": return "C";
                    case "68": return "D";
                    case "69": return "E";
                    case "70": return "F";
                    case "71": return "G";
                    case "72": return "H";
                    case "73": return "I";
                    case "74": return "J";
                    case "75": return "K";
                    case "76": return "L";
                    case "77": return "M";
                    case "78": return "N";
                    case "79": return "O";
                    case "80": return "P";
                    case "81": return "Q";
                    default: return "XX";
                }
            }
            else if (p_strLenth == 7)
            {
                switch (p_str)
                {
                    case "65": return "AA";
                    case "66": return "BA";
                    case "67": return "CA";
                    case "68": return "DA";
                    case "69": return "EA";
                    case "70": return "FA";
                    case "71": return "GA";
                    case "72": return "HA";
                    case "73": return "IA";
                    case "74": return "JA";
                    case "75": return "KA";
                    case "76": return "LA";
                    case "80": return "P";
                    default: return "XX";
                }
            }
            else if (p_strLenth == 4)
            {
                switch (p_str)
                {
                    case "78": return "W";
                    default: return "XX";
                }
            }
            else
            {
                return "XX";
            }
        }
    }
}
