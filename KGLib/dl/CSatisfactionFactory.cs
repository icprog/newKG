using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tw.com.yj.CommonLib;

namespace tw.com.kg.lib
{
    public class CSatisfactionFactory : YJCCommonFactory
    {
        public CSatisfactionFactory(YJCommonContext p_context)
        {
            setContext(p_context);
        }
        public CSatisfaction createCSatisfaction()
        {
            return new CSatisfaction();
        }

        public void insert(CSatisfaction p_data)
        {
            string l_Sql = "";

            l_Sql += "INSERT INTO [KG].[dbo].[tbSatisfaction] VALUES (";
            l_Sql += " '" + p_data.f_branchid施工地點 + "'";
            l_Sql += ", '" + p_data.f_car車牌 + "'";
            l_Sql += ", '" + p_data.f_smid業代 + "'";
            l_Sql += ", '" + p_data.f_date時間 + "'";
            l_Sql += ", " + p_data.f_glassclean玻璃清潔 + "";
            l_Sql += ", " + p_data.f_dirtpaint漆面髒汙 + "";
            l_Sql += ", " + p_data.f_waxfinish漆面打蠟 + "";
            l_Sql += ", " + p_data.f_engineroom引擎室 + "";
            l_Sql += ", " + p_data.f_tirerims輪胎鋼圈 + "";
            l_Sql += ", " + p_data.f_leather皮椅 + "";
            l_Sql += ", " + p_data.f_dashboard儀錶板 + "";
            l_Sql += ", " + p_data.f_carpet地毯清潔 + "";
            l_Sql += ", " + p_data.f_gadget小配件 + "";
            l_Sql += ", " + p_data.f_deliverytime交車時間 + "";
            l_Sql += ", '" + p_data.f_memo備註 + "'";
            l_Sql += ")";
            ivContext.資料管理員.excuteSqlNonquery(l_Sql);
        }
    }
}
