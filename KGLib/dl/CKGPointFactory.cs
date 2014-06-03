using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using tw.com.yj.CommonLib;

namespace tw.com.kg.lib
{
    public class CKGPointFactory : YJCCommonFactory
    {
        public CKGPointFactory(YJCommonContext p_context)
        {
            setContext(p_context);
        }

        public CKGPoint createCKGPoint()
        {
            return new CKGPoint();
        }

        public CKGPoint[] getAllCKGPoint()
        {
            string l_strSql = "SELECT * FROM [KG].[dbo].[tbKGPoint]";
            return queryBySql(l_strSql);
        }

        public void update業代點數(string p_strSmid, int p_int點數)
        {
            string l_strSql = "UPDATE [KG].[dbo].[tbKGPoint] SET ";
            l_strSql += "[f_Point] = '" + p_int點數 + "'";
            l_strSql += " WHERE [f_Smid] = '" + p_strSmid + "'";
            ivContext.資料管理員.excuteSqlNonquery(l_strSql);
        }

        private int sum(List<CKGPointDetail> p_list)
        {
            int l_intSum = 0;
            for (int i = 0; i < p_list.Count; i++)
            {
                l_intSum += p_list[i].f_ImportPoint匯入點數;
            }
            return l_intSum;
        }

        /// <summary>
        /// //(Yu 20090617) 用Hashtable將點數匯入虛擬帳戶並寫入匯入記錄
        /// </summary>
        /// <param name="p_codes"></param>
        public void insert點數與記錄ByHashtable(Hashtable p_ht)
        {
            foreach (string l_strSmid in p_ht.Keys)
            {
                string l_strSql = "SELECT * FROM [KG].[dbo].[tbKGPoint] WHERE f_Smid ='" + l_strSmid + "'";
                DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_strSql);
                CKGPoint l_code = createCKGPoint();
                l_code.f_Smid業代員編 = l_strSmid;
                l_code.f_Name業代姓名 = ((List<CKGPointDetail>)p_ht[l_strSmid])[0].f_Name業代姓名;
                l_code.f_Point現有點數 = sum((List<CKGPointDetail>)p_ht[l_strSmid]);

                if (l_dv.Count > 0)
                {
                    updateOldCKGPoint(l_code); ;//有點數資料的加上匯入的點數
                }
                else
                {
                    insertCKGPoint(l_code);//沒有點數資料的直接新增
                }

                CKGPointDetailFactory l_factory = new CKGPointDetailFactory(ivContext);
                l_factory.insertCKGPointDetailBy點數匯入(((List<CKGPointDetail>)p_ht[l_strSmid]).ToArray());
            }
        }

        /// <summary>
        /// (Yu 20090510) 更新取消沖帳後業代的點數歸回
        /// </summary>
        /// <param name="p_strSmid"></param>
        /// <param name="p_int沖帳點數">沖帳點數 or 退貨點數</param>
        public void update沖帳取消或退貨成功後點數歸回(string p_strSmid, int p_int點數)
        {
            string l_strSql = "UPDATE [KG].[dbo].[tbKGPoint] SET ";
            l_strSql += "[f_Point] = (f_Point + " + p_int點數 + ")";
            l_strSql += " WHERE [f_Smid] = '" + p_strSmid + "'";
            ivContext.資料管理員.excuteSqlNonquery(l_strSql);
        }


        //public void update自動扣除沖帳點數(ArrayList p_al沖帳)
        //{
        //    if (p_al沖帳.Count <= 0)
        //    { return; }
        //    string l_strSql = " BEGIN ";
        //    for (int i = 0; i < p_al沖帳.Count; i++)
        //    {
        //        l_strSql+= " UPDATE [kdnews].[dbo].[tbKGPoint] SET ";
        //        l_strSql += " [f_Point] = (f_Point - " + ((CKGPartInMoneyDetail)p_al沖帳[i]).f_InMoney沖帳金額 + ")";
        //        l_strSql += " WHERE [f_Smid] = '" + ((CKGPartInMoneyDetail)p_al沖帳[i]).f_SalesSmid業代員編 + "';";
        //    }
        //    l_strSql += " END ";
        //    ivContext.資料管理員.excuteSqlNonquery(l_strSql);
        //}

        /// <summary>
        /// (Yu 20090510)
        /// </summary>
        /// <param name="p_strSmid"></param>
        /// <param name="p_int沖帳點數"></param>
        public void update扣除沖帳點數(string p_strSmid, int p_int沖帳點數)
        {
            string l_strSql = "UPDATE [KG].[dbo].[tbKGPoint] SET ";
            l_strSql += "[f_Point] = (f_Point - " + p_int沖帳點數 + ")";
            l_strSql += " WHERE [f_Smid] = '" + p_strSmid + "'";
            ivContext.資料管理員.excuteSqlNonquery(l_strSql); 
        }

        /// <summary>
        /// (Yu 20090508) 取得業代點數資料
        /// </summary>
        /// <param name="p_strSmid">業代員編</param>
        /// <returns></returns>
        public CKGPoint get業代點數資料(string p_strSmid)
        {
            string l_strSql = "SELECT * FROM [KG].[dbo].[tbKGPoint] WHERE f_Smid ='" + p_strSmid + "'";
            CKGPoint[] l_codes = queryBySql(l_strSql);
            if (l_codes != null)
            {
                return l_codes[0];
            }
            else
            {
                return null;
            }
        }


        private CKGPoint[] queryBySql(string p_sql)
        {
            DataView l_dv = ivContext.資料管理員.getDataViewBySql(p_sql);
            List<CKGPoint> l_datas = new List<CKGPoint>();

            if (l_dv.Count > 0)
            {
                for (int i = 0; i < l_dv.Count; i++)
                {
                    CKGPoint l_code = createCKGPoint();
                    l_code.f_Smid業代員編 = l_dv[i]["f_Smid"].ToString();
                    l_code.f_Name業代姓名 = l_dv[i]["f_Name"].ToString();
                    l_code.f_Point現有點數 = Convert.ToInt32(l_dv[i]["f_Point"].ToString());
                    l_datas.Add(l_code);
                }
                return l_datas.ToArray();
            }
            else
            {
                return null;
            }
        }

        public void insertCKGPoint(CKGPoint p_code)
        {
            string l_strSql = "INSERT INTO [KG].[dbo].[tbKGPoint] ([f_Smid],[f_Name],[f_Point])VALUES(";
            l_strSql += "  '" + p_code.f_Smid業代員編 + "' ";
            l_strSql += ", N'" + p_code.f_Name業代姓名 + "' ";
            l_strSql += ", '" + p_code.f_Point現有點數 + "' ";
            l_strSql += ")";

            ivContext.資料管理員.excuteSqlNonquery(l_strSql);
        }

        public void updateCKGPoint(CKGPoint p_code)
        {
            string l_strSql = "UPDATE [KG].[dbo].[tbKGPoint] SET ";
            l_strSql += "[f_Name] = N'" + p_code.f_Name業代姓名 + "',";
            l_strSql += "[f_Point] = '" + p_code.f_Point現有點數 + "'";
            l_strSql += " WHERE [f_Smid] = '" + p_code.f_Smid業代員編 + "'";
            ivContext.資料管理員.excuteSqlNonquery(l_strSql);
        }
        public void updateOldCKGPoint(CKGPoint p_code)
        {
            string l_strSql = "UPDATE [KG].[dbo].[tbKGPoint] SET ";
            l_strSql += "[f_Point] = (f_Point + " + p_code.f_Point現有點數.ToString() + ") ,";//有點數資料的加上匯入的點數
            l_strSql += "[f_Name] = N'" + p_code.f_Name業代姓名 + "'";
            l_strSql += " WHERE f_Smid = '" + p_code.f_Smid業代員編 + "'";

            ivContext.資料管理員.excuteSqlNonquery(l_strSql);
        }

        public void deleteCKGPoint(string p_Smid)
        {
            string l_strSql = "DELETE [KG].[dbo].[tbKGPoint] WHERE [f_Smid] = '" + p_Smid + "'";
            ivContext.資料管理員.excuteSqlNonquery(l_strSql);
        }
    }
}