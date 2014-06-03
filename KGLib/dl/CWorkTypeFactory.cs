using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tw.com.yj.CommonLib;
using System.Data;

namespace tw.com.kg.lib
{
    public class CWorkTypeFactory : YJCCommonFactory
    {
        public CWorkTypeFactory(YJCommonContext p_context)
        {
            setContext(p_context);
        }
        public CWorkType createCWorkType()
        {
            return new CWorkType();
        }

        public void deleteByID(string p_id)
        {
            string l_Sql = "";

            l_Sql += "delete from  [KG].[dbo].[tbWorkType] where f_typeid = '" + p_id + "'";
        
            ivContext.資料管理員.excuteSqlNonquery(l_Sql);
        }
        public void insert(CWorkType p_data)
        {
            string l_Sql = "";

            l_Sql += "INSERT INTO [KG].[dbo].[tbWorkType] VALUES (";
            l_Sql += " '" + p_data.f_typeid洗車種類代碼 + "'";
            l_Sql += ", '" + p_data.f_typename洗車種類名稱 + "'";
            l_Sql += ", " + p_data.f_money價錢 + "";
            l_Sql += ", " + p_data.f_moneyBySmid員工價 + "";
            l_Sql += ", " + p_data.f_moneyByIn內部員工薪資 + "";
            l_Sql += ", " + p_data.f_moneyByOut外部員工薪資 + "";
            l_Sql += ", " + p_data.f_boundByService服務獎金數 + "";
            l_Sql += ", " + p_data.f_boundBySmid業代獎金數 + "";
            l_Sql += ")";
            ivContext.資料管理員.excuteSqlNonquery(l_Sql);
        }

        public void update(CWorkType p_data)
        {
            string l_Sql = "";

            l_Sql += "UPDATE [KG].[dbo].[tbWorkType]";
            l_Sql += "SET [f_typename] =" + p_data.f_typename洗車種類名稱 + "'";
            l_Sql += ",[f_money] =" + p_data.f_money價錢 + "";
            l_Sql += ",[f_moneyBySmid] =" + p_data.f_moneyBySmid員工價 + "";
            l_Sql += " ,[f_moneyByIn]=" + p_data.f_moneyByIn內部員工薪資 + "";
            l_Sql += ",[f_moneyByOut] =" + p_data.f_moneyByOut外部員工薪資 + "";
            l_Sql += ",[f_boundByService] =" + p_data.f_boundByService服務獎金數 + "";
            l_Sql += ",[f_boundBySmid] =" + p_data.f_boundBySmid業代獎金數 + "";
            l_Sql += " WHERE [f_typeid] = '" + p_data.f_typeid洗車種類代碼 + "'";

            ivContext.資料管理員.excuteSqlNonquery(l_Sql);
        }

        public CWorkType[] getAllWorkType()
        {
            string l_Sql = "";

            l_Sql += "select * from tbWorkType";

            return queryBySql(l_Sql);

        }
        public CWorkType[] getAllWorkType(string p_typeid)
        {
            string l_Sql = "";

            l_Sql += "select * from tbWorkType where f_typeid like '"+p_typeid+"%'";

            return queryBySql(l_Sql);

        }
        public int get價錢By代碼(string p_str代碼)
        {
            string l_Sql = "";

            l_Sql += "select f_money from tbWorkType where f_typeid = '" + p_str代碼 + "'";

            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_Sql);

            return Convert.ToInt32(l_dv[0]["f_money"].ToString());

        }
        public CWorkType getCWorkTypeBy代碼(string p_str代碼)
        {
            string l_Sql = "";

            l_Sql += "select * from tbWorkType where f_typeid = '" + p_str代碼 + "' order by f_money asc";

            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_Sql);

            return queryBySql(l_Sql)[0];

        }
        private CWorkType[] queryBySql(string p_sql)
        {
            DataView l_dv = ivContext.資料管理員.getDataViewBySql(p_sql);
            CWorkType[] l_datas = new CWorkType[l_dv.Count];

            if (l_dv != null)
            {
                for (int i = 0; i < l_datas.Length; i++)
                {
                    l_datas[i] = createCWorkType();
                    l_datas[i].f_typeid洗車種類代碼 = l_dv[i]["f_typeid"].ToString();
                    l_datas[i].f_typename洗車種類名稱 = l_dv[i]["f_typename"].ToString();
                    l_datas[i].f_money價錢 = Convert.ToInt32(l_dv[i]["f_money"].ToString());
                    l_datas[i].f_moneyBySmid員工價 =Convert.ToInt32( l_dv[i]["f_moneyBySmid"].ToString());
                    l_datas[i].f_moneyByIn內部員工薪資 =Convert.ToInt32( l_dv[i]["f_moneyByIn"].ToString());
                    l_datas[i].f_moneyByOut外部員工薪資 =Convert.ToInt32( l_dv[i]["f_moneyByOut"].ToString());
                    l_datas[i].f_boundByService服務獎金數 =Convert.ToDouble( l_dv[i]["f_boundByService"].ToString());
                    l_datas[i].f_boundBySmid業代獎金數 = Convert.ToDouble(l_dv[i]["f_boundBySmid"].ToString());
                }
                return l_datas;
            }
            return null;
        }
    }
}
