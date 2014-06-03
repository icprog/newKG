using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tw.com.yj.CommonLib;
using System.Data;

namespace tw.com.kg.lib
{
    public class C工單實績Factory : YJCCommonFactory
    {
        public C工單實績Factory(YJCommonContext p_context)
        {
            setContext(p_context);
        }
        public C工單實績 createC工單實績()
        {
            return new C工單實績();
        }

        public C工單實績[] get工單實績(string p_BDate, string p_EDate,string p_工單類型)
        {
            string l_sql = "";

            l_sql += " select f_branchid,f_type,sum(f_money) as f_money,count(f_branchid) as f_cnt";
            l_sql += " from dbo.tbWork w ";
            l_sql += " where 1=1 ";

            if (!"".Equals(p_BDate))
            {
                l_sql += " and substring(w.f_editdate,0,11) between '" + p_BDate + "' and '" + p_EDate + "'";
            }
            if (!"".Equals(p_工單類型))
            {
                l_sql += " and f_type = '" + p_工單類型 + "'";
            }
            l_sql += " group by f_branchid,f_type";
            l_sql += " order by f_branchid";

            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_sql);
            C工單實績[] l_datas = new C工單實績[l_dv.Count];

            if (l_dv != null)
            {
                for (int i = 0; i < l_datas.Length; i++)
                {
                    l_datas[i] = createC工單實績();
                    l_datas[i].所別 = l_dv[i]["f_branchid"].ToString();
                    l_datas[i].工單類型 = l_dv[i]["f_type"].ToString();
                    l_datas[i].金額 = Convert.ToInt32(l_dv[i]["f_money"].ToString());
                    l_datas[i].台數 = Convert.ToInt32(l_dv[i]["f_cnt"].ToString());
                }
                return l_datas;
            }
            return null;
        }
    }
}
