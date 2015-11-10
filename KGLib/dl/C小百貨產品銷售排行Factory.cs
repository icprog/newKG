using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tw.com.yj.CommonLib;
using System.Data;

namespace tw.com.kg.lib
{
    public class C小百貨產品銷售排行Factory : YJCCommonFactory
    {
        public C小百貨產品銷售排行Factory(YJCommonContext p_context)
        {
            setContext(p_context);
        }
        public C小百貨產品銷售排行 createC小百貨產品銷售排行()
        {
            return new C小百貨產品銷售排行();
        }


        public C小百貨產品銷售排行[] get產品排行(string p_BDate, string p_EDate)
        {
            string l_sql = "";

            l_sql += " select f_productid,f_productname,count(f_productid) as count,sum(f_total) as money  ";
            l_sql += " from kg..tbKGPartOrder master ";
            l_sql += " inner join kg..tbKGPartOrderDetail detail on master.f_exchangeid = detail.f_exchangeid  ";

            if (!"".Equals(p_BDate))
            {
                l_sql += " where f_insertdate between '" + p_BDate + "' and '" + p_EDate + "' ";
            }
                  
            l_sql += " group by detail.f_productid,detail.f_productname ";
            l_sql += " order by count(f_productid) desc ";

            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_sql);
            C小百貨產品銷售排行[] l_datas = new C小百貨產品銷售排行[l_dv.Count];

            if (l_dv != null)
            {
                for (int i = 0; i < l_datas.Length; i++)
                {
                    l_datas[i] = createC小百貨產品銷售排行();
                    l_datas[i].編號 = l_dv[i]["f_productid"].ToString();
                    l_datas[i].名稱 = l_dv[i]["f_productname"].ToString();
                    l_datas[i].銷售次數 = Convert.ToInt32(l_dv[i]["count"].ToString());
                    l_datas[i].總銷售金額 = Convert.ToInt32(l_dv[i]["money"].ToString());
                }
                return l_datas;
            }
            return null;
        }
    }
}
