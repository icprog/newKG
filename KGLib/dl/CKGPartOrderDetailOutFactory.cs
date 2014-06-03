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
        /// (Yu 20090514) �α�����o�~�N�h�f���
        /// </summary>
        /// <param name="p_str�U�z���s">�U�z���s</param>
        /// <param name="p_strp_str���ʳ渹">���ʳ渹</param>
        /// <param name="p_str�~�N���s">�~�N���s</param>
        /// <param name="p_str�h�f���A">�h�f���A True:�w�����h�f�AFalse:�������h�f</param>
        /// <param name="p_strStartDay">�h�f�_�l���</param>
        /// <param name="p_strEndDay">�h�f�������</param>
        /// <returns></returns>
        public CKGPartOrderDetailOut[] getAll�h�f���By����(string p_str�U�z���s, string p_str���ʳ渹,string p_str���ʩҧO, string p_str�~�N���s, string p_str�h�f���A, string p_strStartDay, string p_strEndDay)
        {
            string l_strSql = "SELECT * FROM [KG].[dbo].[tbKGPartOrderDetailOut] WHERE 1=1 ";

            if (!"".Equals(p_str���ʳ渹))
            {
                l_strSql += " AND f_ExchangeID = '" + p_str���ʳ渹 + "' ";
            }
             if (!"".Equals(p_str���ʩҧO))
            {
                l_strSql += " AND f_branchid = '" + p_str���ʩҧO + "' ";
            }
            
            if (!"".Equals(p_str�U�z���s))
            {
                l_strSql += " AND f_AssistantSmid = '" + p_str�U�z���s + "' ";
            }

            if (!"".Equals(p_str�~�N���s))
            {
                l_strSql += " AND f_SalesSmid = '" + p_str�~�N���s + "' ";
            }

            if (!"".Equals(p_str�h�f���A))
            {
                l_strSql += " AND f_Check ='" + p_str�h�f���A + "'";
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
        public CKGPartOrderDetailOut get�h�f���ById(string p_strId)
        {
            string l_strSql = "SELECT * FROM [KG].[dbo].[tbKGPartOrderDetailOut] WHERE f_id =" + p_strId;
            return queryBySql(l_strSql)[0];
        }


        /// <summary>
        /// (Yu 20090513)
        /// </summary>
        /// <param name="p_str���ʳ渹"></param>
        /// <returns></returns>
        public CKGPartOrderDetailOut[] get�h�f���By���ʳ渹(string p_str���ʳ渹,string p_str�U�zSmid)
        {
            string l_strSql = "SELECT * FROM [KG].[dbo].[tbKGPartOrderDetailOut] WHERE f_ExchangeID ='" + p_str���ʳ渹 + "'";
            l_strSql += " AND f_AssistantSmid='" + p_str�U�zSmid + "'";
            return queryBySql(l_strSql);
        }

        private CKGPartOrderDetailOut[] queryBySql(string p_sql)
        {
            DataView l_dv = ivContext.��ƺ޲z��.getDataViewBySql(p_sql);
            List<CKGPartOrderDetailOut> l_datas = new List<CKGPartOrderDetailOut>();

            if (l_dv.Count > 0)
            {
                for (int i = 0; i < l_dv.Count; i++)
                {
                    CKGPartOrderDetailOut l_code = createCKGPartOrderDetailOut();
                    l_code.f_id = Convert.ToInt32(l_dv[i]["f_id"].ToString());
                    l_code.f_ExchangeID���ʳ渹 = l_dv[i]["f_ExchangeID"].ToString();
                    l_code.f_AssistantSmid�h�f�U�z���s = l_dv[i]["f_AssistantSmid"].ToString();
                    l_code.f_SalesSmid�~�N���s = l_dv[i]["f_SalesSmid"].ToString();
                    l_code.f_SalesBranch�~�N��� = l_dv[i]["f_branchid"].ToString();
                    l_code.f_ProductID���~�s�� = l_dv[i]["f_ProductID"].ToString();
                    l_code.f_ProductName���~�W�� = l_dv[i]["f_ProductName"].ToString();
                    l_code.f_OutAmount�h�f�ƶq = Convert.ToInt32(l_dv[i]["f_OutAmount"].ToString());
                    l_code.f_OutDate�h�f��� = l_dv[i]["f_OutDate"].ToString();
                    l_code.f_Qty���~��� = l_dv[i]["f_Qty"].ToString();
                    l_code.f_Cost���~���� = Convert.ToInt32(l_dv[i]["f_Cost"].ToString());
                    l_code.f_UnitPrice���~��� = Convert.ToInt32(l_dv[i]["f_UnitPrice"].ToString());
                    l_code.f_ListPrice��ĳ��� = Convert.ToInt32(l_dv[i]["f_ListPrice"].ToString());
                    l_code.f_OutTotal�`�p�h�f���� = Convert.ToInt32(l_dv[i]["f_OutTotal"].ToString());
                    l_code.f_OutReasons�h�f��] = l_dv[i]["f_OutReasons"].ToString();
                    l_code.f_Check�޲z�̽T�{�h�f = l_dv[i]["f_Check"].ToString();
                    l_code.f_CheckDate�T�{�h�f��� = l_dv[i]["f_CheckDate"].ToString();
                    l_code.f_EditDate�s���� = l_dv[i]["f_EditDate"].ToString();
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
            l_strSql += " '" + p_code.f_ExchangeID���ʳ渹 + "' ";
            l_strSql += ", '" + p_code.f_AssistantSmid�h�f�U�z���s + "' ";
            l_strSql += ", '" + p_code.f_SalesSmid�~�N���s + "' ";
            l_strSql += ", '" + p_code.f_SalesBranch�~�N��� + "' ";
            l_strSql += ", '" + p_code.f_ProductID���~�s�� + "' ";
            l_strSql += ", '" + p_code.f_ProductName���~�W��.Replace("'", "''") + "' ";
            l_strSql += ", '" + p_code.f_OutAmount�h�f�ƶq + "' ";
            l_strSql += ", '" + p_code.f_OutDate�h�f��� + "' ";
            l_strSql += ", '" + p_code.f_Qty���~��� + "' ";
            l_strSql += ", '" + p_code.f_Cost���~���� + "' ";
            l_strSql += ", '" + p_code.f_UnitPrice���~��� + "' ";
            l_strSql += ", '" + p_code.f_ListPrice��ĳ��� + "' ";
            l_strSql += ", '" + p_code.f_OutTotal�`�p�h�f���� + "' ";
            l_strSql += ", '" + p_code.f_OutReasons�h�f��] + "' ";
            l_strSql += ", '" + p_code.f_Check�޲z�̽T�{�h�f + "' ";
            l_strSql += ", '" + p_code.f_CheckDate�T�{�h�f��� + "' ";
            l_strSql += ", '" + p_code.f_EditDate�s���� + "' ";
            l_strSql += ")";

            ivContext.��ƺ޲z��.excuteSqlNonquery(l_strSql);
        }

        /// <summary>
        /// (Yu 20090514) �޲z�̽T�{�h�f
        /// </summary>
        /// <param name="p_id"></param>
        public void update�T�{�h�fBy�޲z��(string p_id ,string p_strCheckDate)
        {
            string l_strSql = "UPDATE [KG].[dbo].[tbKGPartOrderDetailOut] SET ";
            l_strSql += "[f_Check] = 'True' ,";
            l_strSql += "[f_CheckDate] = '" + p_strCheckDate + "'";
            l_strSql += " WHERE f_id = '" + p_id + "'";
            ivContext.��ƺ޲z��.excuteSqlNonquery(l_strSql);
        }

        public void updateCKGPartOrderDetailOut(CKGPartOrderDetailOut p_code)
        {
            string l_strSql = "UPDATE [KG].[dbo].[tbKGPartOrderDetailOut] SET ";
            l_strSql += "[f_ExchangeID] = '" + p_code.f_ExchangeID���ʳ渹 + "',";
            l_strSql += "[f_AssistantSmid] = '" + p_code.f_AssistantSmid�h�f�U�z���s + "',";
            l_strSql += "[f_AssistantName] = N'" + p_code.f_AssistantName�h�f�U�z�m�W + "',";
            l_strSql += "[f_SalesSmid] = '" + p_code.f_SalesSmid�~�N���s + "',";
            l_strSql += "[f_SalesName] = N'" + p_code.f_SalesName�~�N�m�W + "',";
            l_strSql += "[f_SalesBranch] = '" + p_code.f_SalesBranch�~�N��� + "',";
            l_strSql += "[f_ProductID] = '" + p_code.f_ProductID���~�s�� + "',";
            l_strSql += "[f_ProductName] = '" + p_code.f_ProductName���~�W��.Replace("'", "''") + "',";
            l_strSql += "[f_OutAmount] = '" + p_code.f_OutAmount�h�f�ƶq + "',";
            l_strSql += "[f_OutDate] = '" + p_code.f_OutDate�h�f��� + "',";
            l_strSql += "[f_Qty] = '" + p_code.f_Qty���~��� + "',";
            l_strSql += "[f_Cost] = '" + p_code.f_Cost���~���� + "',";
            l_strSql += "[f_UnitPrice] = '" + p_code.f_UnitPrice���~��� + "',";
            l_strSql += "[f_ListPrice] = '" + p_code.f_ListPrice��ĳ��� + "',";
            l_strSql += "[f_OutTotal] = '" + p_code.f_OutTotal�`�p�h�f���� + "',";
            l_strSql += "[f_OutReasons] = '" + p_code.f_OutReasons�h�f��] + "',";
            l_strSql += "[f_Check] = '" + p_code.f_Check�޲z�̽T�{�h�f + "',";
            l_strSql += "[f_CheckDate] = '" + p_code.f_CheckDate�T�{�h�f��� + "',";
            l_strSql += "[f_EditDate] = '" + p_code.f_EditDate�s���� + "'";
            l_strSql += " WHERE f_id = '" + p_code.f_id + "'";
            ivContext.��ƺ޲z��.excuteSqlNonquery(l_strSql);
        }

        public void deleteCKGPartOrderDetailOut(string p_id)
        {
            string l_strSql = "DELETE [KG].[dbo].[tbKGPartOrderDetailOut] WHERE [f_id] = '" + p_id + "'";
            ivContext.��ƺ޲z��.excuteSqlNonquery(l_strSql);
        }
    }
}