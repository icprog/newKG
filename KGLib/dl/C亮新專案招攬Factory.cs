using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using tw.com.yj.CommonLib;

namespace tw.com.kg.lib
{
    public class C亮新專案招攬Factory : YJCCommonFactory
    {
        public C亮新專案招攬Factory(YJCommonContext p_context)
        {
            setContext(p_context);
        }
        public C亮新專案招攬 createC亮新專案招攬()
        {
            return new C亮新專案招攬();
        }


        public C亮新專案招攬[] get亮新專案招攬明細(string p_BDate, string p_EDate, string p_BCloseDate, string p_ECloseDate, string p_strBranchid, string p_str是否招攬, string p_str洗車別, string p_str是否完工)
        {
            string l_sql = "";

            l_sql += " select w.f_closedate,w.f_engo,w.f_workid,w.f_worktype,w.f_money,t.branch,t.emp_id,t.name,w.f_branchid,u.f_username,i.f_name,y.f_boundBySmid";
            l_sql += " from dbo.tbWork w";
            l_sql += " left join kdnews..T_HRPersonel t on w.f_introducer = t.emp_id";
            l_sql += " inner join kg..tbUser u on w.f_edituser = u.f_userid ";
            l_sql += " left join kg..tbInsurance i on w.f_insuranceid = i.f_id  ";
            l_sql += " inner join kg..tbWorkType y on w.f_worktype = y.f_typeid  ";
            
            if ("".Equals(p_str洗車別))
            {
                l_sql += " where f_worktype in ('L1','L2','L3','L4','L5','N1','N2','N3','N4','N5')";//只抓取亮新代碼
            }
            else if ("A".Equals(p_str洗車別))
            {
                l_sql += " where f_worktype in ('A1','A2','A3','A4','A5')";//只抓取小美容代碼
            }
            else if ("B".Equals(p_str洗車別))
            {
                l_sql += " where f_worktype in ('B1','B2','B3','B4','B5')";//只抓取覆膜代碼
            }


                //l_sql += " and w.f_closedate <> ''";//完工才計算

            if (!"".Equals(p_BDate))
            {
                l_sql += " and substring(w.f_editdate,0,11) between '" + p_BDate + "' and '" + p_EDate + "'";
            }
            if (!"".Equals(p_BCloseDate))
            {
                l_sql += " and w.f_closedate between '" + p_BCloseDate + "' and '" + p_ECloseDate + "'";
            }
            if (!"".Equals(p_strBranchid))
            {
                l_sql += " and w.f_branchid = '" + p_strBranchid + "'";
            }

            if (!"".Equals(p_str是否招攬))
            {
                if ("Y".Equals(p_str是否招攬))
                {
                    l_sql += " and w.f_introducer <> '' ";
                }
                else
                {
                    l_sql += " and w.f_introducer = '' ";
                }
            }

            if (!"".Equals(p_str是否完工))
            {
                if ("Y".Equals(p_str是否完工))
                {
                    l_sql += " and w.f_closedate <> '' ";
                }
                else
                {
                    l_sql += " and w.f_closedate = '' ";
                }
            }
            l_sql += " order by w.f_closedate,w.f_branchid";

            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_sql);
            C亮新專案招攬[] l_datas = new C亮新專案招攬[l_dv.Count];

            if (l_dv != null)
            {
                for (int i = 0; i < l_datas.Length; i++)
                {
                    l_datas[i] = createC亮新專案招攬();
                    l_datas[i].完工日期 = l_dv[i]["f_closedate"].ToString();
                    l_datas[i].引擎號碼 = l_dv[i]["f_engo"].ToString();
                    l_datas[i].工單單號 = l_dv[i]["f_workid"].ToString();
                    l_datas[i].施工代號 = l_dv[i]["f_worktype"].ToString();
                    l_datas[i].金額 = Convert.ToInt32(l_dv[i]["f_money"].ToString());

                    //2011-05-05 新增小美容and覆膜之獎金計算
                    if ("".Equals(p_str洗車別))
                    {
                        l_datas[i].獎金 = l_datas[i].金額 * 0.1;//10%獎金
                    }
                    else
                    {
                        l_datas[i].獎金 = Convert.ToInt32(l_dv[i]["f_boundBySmid"].ToString());
                    }
                    
                   
                    l_datas[i].招攬單位 = l_dv[i]["branch"].ToString();
                    l_datas[i].招攬人員員編 = l_dv[i]["emp_id"].ToString();
                    l_datas[i].招攬人員名稱 = l_dv[i]["name"].ToString();
                    l_datas[i].開單據點 = l_dv[i]["f_branchid"].ToString();
                    l_datas[i].開單人員 = l_dv[i]["f_username"].ToString();
                    l_datas[i].保險公司 = l_dv[i]["f_name"].ToString();
                }
                return l_datas;
            }
            return null;
        }
    }
}
