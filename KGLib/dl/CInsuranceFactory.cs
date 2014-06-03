using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tw.com.yj.CommonLib;
using System.Data;

namespace tw.com.kg.lib
{
    public class CInsuranceFactory : YJCCommonFactory
    {
        public CInsuranceFactory(YJCommonContext p_context)
        {
            setContext(p_context);
        }
        public CInsurance createCInsurance()
        {
            return new CInsurance();
        }


        public void insert(CInsurance p_data)
        {
            string l_Sql = "";

            l_Sql += "INSERT INTO [KG].[dbo].[tbInsurance](f_id,f_name) VALUES (";
            l_Sql += " '" + p_data.f_id代碼 + "'";
            l_Sql += ", '" + p_data.f_f_name名稱 + "'";
            l_Sql += ")";
            ivContext.資料管理員.excuteSqlNonquery(l_Sql);
        }

        public CInsurance[] getAll保險公司()
        {
            string l_Sql = "";

            l_Sql += " select * from  [KG].[dbo].[tbInsurance]";

            return queryBySql(l_Sql);
        }

        public CInsurance[] getAll保險公司介紹()
        {
            string l_Sql = "";
            //保險介紹只有富邦,兆豐,泰安,明台,蘇黎世 20130411 way
            l_Sql += " select * from  [KG].[dbo].[tbInsurance] where f_id in ('a','e','d','b','c')";

            return queryBySql(l_Sql);
        }

        public void deleteByID(string p_id)
        {
            string l_Sql = "";

            l_Sql += "delete from tbInsurance where f_id = '" + p_id + "'";
            ivContext.資料管理員.excuteSqlNonquery(l_Sql);
        }
        private CInsurance[] queryBySql(string p_sql)
        {
            DataView l_dv = ivContext.資料管理員.getDataViewBySql(p_sql);
            CInsurance[] l_datas = new CInsurance[l_dv.Count];

            if (l_dv != null)
            {
                for (int i = 0; i < l_datas.Length; i++)
                {
                    l_datas[i] = createCInsurance();
                    l_datas[i].f_id代碼 = l_dv[i]["f_id"].ToString();
                    l_datas[i].f_f_name名稱 = l_dv[i]["f_name"].ToString();
                }
                return l_datas;
            }
            return null;
        }
    }
}
