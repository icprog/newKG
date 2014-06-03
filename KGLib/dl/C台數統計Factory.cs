using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tw.com.yj.CommonLib;
using System.Data;

namespace tw.com.kg.lib
{
    public class C台數統計Factory: YJCCommonFactory
    {
        public C台數統計Factory(YJCommonContext p_context)
        {
            setContext(p_context);
        }
        public C台數統計 createC台數統計()
        {
            return new C台數統計();
        }

        public C台數統計[] get台數統計(string p_BDate, string p_EDate, string p_所別 ,string p_str所廠)
        {
            string l_sql = "";

            l_sql += " select f_branchid,";
            //精緻洗車
            l_sql += " R = IsNull(sum(case ";
            l_sql += " when (isnull(f_worktype,'')  in ('R1','R2','R3','R4','R5')) then 1.0";
            l_sql += " end),0),";

            l_sql += " Rm = IsNull(sum(case ";
            l_sql += " when (isnull(f_worktype,'')  in ('R1','R2','R3','R4','R5')) then f_money";
            l_sql += " end),0),";
            //磁土美容
            l_sql += " M = IsNull(sum(case ";
            l_sql += " when (isnull(f_worktype,'')  in ('M1','M2','M3','M4','M5')) then 1.0";
            l_sql += " end),0),";

            l_sql += " Mm = IsNull(sum(case ";
            l_sql += " when (isnull(f_worktype,'')  in ('M1','M2','M3','M4','M5')) then f_money";
            l_sql += " end),0),";
            //超值美容
            l_sql += " S = IsNull(sum(case";
            l_sql += " when (isnull(f_worktype,'')  in ('S1','S2','S3','S4','S5')) then 1.0";
            l_sql += "  end),0),";

            l_sql += " Sm = IsNull(sum(case";
            l_sql += " when (isnull(f_worktype,'')  in ('S1','S2','S3','S4','S5')) then f_money";
            l_sql += " end),0),";
            //亮新I
            l_sql += " L = IsNull(sum(case ";
            l_sql += " when (isnull(f_worktype,'')  in ('L1','L2','L3','L4','L5')) then 1.0";
            l_sql += " end),0),";

            l_sql += " Lm = IsNull(sum(case ";
            l_sql += " when (isnull(f_worktype,'')  in ('L1','L2','L3','L4','L5')) then f_money";
            l_sql += " end),0),";
            //亮新II
            l_sql += " N = IsNull(sum(case ";
            l_sql += " when (isnull(f_worktype,'')  in ('N1','N2','N3','N4','N5')) then 1.0";
            l_sql += " end),0),";

            l_sql += " Nm = IsNull(sum(case ";
            l_sql += " when (isnull(f_worktype,'')  in ('N1','N2','N3','N4','N5')) then f_money";
            l_sql += " end),0),";
            //內裝美容
            l_sql += " I = IsNull(sum(case ";
            l_sql += " when (isnull(f_worktype,'')  in ('I1','I2','I3','I4','I5')) then 1.0 ";
            l_sql += " end),0),";

            l_sql += " Im = IsNull(sum(case";
            l_sql += " when (isnull(f_worktype,'')  in ('I1','I2','I3','I4','I5')) then f_money";
            l_sql += " end),0),";
            //引擎清潔
            l_sql += " E = IsNull(sum(case";
            l_sql += " when (isnull(f_worktype,'')  in ('E1','E2','E3','E4','E5')) then 1.0";
            l_sql += " end),0),";

            l_sql += " Em = IsNull(sum(case";
            l_sql += " when (isnull(f_worktype,'')  in ('E1','E2','E3','E4','E5')) then f_money";
            l_sql += " end),0),";

            //玻璃油膜
            l_sql += " G = IsNull(sum(case";
            l_sql += " when (isnull(f_worktype,'')  in ('G1','G2','G3','G4','G5')) then 1.0";
            l_sql += " end),0),";

            l_sql += " Gm = IsNull(sum(case";
            l_sql += " when (isnull(f_worktype,'')  in ('G1','G2','G3','G4','G5')) then f_money";
            l_sql += " end),0),";

            l_sql += " D00 = IsNull(sum(case";
            l_sql += " when (isnull(f_worktype,'')  in ('D00-X1')) then 1.0";
            l_sql += " end),0),";

            l_sql += " D00m = IsNull(sum(case";
            l_sql += " when (isnull(f_worktype,'')  in ('D00-X1')) then f_money";
            l_sql += " end),0),";

            //多區分中古車整備 2011-11-23 way
            l_sql += " D01 = IsNull(sum(case";
            l_sql += " when (isnull(f_worktype,'')  in ('D00-X2')) then 1.0";
            l_sql += " end),0),";

            l_sql += " D01m = IsNull(sum(case";
            l_sql += " when (isnull(f_worktype,'')  in ('D00-X2')) then f_money";
            l_sql += " end),0),";

            //2011-05-05 新增兩種洗車總類
            l_sql += " A = IsNull(sum(case";
            l_sql += " when (isnull(f_worktype,'')  in ('A1','A2','A3','A4','A5')) then 1.0";
            l_sql += " end),0),";

            l_sql += " Am = IsNull(sum(case";
            l_sql += " when (isnull(f_worktype,'')  in ('A1','A2','A3','A4','A5')) then f_money";
            l_sql += " end),0),";

            l_sql += " B = IsNull(sum(case";
            l_sql += " when (isnull(f_worktype,'')  in ('B1','B2','B3','B4','B5')) then 1.0";
            l_sql += " end),0),";

            l_sql += " Bm = IsNull(sum(case";
            l_sql += " when (isnull(f_worktype,'')  in ('B1','B2','B3','B4','B5')) then f_money";
            l_sql += " end),0)";

            l_sql += " from dbo.tbWork w ";

            l_sql += " where 1=1";
            //l_sql += " where f_closedate <> ''"; 

            if (!"".Equals(p_BDate))//20101004 改成已完工日下去判斷實績,不以是否空白判斷
            {
                l_sql += " and f_closedate between '" + p_BDate + "' and '" + p_EDate + "'";
            }
            //if (!"".Equals(p_BDate))
            //{
            //    l_sql += " and substring(f_editdate,0,11) between '" + p_BDate + "' and '" + p_EDate + "'";
            //}
            if (!"".Equals(p_所別))
            {
                l_sql += " and f_branchid ='" + p_所別 + "'";
            }
            if (!"".Equals(p_str所廠))
            {
                if ("所".Equals(p_str所廠))
                {
                    l_sql += " and  f_type in ('新車')";
                }
                else
                {
                    l_sql += " and  f_type in ('一般','保險','保險公司介紹','員工')";
                }
            }
            l_sql += " group by f_branchid";
            l_sql += " order by f_branchid";


            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_sql);
            C台數統計[] l_datas = new C台數統計[l_dv.Count];

            if (l_dv != null)
            {
                for (int i = 0; i < l_datas.Length; i++)
                {
                    l_datas[i] = createC台數統計();
                    l_datas[i].所別 = l_dv[i]["f_branchid"].ToString();
                    l_datas[i].R_精緻洗車 =Convert.ToInt32( l_dv[i]["R"]);
                    l_datas[i].R_精緻洗車money = Convert.ToInt32(l_dv[i]["Rm"]);
                    l_datas[i].M_磁土美容 =Convert.ToInt32( l_dv[i]["M"]);
                    l_datas[i].M_磁土美容money = Convert.ToInt32(l_dv[i]["Mm"]);
                    l_datas[i].S_超值美容 =Convert.ToInt32( l_dv[i]["S"]);
                    l_datas[i].S_超值美容money = Convert.ToInt32(l_dv[i]["Sm"]);
                    l_datas[i].L_亮新I =Convert.ToInt32( l_dv[i]["L"]);
                    l_datas[i].L_亮新Imoney = Convert.ToInt32(l_dv[i]["Lm"]);
                    l_datas[i].N_亮新II = Convert.ToInt32(l_dv[i]["N"]);
                    l_datas[i].N_亮新IImoney = Convert.ToInt32(l_dv[i]["Nm"]);
                    l_datas[i].I_內裝美容 =Convert.ToInt32( l_dv[i]["I"]);
                    l_datas[i].I_內裝美容money = Convert.ToInt32(l_dv[i]["Im"]);
                    l_datas[i].E_引擎清潔 = Convert.ToInt32(l_dv[i]["E"]);
                    l_datas[i].E_引擎清潔money = Convert.ToInt32(l_dv[i]["Em"]);
                    l_datas[i].G_玻璃油膜 = Convert.ToInt32(l_dv[i]["G"]);
                    l_datas[i].G_玻璃油膜money = Convert.ToInt32(l_dv[i]["Gm"]);

                    l_datas[i].D00_高運 = Convert.ToInt32(l_dv[i]["D00"]);
                    l_datas[i].D00_高運money = Convert.ToInt32(l_dv[i]["D00m"]);


                    l_datas[i].D00_CPO2 = Convert.ToInt32(l_dv[i]["D01"]);
                    l_datas[i].D00_CPO2money = Convert.ToInt32(l_dv[i]["D01m"]);

                    //2011-05-05 新增兩種洗車總類
                    l_datas[i].A_小美容 = Convert.ToInt32(l_dv[i]["A"]);
                    l_datas[i].A_小美容money = Convert.ToInt32(l_dv[i]["Am"]);
                    l_datas[i].B_覆膜 = Convert.ToInt32(l_dv[i]["B"]);
                    l_datas[i].B_覆膜money = Convert.ToInt32(l_dv[i]["Bm"]);
                }
                return l_datas;
            }
            return null;
        }
    }
}
