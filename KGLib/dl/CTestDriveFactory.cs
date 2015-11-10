using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tw.com.yj.CommonLib;
using System.Data;

namespace tw.com.kg.lib
{
    public class CTestDriveFactory : YJCCommonFactory
    {
        public CTestDriveFactory(YJCommonContext p_context)
        {
            setContext(p_context);
        }
        public CTestDrive createCTestDrive()
        {
            return new CTestDrive();
        }

        public CTestDrive getCTestDriveBySearch(string p_engo)
        {
            string l_query = "";
            if (!"".Equals(p_engo))
            {
                l_query += " f_engo='" + p_engo + "' or  f_carno = '" + p_engo + "' and ";
            }
            string l_sql = "";
            l_sql += " select * from tbTestDrive ";
            if (l_query.Length > 0)
            {
                l_sql += " where " + l_query.Substring(0, l_query.Length - 4);
            }

            try
            {
                return queryBySql(l_sql)[0];
            }
            catch { return null; }
        }
        private CTestDrive[] queryBySql(string p_sql)
        {
            DataView l_dv = ivContext.資料管理員.getDataViewBySql(p_sql);
            CTestDrive[] l_datas = new CTestDrive[l_dv.Count];

            if (l_dv != null)
            {
                for (int i = 0; i < l_datas.Length; i++)
                {
                    l_datas[i] = createCTestDrive();
                    l_datas[i].f_carno車牌 = l_dv[i]["f_carno"].ToString();
                    l_datas[i].f_engo引擎號碼 = l_dv[i]["f_engo"].ToString();
                }
                return l_datas;
            }
            return null;
        }

    }
}
