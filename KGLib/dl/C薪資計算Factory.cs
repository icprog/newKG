using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tw.com.yj.CommonLib;
using System.Data;

namespace tw.com.kg.lib
{
    public class C薪資計算Factory : YJCCommonFactory
    {
        public C薪資計算Factory(YJCommonContext p_context)
        {
            setContext(p_context);
        }
        public C薪資計算 createC薪資計算()
        {
            return new C薪資計算();
        }


        public C薪資計算[] get薪資(string p_BDate,string p_EDate,string p_smid)
        {
            string l_sql = "";

            l_sql += " select u.f_userid,u.f_username";
            l_sql += " ,sum(wt.f_moneybyin/aa.countamt)  as f_amt ,sum(wt.f_moneyByOut/aa.countamt) as f_amtout ";
            l_sql += " from ";
            l_sql += " (";
            l_sql += " select c_in.f_workid,count(c_in.f_workid) as countamt";
            l_sql += " from tbConstruction c_in ";
            l_sql += " join tbWork w_in on c_in.f_workid = w_in.f_workid ";
            l_sql += " where w_in.f_closedate between '" + p_BDate + "' and '" + p_EDate + "'";
            l_sql += " group by c_in.f_workid";
            l_sql += " ) aa";
            l_sql += " inner join tbConstruction c on aa.f_workid = c.f_workid";
            l_sql += " inner join dbo.tbWork w on c.f_workid = w.f_workid ";//需要工單資訊,join施工table
            l_sql += " inner join dbo.tbUser u on c.f_smid = u.f_userid ";//需要人員資訊,join人員table
            l_sql += " inner join dbo.tbWorkType wt on wt.f_typeid = w.f_worktype ";//需要獎金資訊,join種類table
            l_sql += " where w.f_staus = '完工'";//完工才算薪資

            if (!"".Equals(p_BDate))
            {
                l_sql += " and w.f_closedate between '" + p_BDate + "' and '" + p_EDate + "'";
            }
            if (!"".Equals(p_smid))
            {
                l_sql += " and c.f_smid = '" + p_smid + "'";
            }
            l_sql += " group by u.f_userid,u.f_username";

            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_sql);
            C薪資計算[] l_datas = new C薪資計算[l_dv.Count];

            if (l_dv != null)
            {
                for (int i = 0; i < l_datas.Length; i++)
                {
                    l_datas[i] = createC薪資計算();
                    l_datas[i].編號 = l_dv[i]["f_userid"].ToString();
                    l_datas[i].姓名 = l_dv[i]["f_username"].ToString();
                    l_datas[i].薪資 = l_dv[i]["f_amt"].ToString();
                    l_datas[i].外部薪資 = l_dv[i]["f_amtout"].ToString();
                }
                return l_datas;
            }
            return null;
        }
    }
}
