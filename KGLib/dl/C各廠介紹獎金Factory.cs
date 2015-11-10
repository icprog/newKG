using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tw.com.yj.CommonLib;
using System.Data;

namespace tw.com.kg.lib
{
    public class C各廠介紹獎金Factory : YJCCommonFactory
    {
        public C各廠介紹獎金Factory(YJCommonContext p_context)
        {
            setContext(p_context);
        }
        public C各廠介紹獎金 createC各廠介紹獎金()
        {
            return new C各廠介紹獎金();
        }


        //public C各廠介紹獎金[] get各廠介紹獎金(string p_BDate, string p_EDate)
        //{
        //    string l_sql = "";
        //    l_sql += "select f_branchid,sum(f_money) as amt,";
        //    //將有介紹人的金額加總,方便統計全部獎金與介紹獎金
        //    l_sql += " otheramt = IsNull(sum(case ";
        //    l_sql += " when (isnull(f_introducer,'') <> '' ) then f_money";
        //    l_sql += " end),0)";
        //    l_sql += " from dbo.tbWork w";
        //    //新車為營業所業績故不計算在內
        //    l_sql += " where f_type in ('一般','保險','員工')";

        //    if (!"".Equals(p_BDate))
        //    {
        //        l_sql += " and w.editdate between '" + p_BDate + "' and '" + p_EDate + "'";
        //    }

        //    l_sql += " group by f_branchid";

        //    DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_sql);
        //    C各廠介紹獎金[] l_datas = new C各廠介紹獎金[l_dv.Count];

        //    if (l_dv != null)
        //    {
        //        for (int i = 0; i < l_datas.Length; i++)
        //        {
        //            l_datas[i] = createC各廠介紹獎金();
        //            l_datas[i].據點 = l_dv[i]["f_branchid"].ToString();
        //            l_datas[i].業績 = Convert.ToInt32(l_dv[i]["amt"]);
        //            l_datas[i].所介紹業績 = Convert.ToInt32(l_dv[i]["otheramt"]);
        //            //廠業績 = (該廠總業績 - 所介紹業績) * 40%
        //            l_datas[i].獎金 = (l_datas[i].業績 - l_datas[i].所介紹業績) * 0.4;
        //        }
        //        return l_datas;
        //    }
        //    return null;
        //}


        public C各廠介紹獎金[] get各廠介紹獎金(string p_BDate, string p_EDate)
        {
            string l_sql = "";
            l_sql += "select f_branchid,";
            //不計算有介紹人的金額加總
            l_sql += " amt = IsNull(sum(case when (isnull(f_type,'')  in ('一般','員工') and isnull(f_introducer,'') = '' ) then f_money end),0),";
            l_sql += " otheramt = IsNull(sum(case when (isnull(f_type,'')  in ('保險') and isnull(f_introducer,'') = '' ) then f_money end),0)";
            l_sql += " from dbo.tbWork w ";
            //新車為營業所業績故不計算在內
            l_sql += " where f_type in ('一般','保險','員工')";
            //l_sql += " and f_closedate <> '' ";
           //亮新也不列入計算
            //l_sql += " and f_worktype not in ('L1','L2','L3','L4','L5','N1','N2','N3','N4','N5')";

            if (!"".Equals(p_BDate))
            {
                l_sql += " and f_closedate between '" + p_BDate + "' and '" + p_EDate + "'";
            }

            l_sql += " group by f_branchid";
            l_sql += " order by f_branchid";

            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_sql);
            C各廠介紹獎金[] l_datas = new C各廠介紹獎金[l_dv.Count];

            if (l_dv != null)
            {
                for (int i = 0; i < l_datas.Length; i++)
                {
                    l_datas[i] = createC各廠介紹獎金();
                    l_datas[i].據點 = l_dv[i]["f_branchid"].ToString();
                    l_datas[i].一般業績 = Convert.ToInt32(l_dv[i]["amt"]);
                    //一般獎金 = 該廠業績 * 8%
                    l_datas[i].一般獎金 = l_datas[i].一般業績 * 0.08;
                    l_datas[i].保險業績 = Convert.ToInt32(l_dv[i]["otheramt"]);
                    //保險獎金 = 該廠業績 * 8%
                    l_datas[i].保險獎金 = l_datas[i].保險業績 * 0.04;
                }
                return l_datas;
            }
            return null;
        }



        public C各廠介紹獎金[] get各廠介紹獎金By明細(string p_BDate, string p_EDate,string p_Branchid)
        {
            string l_sql = "";
            l_sql += "select f_editdate,f_workid,f_engo,f_worktype,f_money,f_edituser,t.name,f_type,i.f_name ";
            //不計算有介紹人的金額加總
            l_sql += " from dbo.tbWork w ";
            l_sql += " left join kdnews..T_HRPersonel t on w.f_introducer = t.emp_id";
            l_sql += " left join kg..tbInsurance i on w.f_insuranceid = i.f_id ";
            //新車為營業所業績故不計算在內
            l_sql += " where f_type in ('一般','保險','員工') ";
            //亮新也不列入計算
            //l_sql += " and f_worktype in ('L1','L2','L3','L4','L5','N1','N2','N3','N4','N5')";
            //l_sql += " and isnull(f_introducer,'') = ''";

            if (!"".Equals(p_BDate))
            {
                l_sql += " and w.f_closedate between '" + p_BDate + "' and '" + p_EDate + "'";
            }
            if (!"".Equals(p_Branchid))
            {
                l_sql += " and w.f_branchid = '" + p_Branchid + "'";
            }
            l_sql += " order by f_branchid,f_editdate";
            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_sql);
            C各廠介紹獎金[] l_datas = new C各廠介紹獎金[l_dv.Count];

            if (l_dv != null)
            {
                for (int i = 0; i < l_datas.Length; i++)
                {
                    l_datas[i] = createC各廠介紹獎金();
                    l_datas[i].開單日期 = l_dv[i]["f_editdate"].ToString();
                    l_datas[i].工單號碼 = l_dv[i]["f_workid"].ToString();
                    l_datas[i].引擎號碼 = l_dv[i]["f_engo"].ToString();
                    l_datas[i].洗車種類 = l_dv[i]["f_worktype"].ToString();
                    l_datas[i].開單人員 = l_dv[i]["f_edituser"].ToString();
                    l_datas[i].名稱 = l_dv[i]["name"].ToString();
                    l_datas[i].金額 =Convert.ToInt32( l_dv[i]["f_money"].ToString() );
                    l_datas[i].工單類型 = l_dv[i]["f_type"].ToString();
                    l_datas[i].保險公司 = l_dv[i]["f_name"].ToString();
                }
                return l_datas;
            }
            return null;
        }
    }
}
