using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web;
using System.Web.UI;

namespace tw.com.kg.lib
{
    public class SealedGlobalPage
    {
        public static readonly string SESSIONKEY_LOGIN_USER_DATA = "SESSIONKEY_LOGIN_USER_DATA";
        public static readonly string SESSIONKEY_LOGIN_USER_DATA_CARSALE = "SESSIONKEY_LOGIN_USER_DATA_CARSALE";
        public static readonly string SESSIONKEY_WORKTYPE = "SESSIONKEY_WORKTYPE";
        public static readonly string SESSIONKEY_DATAOPERATIONLISTENER = "SESSIONKEY_DATAOPERATIONLISTENER";

        public static readonly string SESSIONKEY_KGPOINT_EXCEL_LOCATION = "SESSIONKEY_KGPOINT_EXCEL_LOCATION";
        public static readonly string SESSIONKEY_KGPOINT_IMPORT_EXCEL = "SESSIONKEY_KGPOINT_IMPORT_EXCEL";


        public static readonly string SESSIONKEY_WORK_SERACH = "SESSIONKEY_WORK_SERACH";
        public static readonly string SESSIONKEY_PARTS = "SESSIONKEY_PARTS";


        public static readonly string SESSIONKEY_INMONEY_WORKID = "SESSIONKEY_INMONEY_WORKID";

        public static readonly string VIEWSTATE_INMONEY = "VIEWSTATE_INMONEY";

        public static readonly string SESSIONKEY_KGPARTORDER_TEMPTABLE = "SESSIONKEY_KGPARTORDER_TEMPTABLE";

        public static readonly string SESSIONKEY_KGPARTORDERDETAIL_HASHTABLE = "SESSIONKEY_KGPARTORDERDETAIL_HASHTABLE";
        #region Context相關
        /// <summary>
        /// getContext
        /// </summary>
        /// <param name="p_control">Web Control</param>
        /// <returns>CUIContext</returns>
        public static CUIContext getContext(System.Web.UI.UserControl p_control)
        {
            return getContext(p_control.Page);
        }
        /// <summary>
        /// getContext
        /// </summary>
        /// <param name="p_page"> Web Page</param>
        /// <returns>CUIContext</returns>
        public static CUIContext getContext(System.Web.UI.Page p_page)
        {
            CUIContext l_context = (CUIContext)p_page.Session[CUIContext.TypeName];
            if (l_context == null && p_page.Parent != null)
            {
                l_context = (CUIContext)((Page)p_page.Parent).Session[CUIContext.TypeName];
            }
            if (l_context == null)
            {
                l_context = new CUIContext();
                setContext(p_page, l_context);
            }
            p_page.Session.Add(SealedGlobalPage.SESSIONKEY_DATAOPERATIONLISTENER, p_page);
            return l_context;
        }
        /// <summary>
        /// setContext 把Context放置Session & Application
        /// </summary>
        /// <param name="p_control"> Web Control</param>
        /// <param name="p_context"> CUIContext</param>
        public static void setContext(System.Web.UI.UserControl p_control, CUIContext p_context)
        {
            setContext(p_control.Page, p_context);
        }
        /// <summary>
        /// setContext 把Context放置Session & Application
        /// </summary>
        /// <param name="p_page">Web Page</param>
        /// <param name="p_context">CUIContext</param>
        public static void setContext(System.Web.UI.Page p_page, CUIContext p_context)
        {
            p_page.Session.Add(CUIContext.TypeName, p_context);
        }
        #endregion

    }
}
