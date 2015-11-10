using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tw.com.yj.CommonLib;
using System.Data;

namespace tw.com.kg.lib
{
    public class CInMoneyDetailFactory : YJCCommonFactory
    {
        public CInMoneyDetailFactory(YJCommonContext p_context)
        {
            setContext(p_context);
        }
        public CInMoneyDetail createCInMoneyDetail()
        {
            return new CInMoneyDetail();
        }


        public void insert(CInMoneyDetail p_data)
        {
            string l_Sql = "";

            l_Sql += "INSERT INTO [KG].[dbo].[tbInMoneyDetail] VALUES (";
            l_Sql += " '" + p_data.f_workid工單單號 + "'";
            l_Sql += ", " + p_data.f_money應收金額 + "";
            l_Sql += ", '" + p_data.f_editdate沖帳日期 + "'";
            l_Sql += ")";
            ivContext.資料管理員.excuteSqlNonquery(l_Sql);
        }
        public void delete(CInMoneyDetail p_data)
        {
            string l_Sql = "";

            l_Sql += "delete from  [KG].[dbo].[tbInMoneyDetail]";
            l_Sql += " WHERE [f_id] = " + p_data.f_id + "";

            ivContext.資料管理員.excuteSqlNonquery(l_Sql);
        }


        private CInMoneyDetail[] queryBySql(string p_sql)
        {
            DataView l_dv = ivContext.資料管理員.getDataViewBySql(p_sql);
            CInMoneyDetail[] l_datas = new CInMoneyDetail[l_dv.Count];

            if (l_dv != null)
            {
                for (int i = 0; i < l_datas.Length; i++)
                {
                    l_datas[i] = createCInMoneyDetail();
                    l_datas[i].f_id =Convert.ToInt32( l_dv[i]["f_id"].ToString() );
                    l_datas[i].f_workid工單單號 = l_dv[i]["f_workid"].ToString();
                    l_datas[i].f_money應收金額 =Convert.ToInt32( l_dv[i]["f_money"].ToString() );
                    l_datas[i].f_editdate沖帳日期 = l_dv[i]["f_editdate"].ToString();
                }
                return l_datas;
            }
            return null;
        }
    }
}
