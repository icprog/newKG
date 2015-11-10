using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using tw.com.yj.CommonLib;

namespace tw.com.kg.lib
{
    public class CUserFactory : YJCCommonFactory
    {
        public CUserFactory(YJCommonContext p_context)
        {
            setContext(p_context);
        }
        public CUser createCUser()
        {
            return new CUser();
        }


        public CUser getUserByUserName(string p_UserName,string p_Password)
        {
            string l_sql = "";
            l_sql += " select *";
            l_sql += " from dbo.tbUser";
            l_sql += " where f_userid = '" + p_UserName + "'";
            l_sql += " and f_password = '" + p_Password + "'";

            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_sql);
            CUser l_datas = createCUser();
            if (l_dv.Count != 0)
            {
                l_datas = createCUser();
                l_datas.f_userid帳號 = l_dv[0]["f_userid"].ToString();
                l_datas.f_password密碼 = l_dv[0]["f_password"].ToString();
                l_datas.f_username姓名 = l_dv[0]["f_username"].ToString();
                l_datas.f_branchid所別 = l_dv[0]["f_branchid"].ToString();
                l_datas.f_lvl等級 = Convert.ToInt32(l_dv[0]["f_lvl"].ToString());
                return l_datas;
            }
            return null;
        }
        public CUser get取得使用者by帳號(string p_str帳號)
        {
            string l_sql = "";

            l_sql += " select a.*,b.branch";
            l_sql += " from kg..tbUser a";
            l_sql += " left join kdnews..t_hrpersonel b on a.f_userid = b.emp_id";
            l_sql += " where a.f_userid ='" + p_str帳號 + "'";

            //l_sql += " select * from tbUser where f_userid ='" + p_str帳號 + "'";

            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_sql);
            CUser l_datas = createCUser();

            if (l_dv.Count != 0)
            {
                //for (int i = 0; i < l_datas.Length; i++)
                //{
                    l_datas = createCUser();
                    l_datas.f_userid帳號 = l_dv[0]["f_userid"].ToString();
                    l_datas.f_password密碼 = l_dv[0]["f_password"].ToString();
                    l_datas.f_username姓名 = l_dv[0]["f_username"].ToString();
                    l_datas.f_branchid所別 = l_dv[0]["f_branchid"].ToString();
                    l_datas.f_lvl等級 = Convert.ToInt32(l_dv[0]["f_lvl"].ToString());
                    l_datas.f_branch所別名稱 = l_dv[0]["branch"].ToString();
                //}
                return l_datas;
            }
            return null;

        }

        public void deleteByID(string p_ID)
        {
            string l_Sql = "";

            l_Sql += "delete from [KG].[dbo].[tbUser] where f_userid ='" + p_ID + "'";
            ivContext.資料管理員.excuteSqlNonquery(l_Sql);
        }

        public void insert(CUser p_data)
        {
            string l_Sql = "";

            l_Sql += "INSERT INTO [KG].[dbo].[tbUser] VALUES (";
            l_Sql += " '" + p_data.f_userid帳號 + "'";
            l_Sql += ", '" + p_data.f_password密碼 + "'";
            l_Sql += ", '" + p_data.f_username姓名 + "'";
            l_Sql += ", '" + p_data.f_branchid所別 + "'";
            l_Sql += ",  " + p_data.f_lvl等級 + "";
            l_Sql += ")";
            ivContext.資料管理員.excuteSqlNonquery(l_Sql);
        }
        public void update(CUser p_data)
        {
            string l_Sql = "";

            l_Sql += "update [KG].[dbo].[tbUser] set ";
            l_Sql += "  f_password = '" + p_data.f_password密碼 + "'";
            l_Sql += ", f_username = '" + p_data.f_username姓名 + "'";
            l_Sql += ", f_branchid = '" + p_data.f_branchid所別 + "'";
            l_Sql += ", f_lvl = " + p_data.f_lvl等級 + "";
            l_Sql += " where f_userid ='" + p_data.f_userid帳號 + "'";
            ivContext.資料管理員.excuteSqlNonquery(l_Sql);
        }

        public CUser[] getAll洗車人員()
        {

            string l_sql = "";
            l_sql += " select * from tbUser where f_lvl =0 order by f_userid";

            if (queryBySql(l_sql).Length != 0)
            {
                return queryBySql(l_sql);
            }
            return null;
        }
        public CUser[] getAll所別()
        {

            string l_sql = "";
            l_sql += " select f_branchid from tbUser group by f_branchid";

            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_sql);
            CUser[] l_datas = new CUser[l_dv.Count];

            if (l_dv != null)
            {
                for (int i = 0; i < l_datas.Length; i++)
                {
                    l_datas[i] = createCUser();
                    l_datas[i].f_branchid所別 = l_dv[i]["f_branchid"].ToString();
                }
                return l_datas;
            }
            return null;
        }
        public CUser[] getAllUser()
        {

            string l_sql = "";
            l_sql += " select * from tbUser order by f_branchid,f_userid";

            CUser[] l_user = queryBySql(l_sql);
            if (l_user.Length != 0)
            {
                return l_user;
            }
            return null;
        }

        public CUser[] getAllUserBySearch(string p_帳號,string p_所別,string p_等級)
        {
            string l_query = "";
            if (!"".Equals(p_帳號))
            {
                l_query += " f_userid='" + p_帳號 + "' and ";
            }
            if (!"".Equals(p_所別))
            {
                l_query += " f_branchid='" + p_所別 + "' and ";
            }
            if (!"".Equals(p_等級))
            {
                l_query += " f_lvl='" + p_等級 + "' and ";
            }

            string l_sql = "";
            l_sql += " select * from tbUser ";

            if (l_query.Length > 0)
            {
                l_sql += " where " + l_query.Substring(0,l_query.Length-4);
            }
            l_sql += " order by f_branchid,f_lvl";

               return queryBySql(l_sql);
        }
        private CUser[] queryBySql(string p_sql)
        {
            DataView l_dv = ivContext.資料管理員.getDataViewBySql(p_sql);
            CUser[] l_datas = new CUser[l_dv.Count];

            if (l_dv != null)
            {
                for (int i = 0; i < l_datas.Length; i++)
                {
                    l_datas[i] = createCUser();
                    l_datas[i].f_userid帳號 = l_dv[i]["f_userid"].ToString();
                    l_datas[i].f_password密碼 = l_dv[i]["f_password"].ToString();
                    l_datas[i].f_username姓名 = l_dv[i]["f_username"].ToString();
                    l_datas[i].f_branchid所別 = l_dv[i]["f_branchid"].ToString();
                    l_datas[i].f_lvl等級 = Convert.ToInt32(l_dv[i]["f_lvl"].ToString());
                }
                return l_datas;
            }
            return null;
        }


        /// <summary>
        /// 取得高都員工檔方便判斷
        /// </summary>
        /// <param name="p_smid"></param>
        /// <returns></returns>
        public CUser get高都員工檔(string p_smid)
        {
            string l_sql = "";
            l_sql += "select * from kdnews..T_HRPersonel where Emp_id ='" + p_smid + "'";

            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_sql);
            CUser l_datas = createCUser();

            if (l_dv.Count > 0 )
            {
                l_datas.f_branchid所別 = l_dv[0]["Branch"].ToString();
                l_datas.f_username姓名 = l_dv[0]["Name"].ToString();
                return l_datas;
            }
            return null;
        }




        public CUser getTestEIP討論區()
        {
            string l_sql = "";

            l_sql += " select * from TB_EIP_FORUM_ARTICLE";
            l_sql += " where subject = '【2011年夏季刊_生活找樂子】高都少婦『素華』帶你吃透透~『POSITANO波西塔諾』'";
            l_sql += " order by CREATE_DATE";

            //l_sql += " select * from tbUser where f_userid ='" + p_str帳號 + "'";

            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_sql);
            CUser l_datas = createCUser();

            if (l_dv.Count != 0)
            {
                //for (int i = 0; i < l_datas.Length; i++)
                //{
                l_datas = createCUser();
                l_datas.f_userid帳號 = l_dv[0]["CONTEXT"].ToString();
                //}
                return l_datas;
            }
            return null;

        }

    }
}
