using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using tw.com.yj.CommonLib;

namespace tw.com.kg.lib
{
    public class CKGPointDetailFactory : YJCCommonFactory
    {
        public CKGPointDetailFactory(YJCommonContext p_context)
        {
            setContext(p_context);
        }

        public CKGPointDetail createCKGPointDetail()
        {
            return new CKGPointDetail();
        }

        public CKGPointDetail[] getAllCKGPointDetail()
        {
            string l_strSql = "SELECT * FROM [KG].[dbo].[tbKGPointDetail]";
            return queryBySql(l_strSql);
        }

        /// <summary>
        /// (Yu 20090515) 取得資料庫內所有的匯入模式 (DISTINCT f_ImportType)
        /// </summary>
        /// <returns></returns>
        public CKGPointDetail[] get匯入模式()
        {
            string l_strSql = "SELECT DISTINCT f_ImportType FROM [KG].[dbo].[tbKGPointDetail]";

            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_strSql);
            List<CKGPointDetail> l_datas = new List<CKGPointDetail>();

            if (l_dv.Count > 0)
            {
                for (int i = 0; i < l_dv.Count; i++)
                {
                   CKGPointDetail l_code = createCKGPointDetail();
                   l_code.f_ImportType匯入方式 = l_dv[i]["f_ImportType"].ToString();
                   l_datas.Add(l_code);
                }
                return l_datas.ToArray();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// (Yu 20090515) 取得點數匯入記錄資料By條件
        /// </summary>
        /// <param name="p_str業代員編"></param>
        /// <param name="p_str匯入方式"></param>
        /// <param name="p_strStartDay"></param>
        /// <param name="p_strEndDay"></param>
        /// <returns></returns>
        public CKGPointDetail[] getCKGPointDetailBy條件(string p_str所別,string p_str業代員編, string p_str匯入方式,string p_str入帳銀行, string p_strStartDay, string p_strEndDay)
        {
            string l_strSql = "SELECT f_id,f_Smid,f_Name,Branch='F'+Substring(T.Branchid,5,2),f_ImportPoint,f_ImportDate,f_ImportSmid,f_ImportName,f_ImportType,f_InMoneyBank,f_InvoiceNo,f_PayBank,f_BankCharge, f_Memo";
            l_strSql += " FROM [KG].[dbo].[tbKGPointDetail] K ";
            l_strSql += " INNER JOIN [kdnews].[dbo].[T_HRPersonel] T ";
            l_strSql += " ON K.f_Smid = T.Emp_id WHERE 1=1";

            if (!"".Equals(p_str所別))
            {
                l_strSql += " AND 'F'+ Substring(T.Branchid,5,2) ='" + p_str所別 + "'";
            }
            if (!"".Equals(p_str業代員編))
            {
                l_strSql += " AND K.f_Smid ='" + p_str業代員編 + "'";
            }
            if (!"".Equals(p_str匯入方式))
            {
                l_strSql += " AND K.f_ImportType ='" + p_str匯入方式 + "'";
            }
            if (!"".Equals(p_str入帳銀行))
            {
                l_strSql += " AND K.f_InMoneyBank ='" + p_str入帳銀行 + "'";
            }

            if (!"".Equals(p_strStartDay) && "".Equals(p_strEndDay))
            {
                l_strSql += " AND K.f_ImportDate >='" + p_strStartDay + "'";
            }
            else if ("".Equals(p_strStartDay) && !"".Equals(p_strEndDay))
            {
                l_strSql += " AND K.f_ImportDate <='" + p_strEndDay + "'";
            }
            else if (!"".Equals(p_strStartDay) && !"".Equals(p_strEndDay))
            {
                l_strSql += " AND K.f_ImportDate BETWEEN '" + p_strStartDay + " 00:00:00' AND '" + p_strEndDay + " 23:59:59'";
            }

            l_strSql += " ORDER BY Branch,K.f_Smid,K.f_ImportDate";
            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_strSql);
            List<CKGPointDetail> l_datas = new List<CKGPointDetail>();

            if (l_dv.Count > 0)
            {
                for (int i = 0; i < l_dv.Count; i++)
                {
                   CKGPointDetail l_code= createCKGPointDetail();
                   l_code.f_id = Convert.ToInt32(l_dv[i]["f_id"].ToString());
                   l_code.f_Smid業代員編 = l_dv[i]["f_Smid"].ToString();
                   l_code.f_Name業代姓名 = l_dv[i]["f_Name"].ToString();
                   l_code.Branch所別 = l_dv[i]["Branch"].ToString();
                   l_code.f_ImportPoint匯入點數 = Convert.ToInt32(l_dv[i]["f_ImportPoint"].ToString());
                   l_code.f_ImportDate匯入日期 = l_dv[i]["f_ImportDate"].ToString();
                   l_code.f_ImportSmid匯入人員員編 = l_dv[i]["f_ImportSmid"].ToString();
                   l_code.f_ImportName匯入人員姓名 = l_dv[i]["f_ImportName"].ToString();
                   l_code.f_ImportType匯入方式 = l_dv[i]["f_ImportType"].ToString();
                   l_code.f_InvoiceNo發票號碼 = l_dv[i]["f_InvoiceNo"].ToString();
                   l_code.f_PayBank刷卡銀行 = l_dv[i]["f_PayBank"].ToString();
                   l_code.f_BankCharge手續費 = Convert.ToInt32(l_dv[i]["f_BankCharge"].ToString());
                   l_code.f_InMoneyBank入帳銀行 = l_dv[i]["f_InMoneyBank"].ToString();
                   l_code.f_Memo = l_dv[i]["f_Memo"].ToString();
                   l_datas.Add(l_code);
                }
                return l_datas.ToArray();
            }
            else
            {
                return null;
            }
        }

        public void SetMemo(string pMemo, string pId) 
        {
            StringBuilder lsb = new StringBuilder();
            lsb.Append(" UPDATE [KG].[dbo].[tbKGPointDetail] SET f_Memo = '" + pMemo + "' ");
            lsb.Append(" WHERE f_id = '" + pId + "' ");

            ivContext.資料管理員.excuteSqlNonquery(lsb.ToString());
        }

        private CKGPointDetail[] queryBySql(string p_sql)
        {
            DataView l_dv = ivContext.資料管理員.getDataViewBySql(p_sql);
            List<CKGPointDetail> l_datas = new List<CKGPointDetail>();

            if (l_dv.Count > 0)
            {
                for (int i = 0; i < l_dv.Count; i++)
                {
                   CKGPointDetail l_code = createCKGPointDetail();
                   l_code.f_id = Convert.ToInt32(l_dv[i]["f_id"].ToString());
                   l_code.f_Smid業代員編 = l_dv[i]["f_Smid"].ToString();
                   l_code.f_Name業代姓名 = l_dv[i]["f_Name"].ToString();
                   l_code.f_ImportPoint匯入點數 = Convert.ToInt32(l_dv[i]["f_ImportPoint"].ToString());
                   l_code.f_ImportDate匯入日期 = l_dv[i]["f_ImportDate"].ToString();
                   l_code.f_ImportSmid匯入人員員編 = l_dv[i]["f_ImportSmid"].ToString();
                   l_code.f_ImportName匯入人員姓名 = l_dv[i]["f_ImportName"].ToString();
                   l_code.f_ImportType匯入方式 = l_dv[i]["f_ImportType"].ToString();
                   l_code.f_InvoiceNo發票號碼 = l_dv[i]["f_InvoiceNo"].ToString();
                   l_code.f_PayBank刷卡銀行 = l_dv[i]["f_PayBank"].ToString();
                   l_code.f_BankCharge手續費 = Convert.ToInt32(l_dv[i]["f_BankCharge"].ToString());
                   l_code.f_InMoneyBank入帳銀行 = l_dv[i]["f_InMoneyBank"].ToString();
                   l_datas.Add(l_code);
                }
                return l_datas.ToArray();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// (Yu 20090513) Insert By 點數匯入
        /// </summary>
        /// <param name="p_codes"></param>
        public void insertCKGPointDetailBy點數匯入(CKGPointDetail[] p_codes)
        {
            string l_strSql = " BEGIN ";
            for (int i = 0; i < p_codes.Length; i++)
            {
                l_strSql += "INSERT INTO [KG].[dbo].[tbKGPointDetail] ([f_Smid],[f_Name],[f_ImportPoint],[f_ImportDate],[f_ImportSmid],[f_ImportName],[f_ImportType],[f_InvoiceNo],[f_BankCharge])VALUES(";
                l_strSql += " '" + p_codes[i].f_Smid業代員編 + "' ";
                l_strSql += ", N'" + p_codes[i].f_Name業代姓名 + "' ";
                l_strSql += ", '" + p_codes[i].f_ImportPoint匯入點數 + "' ";
                l_strSql += ", '" + p_codes[i].f_ImportDate匯入日期 + "' ";
                l_strSql += ", '" + p_codes[i].f_ImportSmid匯入人員員編 + "' ";
                l_strSql += ", N'" + p_codes[i].f_ImportName匯入人員姓名 + "' ";
                l_strSql += ", '" + p_codes[i].f_ImportType匯入方式 + "' ";
                l_strSql += ", '" + p_codes[i].f_InvoiceNo發票號碼 + "' ";
                l_strSql += ", '" + p_codes[i].f_BankCharge手續費 + "' ";
                l_strSql += ");";
            }
            l_strSql += " END ";
            ivContext.資料管理員.excuteSqlNonquery(l_strSql);
        }

        public void insertCKGPointDetail(CKGPointDetail p_code)
        {
            string l_strSql = "INSERT INTO [KG].[dbo].[tbKGPointDetail] ([f_Smid],[f_Name],[f_ImportPoint],[f_ImportDate],[f_ImportSmid],[f_ImportName],[f_ImportType],[f_InvoiceNo],[f_PayBank],[f_BankCharge],[f_InMoneyBank],[f_Memo])VALUES(";
            l_strSql += " '" + p_code.f_Smid業代員編 + "' ";
            l_strSql += ", N'" + p_code.f_Name業代姓名 + "' ";
            l_strSql += ", '" + p_code.f_ImportPoint匯入點數 + "' ";
            l_strSql += ", '" + p_code.f_ImportDate匯入日期 + "' ";
            l_strSql += ", '" + p_code.f_ImportSmid匯入人員員編 + "' ";
            l_strSql += ", N'" + p_code.f_ImportName匯入人員姓名 + "' ";
            l_strSql += ", '" + p_code.f_ImportType匯入方式 + "' ";
            l_strSql += ", '" + p_code.f_InvoiceNo發票號碼 + "' ";
            l_strSql += ", '" + p_code.f_PayBank刷卡銀行 + "' ";
            l_strSql += ", '" + p_code.f_BankCharge手續費 + "' ";
            l_strSql += ", '" + p_code.f_InMoneyBank入帳銀行 + "' ";
            l_strSql += ", '" + p_code.f_Memo + "' ";
            l_strSql += ")";

            ivContext.資料管理員.excuteSqlNonquery(l_strSql);
        }

        public void updateCKGPointDetail(CKGPointDetail p_code)
        {
            string l_strSql = "UPDATE [KG].[dbo].[tbKGPointDetail] SET ";
            l_strSql += "[f_Smid] = '" + p_code.f_Smid業代員編 + "',";
            l_strSql += "[f_Name] = N'" + p_code.f_Name業代姓名 + "',";
            l_strSql += "[f_ImportPoint] = '" + p_code.f_ImportPoint匯入點數 + "',";
            l_strSql += "[f_ImportDate] = '" + p_code.f_ImportDate匯入日期 + "',";
            l_strSql += "[f_ImportSmid] = '" + p_code.f_ImportSmid匯入人員員編 + "',";
            l_strSql += "[f_ImportName] = N'" + p_code.f_ImportName匯入人員姓名 + "',";
            l_strSql += "[f_ImportType] = '" + p_code.f_ImportType匯入方式 + "',";
            l_strSql += "[f_InvoiceNo] = '" + p_code.f_InvoiceNo發票號碼 + "'";
            l_strSql += " WHERE f_id = '" + p_code.f_id + "'";
            ivContext.資料管理員.excuteSqlNonquery(l_strSql);
        }

        public void deleteCKGPointDetail(string p_id)
        {
            string l_strSql = "DELETE [KG].[dbo].[tbKGPointDetail] WHERE [f_id] = '" + p_id + "'";
            ivContext.資料管理員.excuteSqlNonquery(l_strSql);
        }
    }
}