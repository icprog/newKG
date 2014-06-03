using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using tw.com.yj.CommonLib;

namespace tw.com.kg.lib
{
    public class CKGPartOrderFactory : YJCCommonFactory
    {
        public CKGPartOrderFactory(YJCommonContext p_context)
        {
            setContext(p_context);
        }

        public CKGPartOrder createCKGPartOrder()
        {
            return new CKGPartOrder();
        }

        public CKGPartOrder[] getAllCKGPartOrder()
        {
            string l_strSql = "SELECT * FROM [KG].[dbo].[tbKGPartOrder]";
            return queryBySql(l_strSql);
        }

        /// <summary>
        /// (Yu 20091117) 得
        /// </summary>
        /// <param name="p_str所別"></param>
        /// <param name="p_str廠商"></param>
        /// <param name="p_strStartDay"></param>
        /// <param name="p_strEndDay"></param>
        /// <returns></returns>
        public CKGPartOrder[] get條件時間內的已結實績總額(string p_str所別, string p_str廠商, string p_strStartDay, string p_strEndDay)
        {
            string l_strSql = "SELECT f_SalesBranch,Sum(f_TotalCost) AS f_TotalCost,Sum(f_TotalPrice) AS f_TotalPrice ";
            l_strSql += " FROM  [KG].[dbo].[tbKGPartOrder] ";
            l_strSql += " WHERE 1=1 ";

            if (!"".Equals(p_str所別))
            {
                l_strSql += " AND f_SalesBranch ='" + p_str所別 + "'";
            }
            if (!"".Equals(p_str廠商))
            {
                l_strSql += " AND f_Vendor ='" + p_str廠商 + "'";
            }

            if (!"".Equals(p_strStartDay) && "".Equals(p_strEndDay))
            {
                l_strSql += " AND f_InsertDate >='" + p_strStartDay + "'";
            }
            else if ("".Equals(p_strStartDay) && !"".Equals(p_strEndDay))
            {
                l_strSql += " AND f_InsertDate <='" + p_strEndDay + "'";
            }
            else if (!"".Equals(p_strStartDay) && !"".Equals(p_strEndDay))
            {
                l_strSql += " AND f_InsertDate BETWEEN '" + p_strStartDay + "' AND '" + p_strEndDay + "'";
            }

            l_strSql += " GROUP BY f_SalesBranch";
            l_strSql += " ORDER BY f_SalesBranch";

            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_strSql);
            List<CKGPartOrder> l_datas = new List<CKGPartOrder>();

            if (l_dv.Count > 0)
            {
                for (int i = 0; i < l_dv.Count; i++)
                {
                    CKGPartOrder l_code = createCKGPartOrder();
                    l_code.f_SalesBranch業代單位 = l_dv[i]["f_SalesBranch"].ToString();
                    l_code.f_TotalCost總成本價 = Convert.ToInt32(l_dv[i]["f_TotalCost"].ToString());
                    l_code.f_TotalPrice總計價格 = Convert.ToInt32(l_dv[i]["f_TotalPrice"].ToString());
                    l_datas.Add(l_code);
                }
                return l_datas.ToArray();
            }
            else
            {
                return null;
            }
        }

        private string setReturnBranchid()
        {
            string l_strSql = "";
            l_strSql += "	Branchid = (case	";
            l_strSql += " when f_SalesBranch ='岡山營業所' then 'F030' ";
            l_strSql += " when f_SalesBranch ='屏東營業所' then 'F040' ";
            l_strSql += " when f_SalesBranch ='北高營業所' then 'F070' ";
            l_strSql += " when f_SalesBranch ='旗山營業所' then 'F080' ";
            l_strSql += " when f_SalesBranch ='潮州營業所' then 'F090' ";
            l_strSql += " when f_SalesBranch ='小港營業所' then 'F100' ";
            l_strSql += " when f_SalesBranch ='九如營業所' then 'F110' ";
            l_strSql += " when f_SalesBranch ='鳳山營業所' then 'F120' ";
            l_strSql += " when f_SalesBranch ='湖內營業所' then 'F130' ";
            l_strSql += " when f_SalesBranch ='北屏營業所' then 'F140' ";
            l_strSql += " when f_SalesBranch ='青年營業所' then 'F150' ";
            l_strSql += " when f_SalesBranch ='瑞豐營業所' then 'F170' ";
            l_strSql += " when f_SalesBranch ='右昌營業所' then 'F180' ";
            l_strSql += " when f_SalesBranch ='東港營業所' then 'F200' ";
            l_strSql += " when f_SalesBranch ='鳳林營業所' then 'F220' ";
            l_strSql += " when f_SalesBranch ='三多營業所' then 'F270' ";
            l_strSql += " when f_SalesBranch ='民族營業所' then 'F52L' ";
            l_strSql += " when f_SalesBranch ='建國營業所' then 'F53L' ";
            l_strSql += " when f_SalesBranch ='高運 - 明誠' then 'F710'";
            l_strSql += " when f_SalesBranch ='高運 - 澄清' then 'F720'";
            l_strSql += " when f_SalesBranch ='岡山服務廠' then 'F036' ";
            l_strSql += " when f_SalesBranch ='屏東服務廠' then 'F046' ";
            l_strSql += " when f_SalesBranch ='北高服務廠' then 'F076' ";
            l_strSql += " when f_SalesBranch ='旗山服務廠' then 'F086' ";
            l_strSql += " when f_SalesBranch ='潮州服務廠' then 'F096' ";
            l_strSql += " when f_SalesBranch ='小港服務廠' then 'F106' ";
            l_strSql += " when f_SalesBranch ='九如服務廠' then 'F116' ";
            l_strSql += " when f_SalesBranch ='鳳山服務廠' then 'F126' ";
            l_strSql += " when f_SalesBranch ='湖內服務廠' then 'F136' ";
            l_strSql += " when f_SalesBranch ='北屏服務廠' then 'F146' ";
            l_strSql += " when f_SalesBranch ='青年服務廠' then 'F156' ";
            l_strSql += " when f_SalesBranch ='楠梓服務廠' then 'F166' ";
            l_strSql += " when f_SalesBranch ='瑞豐服務廠' then 'F176' ";
            l_strSql += " when f_SalesBranch ='右昌服務廠' then 'F186' ";
            l_strSql += " when f_SalesBranch ='麟洛服務廠' then 'F196' ";
            l_strSql += " when f_SalesBranch ='東港服務廠' then 'F206' ";
            l_strSql += " when f_SalesBranch ='里港服務廠' then 'F216' ";
            l_strSql += " when f_SalesBranch ='鳳林服務廠' then 'F226' ";
            l_strSql += " when f_SalesBranch ='恆春服務廠' then 'F246' ";
            l_strSql += " when f_SalesBranch ='三多服務廠' then 'F276' ";
            l_strSql += " when f_SalesBranch ='中華服務廠' then 'F51S' ";
            l_strSql += " when f_SalesBranch ='民族服務廠' then 'F52S' ";
            l_strSql += " when f_SalesBranch ='建國服務廠' then 'F53S' ";
            l_strSql += " when f_SalesBranch ='總公司' then 'F800' ";
            l_strSql += " end ";
            l_strSql += " ) ";

            return l_strSql;
        }

        /// <summary>
        ///  (Yu 20090514) 取得已訂購的請購編號By助理Smid
        /// </summary>
        /// <param name="p_str請購單號">請購單號</param>
        /// <param name="p_str助理員編">助理員編</param>
        /// <param name="p_strVendor">廠商</param>
        /// <param name="p_strStartDay">請購起始日期</param>
        /// <param name="p_strEndDay">請購結束日期</param>
        /// <param name="p_str點收狀態">點收狀態 Buy:未點收 Check:點收</param>
        /// <returns></returns>
        public CKGPartOrder[] get已訂購的請購編號By助理Smid(string p_str請購單號, string p_str助理員編,string p_strVendor, string p_strStartDay, string p_strEndDay,string p_str點收狀態)
        {
            string l_strSql = "SELECT * FROM [KG].[dbo].[tbKGPartOrder] WHERE 1=1 ";

            if (!"".Equals(p_str請購單號))
            {
                l_strSql += " AND f_ExchangeID = '" + p_str請購單號 + "' ";
            }
            if (!"".Equals(p_str助理員編))
            {
                l_strSql += " AND f_AssistantSmid = '" + p_str助理員編 + "' ";
            }
            if (!"".Equals(p_strVendor))
            {
                l_strSql += " AND f_Vendor = '" + p_strVendor + "' ";
            }
            if (!"".Equals(p_strStartDay) && "".Equals(p_strEndDay))
            {
                l_strSql += " AND f_InsertDate >='" + p_strStartDay + "'";
            }
            else if ("".Equals(p_strStartDay) && !"".Equals(p_strEndDay))
            {
                l_strSql += " AND f_InsertDate <='" + p_strEndDay + "'";
            }
            else if (!"".Equals(p_strStartDay) && !"".Equals(p_strEndDay))
            {
                l_strSql += " AND f_InsertDate BETWEEN '" + p_strStartDay + "' AND '" + p_strEndDay + "'";
            }
            l_strSql += " AND f_Status = '" + p_str點收狀態 + "'";
            return queryBySql(l_strSql);
        }

        /// <summary>
        /// (Yu 20090507) 取得各所年報表的請購總金額
        /// </summary>
        /// <param name="p_str所別"></param>
        /// <param name="p_str廠商"></param>
        /// <param name="p_strStartDay"></param>
        /// <param name="p_strEndDay"></param>
        /// <returns></returns>
        public CKGPartOrder[] get各所年報的請購總金額(string p_str所別, string p_str廠商, string p_strStartMonth, string p_strEndMonth, bool p_bool含直販)
        {
            string l_strSql = "SELECT Substring(f_ExchangeID,2,4) AS f_InsertDate,f_SalesBranch,Sum(f_TotalCost) AS f_TotalCost,Sum(f_TotalPrice) AS f_TotalPrice ,";
            l_strSql += setReturnBranchid();
            l_strSql += " FROM dbo.tbKGPartOrder WHERE 1=1";

            if (!"".Equals(p_str所別))
            {
                l_strSql += " AND f_SalesBranch ='" + p_str所別 + "'";
            }
            if (!"".Equals(p_str廠商))
            {
                l_strSql += " AND f_Vendor ='" + p_str廠商 + "'";
            }
            if (!p_bool含直販)
            {
                l_strSql += " AND f_SalesBranchid not in ('FB50075')";
            }
            if (!"".Equals(p_strStartMonth) && "".Equals(p_strEndMonth))
            {
                l_strSql += " AND f_InsertDate >= '" + p_strStartMonth + "'";
            }
            else if ("".Equals(p_strStartMonth) && !"".Equals(p_strEndMonth))
            {
                l_strSql += " AND f_InsertDate <= '" + p_strEndMonth + "'";
            }
            else if (!"".Equals(p_strStartMonth) && !"".Equals(p_strEndMonth))
            {
                l_strSql += " AND f_InsertDate BETWEEN '" + p_strStartMonth + "' AND '" + p_strEndMonth + "'";
            }

            l_strSql += " GROUP BY f_SalesBranch,Substring(f_ExchangeID,2,4) ";
            l_strSql += " ORDER BY Substring(f_ExchangeID,2,4),Branchid ";

            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_strSql);
            List<CKGPartOrder> l_datas = new List<CKGPartOrder>();

            if (l_dv.Count > 0)
            {
                for (int i = 0; i < l_dv.Count; i++)
                {
                   CKGPartOrder l_code = createCKGPartOrder();
                   l_code.f_InsertDate請購日期 = l_dv[i]["f_InsertDate"].ToString();
                   l_code.f_SalesBranch業代單位 = l_dv[i]["f_SalesBranch"].ToString();
                   l_code.f_TotalCost總成本價 = Convert.ToInt32(l_dv[i]["f_TotalCost"].ToString());
                   l_code.f_TotalPrice總計價格 = Convert.ToInt32(l_dv[i]["f_TotalPrice"].ToString());
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
        /// (Yu 20090507) 取得各所月報表的請購總金額
        /// </summary>
        /// <param name="p_str所別"></param>
        /// <param name="p_str廠商"></param>
        /// <param name="p_strStartDay"></param>
        /// <param name="p_strEndDay"></param>
        /// <returns></returns>
        public CKGPartOrder[] get各所月報的請購總金額(string p_str所別, string p_str廠商, string p_strStartMonth, string p_strEndMonth, bool p_bool含直販)
        {
            string l_strSql = "SELECT Substring(f_ExchangeID,2,6) AS f_InsertDate,f_SalesBranch,Sum(f_TotalCost) AS f_TotalCost,Sum(f_TotalPrice) AS f_TotalPrice, ";
            l_strSql += setReturnBranchid();
            l_strSql+=" FROM dbo.tbKGPartOrder WHERE 1=1";

            if (!"".Equals(p_str所別))
            {
                l_strSql += " AND f_SalesBranch ='" + p_str所別 + "'";
            }
            if (!"".Equals(p_str廠商))
            {
                l_strSql += " AND f_Vendor ='" + p_str廠商 + "'";
            }
            if (!p_bool含直販)
            {
                l_strSql += " AND f_SalesBranchid not in ('FB50075')";
            }
            if (!"".Equals(p_strStartMonth) && "".Equals(p_strEndMonth))
            {
                l_strSql += " AND f_InsertDate >= '" + p_strStartMonth + "'";
            }
            else if ("".Equals(p_strStartMonth) && !"".Equals(p_strEndMonth))
            {
                l_strSql += " AND f_InsertDate <='" + p_strEndMonth + "'";
            }
            else if (!"".Equals(p_strStartMonth) && !"".Equals(p_strEndMonth))
            {
                l_strSql += " AND f_InsertDate BETWEEN '" + p_strStartMonth + "' AND '" + p_strEndMonth + "'";
            }

            l_strSql += " GROUP BY f_SalesBranch,Substring(f_ExchangeID,2,6) ";
            l_strSql += " ORDER BY Substring(f_ExchangeID,2,6),Branchid ";

            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_strSql);
            List<CKGPartOrder> l_datas = new List<CKGPartOrder>();

            if (l_dv.Count > 0)
            {
                for (int i = 0; i < l_dv.Count; i++)
                {
                   CKGPartOrder l_code= createCKGPartOrder();
                   l_code.f_InsertDate請購日期 = l_dv[i]["f_InsertDate"].ToString();
                   l_code.f_SalesBranch業代單位 = l_dv[i]["f_SalesBranch"].ToString();
                   l_code.f_TotalCost總成本價 = Convert.ToInt32(l_dv[i]["f_TotalCost"].ToString());
                   l_code.f_TotalPrice總計價格 = Convert.ToInt32(l_dv[i]["f_TotalPrice"].ToString());
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
        /// (Yu 20090507) 取得各所日報表的請購總金額
        /// </summary>
        /// <param name="p_str所別"></param>
        /// <param name="p_str廠商"></param>
        /// <param name="p_strStartDay"></param>
        /// <param name="p_strEndDay"></param>
        /// <param name="p_bool含直販">Treu: 含直販課，False:不含直販課</param>
        /// <returns></returns>
        public CKGPartOrder[] get各所日報的請購總金額(string p_str所別, string p_str廠商, string p_strStartDay, string p_strEndDay)
        {
            string l_strSql = "SELECT f_branchid,f_InsertDate,Sum(f_TotalCost) AS f_TotalCost,Sum(f_TotalPrice) AS f_TotalPrice ,Sum(f_TotalSale) AS f_TotalSale";
            //l_strSql += setReturnBranchid();
            l_strSql += " FROM  [KG].[dbo].[tbKGPartOrder] ";
            l_strSql += " WHERE 1=1 ";

            if (!"".Equals(p_str所別))
            {
                l_strSql += " AND f_branchid ='" + p_str所別 + "'";
            }
            if (!"".Equals(p_str廠商))
            {
                l_strSql += " AND f_Vendor ='" + p_str廠商 + "'";
            }

            if (!"".Equals(p_strStartDay) && "".Equals(p_strEndDay))
            {
                l_strSql += " AND f_InsertDate >='" + p_strStartDay + "'";
            }
            else if ("".Equals(p_strStartDay) && !"".Equals(p_strEndDay))
            {
                l_strSql += " AND f_InsertDate <='" + p_strEndDay + "'";
            }
            else if (!"".Equals(p_strStartDay) && !"".Equals(p_strEndDay))
            {
                l_strSql += " AND f_InsertDate BETWEEN '" + p_strStartDay + "' AND '" + p_strEndDay + "'";
            }

            l_strSql += " GROUP BY f_branchid,f_InsertDate";
            l_strSql += " ORDER BY f_branchid,f_InsertDate";

            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_strSql);
            List<CKGPartOrder> l_datas = new List<CKGPartOrder>();

            if (l_dv.Count > 0)
            {
                for (int i = 0; i < l_dv.Count; i++)
                {
                    
                   CKGPartOrder l_code = createCKGPartOrder();
                   l_code.f_SalesBranch業代單位 = l_dv[i]["f_branchid"].ToString();
                   l_code.f_InsertDate請購日期 = l_dv[i]["f_InsertDate"].ToString();
                   l_code.f_TotalCost總成本價 = Convert.ToInt32(l_dv[i]["f_TotalCost"].ToString());
                   l_code.f_TotalPrice總計價格 = Convert.ToInt32(l_dv[i]["f_TotalPrice"].ToString());
                   l_code.f_TotalSale總販賣價 = Convert.ToInt32("0"+l_dv[i]["f_TotalSale"].ToString());
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
        /// (Yu 20090505) 修改作業使用
        /// </summary>
        /// <param name="p_str業代員編"></param>
        /// <param name="p_str請購狀態"></param>
        /// <param name="p_strStartDay"></param>
        /// <param name="p_strEndDay"></param>
        /// <returns></returns>
        public CKGPartOrder[] get請購編號By修改(string p_str助理員編, string p_str請購單號, string p_str業代員編, string p_strStartDay, string p_strEndDay)
        {
            string l_strSql = "SELECT * FROM [KG].[dbo].[tbKGPartOrder] WHERE 1=1 ";

            if (!"".Equals(p_str助理員編))
            {
                l_strSql += " AND f_AssistantSmid = '" + p_str助理員編 + "' ";
            }
            if (!"".Equals(p_str請購單號))
            {
                l_strSql += " AND f_ExchangeID = '" + p_str請購單號 + "' ";
            }
            if (!"".Equals(p_str業代員編))
            {
                l_strSql += " AND f_SalesSmid = '" + p_str業代員編 + "' ";
            }

            if (!"".Equals(p_strStartDay) && "".Equals(p_strEndDay))
            {
                l_strSql += " AND f_InsertDate >='" + p_strStartDay + "'";
            }
            else if ("".Equals(p_strStartDay) && !"".Equals(p_strEndDay))
            {
                l_strSql += " AND f_InsertDate <='" + p_strEndDay + "'";
            }
            else if (!"".Equals(p_strStartDay) && !"".Equals(p_strEndDay))
            {
                l_strSql += " AND f_InsertDate BETWEEN '" + p_strStartDay + "' AND '" + p_strEndDay + "'";
            }
            return queryBySql(l_strSql);
        }

        
        /// <summary>
        /// (Yu 20090515) 取得請購單By條件
        /// </summary>
        /// <param name="p_str助理員編">助理員編</param>
        /// <param name="p_str業代員編">業代員編</param>
        /// <param name="p_str請購單號">請購單號</param>
        /// <param name="p_str請購狀態">請購狀態 Check:點收完成;Buy:訂購待貨中;空白:f_Status不是空白者</param>
        /// <param name="p_strStartDay">請購單起始日期</param>
        /// <param name="p_strEndDay">請購單結束日期</param>
        /// <returns></returns>
        public CKGPartOrder[] getAll請購單號By條件(string p_str助理員編, string p_str業代員編, string p_str請購單號, string p_str請購狀態, string p_strStartDay, string p_strEndDay)
        {
            string l_strSql = "SELECT o.*,h.name,h.branch FROM [KG].[dbo].[tbKGPartOrder] o";
            l_strSql += " left join kdnews..T_HRPersonel h on h.emp_id = o.f_SalesSmid ";
            l_strSql += " WHERE 1=1 ";

            if (!"".Equals(p_str助理員編))
            {
                l_strSql += " AND f_AssistantSmid = '" + p_str助理員編 + "' ";
            }

            if (!"".Equals(p_str請購單號))
            {
                l_strSql += " AND f_ExchangeID = '" + p_str請購單號 + "' ";
            }

            if (!"".Equals(p_str業代員編))
            {
                l_strSql += " AND f_SalesSmid = '" + p_str業代員編 + "' ";
            }

            if (!"".Equals(p_strStartDay) && "".Equals(p_strEndDay))
            {
                l_strSql += " AND f_InsertDate >='" + p_strStartDay + "'";
            }
            else if ("".Equals(p_strStartDay) && !"".Equals(p_strEndDay))
            {
                l_strSql += " AND f_InsertDate <='" + p_strEndDay + "'";
            }
            else if (!"".Equals(p_strStartDay) && !"".Equals(p_strEndDay))
            {
                l_strSql += " AND f_InsertDate BETWEEN '" + p_strStartDay + "' AND '" + p_strEndDay + "'";
            }

            l_strSql += " ORDER BY f_SalesSmid,f_InsertDate";
            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_strSql);
            List<CKGPartOrder> l_datas = new List<CKGPartOrder>();

            if (l_dv.Count > 0)
            {
                for (int i = 0; i < l_dv.Count; i++)
                {
                    CKGPartOrder l_code = createCKGPartOrder();
                    l_code.f_ExchangeID請購單號 = l_dv[i]["f_ExchangeID"].ToString();
                    l_code.f_Vendor請購廠商 = l_dv[i]["f_Vendor"].ToString();
                    l_code.f_EngineNo引擎號碼 = l_dv[i]["f_EngineNo"].ToString();
                    l_code.f_AssistantSmid助理員編 = l_dv[i]["f_AssistantSmid"].ToString();
                    l_code.f_SalesSmid業代員編 = l_dv[i]["f_SalesSmid"].ToString();
                    l_code.f_SalesName業代姓名 = l_dv[i]["name"].ToString();
                    l_code.f_SalesBranch業代單位 = l_dv[i]["branch"].ToString();
                    l_code.f_TotalCost總成本價 = Convert.ToInt32(l_dv[i]["f_TotalCost"].ToString());
                    l_code.f_TotalPrice總計價格 = Convert.ToInt32(l_dv[i]["f_TotalPrice"].ToString());
                    l_code.f_Memo備註說明 = l_dv[i]["f_Memo"].ToString();
                    l_code.f_InsertDate請購日期 = l_dv[i]["f_InsertDate"].ToString();
                    l_code.f_InsertIP輸入電腦IP = l_dv[i]["f_InsertIP"].ToString();
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


        /// (Yu 20090426) 多載 By請購單號、助理員編、訂購日期為篩選條件
        /// </summary>
        /// <param name="p_strExchengID">請購單號</param>
        /// <param name="p_AssistantSmid">助理員編</param>
        /// <param name="p_strStartDay">起始訂購日期</param>
        /// <param name="p_strEndDay">結束訂購日期</param>
        /// <returns></returns>
        public CKGPartOrder[] getKGPartOrderBy請購單號(string p_strExchangeID, string p_AssistantSmid,string p_strVendor, string p_strStartDay, string p_strEndDay)
        {
            string l_strSql = "SELECT o.*,h.name,h.branch FROM [KG].[dbo].[tbKGPartOrder] o";
            l_strSql += " left join kdnews..T_HRPersonel h on h.emp_id = o.f_SalesSmid ";
            l_strSql += " WHERE 1=1 ";
            if (!"".Equals(p_strExchangeID))
            {
                l_strSql += " AND f_ExchangeID = '" + p_strExchangeID + "' ";
            }
            if (!"".Equals(p_AssistantSmid))
            {
                l_strSql += " AND f_AssistantSmid = '" + p_AssistantSmid + "' ";
            }
            if (!"".Equals(p_strVendor))
            {
                l_strSql += " AND f_Vendor = '" + p_strVendor + "' ";
            }
            if (!"".Equals(p_strStartDay) && "".Equals(p_strEndDay))
            {
                l_strSql += " AND f_InsertDate >='" + p_strStartDay + "'";
            }
            else if ("".Equals(p_strStartDay) && !"".Equals(p_strEndDay))
            {
                l_strSql += " AND f_InsertDate <='" + p_strEndDay + "'";
            }
            else if (!"".Equals(p_strStartDay) && !"".Equals(p_strEndDay))
            {
                l_strSql += " AND f_InsertDate BETWEEN '" + p_strStartDay + "' AND '" + p_strEndDay + "'";
            }
            l_strSql += " ORDER BY f_InsertDate DESC";

            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_strSql);
            List<CKGPartOrder> l_datas = new List<CKGPartOrder>();

            if (l_dv.Count > 0)
            {
                for (int i = 0; i < l_dv.Count; i++)
                {
                    CKGPartOrder l_code = createCKGPartOrder();
                    l_code.f_ExchangeID請購單號 = l_dv[i]["f_ExchangeID"].ToString();
                    l_code.f_Vendor請購廠商 = l_dv[i]["f_Vendor"].ToString();
                    l_code.f_EngineNo引擎號碼 = l_dv[i]["f_EngineNo"].ToString();
                    l_code.f_AssistantSmid助理員編 = l_dv[i]["f_AssistantSmid"].ToString();
                    l_code.f_SalesSmid業代員編 = l_dv[i]["f_SalesSmid"].ToString();
                    l_code.f_SalesName業代姓名 = l_dv[i]["name"].ToString();
                    l_code.f_SalesBranch業代單位 = l_dv[i]["branch"].ToString();
                    l_code.f_TotalCost總成本價 = Convert.ToInt32(l_dv[i]["f_TotalCost"].ToString());
                    l_code.f_TotalPrice總計價格 = Convert.ToInt32(l_dv[i]["f_TotalPrice"].ToString());
                    l_code.f_Memo備註說明 = l_dv[i]["f_Memo"].ToString();
                    l_code.f_InsertDate請購日期 = l_dv[i]["f_InsertDate"].ToString();
                    l_code.f_InsertIP輸入電腦IP = l_dv[i]["f_InsertIP"].ToString();
                    l_code.f_EditDate編輯日期 = l_dv[i]["f_EditDate"].ToString();
                    l_code.f_TotalSale總販賣價 = Convert.ToInt32("0"+l_dv[i]["f_TotalSale"].ToString());
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
        /// (Yu 20090424) 多載 取得條件為請購單號
        /// </summary>
        /// <param name="p_strExchengID">請購單號</param>
        /// <param name="p_AssistantSmid">助理員編</param>
        /// <returns></returns>
        public CKGPartOrder getKGPartOrderBy請購單號(string p_strExchangeID, string p_AssistantSmid)
        {
            string l_strSql = "SELECT *,h.name,h.branch FROM [KG].[dbo].[tbKGPartOrder] o";

            l_strSql += " left join kdnews..T_HRPersonel h on h.emp_id = o.f_SalesSmid ";
            
            l_strSql +=" WHERE f_ExchangeID = '" + p_strExchangeID + "' ";

            if (!"".Equals(p_AssistantSmid))
            {
                l_strSql += " AND f_AssistantSmid ='" + p_AssistantSmid + "'";
            }
            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_strSql);
            List<CKGPartOrder> l_datas = new List<CKGPartOrder>();

            if (l_dv.Count > 0)
            {
                for (int i = 0; i < l_dv.Count; i++)
                {
                    CKGPartOrder l_code = createCKGPartOrder();
                    l_code.f_ExchangeID請購單號 = l_dv[i]["f_ExchangeID"].ToString();
                    l_code.f_Vendor請購廠商 = l_dv[i]["f_Vendor"].ToString();
                    l_code.f_EngineNo引擎號碼 = l_dv[i]["f_EngineNo"].ToString();
                    l_code.f_AssistantSmid助理員編 = l_dv[i]["f_AssistantSmid"].ToString();
                    l_code.f_SalesSmid業代員編 = l_dv[i]["f_SalesSmid"].ToString();
                    l_code.f_SalesName業代姓名 = l_dv[i]["name"].ToString();
                    l_code.f_SalesBranch業代單位 = l_dv[i]["branch"].ToString();
                    l_code.f_TotalCost總成本價 = Convert.ToInt32(l_dv[i]["f_TotalCost"].ToString());
                    l_code.f_TotalPrice總計價格 = Convert.ToInt32(l_dv[i]["f_TotalPrice"].ToString());
                    l_code.f_TotalSale總販賣價 = Convert.ToInt32("0"+l_dv[i]["f_TotalSale"].ToString());
                    l_code.f_Memo備註說明 = l_dv[i]["f_Memo"].ToString();
                    l_code.f_InsertDate請購日期 = l_dv[i]["f_InsertDate"].ToString();
                    l_code.f_InsertIP輸入電腦IP = l_dv[i]["f_InsertIP"].ToString();
                    l_code.f_EditDate編輯日期 = l_dv[i]["f_EditDate"].ToString();
                    l_datas.Add(l_code);
                }
            }
            else
            {
                return null;
            }
            if (l_datas == null)
            {
                return null;
            }
            else
            {
                return l_datas.ToArray()[0];
            }
        }

        //public CKGPartOrder[] get找出請購單主檔By條件(CKGPartOutOrder p_code)
        //{
        //    string l_strSql = "SELECT * FROM tbkgpartorder where 1=1 ";
        //    if (!"".Equals(p_code.f_Vendor訂購廠商))
        //    {
        //        l_strSql += " AND  f_Vendor ='" + p_code.f_Vendor訂購廠商 + "'";
        //    }
        //    l_strSql += " AND f_ExchangeID in( ";
        //    l_strSql += "  select f_ExchangeID from  tbKGPartOutOrderDetail where ";
        //    l_strSql += " f_OrderID ='" + p_code.f_OrderID訂單編號 + "' ";

        //    if (!"".Equals(p_code.StartDay起始日期) && "".Equals(p_code.EndDay結束日期))
        //    {
        //        l_strSql += " AND f_OrderDate >='" + p_code.StartDay起始日期 + "'";
        //    }
        //    else if ("".Equals(p_code.StartDay起始日期) && !"".Equals(p_code.EndDay結束日期))
        //    {
        //        l_strSql += " AND f_OrderDate <='" + p_code.EndDay結束日期 + "'";
        //    }
        //    else if (!"".Equals(p_code.StartDay起始日期) && !"".Equals(p_code.EndDay結束日期))
        //    {
        //        l_strSql += " AND f_OrderDate BETWEEN '" + p_code.StartDay起始日期 + "' AND '" + p_code.EndDay結束日期 + "'";
        //    }

        //    if (!"".Equals(p_code.f_SendTo送貨地點))
        //    {
        //        l_strSql += " and f_SalesBranch ='" + p_code.f_SendTo送貨地點 + "'";
        //    }
        //    l_strSql += " ) ";

        //    return queryBySql(l_strSql);
        //}

        public CKGPartOrder getKGPartOrderBy請購單號(string p_strExchangeID)
        {
            string l_strSql = "SELECT * FROM [KG].[dbo].[tbKGPartOrder] WHERE f_ExchangeID = '" + p_strExchangeID + "' ";
            return queryBySql(l_strSql)[0];
        }

        public CKGPartOrder get顧客姓名ByEngo(string p_strEngo)
        {
            string l_strSql = "select * from kddb..orders where engno = '" + p_strEngo + "'";

            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_strSql);
            List<CKGPartOrder> l_datas = new List<CKGPartOrder>();

            if (l_dv.Count > 0)
            {
                for (int i = 0; i < l_dv.Count; i++)
                {
                    CKGPartOrder l_code = createCKGPartOrder();
                    l_code.f_customername顧客姓名 = l_dv[i]["ordpnm"].ToString();
                    l_datas.Add(l_code);
                }
                return l_datas.ToArray()[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// (Yu 20090505) 
        /// </summary>
        /// <param name="p_str廠商"></param>
        /// <param name="p_str所別"></param>
        /// <returns></returns>
        public CKGPartOrder[] get所別未定購的請購明細(string p_str廠商, string p_str所別)
        {
            string l_strSql = " SELECT * FROM [KG].[dbo].[tbKGPartOrder] WHERE f_IsSend='False'";//狀態False者表示尚未訂購

            if (!"".Equals(p_str廠商))
            {
                l_strSql += " AND f_Vendor ='" + p_str廠商 + "'";
            }
            if (!"".Equals(p_str所別))
            {
                l_strSql += " AND f_branchid ='" + p_str所別 + "'";
            }

            return queryBySql(l_strSql);
        }


        /// <summary>
        /// (Yu 20090505) 
        /// </summary>
        /// <param name="p_str廠商"></param>
        /// <param name="p_str所別"></param>
        /// <returns></returns>
        public CKGPartOrder[] getGroupBy未訂購所別筆數(string p_str廠商, string p_str所別)
        {
            //string l_strSql = " SELECT f_branchid,f_Vendor,Count(f_ExchangeID) as NonSendConut FROM [KG].[dbo].[tbKGPartOrder] WHERE f_IsSend='False'";//狀態False者表示尚未訂購
            string l_strSql = " SELECT f_branchid,f_Vendor,Count(f_ExchangeID) as NonSendConut FROM [KG].[dbo].[tbKGPartOrder] WHERE f_exchangeid = 'EF21S20131105830' ";//狀態False者表示尚未訂購

            if (!"".Equals(p_str廠商))
            {
                l_strSql += " AND f_Vendor ='" + p_str廠商 + "'";
            }
            if (!"".Equals(p_str所別))
            {
                l_strSql += " AND f_branchid ='" + p_str所別 + "'";
            }
            l_strSql += " GROUP BY f_branchid,f_Vendor ";

            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_strSql);
            List<CKGPartOrder> l_datas = new List<CKGPartOrder>();

            if (l_dv.Count > 0)
            {
                for (int i = 0; i < l_dv.Count; i++)
                {
                   CKGPartOrder l_code = createCKGPartOrder();
                   l_code.f_SalesBranch業代單位 = l_dv[i]["f_branchid"].ToString();
                   l_code.f_Vendor請購廠商 = l_dv[i]["f_Vendor"].ToString();
                   l_code.NonSendCount未發送的請購筆數 = l_dv[i]["NonSendConut"].ToString();
                   l_datas.Add(l_code);
                }
                return l_datas.ToArray();
            }
            else
            {
                return null;
            }
        }
        
        
        public CKGPartOrder[] getAllCKGPartOrderBy助理未訂購(string p_str助理Smid,string p_str廠商)
        {
            string l_strSql = "SELECT * FROM [KG].[dbo].[tbKGPartOrder] WHERE f_Status='' ";//狀態空白者表示尚未訂購
            if (!"".Equals(p_str助理Smid))
            {
                l_strSql += " AND f_AssistantSmid ='" + p_str助理Smid + "'";
            }
            if (!"".Equals(p_str廠商))
            {
                l_strSql += " AND f_Vendor ='" + p_str廠商 + "'";
            }
            return queryBySql(l_strSql);
        }

        private CKGPartOrder[] queryBySql(string p_sql)
        {
            DataView l_dv = ivContext.資料管理員.getDataViewBySql(p_sql);
            List<CKGPartOrder> l_datas = new List<CKGPartOrder>();

            if (l_dv.Count > 0)
            {
                for (int i = 0; i < l_dv.Count; i++)
                {
                    CKGPartOrder l_code = createCKGPartOrder();
                    l_code.f_ExchangeID請購單號 = l_dv[i]["f_ExchangeID"].ToString();
                    l_code.f_Vendor請購廠商 = l_dv[i]["f_Vendor"].ToString();
                    l_code.f_EngineNo引擎號碼 = l_dv[i]["f_EngineNo"].ToString();
                    l_code.f_AssistantSmid助理員編 = l_dv[i]["f_AssistantSmid"].ToString();
                    l_code.f_SalesSmid業代員編 = l_dv[i]["f_SalesSmid"].ToString();
                    l_code.f_TotalCost總成本價 = Convert.ToInt32(l_dv[i]["f_TotalCost"].ToString());
                    l_code.f_TotalPrice總計價格 = Convert.ToInt32(l_dv[i]["f_TotalPrice"].ToString());
                    l_code.f_Memo備註說明 = l_dv[i]["f_Memo"].ToString();
                    l_code.f_InsertDate請購日期 = l_dv[i]["f_InsertDate"].ToString();
                    l_code.f_InsertIP輸入電腦IP = l_dv[i]["f_InsertIP"].ToString();
                    l_code.f_EditDate編輯日期 = l_dv[i]["f_EditDate"].ToString();
                    l_code.f_Branchid請購單位 = l_dv[i]["f_branchid"].ToString();
                    l_code.f_TotalSale總販賣價 = Convert.ToInt32("0"+l_dv[i]["f_TotalSale"].ToString());
                    l_datas.Add(l_code);
                }
                return l_datas.ToArray();
            }
            else
            {
                return null;
            }
        }

        public void insertCKGPartOrder(CKGPartOrder p_code)
        {
            string l_strSql = "INSERT INTO [KG].[dbo].[tbKGPartOrder] ([f_ExchangeID],[f_Vendor],[f_EngineNo],[f_AssistantSmid],[f_SalesSmid],[f_branchid],[f_TotalCost],[f_TotalPrice],[f_IsSend],[f_Memo],[f_InsertDate],[f_InsertIP],[f_EditDate],[f_TotalSale])VALUES(";
            l_strSql += " '" + p_code.f_ExchangeID請購單號 + "' ";
            l_strSql += ", '" + p_code.f_Vendor請購廠商 + "' ";
            l_strSql += ", '" + p_code.f_EngineNo引擎號碼 + "' ";
            l_strSql += ", '" + p_code.f_AssistantSmid助理員編 + "' ";
            l_strSql += ", '" + p_code.f_SalesSmid業代員編 + "' ";
            l_strSql += ", '" + p_code.f_AssistantBranchid助理單位編號 + "' ";
            l_strSql += ", '" + p_code.f_TotalCost總成本價 + "' ";
            l_strSql += ", '" + p_code.f_TotalPrice總計價格 + "' ";
            l_strSql += ", '" + p_code.f_IsSend是否發送 + "' ";
            l_strSql += ", '" + p_code.f_Memo備註說明 + "' ";
            l_strSql += ", '" + p_code.f_InsertDate請購日期 + "' ";
            l_strSql += ", '" + p_code.f_InsertIP輸入電腦IP + "' ";
            l_strSql += ", '" + p_code.f_EditDate編輯日期 + "' ";
            l_strSql += ", " + p_code.f_TotalSale總販賣價 + " ";
            l_strSql += ")";

            ivContext.資料管理員.excuteSqlNonquery(l_strSql);

            CKGPartOrderDetail[] l_codes = p_code.明細;
            CKGPartOrderDetailFactory l_factory = new CKGPartOrderDetailFactory(ivContext);
            l_factory.insertCKGPartOrderDetail(l_codes);
        }

        /// <summary>
        /// (Yu 20090514) 更新點收後請購單的f_Status狀態為Check
        /// </summary>
        /// <param name="p_str請購單號"></param>
        public void update點收後的狀態By請購單號(string p_str請購單號)
        {
            string l_strSql = "UPDATE [KG].[dbo].[tbKGPartOrder] SET ";
            l_strSql += "[f_Status] = 'Check',";
            l_strSql += "[f_EditDate] = '" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "'";
            l_strSql += " WHERE f_ExchangeID = '" + p_str請購單號 + "'";

            ivContext.資料管理員.excuteSqlNonquery(l_strSql);
        }

        public void update訂購或點收後請購單的狀態(CKGPartOrder p_codes)
        {
            string l_strSql = " BEGIN ";
            //for (int i = 0; i < p_codes.Length; i++)
            //{
                l_strSql += "UPDATE [KG].[dbo].[tbKGPartOrder] SET ";
                l_strSql += "[f_IsSend] = 'True'";
                l_strSql += " WHERE f_ExchangeID = '" + p_codes.f_ExchangeID請購單號 + "' ;";
            //}
            l_strSql += " END";
            ivContext.資料管理員.excuteSqlNonquery(l_strSql);
        }
        public void update總計成本與總計價格By請購明細取消物品項目(CKGPartOrder p_code)
        {
            string l_strSql = "UPDATE [KG].[dbo].[tbKGPartOrder] SET ";
            l_strSql += "[f_TotalCost] = '" + p_code.f_TotalCost總成本價 + "',";
            l_strSql += "[f_TotalPrice] = '" + p_code.f_TotalPrice總計價格 + "',";
            l_strSql += "[f_EditDate] = '" + p_code.f_EditDate編輯日期 + "'";
            l_strSql += " WHERE f_ExchangeID = '" + p_code.f_ExchangeID請購單號 + "'";
            ivContext.資料管理員.excuteSqlNonquery(l_strSql);
        }

        public void update主檔狀態By明細全部取消(CKGPartOrder p_code)
        {
            string l_strSql = "UPDATE [KG].[dbo].[tbKGPartOrder] SET ";
            l_strSql += "[f_TotalCost] = '" + p_code.f_TotalCost總成本價 + "',";
            l_strSql += "[f_TotalPrice] = '" + p_code.f_TotalPrice總計價格 + "',";
            l_strSql += "[f_Status] = '" + p_code.f_Status請購狀態 + "',";
            l_strSql += "[f_EditDate] = '" + p_code.f_EditDate編輯日期 + "'";
            l_strSql += " WHERE f_ExchangeID = '" + p_code.f_ExchangeID請購單號 + "'";
            ivContext.資料管理員.excuteSqlNonquery(l_strSql);
        }

        public void updateCKGPartOrder(CKGPartOrder p_code)
        {
            string l_strSql = "UPDATE [KG].[dbo].[tbKGPartOrder] SET ";
            l_strSql += "[f_AssistantSmid] = '" + p_code.f_AssistantSmid助理員編 + "',";
            l_strSql += "[f_AssistantName] = '" + p_code.f_AssistantName助理姓名 + "',";
            l_strSql += "[f_AssistantBranch] = '" + p_code.f_AssistantBranch助理單位 + "',";
            l_strSql += "[f_SalesSmid] = '" + p_code.f_SalesSmid業代員編 + "',";
            l_strSql += "[f_SalesName] = '" + p_code.f_SalesName業代姓名 + "',";
            l_strSql += "[f_SalesBranch] = '" + p_code.f_SalesBranch業代單位 + "',";
            l_strSql += "[f_TotalCost] = '" + p_code.f_TotalCost總成本價 + "',";
            l_strSql += "[f_TotalPrice] = '" + p_code.f_TotalPrice總計價格 + "',";
            l_strSql += "[f_Status] = '" + p_code.f_Status請購狀態 + "',";
            l_strSql += "[f_Memo] = '" + p_code.f_Memo備註說明 + "',";
            l_strSql += "[f_InsertDate] = '" + p_code.f_InsertDate請購日期 + "',";
            l_strSql += "[f_InsertIP] = '" + p_code.f_InsertIP輸入電腦IP + "',";
            l_strSql += "[f_EditDate] = '" + p_code.f_EditDate編輯日期 + "'";
            l_strSql += " WHERE f_ExchangeID = '" + p_code.f_ExchangeID請購單號 + "'";
            ivContext.資料管理員.excuteSqlNonquery(l_strSql);
        }

        public void deleteCKGPartOrder(string p_strExchangeID)
        {
            string l_strSql = "DELETE [KG].[dbo].[tbKGPartOrder] WHERE [f_ExchangeID] = '" + p_strExchangeID + "'";
            ivContext.資料管理員.excuteSqlNonquery(l_strSql);
        }


        public CKGPartOrder[] get小百貨對帳單資訊(string p_strStartDay, string p_strEndDay, string p_branchid, string p_Vendor)
        {
            string l_strSql = "";
            l_strSql += " select *";
            l_strSql += " from [tbKGPartOrder]";
            l_strSql += " where f_issend = 'true'";

            if (!"".Equals(p_Vendor))
            {
                l_strSql += " AND f_Vendor ='" + p_Vendor + "'";
            }
            if (!"".Equals(p_branchid))
            {
                l_strSql += " AND f_branchid ='" + p_branchid + "'";
            }
            if (!"".Equals(p_strStartDay) && "".Equals(p_strEndDay))
            {
                l_strSql += " AND f_InsertDate >='" + p_strStartDay + "'";
            }
            else if ("".Equals(p_strStartDay) && !"".Equals(p_strEndDay))
            {
                l_strSql += " AND f_InsertDate <='" + p_strEndDay + "'";
            }
            else if (!"".Equals(p_strStartDay) && !"".Equals(p_strEndDay))
            {
                l_strSql += " AND f_InsertDate BETWEEN '" + p_strStartDay + "' AND '" + p_strEndDay + "'";
            }
            l_strSql += " order by f_InsertDate";
            return queryBySql(l_strSql);
        }
    }
}