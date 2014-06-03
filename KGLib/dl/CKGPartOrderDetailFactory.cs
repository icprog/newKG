using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using tw.com.yj.CommonLib;

namespace tw.com.kg.lib
{
    public class CKGPartOrderDetailFactory : YJCCommonFactory
    {
        public CKGPartOrderDetailFactory(YJCommonContext p_context)
        {
            setContext(p_context);
        }

        public CKGPartOrderDetail createCKGPartOrderDetail()
        {
            return new CKGPartOrderDetail();
        }

        public CKGPartOrderDetail[] getAllCKGPartOrderDetail()
        {
            string l_strSql = "SELECT * FROM [kdnews].[dbo].[tbKGPartOrderDetail]";
            return queryBySql(l_strSql);
        }

        /// <summary>
        /// (Yu 20100206) 取得直販課訂購明細
        /// </summary>
        /// <param name="p_str員編"></param>
        /// <param name="p_str廠商"></param>
        /// <param name="p_strStartDay"></param>
        /// <param name="p_strEndDay"></param>
        /// <returns></returns>
        public CKGPartOrderDetail[] get直販課訂購明細(string p_str員編, string p_str廠商, string p_strStartDay, string p_strEndDay)
        {
            string l_strSql = "SELECT * FROM tbKGPartOrderDetail";
            l_strSql += " WHERE f_ExchangeID in ( SELECT f_ExchangeID FROM tbKGPartOrder WHERE f_SalesBranchid ='FB50075'";

            if (!"".Equals(p_str員編))
            {
                l_strSql += " AND f_SalesSmid ='" + p_str員編 + "'";
            }
            if (!"".Equals(p_str廠商))
            {
                l_strSql += " AND f_Vendor ='" + p_str廠商 + "'";
            }
            if (!"".Equals(p_strStartDay) && "".Equals(p_strEndDay))
            {
                l_strSql += " AND f_InsertDate >='" + p_strStartDay + "'";
            }
            else if (!"".Equals(p_strStartDay) && !"".Equals(p_strEndDay))
            {
                l_strSql += " AND f_InsertDate >= '" + p_strStartDay + "' AND f_InsertDate <= '" + p_strEndDay + "'";
            }
            l_strSql += " ) ";

            l_strSql += " ORDER BY f_SalesSmid, f_ExchangeID";

            return queryBySql(l_strSql);
        }

        /// <summary>
        /// (Yu 20090514) 取得請購單明細內的單一產品資料
        /// </summary>
        /// <param name="p_strExchangeID">請購單號</param>
        /// <param name="p_strProductID">產品Id</param>
        /// <returns></returns>
        public CKGPartOrderDetail get請購單內的單一產品明細(string p_strExchangeID,string p_strProductID)
        {
            string l_strSql = "SELECT * FROM [KG].[dbo].[tbKGPartOrderDetail] WHERE f_ExchangeID='" + p_strExchangeID + "'";
            l_strSql += " AND f_ProductID='" + p_strProductID + "'";
            return queryBySql(l_strSql)[0];
        }


        /// <summary>
        /// (Yu 20090421) 取得請購明細By請購單號
        /// </summary>
        /// <param name="p_strExchangeID">請購單號</param>
        /// <returns></returns>
        public CKGPartOrderDetail[] get請購明細ByExchangeID(string p_strExchangeID)
        {
            //string l_strSql = "SELECT * FROM [KG].[dbo].[tbKGPartOrderDetail] WHERE f_ExchangeID='" + p_strExchangeID + "'";

            string l_strSql = "SELECT d.*,c.Name";
             l_strSql += " FROM [KG].[dbo].[tbKGPartOrderDetail] d";
             l_strSql += " inner join dbo.tbKGPartOrder p on d.f_ExchangeID = p.f_ExchangeID";
             l_strSql += " left join kddb..orders o on o.EngNo = p.f_engineno";
             l_strSql += " left join kddb..customer c on o.customerid = c.customerid";
             l_strSql += " WHERE d.f_ExchangeID ='" + p_strExchangeID + "'";

             DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_strSql);
             List<CKGPartOrderDetail> l_datas = new List<CKGPartOrderDetail>();

             if (l_dv.Count > 0)
             {
                 for (int i = 0; i < l_dv.Count; i++)
                 {
                     CKGPartOrderDetail l_code = createCKGPartOrderDetail();
                     l_code.f_ExchangeID請購單號 = l_dv[i]["f_ExchangeID"].ToString();
                     //l_code.f_AssistantSmid助理員編 = l_dv[i]["f_AssistantSmid"].ToString();
                     //l_code.f_SalesSmid業代員編 = l_dv[i]["f_SalesSmid"].ToString();
                     l_code.f_ProductID產品編號 = l_dv[i]["f_ProductID"].ToString();
                     l_code.f_ProductName產品名稱 = l_dv[i]["f_ProductName"].ToString();
                     l_code.f_Amount選購數量 = Convert.ToInt32(l_dv[i]["f_Amount"].ToString());
                     l_code.f_Qty產品單位 = l_dv[i]["f_Qty"].ToString();
                     l_code.f_Cost產品成本價 = Convert.ToInt32(l_dv[i]["f_Cost"].ToString());
                     l_code.f_UnitPrice產品單價 = Convert.ToInt32(l_dv[i]["f_UnitPrice"].ToString());
                     l_code.f_ListPrice建議售價 = Convert.ToInt32(l_dv[i]["f_ListPrice"].ToString());
                     l_code.f_Total總計價格 = Convert.ToInt32(l_dv[i]["f_Total"].ToString());
                     l_code.f_EditDate編輯日期 = l_dv[i]["f_EditDate"].ToString();
                     l_code.f_SalePrice販賣價 = Convert.ToInt32("0" + l_dv[i]["f_SalePrice"].ToString());

                     l_code.顧客姓名 = l_dv[i]["Name"].ToString();
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
        /// (way 20130520) 取得請購明細By請購單號s
        /// </summary>
        /// <param name="p_strExchangeID">請購單號s</param>
        /// <returns></returns>
        public CKGPartOrderDetail[] get請購明細ByExchangeID(List<string> p_strExchangeIDs)
        {
            //string l_strSql = "SELECT * FROM [KG].[dbo].[tbKGPartOrderDetail] WHERE f_ExchangeID='" + p_strExchangeID + "'";
            if (p_strExchangeIDs.Count <= 0)
            {
                return null;
            }
            string l_strSql = "SELECT d.*,c.Name";
            l_strSql += " FROM [KG].[dbo].[tbKGPartOrderDetail] d";
            l_strSql += " inner join dbo.tbKGPartOrder p on d.f_ExchangeID = p.f_ExchangeID";
            l_strSql += " left join kddb..orders o on o.EngNo = p.f_engineno";
            l_strSql += " left join kddb..customer c on o.customerid = c.customerid";
            string l_str = "";
            for (int i = 0; i < p_strExchangeIDs.Count; i++)
            {
                l_str += "'" + p_strExchangeIDs[i] + "',";
            }
            l_strSql += " WHERE d.f_ExchangeID in (" + l_str.Substring(0, l_str.Length-1) + ")";

            l_strSql += " order by d.f_EditDate";
            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_strSql);
            List<CKGPartOrderDetail> l_datas = new List<CKGPartOrderDetail>();

            if (l_dv.Count > 0)
            {
                for (int i = 0; i < l_dv.Count; i++)
                {
                    CKGPartOrderDetail l_code = createCKGPartOrderDetail();
                    l_code.f_ExchangeID請購單號 = l_dv[i]["f_ExchangeID"].ToString();
                    //l_code.f_AssistantSmid助理員編 = l_dv[i]["f_AssistantSmid"].ToString();
                    //l_code.f_SalesSmid業代員編 = l_dv[i]["f_SalesSmid"].ToString();
                    l_code.f_ProductID產品編號 = l_dv[i]["f_ProductID"].ToString();
                    l_code.f_ProductName產品名稱 = l_dv[i]["f_ProductName"].ToString();
                    l_code.f_Amount選購數量 = Convert.ToInt32(l_dv[i]["f_Amount"].ToString());
                    l_code.f_Qty產品單位 = l_dv[i]["f_Qty"].ToString();
                    l_code.f_Cost產品成本價 = Convert.ToInt32(l_dv[i]["f_Cost"].ToString());
                    l_code.f_UnitPrice產品單價 = Convert.ToInt32(l_dv[i]["f_UnitPrice"].ToString());
                    l_code.f_ListPrice建議售價 = Convert.ToInt32(l_dv[i]["f_ListPrice"].ToString());
                    l_code.f_Total總計價格 = Convert.ToInt32(l_dv[i]["f_Total"].ToString());
                    l_code.f_EditDate編輯日期 = l_dv[i]["f_EditDate"].ToString();
                    l_code.f_SalePrice販賣價 = Convert.ToInt32("0" + l_dv[i]["f_SalePrice"].ToString());

                    l_code.顧客姓名 = l_dv[i]["Name"].ToString();
                    l_datas.Add(l_code);
                }
                return l_datas.ToArray();
            }
            else
            {
                return null;
            }
        }


        private CKGPartOrderDetail[] queryBySql(string p_sql)
        {
            DataView l_dv = ivContext.資料管理員.getDataViewBySql(p_sql);
            List<CKGPartOrderDetail> l_datas = new List<CKGPartOrderDetail>();

            if (l_dv.Count > 0)
            {
                for (int i = 0; i < l_dv.Count; i++)
                {
                    CKGPartOrderDetail l_code = createCKGPartOrderDetail();
                    l_code.f_ExchangeID請購單號 = l_dv[i]["f_ExchangeID"].ToString();
                    //l_code.f_AssistantSmid助理員編 = l_dv[i]["f_AssistantSmid"].ToString();
                    //l_code.f_SalesSmid業代員編 = l_dv[i]["f_SalesSmid"].ToString();
                    l_code.f_ProductID產品編號 = l_dv[i]["f_ProductID"].ToString();
                    l_code.f_ProductName產品名稱 = l_dv[i]["f_ProductName"].ToString();
                    l_code.f_Amount選購數量 = Convert.ToInt32(l_dv[i]["f_Amount"].ToString());
                    l_code.f_Qty產品單位 = l_dv[i]["f_Qty"].ToString();
                    l_code.f_Cost產品成本價 = Convert.ToInt32(l_dv[i]["f_Cost"].ToString());
                    l_code.f_UnitPrice產品單價 = Convert.ToInt32(l_dv[i]["f_UnitPrice"].ToString());
                    l_code.f_ListPrice建議售價 = Convert.ToInt32(l_dv[i]["f_ListPrice"].ToString());
                    l_code.f_Total總計價格 = Convert.ToInt32(l_dv[i]["f_Total"].ToString());
                    l_code.f_EditDate編輯日期 = l_dv[i]["f_EditDate"].ToString();
                    l_code.f_SalePrice販賣價 = Convert.ToInt32("0"+l_dv[i]["f_SalePrice"].ToString());

                    l_datas.Add(l_code);
                }
                return l_datas.ToArray();
            }
            else
            {
                return null;
            }
        }

        public void insertCKGPartOrderDetail(CKGPartOrderDetail[] p_codes)
        {
            string l_strSql = " BEGIN ";
            for (int i = 0; i < p_codes.Length; i++)
            {

                l_strSql += " INSERT INTO [KG].[dbo].[tbKGPartOrderDetail] ([f_ExchangeID],[f_ProductID],[f_ProductName],[f_Amount],[f_Qty],[f_Cost],[f_UnitPrice],[f_ListPrice],[f_Total],[f_EditDate],[f_SalePrice])VALUES(";
                l_strSql += "  '" + p_codes[i].f_ExchangeID請購單號 + "' ";
                l_strSql += ", '" + p_codes[i].f_ProductID產品編號 + "' ";
                l_strSql += ", '" + p_codes[i].f_ProductName產品名稱.Replace("'", "''") + "' ";
                l_strSql += ", '" + p_codes[i].f_Amount選購數量 + "' ";
                l_strSql += ", '" + p_codes[i].f_Qty產品單位 + "' ";
                l_strSql += ", '" + p_codes[i].f_Cost產品成本價 + "' ";
                l_strSql += ", '" + p_codes[i].f_UnitPrice產品單價 + "' ";
                l_strSql += ", '" + p_codes[i].f_ListPrice建議售價 + "' ";
                l_strSql += ", '" + p_codes[i].f_Total總計價格 + "' ";
                l_strSql += ", '" + p_codes[i].f_EditDate編輯日期 + "' ";
                l_strSql += ", " + p_codes[i].f_SalePrice販賣價 + " ";
                l_strSql += ") ;";

            }
            l_strSql += " END";
            ivContext.資料管理員.excuteSqlNonquery(l_strSql);
        }


        public void updateCKGPartOrderDetail(CKGPartOrderDetail p_code)
        {
            string l_strSql = "UPDATE [kdnews].[dbo].[tbKGPartOrderDetail] SET ";
            l_strSql += "[f_AssistantSmid] = '" + p_code.f_AssistantSmid助理員編 + "',";
            l_strSql += "[f_SalesSmid] = '" + p_code.f_SalesSmid業代員編 + "',";
            l_strSql += "[f_ProductID] = '" + p_code.f_ProductID產品編號 + "',";
            l_strSql += "[f_ProductName] = '" + p_code.f_ProductName產品名稱.Replace("'", "''") + "',";
            l_strSql += "[f_Amount] = '" + p_code.f_Amount選購數量 + "',";
            l_strSql += "[f_Cost] = '" + p_code.f_Cost產品成本價 + "',";
            l_strSql += "[f_UnitPrice] = '" + p_code.f_UnitPrice產品單價 + "',";
            l_strSql += "[f_Total] = '" + p_code.f_Total總計價格 + "',";
            l_strSql += "[f_EditDate] = '" + p_code.f_EditDate編輯日期 + "'";
            l_strSql += " WHERE f_ExchangeID = '" + p_code.f_ExchangeID請購單號 + "'";
            ivContext.資料管理員.excuteSqlNonquery(l_strSql);
        }

        public void deleteCKGPartOrderDetail(string p_strExchangeID)
        {
            string l_strSql = "DELETE [kdnews].[dbo].[tbKGPartOrderDetail] WHERE [f_ExchangeID] = '" + p_strExchangeID + "'";
            ivContext.資料管理員.excuteSqlNonquery(l_strSql);
        }
    }
}