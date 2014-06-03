using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tw.com.yj.CommonLib;
using System.Data;
using System.Collections;

namespace tw.com.kg.lib
{
    public class CInMoneyFactory : YJCCommonFactory
    {
        public CInMoneyFactory(YJCommonContext p_context)
        {
            setContext(p_context);
        }
        public CInMoney createCInMoney()
        {
            return new CInMoney();
        }

        public void insert(CInMoney p_data)
        {
            string l_Sql = "";

            l_Sql += "INSERT INTO [KG].[dbo].[tbInMoney] VALUES (";
            l_Sql += " '" + p_data.f_moneyid應收單號 + "'";
            l_Sql += ", '" + p_data.f_workid工單單號 + "'";
            l_Sql += ", " + p_data.f_money應收金額 + "";
            l_Sql += ", '" + p_data.f_editdate帳款日期 + "'";
            l_Sql += ", '" + p_data.f_isclose是否關帳 + "'";
            l_Sql += ", " + p_data.f_yesmoney已沖金額 + "";
            l_Sql += ", '" + p_data.f_smid帳款人 + "'";
            l_Sql += ", '" + p_data.f_memo備註 + "'";
            l_Sql += ", '" + p_data.f_type種類 + "'";
            l_Sql += ", ''";
            l_Sql += ")";
            ivContext.資料管理員.excuteSqlNonquery(l_Sql);
        }
        public void delete(CInMoney p_data)
        {
            string l_Sql = "";

            l_Sql += "delete from  [KG].[dbo].[tbInMoney]";
            l_Sql += " WHERE [f_workid] = '" + p_data.f_workid工單單號 + "'";

            ivContext.資料管理員.excuteSqlNonquery(l_Sql);
        }

        public void update多筆沖帳(ArrayList p_al, CUser p_User, string l_strIP)
        {
            string l_Sql = "";
            l_Sql += "update [KG].[dbo].[tbInMoney] set f_isclose='Y',f_yesmoney=f_money,f_memo='" + DateTime.Now + "結清帳款,沖帳人:" + p_User.f_username姓名 + ",IP:" + l_strIP + "',f_fulldate='"+DateTime.Today.ToString("yyyy/MM/dd")+"'";
            l_Sql += " where f_workid in (";
            for (int i = 0; i < p_al.Count; i++)
            {
                l_Sql +="'"+ p_al[i].ToString() + "' ,";
            }
            l_Sql = l_Sql.Substring(0, l_Sql.Length - 1);
            l_Sql += ")";

            ivContext.資料管理員.excuteSqlNonquery(l_Sql);

        }

        public CInMoney[] get查詢應收帳款(string p_smid,string p_BDate,string p_EDate)
        {
            string l_Sql = "";

            l_Sql += "select i.*,t.name from  [KG].[dbo].[tbInMoney] i";
            l_Sql += " left join kdnews..T_HRPersonel t on i.f_smid = t.emp_id  ";

            l_Sql += " where f_isclose = 'N'";

            if (!"".Equals(p_smid))
            {
                l_Sql += " and f_smid = '" + p_smid + "'";
            }
            if (!"".Equals(p_BDate))
            {
                l_Sql += " and i.f_editdate between '" + p_BDate + "' and '" + p_EDate + "'";
            }
            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_Sql);
            CInMoney[] l_datas = new CInMoney[l_dv.Count];
            if (l_dv != null)
            {
                for (int i = 0; i < l_datas.Length; i++)
                {
                    l_datas[i] = createCInMoney();
                    l_datas[i].f_moneyid應收單號 = l_dv[i]["f_moneyid"].ToString();
                    l_datas[i].f_workid工單單號 = l_dv[i]["f_workid"].ToString();
                    l_datas[i].f_money應收金額 =Convert.ToInt32( l_dv[i]["f_money"].ToString() );
                    l_datas[i].f_editdate帳款日期 = l_dv[i]["f_editdate"].ToString();
                    l_datas[i].f_isclose是否關帳 = l_dv[i]["f_isclose"].ToString();
                    l_datas[i].f_yesmoney已沖金額 = Convert.ToInt32(l_dv[i]["f_yesmoney"].ToString());
                    l_datas[i].f_smid帳款人 = l_dv[i]["f_smid"].ToString();
                    l_datas[i].f_memo備註 = l_dv[i]["f_memo"].ToString();
                    l_datas[i].f_type種類 = l_dv[i]["f_type"].ToString();
                    l_datas[i].f_smid員工名稱 = l_dv[i]["name"].ToString();
                }
                return l_datas;
            }
            return null;
        }

        private CInMoney[] queryBySql(string p_sql)
        {
            DataView l_dv = ivContext.資料管理員.getDataViewBySql(p_sql);
            CInMoney[] l_datas = new CInMoney[l_dv.Count];

            if (l_dv != null)
            {
                for (int i = 0; i < l_datas.Length; i++)
                {
                    l_datas[i] = createCInMoney();
                    l_datas[i].f_moneyid應收單號 = l_dv[i]["f_moneyid"].ToString();
                    l_datas[i].f_workid工單單號 = l_dv[i]["f_workid"].ToString();
                    l_datas[i].f_moneyid應收單號 = l_dv[i]["f_money"].ToString();
                    l_datas[i].f_editdate帳款日期 = l_dv[i]["f_editdate"].ToString();
                    l_datas[i].f_isclose是否關帳 = l_dv[i]["f_isclose"].ToString();
                    l_datas[i].f_yesmoney已沖金額 =Convert.ToInt32( l_dv[i]["f_yesmoney"].ToString() );
                    l_datas[i].f_smid帳款人 = l_dv[i]["f_smid"].ToString();
                    l_datas[i].f_memo備註 = l_dv[i]["f_memo"].ToString();
                    l_datas[i].f_type種類 = l_dv[i]["f_type"].ToString();
                }
                return l_datas;
            }
            return null;
        }

    }
}
