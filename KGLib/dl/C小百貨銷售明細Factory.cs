using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tw.com.yj.CommonLib;
using System.Data;

namespace tw.com.kg.lib
{
    public class C小百貨銷售明細Factory: YJCCommonFactory
    {
        public C小百貨銷售明細Factory(YJCommonContext p_context)
        {
            setContext(p_context);
        }

        public C小百貨銷售明細 createC小百貨銷售明細()
        {
            return new C小百貨銷售明細();
        }

        public C小百貨銷售明細[] get小百貨銷售明細(string p_BDate, string p_EDate,string p_smid,string p_單號)
        {
            string l_sql = "";

            l_sql += " select  m.f_exchangeid,m.f_insertdate,m.f_salessmid,p.name,d.f_productid,d.f_productname";
            l_sql += " ,d.f_amount,d.f_unitprice,d.f_total,m.f_branchid,d.f_SalePrice ";
            l_sql += " from kg..tbKGPartOrder m";


            l_sql += " inner join kg..tbKGPartOrderDetail d on m.f_exchangeid = d.f_exchangeid";
            l_sql += " left join kdnews..T_HRPersonel p on p.emp_id = m.f_salessmid";
            l_sql += " where 1=1 ";
            if (!"".Equals(p_BDate))
            {
                l_sql += " and f_insertdate between '" + p_BDate + "' and '" + p_EDate + "' ";
            }
            if (!"".Equals(p_smid))
            {
                l_sql += " and m.f_salessmid = '" + p_smid + "'";
            }
            if (!"".Equals(p_單號))
            {
                l_sql += " and m.f_exchangeid = '" + p_單號 + "'";
            }
            l_sql += " order by m.f_insertdate";

            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_sql);
            C小百貨銷售明細[] l_datas = new C小百貨銷售明細[l_dv.Count];

            if (l_dv != null)
            {
                for (int i = 0; i < l_datas.Length; i++)
                {
                    l_datas[i] = createC小百貨銷售明細();
                    l_datas[i].單號 = l_dv[i]["f_exchangeid"].ToString();
                    l_datas[i].日期 = l_dv[i]["f_insertdate"].ToString();
                    l_datas[i].員編 = l_dv[i]["f_salessmid"].ToString();
                    l_datas[i].姓名 = l_dv[i]["name"].ToString();
                    l_datas[i].產品編號 = l_dv[i]["f_productid"].ToString();
                    l_datas[i].產品名稱 = l_dv[i]["f_productname"].ToString();
                    l_datas[i].數量 = Convert.ToInt32(l_dv[i]["f_amount"].ToString());
                    l_datas[i].單價 = Convert.ToInt32(l_dv[i]["f_unitprice"].ToString());
                    l_datas[i].總計 = Convert.ToInt32(l_dv[i]["f_total"].ToString());
                    l_datas[i].販賣單價 = Convert.ToInt32("0"+l_dv[i]["f_SalePrice"].ToString());
                    l_datas[i].所別 = l_dv[i]["f_branchid"].ToString();
                }
                return l_datas;
            }
            return null;
        }

        public C小百貨銷售明細[] get小百貨銷售明細(string p_BDate, string p_EDate, string p_smid, string p_單號, string 廠或所)
        {
            string l_sql = "";

            l_sql += " select  m.f_exchangeid,m.f_insertdate,m.f_salessmid,p.name,d.f_productid,d.f_productname";
            l_sql += " ,d.f_amount,d.f_unitprice,d.f_total,m.f_branchid,d.f_SalePrice ";
            l_sql += " from kg..tbKGPartOrder m";


            l_sql += " inner join kg..tbKGPartOrderDetail d on m.f_exchangeid = d.f_exchangeid";
            l_sql += " left join kdnews..T_HRPersonel p on p.emp_id = m.f_salessmid";
            l_sql += " where 1=1 ";
            if (廠或所.Equals("服務廠"))
            {
                l_sql += " and f_branchid like '%S' ";
            }
            if (!"".Equals(p_BDate))
            {
                l_sql += " and f_insertdate between '" + p_BDate + "' and '" + p_EDate + "' ";
            }
            if (!"".Equals(p_smid))
            {
                l_sql += " and m.f_salessmid = '" + p_smid + "'";
            }
            if (!"".Equals(p_單號))
            {
                l_sql += " and m.f_exchangeid = '" + p_單號 + "'";
            }
            l_sql += " order by m.f_insertdate";

            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_sql);
            C小百貨銷售明細[] l_datas = new C小百貨銷售明細[l_dv.Count];

            if (l_dv != null)
            {
                for (int i = 0; i < l_datas.Length; i++)
                {
                    l_datas[i] = createC小百貨銷售明細();
                    l_datas[i].單號 = l_dv[i]["f_exchangeid"].ToString();
                    l_datas[i].日期 = l_dv[i]["f_insertdate"].ToString();
                    l_datas[i].員編 = l_dv[i]["f_salessmid"].ToString();
                    l_datas[i].姓名 = l_dv[i]["name"].ToString();
                    l_datas[i].產品編號 = l_dv[i]["f_productid"].ToString();
                    l_datas[i].產品名稱 = l_dv[i]["f_productname"].ToString();
                    l_datas[i].數量 = Convert.ToInt32(l_dv[i]["f_amount"].ToString());
                    l_datas[i].單價 = Convert.ToInt32(l_dv[i]["f_unitprice"].ToString());
                    l_datas[i].總計 = Convert.ToInt32(l_dv[i]["f_total"].ToString());
                    l_datas[i].販賣單價 = Convert.ToInt32("0" + l_dv[i]["f_SalePrice"].ToString());
                    l_datas[i].所別 = l_dv[i]["f_branchid"].ToString();
                }
                return l_datas;
            }
            return null;
        }

    }
}
