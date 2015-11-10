using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tw.com.yj.CommonLib;
using System.Data;

namespace tw.com.kg.lib
{
    public class CEngnoFactory : YJCCommonFactory
    {
        public CEngnoFactory(YJCommonContext p_context)
        {
            setContext(p_context);
        }
        public CEngno createCEngno()
        {
            return new CEngno();
        }

        /// <summary>
        /// 取得高都引擎號碼檔
        /// </summary>
        /// <param name="p_smid"></param>
        /// <returns></returns>
        public CEngno get高都引擎號碼檔(string p_engo)
        {
            string l_sql = "";
            l_sql += "select Engno,carcod,ordpnm from kddb..orders where engno ='" + p_engo + "'";

            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_sql);
            CEngno l_datas = createCEngno();

            if (l_dv.Count > 0)
            {
                l_datas.f_engno引擎號碼 = l_dv[0]["Engno"].ToString();
                l_datas.f_carcod車種 = l_dv[0]["carcod"].ToString();
                l_datas.f_orpm訂單顧客 = l_dv[0]["ordpnm"].ToString();

                return l_datas;
            }
            return null;
        }
    }
}
