using System;
using System.Data;
using System.Configuration;
using System.Collections;
using tw.com.yj.CommonLib;
using System.IO;
using System.Text;
using System.Runtime.Remoting.Channels;
using System.Text.RegularExpressions;

namespace tw.com.kg.lib
{
    /// <summary>
    /// CUIContext 的摘要描述
    /// </summary>
    public class CUIContext : YJCommonContext
    {

        public string DBType = "Sql";

        public CUIContext()
        {

            string l_conn = @"server=KDSQL;Connection Lifetime=100;Connection Timeout=600;uid=96002;pwd=s0953039382;dataBase=KG";
            //string l_conn = @"server=172.26.100.8;uid=sa;pwd=hp1020.;dataBase=KG";

            //string l_conn = @"server=172.26.100.8;uid=sa;pwd=hp1020.;dataBase=UOF";
            if (l_conn.IndexOf("OleDb") >= 0)
                DBType = "Ole";
            try
            {
                this.資料管理員 = new YJDbManager(l_conn);
            }
            catch
            {
                throw new Exception("資料庫連接錯誤，請確認路徑：App_Data\\Data 內是否有OrderSystemDB.mdb");
            }
        }

        public CUIContext(string p_connectstring)
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
            try
            {
                this.資料管理員 = new YJDbManager(p_connectstring);
            }
            catch
            {
                throw new Exception("資料庫連接錯誤，請確認連線字串：" + p_connectstring);
            }
        }

        private YJDbManager iv_manager;

        public override YJDbManager 資料管理員
        {
            get
            {
                return iv_manager;
            }
            set
            {
                iv_manager = value;
            }
        }
        private CFactoryManager iv_CFactoryManager = null;
        public CFactoryManager CFactoryManager
        {
            get
            {
                if (iv_CFactoryManager == null)
                    iv_CFactoryManager = new CFactoryManager(this);
                return iv_CFactoryManager;
            }
        }

        public static string TypeName
        {
            get { return "CUIContext"; }
        }

        //public void 螢光棒(GridView GridView1, GridViewRowEventArgs e)
        //{
        //    //--螢光棒---
        //    if (e.Row.RowIndex != -1)
        //    {
        //        Color bb;
        //        Color ff;

        //        if (e.Row.RowIndex % 2 == 0)
        //        {
        //            bb = GridView1.RowStyle.BackColor;
        //            ff = GridView1.RowStyle.ForeColor;
        //        }
        //        else
        //        {
        //            bb = GridView1.AlternatingRowStyle.BackColor;
        //            ff = GridView1.AlternatingRowStyle.ForeColor;
        //        }
        //        string back = "rgb(" + 0 + "," + 255 + "," + 255+ ")";
        //        //string back = "rgb(" + bb.R + "," + bb.G + "," + bb.B + ")";
        //        string fore = "rgb(" + 255 + "," + 255 + "," + 255 + ")";

        //        //e.Row.Attributes["onmouseover"] = "this.style.color='" + fore + "';this.style.backgroundColor='" + back + "';";
        //        e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='" + back + "';";
        //        e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='" + fore + "';";
        //        //e.Row.Attributes["onmouseout"] = "this.style.color='" + fore + "';this.style.backgroundColor='" + back + "';";
        //    }

        //}
    }
}