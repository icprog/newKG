using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tw.com.yj.CommonLib;
using System.Data;

namespace tw.com.kg.lib
{
    public class C保險實績統計Factory : YJCCommonFactory
    {
        public C保險實績統計Factory(YJCommonContext p_context)
        {
            setContext(p_context);
        }
        public C保險實績統計 createC保險實績統計()
        {
            return new C保險實績統計();
        }

        public C保險實績統計[] get保險實績(string p_BDate, string p_EDate, string p_保險公司)
        {
            string l_sql = "";

            l_sql += " select w.f_branchid,i.f_id,i.f_name,sum(w.f_money) as f_money";
            l_sql += " from dbo.tbWork w";
            l_sql += " inner join dbo.tbInsurance i on w.f_insuranceid = i.f_id";
            l_sql += " where f_type = '保險'";

            if (!"".Equals(p_BDate))
            {
                l_sql += " and substring(w.f_editdate,0,11) between '" + p_BDate + "' and '" + p_EDate + "'";
            }
            if (!"".Equals(p_保險公司))
            {
                l_sql += " and i.f_id = '" + p_保險公司 + "'";
            }

            l_sql += " group by w.f_branchid,i.f_id,i.f_name";
            l_sql += " order by w.f_branchid";

            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_sql);
            C保險實績統計[] l_datas = new C保險實績統計[l_dv.Count];

            if (l_dv != null)
            {
                for (int i = 0; i < l_datas.Length; i++)
                {
                    l_datas[i] = createC保險實績統計();
                    l_datas[i].代碼 = l_dv[i]["f_id"].ToString();
                    l_datas[i].所別 = l_dv[i]["f_branchid"].ToString();
                    l_datas[i].代碼名稱 = l_dv[i]["f_name"].ToString();
                    l_datas[i].實績 = l_dv[i]["f_money"].ToString();
                }
                return l_datas;
            }
            return null;
        }

        public C保險實績統計[] get保險公司介紹實績(string p_BDate, string p_EDate, string p_保險公司)
        {
            string l_sql = "";

            l_sql += " select i.f_id,i.f_name,t.f_typename,sum(w.f_money) as f_money,count(w.f_workid) as f_cnt";
            l_sql += " from dbo.tbWork w";
            l_sql += " inner join dbo.tbInsurance i on w.f_insuranceid = i.f_id";
            l_sql += " inner join dbo.tbWorkType t on w.f_workType = t.f_typeid";
            l_sql += " where w.f_type = '保險公司介紹'";

            if (!"".Equals(p_BDate))
            {
                l_sql += " and substring(w.f_editdate,0,11) between '" + p_BDate + "' and '" + p_EDate + "'";
            }
            if (!"".Equals(p_保險公司))
            {
                l_sql += " and i.f_id = '" + p_保險公司 + "'";
            }

            l_sql += " group by i.f_id,i.f_name,t.f_typename";
            l_sql += " order by i.f_id,i.f_name,t.f_typename";

            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_sql);
            C保險實績統計[] l_datas = new C保險實績統計[l_dv.Count];

            if (l_dv != null)
            {
                for (int i = 0; i < l_datas.Length; i++)
                {
                    l_datas[i] = createC保險實績統計();
                    l_datas[i].代碼 = l_dv[i]["f_id"].ToString();
                    l_datas[i].台數 = l_dv[i]["f_cnt"].ToString();
                    l_datas[i].代碼名稱 = l_dv[i]["f_name"].ToString();
                    l_datas[i].實績 = l_dv[i]["f_money"].ToString();
                    l_datas[i].施工項目 = l_dv[i]["f_typename"].ToString();
                }
                return l_datas;
            }
            return null;
        }
    }
}
