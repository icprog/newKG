using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tw.com.yj.CommonLib;
using System.Data;

namespace tw.com.kg.lib
{
    public class C欠款紀錄Factory : YJCCommonFactory
    {
        public C欠款紀錄Factory(YJCommonContext p_context)
        {
            setContext(p_context);
        }
        public C欠款紀錄 createC欠款紀錄()
        {
            return new C欠款紀錄();
        }

        public C欠款紀錄[] get欠款紀錄(string p_BDate, string p_EDate, string p_smid, string p_strB帳款日期, string p_strE帳款日期)
        {
            string l_sql = "";

            l_sql += " select t.branch,i.f_smid,t.name,sum(f_money) as f_money,p.f_Point";
            l_sql += " from  dbo.tbInMoney i";
            l_sql += " left join kdnews..T_HRPersonel t on i.f_smid = t.Emp_id ";
            l_sql += " left join kg..tbKGPoint p on i.f_smid = p.f_Smid ";
            l_sql += " where f_isclose = 'N'";
            if (!"".Equals(p_BDate))
            {
                l_sql += " and i.f_fulldate between '" + p_BDate + "' and '" + p_EDate + "'";

            }
            if (!"".Equals(p_strB帳款日期))
            {
                l_sql += " and i.f_editdate between '" + p_strB帳款日期 + "' and '" + p_strE帳款日期 + "'";

            }
            if (!"".Equals(p_smid))
            {
                l_sql += " and i.f_smid = '" + p_smid + "'";

            }
            l_sql += " group by t.branch,i.f_smid,t.name,p.f_Point";
          
            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_sql);
            C欠款紀錄[] l_datas = new C欠款紀錄[l_dv.Count];

            if (l_dv != null)
            {
                for (int i = 0; i < l_datas.Length; i++)
                {
                    l_datas[i] = createC欠款紀錄();
                    l_datas[i].據點 = l_dv[i]["branch"].ToString();
                    l_datas[i].業編 = l_dv[i]["f_smid"].ToString();
                    l_datas[i].名稱 = l_dv[i]["name"].ToString();
                    l_datas[i].金額 = l_dv[i]["f_money"].ToString();
                    l_datas[i].剩餘點數 = l_dv[i]["f_Point"].ToString();
                }
                return l_datas;
            }
            return null;
        }
        public C欠款紀錄[] get沖帳款紀錄(string p_BDate, string p_EDate, string p_smid, string p_strB帳款日期, string p_strE帳款日期)
        {
            string l_sql = "";

            l_sql += " select t.branch,i.f_smid,t.name,sum(f_money) as f_money";
            l_sql += " from  dbo.tbInMoney i";
            l_sql += " left join kdnews..T_HRPersonel t on i.f_smid = t.Emp_id ";
            l_sql += " where f_isclose = 'Y'";
            if (!"".Equals(p_strB帳款日期))
            {
                l_sql += " and i.f_editdate between '" + p_strB帳款日期 + "' and '" + p_strE帳款日期 + "'";

            }
            if (!"".Equals(p_BDate))
            {
                l_sql += " and i.f_fulldate between '" + p_BDate + "' and '" + p_EDate + "'";

            }
            if (!"".Equals(p_smid))
            {
                l_sql += " and i.f_smid = '" + p_smid + "'";

            }
            l_sql += " group by t.branch,i.f_smid,t.name";

            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_sql);
            C欠款紀錄[] l_datas = new C欠款紀錄[l_dv.Count];

            if (l_dv != null)
            {
                for (int i = 0; i < l_datas.Length; i++)
                {
                    l_datas[i] = createC欠款紀錄();
                    l_datas[i].據點 = l_dv[i]["branch"].ToString();
                    l_datas[i].業編 = l_dv[i]["f_smid"].ToString();
                    l_datas[i].名稱 = l_dv[i]["name"].ToString();
                    l_datas[i].金額 = l_dv[i]["f_money"].ToString();
                }
                return l_datas;
            }
            return null;
        }


        public C欠款紀錄[] get欠款紀錄明細(string p_smid,string p_type,string p_BDate,string p_EDate)
        {
            string l_sql = "";

            //l_sql += " select * from tbInMoney where f_isclose = '" + p_type + "' and f_smid = '" + p_smid + "'";

            //if (!"".Equals(p_BDate))
            //{
            //    l_sql += " and f_editdate between '" + p_BDate + "' and '" + p_EDate + "'";
            //}
            //l_sql += " order by f_editdate";


            l_sql += " select m.*,c.Name,p.f_memo as memo";
            l_sql += " from tbInMoney m";
            l_sql += " left join dbo.tbKGPartOrder p on m.f_workid = p.f_ExchangeID";
            l_sql += " left join dbo.tbWork w on w.f_workid = m.f_workid";
            l_sql += " left join kddb..orders o on o.EngNo = p.f_engineno";
            l_sql += " left join kddb..customer c on o.customerid = c.customerid";
            l_sql += " where m.f_isclose = '" + p_type + "' and m.f_smid = '" + p_smid + "'";
            if (!"".Equals(p_BDate))
            {
                l_sql += " and m.f_editdate between '" + p_BDate + "' and '" + p_EDate + "'";
            }
            l_sql += " order by f_editdate";

            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_sql);
            C欠款紀錄[] l_datas = new C欠款紀錄[l_dv.Count];

            if (l_dv != null)
            {
                for (int i = 0; i < l_datas.Length; i++)
                {
                    l_datas[i] = createC欠款紀錄();
                    l_datas[i].單號 = l_dv[i]["f_workid"].ToString();
                    l_datas[i].金額 = l_dv[i]["f_money"].ToString();
                    l_datas[i].帳款日期 = l_dv[i]["f_editdate"].ToString();
                    l_datas[i].備註 = l_dv[i]["memo"].ToString();
                    l_datas[i].總類 = l_dv[i]["f_type"].ToString();

                    //2013/05/20 新增顧客姓名欄位
                    l_datas[i].顧客姓名 = l_dv[i]["Name"].ToString();
                }
                return l_datas;
            }
            return null;
        }
    }
}
