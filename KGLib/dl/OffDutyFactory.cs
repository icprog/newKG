using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using tw.com.yj.CommonLib;

namespace KGLib.dl
{
    public class OffDutyFactory : YJCCommonFactory
    {

        public OffDutyFactory(YJCommonContext p_context)
        {
            setContext(p_context);
        }

        public void AddOffDuty(string pEmp, string pName)
        {
            try
            {
                StringBuilder lsb = new StringBuilder();

                lsb.Append(" INSERT INTO [KG].[dbo].[TB_OffDutyPeople] Values('" + pEmp + "','" + pName + "') ");

                ivContext.資料管理員.excuteSqlNonquery(lsb.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetData(string pEmp)
        {

            StringBuilder lsb = new StringBuilder();

            lsb.Append(" SELECT * FROM [KG].[dbo].[TB_OffDutyPeople] ");
            if (!String.IsNullOrEmpty(pEmp))
            {
                lsb.Append(" WHERE EMPNO = '" + pEmp + "' ");
            }

            DataView dv = ivContext.資料管理員.getDataViewBySql(lsb.ToString());

            return dv.ToTable();
        }

        public void RemoveData(string pEmp)
        {
            StringBuilder lsb = new StringBuilder();

            lsb.Append(" DELETE FROM [KG].[dbo].[TB_OffDutyPeople] WHERE EMPNO = '" + pEmp + "' ");

            ivContext.資料管理員.excuteSqlNonquery(lsb.ToString());
        }
    }
}
