using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tw.com.yj.CommonLib;
using System.Data;

namespace tw.com.kg.lib
{
    public class 特販審核Factory : YJCCommonFactory
    {
        public 特販審核Factory(YJCommonContext p_context)
        {
            setContext(p_context);
        }

        public 特販審核 create特販審核()
        {
            return new 特販審核();
        }

        public 特販審核[] getAll特販審核(string p_strMonth, CUser l_user)
        {
            string l_strSql = "SELECT * FROM kdreward..customer";
            //l_strSql += " where substring(convert(char(12),orderdate,111),6,2) = '" + p_strMonth + "'";
            l_strSql += " where Status='2'";

            if (l_user.f_lvl等級 == 5)//南區
            {
                l_strSql += " and BranchId in ('F04','F07','F09','F10','F14','F17','F20','F22')";
            }
            else if (l_user.f_lvl等級 == 6)//北區
            {
                l_strSql += " and BranchId in ('F03','F08','F11','F12','F13','F15','F18','F27')";
            }
            else
            {
                l_strSql = "SELECT c.* FROM kdreward..customer c";
                l_strSql += " inner join tbCarSaleUp s on c.custid = s.f_custid";
                l_strSql += " where c.Status='3'";
            }
            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_strSql);

            特販審核[] l_datas = new 特販審核[l_dv.Count];

            if (l_dv != null)
            {
                for (int i = 0; i < l_datas.Length; i++)
                {
                    l_datas[i] = create特販審核();
                    l_datas[i].custid = Convert.ToInt32(l_dv[i]["custid"].ToString());
                    l_datas[i].CustomerId = l_dv[i]["CustomerId"].ToString();
                    l_datas[i].Name = l_dv[i]["Name"].ToString();
                    l_datas[i].Status = l_dv[i]["Status"].ToString();
                    l_datas[i].OrderDate = l_dv[i]["OrderDate"].ToString();
                }
                return l_datas;
            }
            return null;
        }

        public 特販審核[] getAll特販審核s(string p_strMonth, CUser l_user,string p_branchid)
        {
            string l_strSql = "SELECT * FROM kdreward..customer";
            //l_strSql += " where substring(convert(char(12),orderdate,111),6,2) = '" + p_strMonth + "'";
            l_strSql += " where Status='2'";

            if (l_user.f_lvl等級 == 5)//南區
            {
                l_strSql += " and BranchId in ('F04','F07','F09','F10','F14','F17','F20','F22')";

                if (!"".Equals(p_branchid))
                {
                    l_strSql += " and BranchId = '" + p_branchid + "'";
                }
            }
            else if (l_user.f_lvl等級 == 6)//北區
            {
                l_strSql += " and BranchId in ('F03','F08','F11','F12','F13','F15','F18','F27')";

                if (!"".Equals(p_branchid))
                {
                    l_strSql += " and BranchId = '" + p_branchid + "'";
                }
            }
            else
            {
                l_strSql = "SELECT c.* FROM kdreward..customer c";
                l_strSql += " inner join tbCarSaleUp s on c.custid = s.f_custid";
                l_strSql += " where c.Status='3'";
            }
            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_strSql);

            特販審核[] l_datas = new 特販審核[l_dv.Count];

            if (l_dv != null)
            {
                for (int i = 0; i < l_datas.Length; i++)
                {
                    l_datas[i] = create特販審核();
                    l_datas[i].custid = Convert.ToInt32(l_dv[i]["custid"].ToString());
                    l_datas[i].CustomerId = l_dv[i]["CustomerId"].ToString();
                    l_datas[i].Name = l_dv[i]["Name"].ToString();
                    l_datas[i].Status = l_dv[i]["Status"].ToString();
                    l_datas[i].OrderDate = l_dv[i]["OrderDate"].ToString();
                }
                return l_datas;
            }
            return null;
        }

        public 特販審核[] getAll特販審核(string p_strYear, string p_strMonth, CUser l_user, string p_status, string p_strBrachid, string p_strchiefmemo)
        {
            string l_strSql = "SELECT * FROM kdreward..customer";
            l_strSql += " where substring(convert(char(12),orderdate,111),6,2) = '" + p_strMonth + "'";
            l_strSql += " and substring(convert(char(12),orderdate,111),0,5) = '" + p_strYear + "'";
            l_strSql += " and chiefmemo = '" + p_strchiefmemo + "'";

            if (!"".Equals(p_status))
            {
                l_strSql += " and Status='" + p_status + "'";
            }
            if (l_user.f_lvl等級 == 5)//南區
            {
                l_strSql += " and BranchId in ('F04','F07','F09','F10','F14','F17','F20','F22')";
            }
            if (l_user.f_lvl等級 == 6)//北區
            {
                l_strSql += " and BranchId in ('F03','F08','F11','F12','F13','F15','F18','F27')";
            }
            if (!"".Equals(p_strBrachid))//北區
            {
                l_strSql += " and BranchId = '" + p_strBrachid + "'";
            }
            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_strSql);

            特販審核[] l_datas = new 特販審核[l_dv.Count];

            if (l_dv != null)
            {
                for (int i = 0; i < l_datas.Length; i++)
                {
                    l_datas[i] = create特販審核();
                    l_datas[i].custid = Convert.ToInt32(l_dv[i]["custid"].ToString());
                    l_datas[i].CustomerId = l_dv[i]["CustomerId"].ToString();
                    l_datas[i].Name = l_dv[i]["Name"].ToString();
                    l_datas[i].Status = l_dv[i]["Status"].ToString();
                    l_datas[i].otherprize = l_dv[i]["other_prize"].ToString();
                    l_datas[i].saletype = l_dv[i]["sale_type"].ToString();
                    l_datas[i].SupportAmt =Convert.ToDouble( "0"+l_dv[i]["SupportAmt"].ToString() );
                    l_datas[i].RecordDate = l_dv[i]["RecordDate"].ToString();
                    l_datas[i].ManagerMemo = l_dv[i]["CarCenterMemo"].ToString();
                    l_datas[i].OrderDate = l_dv[i]["OrderDate"].ToString();
                }
                return l_datas;
            }
            return null;
        }
        public 特販審核 get特販審核Bycustid(string p_strcustid)
        {
            string l_strSql = "SELECT * FROM kdreward..customer";
            l_strSql += " where custid =" + p_strcustid;
            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_strSql);

            特販審核[] l_datas = new 特販審核[l_dv.Count];

            if (l_dv != null)
            {
                for (int i = 0; i < l_datas.Length; i++)
                {
                    l_datas[i] = create特販審核();
                    l_datas[i].custid = Convert.ToInt32(l_dv[i]["custid"].ToString());
                    l_datas[i].SalesMemo = l_dv[i]["SalesMemo"].ToString();
                    l_datas[i].ChiefMemo = l_dv[i]["ChiefMemo"].ToString();
                    l_datas[i].ManagerMemo = l_dv[i]["ManagerMemo"].ToString();
                    l_datas[i].CarCenterMemo = l_dv[i]["CarCenterMemo"].ToString();

                    l_datas[i].Status = l_dv[i]["Status"].ToString();
                    l_datas[i].otherprize = l_dv[i]["other_prize"].ToString();
                    l_datas[i].saletype = l_dv[i]["sale_type"].ToString();
                    l_datas[i].SupportAmt = Convert.ToDouble("0" + l_dv[i]["SupportAmt"].ToString());
                    l_datas[i].RecordDate = l_dv[i]["RecordDate"].ToString();
                    l_datas[i].OrderDate = l_dv[i]["OrderDate"].ToString();
                    //l_datas[i].sendman = l_dv[i]["sendman"].ToString();
                }
                return l_datas[0];
            }
            return null;
        }


        public void update特販審核Bycustid(特販審核 p_code)
        {
            string l_strSql = " update kdreward..customer set" ;
            l_strSql += " Status='" + p_code.Status + "'";
            l_strSql += " ,CarCenterMemo='" + p_code.CarCenterMemo + "'";
            l_strSql += " ,SupportAmt=" + p_code.SupportAmt + "";
            l_strSql += " ,RecordDate='" + p_code.RecordDate + "'";
            l_strSql += " ,sale_type='" + p_code.saletype + "'";
            l_strSql += " ,other_prize='" + p_code.otherprize + "'";
            l_strSql += " ,ChiefMemo='" + p_code.ChiefMemo + "'";
            l_strSql += " where custid =" + p_code.custid;

            ivContext.資料管理員.excuteSqlNonquery(l_strSql);
        }

        public void update部長審核Bycustid(特販審核 p_code)
        {
            string l_strSql = " update kdreward..customer set";
            l_strSql += " Status='3'";
            l_strSql += " ,CarCenterMemo='等待部長核准'";
            l_strSql += " where custid =" + p_code.custid;

            ivContext.資料管理員.excuteSqlNonquery(l_strSql);
        }
        public void insertInto特販(int p_cutid,string p_edituser)
        {
            string l_strSql = " insert into tbCarSaleUp values (";
            l_strSql += " '" + p_cutid + "'";
            l_strSql += " ,'" + p_edituser + "'";
            l_strSql += " ,'Y'";
            l_strSql += " )";

            ivContext.資料管理員.excuteSqlNonquery(l_strSql);
        }
        public void 取消特販審核Bycustid(string p_strID)
        {
            string l_strSql = " update kdreward..customer set";
            l_strSql += " Status='2'";
            l_strSql += " ,CarCenterMemo=null";
            l_strSql += " ,SupportAmt=null";
            l_strSql += " ,RecordDate=null";
            l_strSql += " ,sale_type=null";
            l_strSql += " ,other_prize=null";
            l_strSql += " where custid =" + p_strID;

            ivContext.資料管理員.excuteSqlNonquery(l_strSql);
        }


        public 特販審核 get客戶資料Bycustid(string p_strcustid)
        {

            string l_strSql = "SELECT c.*,car.CarTypeName,p.name as name1,b.Title FROM kdreward..customer c";
            l_strSql += " left join kddb..CarName car on car.CarCod = c.CarCod";
            l_strSql += " left join kddb..personel p on p.emp_id = c.EmpId";
            l_strSql += " left join kddb..Branch b on b.BranchId = c.BranchId";
            l_strSql += " where custid =" + p_strcustid;
            DataView l_dv = ivContext.資料管理員.getDataViewBySql(l_strSql);

            特販審核[] l_datas = new 特販審核[l_dv.Count];

            if (l_dv != null)
            {
                for (int i = 0; i < l_datas.Length; i++)
                {
                    l_datas[i] = create特販審核();
                    l_datas[i].custid = Convert.ToInt32(l_dv[i]["custid"].ToString());
                    l_datas[i].CustomerId = l_dv[i]["CustomerId"].ToString();
                    l_datas[i].Name = l_dv[i]["Name"].ToString();
                    l_datas[i].Birthday = l_dv[i]["Birthday"].ToString();
                    l_datas[i].FormalAddress = l_dv[i]["FormalAddress"].ToString();
                    l_datas[i].MailAddress = l_dv[i]["MailAddress"].ToString();
                    l_datas[i].InvoiceAddress = l_dv[i]["InvoiceAddress"].ToString();
                    l_datas[i].CarTypeName = l_dv[i]["CarTypeName"].ToString();


                    l_datas[i].BranchId = l_dv[i]["BranchId"].ToString();
                    l_datas[i].CarCod = l_dv[i]["CarCod"].ToString();
                    l_datas[i].YearType = l_dv[i]["YearType"].ToString();
                    l_datas[i].CarType = l_dv[i]["CarType"].ToString();
                    l_datas[i].SFX = l_dv[i]["SFX"].ToString();
                    l_datas[i].EmpId = l_dv[i]["EmpId"].ToString();
                    l_datas[i].Empname = l_dv[i]["name1"].ToString();
                    l_datas[i].Title = l_dv[i]["Title"].ToString();
                    l_datas[i].OrderDate = l_dv[i]["OrderDate"].ToString();
                }
                return l_datas[0];
            }
            return null;
        }
    }
}
