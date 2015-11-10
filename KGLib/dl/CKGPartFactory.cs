using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using tw.com.yj.CommonLib;

namespace tw.com.kg.lib
{
    public class CKGPartFactory : YJCCommonFactory
    {
        public CKGPartFactory(YJCommonContext p_context)
        {
            setContext(p_context);
        }

        public CKGPart createCKGPart()
        {
            return new CKGPart();
        }

        public CKGPart[] getAllCKGPart()
        {
            string l_strSql = "SELECT * FROM [kdnews].[dbo].[tbKGPart]";
            return queryBySql(l_strSql);
        }

        /// <summary>
        /// (Yu 20090524) 用產品編號取得物件
        /// </summary>
        /// <param name="p_strProductID">產品編號</param>
        /// <returns></returns>
        public CKGPart getCKGPartByProductID(string p_strProductID)
        {
            string l_strSql = "SELECT * FROM [kdnews].[dbo].[tbKGPart] WHERE f_ProductID ='" + p_strProductID + "'";
            CKGPart[] l_codes = queryBySql(l_strSql);
            if (l_codes != null)
            {
                return l_codes[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// (Yu 20090515)
        /// </summary>
        /// <param name="p_strId"></param>
        /// <returns></returns>
        public CKGPart getCKGPartById(string p_strId)
        {
            string l_strSql = "SELECT * FROM [kdnews].[dbo].[tbKGPart] WHERE f_id =" + p_strId;
            CKGPart[] l_codes = queryBySql(l_strSql);

            if (l_codes != null)
            {
                return l_codes[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// (Yu 20090515) 查詢產品檔 f_ProductName產品名稱不為空白時，用like方式尋找
        /// </summary>
        /// <param name="p_code"></param>
        /// <returns></returns>
        public CKGPart[] get產品By查詢(CKGPart p_code)
        { 
            string l_strSql = "SELECT * FROM [kdnews].[dbo].[tbKGPart] WHERE 1=1 ";
            if (!"".Equals(p_code.f_TypeID類別編號))
            {
                l_strSql += " AND f_TypeID ='" + p_code.f_TypeID類別編號 + "'";
            }
            //if (!"".Equals(p_code.f_TypeName類別名稱))
            //{
            //    l_strSql += " AND f_TypeName ='" + p_code.f_TypeName類別名稱 + "'";
            //}
            if (!"".Equals(p_code.f_CategoryID種類編號))
            {
                l_strSql += " AND f_CategoryID ='" + p_code.f_CategoryID種類編號 + "'";
            }
            //if (!"".Equals(p_code.f_CategoryName種類名稱))
            //{
            //    l_strSql += " AND f_CategoryName ='" + p_code.f_CategoryName種類名稱 + "'";
            //}
            if (!"".Equals(p_code.f_ProductID產品編號))
            {
                l_strSql += " AND f_ProductID ='" + p_code.f_ProductID產品編號 + "'";
            }
            if (!"".Equals(p_code.f_ProductName產品名稱))
            {
                l_strSql += " AND f_ProductName like '%" + p_code.f_ProductName產品名稱.Replace("'", "''") + "%'";
            }
            l_strSql += " ORDER BY  f_TypeID ,f_CategoryID,f_ProductID";
            return queryBySql(l_strSql);
        }
        
        
        /// <summary>
        /// (Yu 20090515) 確認檢測產品是否已存在 True:存在，False:不存在
        /// </summary>
        /// <param name="p_code"></param>
        /// <returns></returns>
        public bool check產品是否存在(CKGPart p_code)
        {
            string l_strSql = "SELECT * FROM [kdnews].[dbo].[tbKGPart] WHERE 1=1 ";
            if (!"".Equals(p_code.f_TypeID類別編號))
            {
                l_strSql += " AND f_TypeID ='" + p_code.f_TypeID類別編號 + "'";
            }
            //if (!"".Equals(p_code.f_TypeName類別名稱))
            //{
            //    l_strSql += " AND f_TypeName ='" + p_code.f_TypeName類別名稱 + "'";
            //}
            if (!"".Equals(p_code.f_CategoryID種類編號))
            {
                l_strSql += " AND f_CategoryID ='" + p_code.f_CategoryID種類編號 + "'";
            }
            //if (!"".Equals(p_code.f_CategoryName種類名稱))
            //{
            //    l_strSql += " AND f_CategoryName ='" + p_code.f_CategoryName種類名稱 + "'";
            //}
            if (!"".Equals(p_code.f_ProductID產品編號))
            {
                l_strSql += " AND f_ProductID ='" + p_code.f_ProductID產品編號 + "'";
            }
            //if (!"".Equals(p_code.f_ProductName產品名稱))
            //{
            //    l_strSql += " AND f_ProductName ='" + p_code.f_ProductName產品名稱 + "'";
            //}
            if (queryBySql(l_strSql) != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// (Yu 20090515) 用種類編號Id取得物件
        /// </summary>
        /// <returns></returns>
        public CKGPart getCKGPartByCategoryID(string p_strCategoryID)
        {
            string l_strSql = "SELECT * FROM [kdnews].[dbo].[tbKGPart] WHERE f_CategoryID = '" + p_strCategoryID + "'";
            return queryBySql(l_strSql)[0];
        }
        
        
        /// <summary>
        /// (Yu 20090523) 取得洗車的種類
        /// </summary>
        /// <returns></returns>
        public CKGPart[] getCKGPart洗車種類()
        {
            string l_strSql = "SELECT DISTINCT f_CategoryID,f_CategoryName FROM [kdnews].[dbo].[tbKGPart] WHERE f_TypeID = 'D'";
            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_strSql);
            List<CKGPart> l_datas = new List<CKGPart>();

            if (l_dv.Count > 0)
            {
                for (int i = 0; i < l_dv.Count; i++)
                {
                    CKGPart l_code = createCKGPart();
                    l_code.f_CategoryID種類編號 = l_dv[i]["f_CategoryID"].ToString();
                    l_code.f_CategoryName種類名稱 = l_dv[i]["f_CategoryName"].ToString();
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
        /// (Yu 20090515) 取得所有小百貨產品的類別
        /// </summary>
        /// <returns></returns>
        public CKGPart[] getCKGPart所有類別()
        {
            string l_strSql = "SELECT DISTINCT f_TypeID,f_TypeName FROM [kdnews].[dbo].[tbKGPart] order by f_TypeID";

            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_strSql);
            List<CKGPart> l_datas = new List<CKGPart>();

            if (l_dv.Count > 0)
            {
                for (int i = 0; i < l_dv.Count; i++)
                {
                    CKGPart l_code = createCKGPart();
                    l_code.f_TypeID類別編號 = l_dv[i]["f_TypeID"].ToString();
                    l_code.f_TypeName類別名稱 = l_dv[i]["f_TypeName"].ToString();
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
        ///  (Yu 20091027) 新增取得某種類的所有代號
        /// </summary>
        /// <param name="p_strTypeID">A:百貨類，B:清洗類，C:其他類，D:洗車類</param>
        /// <returns></returns>
        public CKGPart[] get某種類的所有代號(string p_strTypeID)
        {
            string l_strSql = "SELECT * FROM [kdnews].[dbo].[tbKGPart] WHERE f_TypeID ='" + p_strTypeID + "'";
            return queryBySql(l_strSql);
        }

        public CKGPart[] getCKGPart所有類別不含洗車()
        {
            string l_strSql = "SELECT DISTINCT f_TypeID,f_TypeName FROM [kdnews].[dbo].[tbKGPart] WHERE f_TypeID <> 'D'";

            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_strSql);
            List<CKGPart> l_datas = new List<CKGPart>();
            
            if (l_dv.Count > 0)
            {
                for (int i = 0; i < l_dv.Count; i++)
                {
                   CKGPart l_code = createCKGPart();
                   l_code.f_TypeID類別編號 = l_dv[i]["f_TypeID"].ToString();
                   l_code.f_TypeName類別名稱 = l_dv[i]["f_TypeName"].ToString();
                   l_datas.Add(l_code);
                }
                return l_datas.ToArray();
            }
            else
            {
                return null;
            }
        }
        public CKGPart[] get種類By類別(string p_strTypeID)
        {
            string l_strSql = "SELECT DISTINCT f_CategoryID,f_CategoryName FROM [kdnews].[dbo].[tbKGPart] WHERE f_TypeID ='" + p_strTypeID + "'";

            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_strSql);
            List<CKGPart> l_datas = new List<CKGPart>();
            if (l_dv.Count > 0)
            {
                for (int i = 0; i < l_dv.Count; i++)
                {
                   CKGPart l_code = createCKGPart();
                   l_code.f_CategoryID種類編號 = l_dv[i]["f_CategoryID"].ToString();
                   l_code.f_CategoryName種類名稱 = l_dv[i]["f_CategoryName"].ToString();
                   l_datas.Add(l_code);
                }
                return l_datas.ToArray();
            }
            else
            {
                return null;
            }
        }
        

        public CKGPart[] get百貨商品By種類(string p_strCategoryID,string p_str廠商)
        {
            string l_strSql = "SELECT DISTINCT f_ProductID,f_ProductName FROM [kdnews].[dbo].[tbKGPart]";
            l_strSql += " WHERE f_CategoryID ='" + p_strCategoryID + "'";
            if (!"".Equals(p_str廠商))
            {
                l_strSql += " AND f_ProductID like '%" + p_str廠商 + "%'";
            }
            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_strSql);
            List<CKGPart> l_datas = new List<CKGPart>();
            if (l_dv.Count > 0)
            {
                for (int i = 0; i < l_dv.Count; i++)
                {
                    CKGPart l_code = createCKGPart();
                    l_code.f_ProductID產品編號 = l_dv[i]["f_ProductID"].ToString();
                    l_code.f_ProductName產品名稱 = l_dv[i]["f_ProductName"].ToString();
                    l_datas.Add(l_code);
                }
                return l_datas.ToArray();
            }
            else
            {
                return null;
            }
        }


        public CKGPart[] get百貨商品By種類By營業所(string p_strCategoryID, string p_str廠商)
        {
            string l_strSql = "SELECT DISTINCT f_ProductID,f_ProductName FROM [kdnews].[dbo].[tbKGPart]";
            l_strSql += " WHERE f_CategoryID ='" + p_strCategoryID + "'";
            if (!"".Equals(p_str廠商))
            {
                l_strSql += " AND f_ProductID like '%" + p_str廠商 + "%'";
            }
            //營業所不能挑選服務廠商品(廠商+F) 20130301 way
            l_strSql += " AND f_ProductID not like '%" + p_str廠商+"F" + "%'";
            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_strSql);
            List<CKGPart> l_datas = new List<CKGPart>();
            if (l_dv.Count > 0)
            {
                for (int i = 0; i < l_dv.Count; i++)
                {
                    CKGPart l_code = createCKGPart();
                    l_code.f_ProductID產品編號 = l_dv[i]["f_ProductID"].ToString();
                    l_code.f_ProductName產品名稱 = l_dv[i]["f_ProductName"].ToString();
                    l_datas.Add(l_code);
                }
                return l_datas.ToArray();
            }
            else
            {
                return null;
            }
        }


        public CKGPart get百貨商品ByProductID(string p_strProductID)
        {
            string l_strSql = "SELECT DISTINCT f_ProductID,f_ProductName,f_Qty,f_Cost,f_SalePrice,f_ListPrice FROM [kdnews].[dbo].[tbKGPart]";
            l_strSql += " WHERE f_ProductID ='" + p_strProductID + "'";

            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_strSql);
            CKGPart l_code = createCKGPart();

            l_code.f_ProductID產品編號 = l_dv[0]["f_ProductID"].ToString();
            l_code.f_ProductName產品名稱 = l_dv[0]["f_ProductName"].ToString();
            l_code.f_Qty單位 = l_dv[0]["f_Qty"].ToString();
            l_code.f_Cost成本價 = Convert.ToInt32(l_dv[0]["f_Cost"].ToString());
            l_code.f_SalePrice業代價 = Convert.ToInt32(l_dv[0]["f_SalePrice"].ToString());
            l_code.f_ListPrice售價 = Convert.ToInt32(l_dv[0]["f_ListPrice"].ToString());
            return l_code;
        }

        private CKGPart[] queryBySql(string p_sql)
        {
            DataView l_dv = ivContext.資料管理員.getDataViewBySql(p_sql);
            List<CKGPart> l_datas = new List<CKGPart>();

            if (l_dv.Count > 0)
            {
                for (int i = 0; i < l_dv.Count; i++)
                {
                   CKGPart l_code = createCKGPart();
                   l_code.f_id = Convert.ToInt32(l_dv[i]["f_id"].ToString());
                   l_code.f_TypeID類別編號 = l_dv[i]["f_TypeID"].ToString();
                   l_code.f_TypeName類別名稱 = l_dv[i]["f_TypeName"].ToString();
                   l_code.f_CategoryID種類編號 = l_dv[i]["f_CategoryID"].ToString();
                   l_code.f_CategoryName種類名稱 = l_dv[i]["f_CategoryName"].ToString();
                   l_code.f_ProductID產品編號 = l_dv[i]["f_ProductID"].ToString();
                   l_code.f_ProductName產品名稱 = l_dv[i]["f_ProductName"].ToString();
                   l_code.f_Qty單位 = l_dv[i]["f_Qty"].ToString();
                   l_code.f_Cost成本價 = Convert.ToInt32(l_dv[i]["f_Cost"].ToString());
                   l_code.f_SalePrice業代價 = Convert.ToInt32(l_dv[i]["f_SalePrice"].ToString());
                   l_code.f_ListPrice售價 = Convert.ToInt32(l_dv[i]["f_ListPrice"].ToString());
                   l_datas.Add(l_code);
                }
                return l_datas.ToArray();
            }
            else
            {
                return null;
            }
        }

        public void insertCKGPart(CKGPart p_code)
        {
            string l_strSql = "INSERT INTO [kdnews].[dbo].[tbKGPart] ([f_TypeID],[f_TypeName],[f_CategoryID],[f_CategoryName],[f_ProductID],[f_ProductName],[f_Qty],[f_Cost],[f_SalePrice],[f_ListPrice])VALUES(";
            l_strSql += " '" + p_code.f_TypeID類別編號 + "' ";
            l_strSql += ", '" + p_code.f_TypeName類別名稱 + "' ";
            l_strSql += ", '" + p_code.f_CategoryID種類編號 + "' ";
            l_strSql += ", '" + p_code.f_CategoryName種類名稱 + "' ";
            l_strSql += ", '" + p_code.f_ProductID產品編號 + "' ";

            l_strSql += ", '" + p_code.f_ProductName產品名稱.Replace("'","''") + "' ";
            l_strSql += ", '" + p_code.f_Qty單位 + "' ";
            l_strSql += ", '" + p_code.f_Cost成本價 + "' ";
            l_strSql += ", '" + p_code.f_SalePrice業代價 + "' ";
            l_strSql += ", '" + p_code.f_ListPrice售價 + "' ";
            l_strSql += ")";

            ivContext.資料管理員.excuteSqlNonquery(l_strSql);
        }
  
        //public void update類別名稱By類別Id(string p_str類別Id, string p_str類別Name)
        //{
        //    string l_strSql = "UPDATE [kdnews].[dbo].[tbKGPart] SET ";
        //    l_strSql += "[f_TypeName] = '" + p_str類別Name + "' ";
        //    l_strSql += " WHERE f_TypeID = '" + p_str類別Id+"'";
        //}

        //public void update種類名稱By種類Id(string p_str種類Id, string p_str種類Name)
        //{
        //    string l_strSql = "UPDATE [kdnews].[dbo].[tbKGPart] SET ";
        //    l_strSql += "[f_CategoryName] = '" + p_str種類Name + "' ";
        //    l_strSql += " WHERE f_CategoryID = '" + p_str種類Id + "'";
        //}
        //public void update產品名稱By產品Id(string p_str產品Id, string p_str產品Name)
        //{
        //    string l_strSql = "UPDATE [kdnews].[dbo].[tbKGPart] SET ";
        //    l_strSql += "[f_ProductName] = '" + p_str產品Name + "' ";
        //    l_strSql += " WHERE f_ProductID = '" + p_str產品Id + "'";
        //}

        /// <summary>
        /// (Yu 20090617) 更新產品的單位、成本價、業代價、建議價 四個欄位
        /// </summary>
        /// <param name="p_code"></param>
        public void updateCKGPart單位and價位(CKGPart p_code)
        {
            string l_strSql = "UPDATE [kdnews].[dbo].[tbKGPart] SET ";
            l_strSql += "[f_Qty] = '" + p_code.f_Qty單位 + "',";
            l_strSql += "[f_Cost] = '" + p_code.f_Cost成本價 + "',";
            l_strSql += "[f_SalePrice] = '" + p_code.f_SalePrice業代價 + "',";
            l_strSql += "[f_ListPrice] = '" + p_code.f_ListPrice售價 + "', ";
            l_strSql += "[f_ProductName] = '" + p_code.f_ProductName產品名稱.Replace("'", "''") +"'";
            l_strSql += " WHERE f_id = " + p_code.f_id;
            ivContext.資料管理員.excuteSqlNonquery(l_strSql);
        }

        public void updateCKGPart(CKGPart p_code)
        {
            string l_strSql = "UPDATE [kdnews].[dbo].[tbKGPart] SET ";
            l_strSql += "[f_TypeID] = '" + p_code.f_TypeID類別編號 + "',";
            l_strSql += "[f_TypeName] = '" + p_code.f_TypeName類別名稱 + "',";
            l_strSql += "[f_CategoryID] = '" + p_code.f_CategoryID種類編號 + "',";
            l_strSql += "[f_CategoryName] = '" + p_code.f_CategoryName種類名稱 + "',";
            l_strSql += "[f_ProductID] = '" + p_code.f_ProductID產品編號 + "',";
            l_strSql += "[f_ProductName] = '" + p_code.f_ProductName產品名稱.Replace("'", "''") + "',";
            l_strSql += "[f_Qty] = '" + p_code.f_Qty單位 + "',";
            l_strSql += "[f_Cost] = '" + p_code.f_Cost成本價 + "',";
            l_strSql += "[f_SalePrice] = '" + p_code.f_SalePrice業代價 + "',";
            l_strSql += "[f_ListPrice] = '" + p_code.f_ListPrice售價 + "'";
            l_strSql += " WHERE f_id = " + p_code.f_id;
            ivContext.資料管理員.excuteSqlNonquery(l_strSql);
        }

        public void deleteCKGPart(string p_id)
        {
            string l_strSql = "DELETE [kdnews].[dbo].[tbKGPart] WHERE [f_id] = '" + p_id + "'";
            ivContext.資料管理員.excuteSqlNonquery(l_strSql);
        }
    }
}