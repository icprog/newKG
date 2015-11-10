using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tw.com.yj.CommonLib;
using System.Data;

namespace tw.com.kg.lib
{
    public class CWorkFactory: YJCCommonFactory
    {
        public CWorkFactory(YJCommonContext p_context)
        {
            setContext(p_context);
        }
        public CWork createCWork()
        {
            return new CWork();
        }

        public CWork[] get工單資訊By管理者(string p_BDate, string p_EDate, string p_str工單號碼, string p_所別, string p_是否完工,
                                        string p_str工單類型, string p_str是否招攬, bool p_bool服務廠, string p_str車牌或引擎, bool p_bool和榮)
        {
            string l_Sql = "";
            l_Sql += "select  w.* ,t.name from tbWork w";
            l_Sql += " left join kdnews..T_HRPersonel t on w.f_edituser = t.emp_id";
            l_Sql += " where 1 = 1";

            if (!"".Equals(p_str工單號碼))
            {
                l_Sql += " and w.f_workid = '" + p_str工單號碼 + "'";
            }

            if (!"".Equals(p_所別))
            {
                l_Sql += " and w.f_branchid ='" + p_所別 + "'";
            }

            //Y:完工 ,N:未完工 判斷欄位f_closedate
            if ("Y".Equals(p_是否完工))
            {
                if (!"".Equals(p_BDate))
                {
                    l_Sql += " and w.f_closedate between '" + p_BDate + "' and '" + p_EDate + "'";
                }
                else
                {
                    l_Sql += " and w.f_closedate <> '' ";
                }
            }
            else if ("N".Equals(p_是否完工))
            {
                if (!"".Equals(p_BDate))
                {
                    l_Sql += " and substring(w.f_editdate,0,11) between '" + p_BDate + "' and '" + p_EDate + "'";
                }
                l_Sql += " and w.f_closedate = '' ";
            }
            else
            {

                if (!"".Equals(p_BDate))
                {
                    l_Sql += " and substring(w.f_editdate,0,11) between '" + p_BDate + "' and '" + p_EDate + "'";
                }
            }

            if (!"".Equals(p_str工單類型))
            {
                l_Sql += " and w.f_type ='" + p_str工單類型 + "'";
            }
            //和榮只看D00
            if (p_bool和榮)
            {
                l_Sql += " and w.f_worktype like 'D00%'";
            }
           

            //Y:完工 ,N:未完工 判斷欄位f_closedate
            if ("Y".Equals(p_str是否招攬))
            {
                l_Sql += " and w.f_introducer <> '' ";
            }
            else if ("N".Equals(p_str是否招攬))
            {
                l_Sql += " and w.f_introducer = '' ";
            }

            //服務廠業績項目是三種,富貴要看的
            if (p_bool服務廠)
            {
                l_Sql += " and w.f_type in ('一般','保險','員工')";
            }
           
            if (!"".Equals(p_str車牌或引擎))
            {
                l_Sql += " and w.f_engo ='" + p_str車牌或引擎 + "'";
            }
            l_Sql += " order by w.f_branchid,w.f_editdate";
            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_Sql);
            CWork[] l_datas = new CWork[l_dv.Count];

            if (l_dv != null)
            {
                for (int i = 0; i < l_datas.Length; i++)
                {
                    l_datas[i] = createCWork();
                    l_datas[i].f_workid工單單號 = l_dv[i]["f_workid"].ToString();
                    l_datas[i].f_engo引擎號碼 = l_dv[i]["f_engo"].ToString();
                    l_datas[i].f_customerid顧客名稱 = l_dv[i]["f_customerid"].ToString();
                    l_datas[i].f_workType洗車種類 = l_dv[i]["f_workType"].ToString();
                    l_datas[i].f_money金額 = Convert.ToInt32(l_dv[i]["f_money"].ToString());
                    l_datas[i].f_memo備註 = l_dv[i]["f_memo"].ToString();
                    l_datas[i].f_edituser開單人員 = l_dv[i]["f_edituser"].ToString();
                    l_datas[i].f_editdate開單日期 = l_dv[i]["f_editdate"].ToString();
                    l_datas[i].f_closeDate完工日 = l_dv[i]["f_closeDate"].ToString();
                    l_datas[i].f_introducer介紹人 = l_dv[i]["f_introducer"].ToString();
                    l_datas[i].f_type工單種類 = l_dv[i]["f_type"].ToString();
                    l_datas[i].f_insuranceid保險代碼 = l_dv[i]["f_insuranceid"].ToString();
                    l_datas[i].f_staus狀態 = l_dv[i]["f_staus"].ToString();
                    l_datas[i].f_branchid工單所別 = l_dv[i]["f_branchid"].ToString();
                    l_datas[i].f_seruser服務專員 = l_dv[i]["f_seruser"].ToString();
                    l_datas[i].f_edituser開單人員 = l_dv[i]["name"].ToString();
                }
                return l_datas;
            }
            return null;
        }

        public CWork get工單資訊By單號(string p_單號)
        {
            string l_Sql = "";

            l_Sql += "select * from tbWork where f_workid = '" + p_單號 + "'";

            CWork[] l_work = queryBySql(l_Sql);
            if (l_work.Length > 0)
            {
                return l_work[0];
            }
            return null;
        }
        public CWork[] get工單資訊By單號s(List<string> p_單號s)
        {
            if (p_單號s.Count <= 0)
            {

                return null;
            }
            string l_Sql = "";

            string l_str = "";
            for (int i = 0; i < p_單號s.Count; i++)
            {
                l_str += "'" + p_單號s[i] + "',";
            }
            l_Sql += "select * from tbWork where f_workid in (" + l_str.Substring(0, l_str.Length-1) + ")";

            CWork[] l_work = queryBySql(l_Sql);
            if (l_work.Length > 0)
            {
                return l_work;
            }
            return null;
        }

        public CWork get判斷是否有同一天重複開單(string p_引擎號碼, string p_日期)
        {
            string l_Sql = "";

            l_Sql += "select f_edituser from tbWork where f_engo = '" + p_引擎號碼 + "' and substring(f_editdate,0,11) ='" + p_日期 + "'";

            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_Sql);
            CWork[] l_datas = new CWork[l_dv.Count];

            if (l_datas.Length > 0)
            {
                for (int i = 0; i < l_datas.Length; i++)
                {
                    l_datas[i] = createCWork();
                    l_datas[i].f_edituser開單人員 = l_dv[i]["f_edituser"].ToString();
                }
                return l_datas[0];
            }
            return null;
        }

        public void deleteBy單號(string p_單號)
        {
            string l_Sql = "";

            l_Sql += "delete from tbWork where f_workid = '" + p_單號 + "'";

            ivContext.資料管理員.excuteSqlNonquery(l_Sql);

            //刪除工單一定要刪除應收帳款
            l_Sql = "delete from tbInMoney where f_workid = '" + p_單號 + "'";

            ivContext.資料管理員.excuteSqlNonquery(l_Sql);
        }

        public CWork[] get工單資訊By單號BySearch(string p_BDate, string p_EDate, string p_str工單號碼, string p_str開立者, bool p_bool完工日, string p_引擎號碼)
        {
            string l_Sql = "";
            l_Sql += "select * from tbWork where f_edituser = '" + p_str開立者 + "'";

            if (!"".Equals(p_str工單號碼))
            {
                l_Sql += " and f_workid = '" + p_str工單號碼 + "'";
            }


            if (!"".Equals(p_BDate))
            {
                if (p_bool完工日)
                {
                    l_Sql += " and f_closeDate between '" + p_BDate + "' and '" + p_EDate + "'";
                }
                else
                {
                    l_Sql += " and substring(f_editdate,0,11) between '" + p_BDate + "' and '" + p_EDate + "'";
                }
            }
            if (!"".Equals(p_引擎號碼))
            {
                l_Sql += " and f_engo = '" + p_引擎號碼 + "'";
            }
            
            return queryBySql(l_Sql);
        }

        public CWork[] get所別待處理工單(string p_str所別)
        {
            string l_Sql = "";
            l_Sql += "select * from tbWork where f_staus = '待處理'";
            l_Sql += " and f_branchid = '" + p_str所別 + "'";
            l_Sql += " order by f_editdate desc";//晚開立的工單在上面

            return queryBySql(l_Sql);
        }

        private CWork[] queryBySql(string p_sql)
        {
            DataView l_dv = ivContext.資料管理員.getDataViewBySql(p_sql);
            CWork[] l_datas = new CWork[l_dv.Count];

            if (l_dv != null)
            {
                for (int i = 0; i < l_datas.Length; i++)
                {
                    l_datas[i] = createCWork();
                    l_datas[i].f_workid工單單號 = l_dv[i]["f_workid"].ToString();
                    l_datas[i].f_engo引擎號碼 = l_dv[i]["f_engo"].ToString();
                    l_datas[i].f_customerid顧客名稱 = l_dv[i]["f_customerid"].ToString();
                    l_datas[i].f_workType洗車種類 = l_dv[i]["f_workType"].ToString();
                    l_datas[i].f_money金額 =Convert.ToInt32( l_dv[i]["f_money"].ToString() );
                    l_datas[i].f_memo備註 = l_dv[i]["f_memo"].ToString();
                    l_datas[i].f_edituser開單人員 = l_dv[i]["f_edituser"].ToString();
                    l_datas[i].f_editdate開單日期 = l_dv[i]["f_editdate"].ToString();
                    l_datas[i].f_closeDate完工日 = l_dv[i]["f_closeDate"].ToString();
                    l_datas[i].f_introducer介紹人 = l_dv[i]["f_introducer"].ToString();
                    l_datas[i].f_type工單種類 = l_dv[i]["f_type"].ToString();
                    l_datas[i].f_insuranceid保險代碼 = l_dv[i]["f_insuranceid"].ToString();
                    l_datas[i].f_staus狀態 = l_dv[i]["f_staus"].ToString();
                    l_datas[i].f_branchid工單所別 = l_dv[i]["f_branchid"].ToString();
                    l_datas[i].f_seruser服務專員 = l_dv[i]["f_seruser"].ToString();          
                }
                return l_datas;
            }
            return null;
        }

        public CWork[] get工單資訊By薪資(string p_strsmid, string p_strBDate , string p_strEDate)
        {
            string l_Sql = "";
            l_Sql += "select  work.* from tbWork as work ";
            l_Sql += " join tbConstruction as cons on cons.f_workid = work.f_workid ";
            l_Sql += "WHERE cons.f_smid = '" + p_strsmid + "'";
            //fix by fox 增加速度
            //l_Sql += " (select f_workid from tbConstruction where f_smid = '" + p_strsmid + "')";
            if (!"".Equals(p_strBDate))
            {
                l_Sql += " and work.f_closeDate between '" + p_strBDate + "' and '" + p_strEDate + "'";
            }
            //l_Sql += " order by  f_editdate";
            return queryBySql(l_Sql);
        }

        public int get工單資訊By業績(string p_strsmid, string p_strBDate, string p_strEDate)
        {
            string l_Sql = "";
            //fix by fox
            //l_Sql += "select sum(f_money) as f_money from tbWork ";
            //l_Sql += "where f_workid in";
            //l_Sql += " (select f_workid from tbConstruction where f_smid = '" + p_strsmid + "')";
            l_Sql += " select sum(w.f_money) as f_money ";
            l_Sql += " from tbConstruction as c ";
            l_Sql += " join tbwork as w on c.f_workid = w.f_workid ";
            l_Sql += " where 1 = 1 ";
            l_Sql += " and f_smid = '" + p_strsmid + "' ";
            if (!"".Equals(p_strBDate))
            {
                l_Sql += " and f_closeDate between '" + p_strBDate + "' and '" + p_strEDate + "'";
            }
            l_Sql += " group by c.f_smid "; //fix by fox

            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_Sql);
            CWork[] l_datas = new CWork[l_dv.Count];

            if (l_dv != null)
            {
                for (int i = 0; i < l_datas.Length; i++)
                {
                    l_datas[i] = createCWork();
                    l_datas[i].f_money金額 = Convert.ToInt32(l_dv[i]["f_money"].ToString());
                }
            }
            return l_datas[0].f_money金額;
        }

        public void insert(CWork p_data)
        {
            string l_Sql = "";

            l_Sql += "INSERT INTO [KG].[dbo].[tbWork](f_workid,f_engo,f_customerid,f_workType";
            l_Sql += " ,f_money,f_memo,f_edituser,f_editdate,f_closeDate,f_introducer,f_type";
            l_Sql += " ,f_insuranceid,f_insurancetype,f_staus,f_branchid,f_seruser) VALUES (";
            l_Sql += " '" + p_data.f_workid工單單號 + "'";
            l_Sql += ", '" + p_data.f_engo引擎號碼 + "'";
            l_Sql += ", '" + p_data.f_customerid顧客名稱 + "'";
            l_Sql += ", '" + p_data.f_workType洗車種類 + "'";
            l_Sql += ",  " + p_data.f_money金額 + "";
            l_Sql += ", '" + p_data.f_memo備註 + "'";
            l_Sql += ", '" + p_data.f_edituser開單人員 + "'";
            l_Sql += ", '" + p_data.f_editdate開單日期 + "'";
            l_Sql += ", '" + p_data.f_closeDate完工日 + "'";
            l_Sql += ", '" + p_data.f_introducer介紹人 + "'";
            l_Sql += ", '" + p_data.f_type工單種類 + "'";
            l_Sql += ", '" + p_data.f_insuranceid保險代碼 + "'";
            l_Sql += ", '" + p_data.f_insurancetype保險型態 + "'";
            l_Sql += ", '" + p_data.f_staus狀態 + "'";
            l_Sql += ", '" + p_data.f_branchid工單所別 + "'";
            l_Sql += ", '" + p_data.f_seruser服務專員 + "'";
            l_Sql += ")";
            ivContext.資料管理員.excuteSqlNonquery(l_Sql);
        }

        public void update(CWork p_data)
        {
            string l_Sql = "";

            l_Sql += "UPDATE [KG].[dbo].[tbWork]";
            l_Sql += " SET [f_engo] ='" + p_data.f_engo引擎號碼 + "'";
            l_Sql += ",[f_customerid] ='"+ p_data.f_customerid顧客名稱+ "'";
            l_Sql += ",[f_workType] ='"+ p_data.f_workType洗車種類+ "'";
            l_Sql += " ,[f_money]="+ p_data.f_money金額+ "";
            l_Sql += ",[f_memo] ='"+ p_data.f_memo備註+ "'";
            l_Sql += ",[f_edituser] ='"+ p_data.f_edituser開單人員+ "'";
            l_Sql += ",[f_editdate] ='"+ p_data.f_editdate開單日期+ "'";
            l_Sql += ",[f_closeDate] ='" + p_data.f_closeDate完工日 + "'";
            l_Sql += ",[f_introducer] ='"+ p_data.f_introducer介紹人+ "'";
            l_Sql += ",[f_type] ='" + p_data.f_type工單種類 + "'";
            l_Sql += ",[f_staus] ='" + p_data.f_staus狀態 + "'";
            l_Sql += ",[f_branchid] ='" + p_data.f_branchid工單所別 + "'";
            l_Sql += " WHERE [f_workid] = '" + p_data.f_workid工單單號 + "'";

            ivContext.資料管理員.excuteSqlNonquery(l_Sql);
        }


        public CWork[] get工單資訊By施工人員檔(CWork p_CWork)
        {
            string l_Sql = "";
            l_Sql += "select * from tbWork where f_workid in (";

            for (int i = 0; i < p_CWork.tb施工人員業績.Length; i++)
            {
                l_Sql += " '" + p_CWork.tb施工人員業績[i].f_workid工單單號 + "',";
            }

            l_Sql = l_Sql.Substring(0, l_Sql.Length - 1);

            l_Sql += ")";


            l_Sql += " order by f_closeDate";

            return queryBySql(l_Sql);
        }
    }
}
