using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using tw.com.yj.CommonLib;

namespace tw.com.kg.lib
{
    public class CConstructionFactory : YJCCommonFactory
    {
        public CConstructionFactory(YJCommonContext p_context)
        {
            setContext(p_context);
        }
        public CConstruction createCConstruction()
        {
            return new CConstruction();
        }

        public void insert_s(List<CConstruction> p_list)
        {
            string l_Sql = "Begin";
            //insert前先刪除之前的使用者
            l_Sql += " Delete from  [KG].[dbo].[tbConstruction] where f_workid='" + p_list[0].f_workid工單單號 + "';";

            for (int i = 0; i < p_list.Count; i++)
            {
                l_Sql += "INSERT INTO [KG].[dbo].[tbConstruction](f_workid,f_smid) VALUES (";
                l_Sql += " '" + p_list[i].f_workid工單單號 + "'";
                l_Sql += ", '" + p_list[i].f_smid施工人員 + "'";
                l_Sql += "); ";
            }
            l_Sql += " End ";
            ivContext.資料管理員.excuteSqlNonquery(l_Sql);
        }

        public void insert(CConstruction p_data)
        {
            string l_Sql = "";

            l_Sql += "INSERT INTO [KG].[dbo].[tbConstruction](f_workid,f_smid) VALUES (";
            l_Sql += " '" + p_data.f_workid工單單號 + "'";
            l_Sql += ", '" + p_data.f_smid施工人員 + "'";
            l_Sql += ")";
            ivContext.資料管理員.excuteSqlNonquery(l_Sql);
        }

        public void delete(CConstruction p_data)
        {
            string l_Sql = "";

            l_Sql += "delete from  [KG].[dbo].[tbConstruction]";
            l_Sql += " WHERE [f_workid] = '" + p_data.f_workid工單單號 + "'";

            ivContext.資料管理員.excuteSqlNonquery(l_Sql);
        }

        public CConstruction[] get施工人員By單號(string l_strWorkid)
        {
            string l_Sql = "";

            l_Sql += " select * from  [KG].[dbo].[tbConstruction] where f_workid='" + l_strWorkid + "'";

            return queryBySql(l_Sql);
        }

        public CConstruction[] get施工人員明細By單號(string p_strWorkid)
        {
            string l_Sql = "";

            l_Sql += " select c.*,u.f_username";
            l_Sql += " from  [KG].[dbo].[tbConstruction] c";
            l_Sql += " inner join [KG].[dbo].tbUser u on c.f_smid = u.f_userid";
            l_Sql += " where f_workid='" + p_strWorkid + "'";

            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_Sql);
            CConstruction[] l_datas = new CConstruction[l_dv.Count];

            if (l_dv != null)
            {
                for (int i = 0; i < l_datas.Length; i++)
                {
                    l_datas[i] = createCConstruction();
                    l_datas[i].f_workid工單單號 = l_dv[i]["f_workid"].ToString();
                    l_datas[i].f_smid施工人員 = l_dv[i]["f_smid"].ToString();
                    l_datas[i].f_smid施工人員名稱 = l_dv[i]["f_username"].ToString();
                }
                return l_datas;
            }
            return null;
        }
        private CConstruction[] queryBySql(string p_sql)
        {
            DataView l_dv = ivContext.資料管理員.getDataViewBySql(p_sql);
            CConstruction[] l_datas = new CConstruction[l_dv.Count];

            if (l_dv != null)
            {
                for (int i = 0; i < l_datas.Length; i++)
                {
                    l_datas[i] = createCConstruction();
                    l_datas[i].f_workid工單單號 = l_dv[i]["f_workid"].ToString();
                    l_datas[i].f_smid施工人員 = l_dv[i]["f_smid"].ToString();
                }
                return l_datas;
            }
            return null;
        }


        public CConstruction[] get業績By施工人員(string p_strSmid,string p_BDate,string p_EDate,bool p_bool完工日)
        {
            string l_Sql = "";

            l_Sql += " select c.*";
            l_Sql += " from dbo.tbConstruction c inner join dbo.tbWork w on w.f_workid = c.f_workid ";
            l_Sql += " where isnull(w.f_closeDate,'') <> ''";//有完工日才算業績
            l_Sql += " and c.f_smid ='" + p_strSmid + "'";

            if (!"".Equals(p_BDate))
            {
                if (p_bool完工日)
                {
                    l_Sql += " and f_closeDate between '" + p_BDate + "' and '" + p_EDate + "'";
               
                }
                else
                {
                    l_Sql += " and substring(w.f_editdate,0,11) between '" + p_BDate + "' and '" + p_EDate + "'";
                }
            }
            return queryBySql(l_Sql);
        }
    }
}
