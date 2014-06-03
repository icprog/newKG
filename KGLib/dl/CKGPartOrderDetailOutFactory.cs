using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using tw.com.yj.CommonLib;

namespace tw.com.kg.lib
{
    public class CKGPartOrderDetailOutFactory : YJCCommonFactory
    {
        public CKGPartOrderDetailOutFactory(YJCommonContext p_context)
        {
            setContext(p_context);
        }

        public CKGPartOrderDetailOut createCKGPartOrderDetailOut()
        {
            return new CKGPartOrderDetailOut();
        }

        public CKGPartOrderDetailOut[] getAllCKGPartOrderDetailOut()
        {
            string l_strSql = "SELECT * FROM [KG].[dbo].[tbKGPartOrderDetailOut]";
            return queryBySql(l_strSql);
        }

        /// <summary>
        /// (Yu 20090514) 用條件取得業代退貨資料
        /// </summary>
        /// <param name="p_str助理員編">助理員編</param>
        /// <param name="p_strp_str請購單號">請購單號</param>
        /// <param name="p_str業代員編">業代員編</param>
        /// <param name="p_str退貨狀態">退貨狀態 True:已完成退貨，False:未完成退貨</param>
        /// <param name="p_strStartDay">退貨起始日期</param>
        /// <param name="p_strEndDay">退貨結束日期</param>
        /// <returns></returns>
        public CKGPartOrderDetailOut[] getAll退貨資料By條件(string p_str助理員編, string p_str請購單號,string p_str請購所別, string p_str業代員編, string p_str退貨狀態, string p_strStartDay, string p_strEndDay)
        {
            string l_strSql = "SELECT * FROM [KG].[dbo].[tbKGPartOrderDetailOut] WHERE 1=1 ";

            if (!"".Equals(p_str請購單號))
            {
                l_strSql += " AND f_ExchangeID = '" + p_str請購單號 + "' ";
            }
             if (!"".Equals(p_str請購所別))
            {
                l_strSql += " AND f_branchid = '" + p_str請購所別 + "' ";
            }
            
            if (!"".Equals(p_str助理員編))
            {
                l_strSql += " AND f_AssistantSmid = '" + p_str助理員編 + "' ";
            }

            if (!"".Equals(p_str業代員編))
            {
                l_strSql += " AND f_SalesSmid = '" + p_str業代員編 + "' ";
            }

            if (!"".Equals(p_str退貨狀態))
            {
                l_strSql += " AND f_Check ='" + p_str退貨狀態 + "'";
            }

            if (!"".Equals(p_strStartDay) && "".Equals(p_strEndDay))
            {
                l_strSql += " AND f_OutDate >='" + p_strStartDay + "'";
            }
            else if ("".Equals(p_strStartDay) && !"".Equals(p_strEndDay))
            {
                l_strSql += " AND f_OutDate <='" + p_strEndDay + "'";
            }
            else if (!"".Equals(p_strStartDay) && !"".Equals(p_strEndDay))
            {
                l_strSql += " AND f_OutDate BETWEEN '" + p_strStartDay + "' AND '" + p_strEndDay + "'";
            }

            l_strSql += " ORDER BY f_OutDate,f_SalesSmid,f_ExchangeID";
            return queryBySql(l_strSql);
        }

        /// <summary>
        /// (Yu 20090514)
        /// </summary>
        /// <param name="p_strId"></param>
        /// <returns></returns>
        public CKGPartOrderDetailOut get退貨資料ById(string p_strId)
        {
            string l_strSql = "SELECT * FROM [KG].[dbo].[tbKGPartOrderDetailOut] WHERE f_id =" + p_strId;
            return queryBySql(l_strSql)[0];
        }


        /// <summary>
        /// (Yu 20090513)
        /// </summary>
        /// <param name="p_str請購單號"></param>
        /// <returns></returns>
        public CKGPartOrderDetailOut[] get退貨資料By請購單號(string p_str請購單號,string p_str助理Smid)
        {
            string l_strSql = "SELECT * FROM [KG].[dbo].[tbKGPartOrderDetailOut] WHERE f_ExchangeID ='" + p_str請購單號 + "'";
            l_strSql += " AND f_AssistantSmid='" + p_str助理Smid + "'";
            return queryBySql(l_strSql);
        }

        private CKGPartOrderDetailOut[] queryBySql(string p_sql)
        {
            DataView l_dv = ivContext.資料管理員.getDataViewBySql(p_sql);
            List<CKGPartOrderDetailOut> l_datas = new List<CKGPartOrderDetailOut>();

            if (l_dv.Count > 0)
            {
                for (int i = 0; i < l_dv.Count; i++)
                {
                    CKGPartOrderDetailOut l_code = createCKGPartOrderDetailOut();
                    l_code.f_id = Convert.ToInt32(l_dv[i]["f_id"].ToString());
                    l_code.f_ExchangeID請購單號 = l_dv[i]["f_ExchangeID"].ToString();
                    l_code.f_AssistantSmid退貨助理員編 = l_dv[i]["f_AssistantSmid"].ToString();
                    l_code.f_SalesSmid業代員編 = l_dv[i]["f_SalesSmid"].ToString();
                    l_code.f_SalesBranch業代單位 = l_dv[i]["f_branchid"].ToString();
                    l_code.f_ProductID產品編號 = l_dv[i]["f_ProductID"].ToString();
                    l_code.f_ProductName產品名稱 = l_dv[i]["f_ProductName"].ToString();
                    l_code.f_OutAmount退貨數量 = Convert.ToInt32(l_dv[i]["f_OutAmount"].ToString());
                    l_code.f_OutDate退貨日期 = l_dv[i]["f_OutDate"].ToString();
                    l_code.f_Qty產品單位 = l_dv[i]["f_Qty"].ToString();
                    l_code.f_Cost產品成本 = Convert.ToInt32(l_dv[i]["f_Cost"].ToString());
                    l_code.f_UnitPrice產品單價 = Convert.ToInt32(l_dv[i]["f_UnitPrice"].ToString());
                    l_code.f_ListPrice建議售價 = Convert.ToInt32(l_dv[i]["f_ListPrice"].ToString());
                    l_code.f_OutTotal總計退貨價格 = Convert.ToInt32(l_dv[i]["f_OutTotal"].ToString());
                    l_code.f_OutReasons退貨原因 = l_dv[i]["f_OutReasons"].ToString();
                    l_code.f_Check管理者確認退貨 = l_dv[i]["f_Check"].ToString();
                    l_code.f_CheckDate確認退貨日期 = l_dv[i]["f_CheckDate"].ToString();
                    l_code.f_EditDate編輯日期 = l_dv[i]["f_EditDate"].ToString();
                    l_datas.Add(l_code);
                }
                return l_datas.ToArray();
            }
            else
            {
                return null;
            }
        }

        public void insertCKGPartOrderDetailOut(CKGPartOrderDetailOut p_code)
        {
            string l_strSql = "INSERT INTO [KG].[dbo].[tbKGPartOrderDetailOut] ([f_ExchangeID],[f_AssistantSmid],[f_SalesSmid],[f_branchid],[f_ProductID],[f_ProductName],[f_OutAmount],[f_OutDate],[f_Qty],[f_Cost],[f_UnitPrice],[f_ListPrice],[f_OutTotal],[f_OutReasons],[f_Check],[f_CheckDate],[f_EditDate])VALUES(";
            l_strSql += " '" + p_code.f_ExchangeID請購單號 + "' ";
            l_strSql += ", '" + p_code.f_AssistantSmid退貨助理員編 + "' ";
            l_strSql += ", '" + p_code.f_SalesSmid業代員編 + "' ";
            l_strSql += ", '" + p_code.f_SalesBranch業代單位 + "' ";
            l_strSql += ", '" + p_code.f_ProductID產品編號 + "' ";
            l_strSql += ", '" + p_code.f_ProductName產品名稱.Replace("'", "''") + "' ";
            l_strSql += ", '" + p_code.f_OutAmount退貨數量 + "' ";
            l_strSql += ", '" + p_code.f_OutDate退貨日期 + "' ";
            l_strSql += ", '" + p_code.f_Qty產品單位 + "' ";
            l_strSql += ", '" + p_code.f_Cost產品成本 + "' ";
            l_strSql += ", '" + p_code.f_UnitPrice產品單價 + "' ";
            l_strSql += ", '" + p_code.f_ListPrice建議售價 + "' ";
            l_strSql += ", '" + p_code.f_OutTotal總計退貨價格 + "' ";
            l_strSql += ", '" + p_code.f_OutReasons退貨原因 + "' ";
            l_strSql += ", '" + p_code.f_Check管理者確認退貨 + "' ";
            l_strSql += ", '" + p_code.f_CheckDate確認退貨日期 + "' ";
            l_strSql += ", '" + p_code.f_EditDate編輯日期 + "' ";
            l_strSql += ")";

            ivContext.資料管理員.excuteSqlNonquery(l_strSql);
        }

        /// <summary>
        /// (Yu 20090514) 管理者確認退貨
        /// </summary>
        /// <param name="p_id"></param>
        public void update確認退貨By管理者(string p_id ,string p_strCheckDate)
        {
            string l_strSql = "UPDATE [KG].[dbo].[tbKGPartOrderDetailOut] SET ";
            l_strSql += "[f_Check] = 'True' ,";
            l_strSql += "[f_CheckDate] = '" + p_strCheckDate + "'";
            l_strSql += " WHERE f_id = '" + p_id + "'";
            ivContext.資料管理員.excuteSqlNonquery(l_strSql);
        }

        public void updateCKGPartOrderDetailOut(CKGPartOrderDetailOut p_code)
        {
            string l_strSql = "UPDATE [KG].[dbo].[tbKGPartOrderDetailOut] SET ";
            l_strSql += "[f_ExchangeID] = '" + p_code.f_ExchangeID請購單號 + "',";
            l_strSql += "[f_AssistantSmid] = '" + p_code.f_AssistantSmid退貨助理員編 + "',";
            l_strSql += "[f_AssistantName] = N'" + p_code.f_AssistantName退貨助理姓名 + "',";
            l_strSql += "[f_SalesSmid] = '" + p_code.f_SalesSmid業代員編 + "',";
            l_strSql += "[f_SalesName] = N'" + p_code.f_SalesName業代姓名 + "',";
            l_strSql += "[f_SalesBranch] = '" + p_code.f_SalesBranch業代單位 + "',";
            l_strSql += "[f_ProductID] = '" + p_code.f_ProductID產品編號 + "',";
            l_strSql += "[f_ProductName] = '" + p_code.f_ProductName產品名稱.Replace("'", "''") + "',";
            l_strSql += "[f_OutAmount] = '" + p_code.f_OutAmount退貨數量 + "',";
            l_strSql += "[f_OutDate] = '" + p_code.f_OutDate退貨日期 + "',";
            l_strSql += "[f_Qty] = '" + p_code.f_Qty產品單位 + "',";
            l_strSql += "[f_Cost] = '" + p_code.f_Cost產品成本 + "',";
            l_strSql += "[f_UnitPrice] = '" + p_code.f_UnitPrice產品單價 + "',";
            l_strSql += "[f_ListPrice] = '" + p_code.f_ListPrice建議售價 + "',";
            l_strSql += "[f_OutTotal] = '" + p_code.f_OutTotal總計退貨價格 + "',";
            l_strSql += "[f_OutReasons] = '" + p_code.f_OutReasons退貨原因 + "',";
            l_strSql += "[f_Check] = '" + p_code.f_Check管理者確認退貨 + "',";
            l_strSql += "[f_CheckDate] = '" + p_code.f_CheckDate確認退貨日期 + "',";
            l_strSql += "[f_EditDate] = '" + p_code.f_EditDate編輯日期 + "'";
            l_strSql += " WHERE f_id = '" + p_code.f_id + "'";
            ivContext.資料管理員.excuteSqlNonquery(l_strSql);
        }

        public void deleteCKGPartOrderDetailOut(string p_id)
        {
            string l_strSql = "DELETE [KG].[dbo].[tbKGPartOrderDetailOut] WHERE [f_id] = '" + p_id + "'";
            ivContext.資料管理員.excuteSqlNonquery(l_strSql);
        }
    }
}