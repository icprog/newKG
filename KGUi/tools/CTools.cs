using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using tw.com.kg.lib;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Data.OleDb;

namespace KGUi.tools
{
    public class CTools
    {

        public static DataTable getFilledColumnsDataTable(string[] p_strColumns)
        {

            DataTable l_table = new DataTable();//  產生欄位標題
            for (int i = 0; i < p_strColumns.Length; i++)
            {
                l_table.Columns.Add(new DataColumn(p_strColumns[i], typeof(string)));
            }
            return l_table;
        }

        public static string get工單號碼(string p_branchid)
        {
            //string l_workid = Guid.NewGuid().ToString().Substring(0, 7);
            string l_str亂數碼 = DateTime.Now.Millisecond.ToString() + DateTime.Now.Minute.ToString();
            if (l_str亂數碼.Length < 3)
            {
                l_str亂數碼 += "0";
            }
            //string l_str日期 =(Convert.ToInt32( DateTime.Today.ToString("yyyyMMdd") ) - 1911).ToString();
            string l_str日期 = DateTime.Today.ToString("yyyyMMdd");
            //if (l_str日期.Length >= 3)
            //{
            //    l_str日期 = l_str日期.Substring(0, 2);
            //}

            string l_workid = l_str日期 + l_str亂數碼;
            return "F" + p_branchid + l_workid;
        }
        public static string get訂單號碼(string p_branchid)
        {
            //string l_workid = Guid.NewGuid().ToString().Substring(0, 7);
            string l_str亂數碼 = DateTime.Now.Millisecond.ToString();
            if (l_str亂數碼.Length < 3)
            {
                l_str亂數碼 += "0";
            }
            //string l_str日期 = (Convert.ToInt32(DateTime.Today.ToString("yyyyMMdd")) - 1911).ToString();
            string l_str日期 = DateTime.Today.ToString("yyyyMMdd");

            //if (l_str日期.Length >= 3)
            //{
            //    l_str日期 = l_str日期.Substring(0, 2);
            //}

            string l_workid = l_str日期 + l_str亂數碼;
            return "E" + p_branchid + l_workid;
        }

        public static void get洗車種類(DropDownList p_ddl, CUIContext p_context, System.Web.UI.Page p_page,string p_strType)
        {
            CWorkType[] l_worktypes = p_context.CFactoryManager.CWorkTypeFactory.getAllWorkType(p_strType);
           
           //if (p_ddl.Items.Count == 0)
           //{
            p_ddl.Items.Clear();
               p_ddl.Items.Add(new ListItem("請選擇", ""));
               for (int i = 0; i < l_worktypes.Length; i++)
               {
                   p_ddl.Items.Add(new ListItem(l_worktypes[i].f_typeid洗車種類代碼 + "_" + l_worktypes[i].f_typename洗車種類名稱, l_worktypes[i].f_typeid洗車種類代碼));
               }
           //}
        }

        public static void get保險公司(RadioButtonList p_rdo, CUIContext p_context)
        {
            CInsurance[] l_Insurances = p_context.CFactoryManager.CInsuranceFactory.getAll保險公司();

            if (p_rdo.Items.Count == 0)
            {
                p_rdo.Items.Add(new ListItem("無", ""));
                for (int i = 0; i < l_Insurances.Length; i++)
                {
                    p_rdo.Items.Add(new ListItem(l_Insurances[i].f_f_name名稱, l_Insurances[i].f_id代碼));
                }
            }
        }
        public static void get保險公司介紹(RadioButtonList p_rdo, CUIContext p_context)
        {
            CInsurance[] l_Insurances = p_context.CFactoryManager.CInsuranceFactory.getAll保險公司介紹();

            if (p_rdo.Items.Count == 0)
            {
                //p_rdo.Items.Add(new ListItem("無", ""));
                for (int i = 0; i < l_Insurances.Length; i++)
                {
                    p_rdo.Items.Add(new ListItem(l_Insurances[i].f_f_name名稱, l_Insurances[i].f_id代碼));
                }
            }
        }

        public static void get所別(DropDownList p_ddl, CUIContext p_context)
        {
            CUser[] l_User = p_context.CFactoryManager.CUserFactory.getAll所別();

            if (p_ddl.Items.Count == 0)
            {
                p_ddl.Items.Add(new ListItem("請選擇", ""));
                for (int i = 0; i < l_User.Length; i++)
                {
                    p_ddl.Items.Add(new ListItem(l_User[i].f_branchid所別, l_User[i].f_branchid所別));
                }
            }
        }
        public static void get使用者等級(DropDownList p_ddl)
        {
            p_ddl.Items.Add(new ListItem("請選擇", ""));
            p_ddl.Items.Add(new ListItem("洗車人員", "0"));
            p_ddl.Items.Add(new ListItem("開單人員", "1"));
            p_ddl.Items.Add(new ListItem("督導人員", "2"));
            p_ddl.Items.Add(new ListItem("高輊管理者", "3"));
        }
        public static string get使用者等級中文顯示(int p_等級)
        {
            switch (p_等級)
            {
                case 0: return "洗車人員";
                case 1: return "開單人員"; 
                case 2: return "督導人員"; 
                case 3: return "高輊管理者"; 
                default: return "";
            }
        }

        public enum Items移動格式 { 複製, 搬移 };
        public enum Item移動項目 { 全部, 選取 };
        public static void ItemsChange(ListItemCollection p_來源Items, ListItemCollection p_目地Items, Items移動格式 p_格式, Item移動項目 p_項目)
        {
            for (int i = 0; i < p_來源Items.Count; i++)
            {
                ListItem l_item = p_來源Items[i];
                if (p_項目.Equals(Item移動項目.全部) || (p_項目.Equals(Item移動項目.選取) && l_item.Selected))
                {
                    l_item.Selected = false;
                    if (p_格式.Equals(Items移動格式.複製))
                        l_item = new ListItem(l_item.Text, l_item.Value);
                    else if (p_格式.Equals(Items移動格式.搬移))
                    {
                        p_來源Items.Remove(l_item);
                        i--;
                    }
                    p_目地Items.Add(l_item);
                }
            }
        }

        public static string get轉換據點中英文(string p_strBranchid)
        {

            switch (p_strBranchid)
            {
                case "F03": return "岡山";
                case "F03S": return "岡山廠";
                case "F04": return "屏東";
                case "F04S": return "屏東廠";
                case "F07": return "北高";
                case "F07S": return "北高廠";
                case "F08": return "旗山";
                case "F08S": return "旗山廠";
                case "F09": return "潮州";
                case "F09S": return "潮州廠";
                case "F10": return "小港";
                case "F10S": return "小港廠";
                case "F11": return "九如";
                case "F11S": return "九如廠";
                case "F12": return "鳳山";
                case "F12S": return "鳳山廠";
                case "F13": return "湖內";
                case "F13S": return "湖內廠";
                case "F14": return "北屏";
                case "F14S": return "北屏廠";
                case "F15": return "青年";
                case "F15S": return "青年廠";
                case "F16": return "楠梓";
                case "F16S": return "楠梓廠";
                case "F17": return "瑞豐";
                case "F17S": return "瑞豐廠";
                case "F19": return "麟洛";
                case "F19S": return "麟洛廠";
                case "F18": return "右昌";
                case "F18S": return "右昌廠";
                case "F20": return "東港";
                case "F20S": return "東港廠";
                case "F21": return "里港";
                case "F21S": return "里港廠";
                case "F22": return "鳳林";
                case "F22S": return "鳳林廠";
                case "F24": return "恆春";
                case "F24S": return "恆春廠";
                case "F27": return "三多";
                case "F27S": return "三多廠";
                case "F51": return "中華";
                case "F52": return "民族";
                case "F53": return "建國";
                case "F71": return "明誠";
                case "F72": return "澄清";
                case "KG": return "高輊";
                case "F11HZ": return "九如(HZ)";
                case "F07HZ": return "北高(HZ)";
                default: return "";
            }
        }

        /// <summary>
        ///  (Yu 20090515) 加入高輊小百貨產品檔所有的產品類別
        /// </summary>
        /// <param name="p_cbo"></param>
        /// <returns></returns>
        public static void 加入高輊小百貨產品類別(DropDownList p_cbo,CUIContext  p_context)
        {
            CKGPart[] l_codes = p_context.CFactoryManager.CKGPartFactory.getCKGPart所有類別();

            p_cbo.Items.Clear();
            p_cbo.Items.Insert(0, "");
            if (l_codes != null)
            {
                for (int i = 0; i < l_codes.Length; i++)
                {
                    p_cbo.Items.Add(new ListItem(l_codes[i].f_TypeID類別編號 + "  " + l_codes[i].f_TypeName類別名稱, l_codes[i].f_TypeID類別編號));
                }
            }
        }
        /// <summary>
        /// 將傳入的DataView參數Persistant到指定的Folder中
        /// </summary>
        /// <param name="p_dataView">要輸出的資料</param>
        /// <param name="p_strPath">要輸出Excel的路徑</param>
        /// <param name="p_strHeader">頁首(報表標題)</param>
        public static void toExcelByDataView(DataView p_dataView, string p_strPath, string p_strHeader)
        {
            string l_strContent = "";
            DataTable l_table = p_dataView.Table;
            // fill columns from dataview.
            for (int i = 0; i < l_table.Columns.Count; i++)
            {
                l_strContent += l_table.Columns[i].ToString() + "\t";
            }
            l_strContent = l_strContent.Substring(0, l_strContent.Length - 1) + "\n";

            // fill rows from dataview
            for (int i = 0; i < l_table.Rows.Count; i++)
            {
                for (int j = 0; j < l_table.Columns.Count; j++)
                {
                    string l_strRow = l_table.Rows[i][j].ToString();
                    if (isNumberic(l_strRow) && l_strRow.Length > 8)
                    {
                        l_strContent += "ˉ";
                    }

                    l_strContent += l_strRow + "\t";
                }
                l_strContent = l_strContent.Substring(0, l_strContent.Length - 1) + "\n";
            }
            if (!"".Equals(p_strHeader))
            {

                l_strContent = p_strHeader + "\n" + l_strContent;
            }
            StreamWriter l_writer = new StreamWriter(p_strPath, false, Encoding.Default);
            l_writer.Write(l_strContent);
            l_writer.Close();
        }

        private static bool isNumberic(string p_strValue)
        {
            try
            {
                double l_dbl = Convert.ToDouble(p_strValue);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<List<string>> get高輊業代點數(string p_filepath, string p_strTableName)
        {
            List<List<string>> l_lists = new List<List<string>>();

            DataTable l_dt = getExcelFileToDataTable(p_filepath, p_strTableName);

            for (int i = 1; i < l_dt.Rows.Count; i++)
            {
                List<string> l_list = new List<string>();
                if ("".Equals(l_dt.Rows[i]["F1"].ToString().Trim()) || "".Equals(l_dt.Rows[i]["F2"].ToString().Trim()) || "".Equals(l_dt.Rows[i]["F3"].ToString().Trim()))
                {
                    throw new Exception("請確認Excel表格內 [業代員編] 或 [業代姓名] 或 [點數] 欄位否有含空白");
                }
                l_list.Add(l_dt.Rows[i]["F1"].ToString());//業代員編
                l_list.Add(l_dt.Rows[i]["F2"].ToString());//業代姓名
                l_list.Add(l_dt.Rows[i]["F3"].ToString());//點數
                l_lists.Add(l_list);
            }

            return l_lists;
        }

        public static DataTable getExcelFileToDataTable(string p_完整檔案路徑, string p_strTableName)
        {
            //預設讀取時就將第一列當作DataSet的DataTable ，HDR=NO 會使用 Fnn (nn = 欄位索引，如 F1, F2, F3, ...) 當做欄位名稱

            string strConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
            strConn += p_完整檔案路徑 + @";Extended Properties=""Excel 8.0;HDR=NO;IMEX=1"";";

            using (OleDbConnection l_oleDbConn = new OleDbConnection(strConn))
            {
                l_oleDbConn.Open();
                DataSet l_ds = new DataSet();
                DataTable l_dt = new DataTable();

                OleDbCommand l_strCmd = new OleDbCommand("SELECT * FROM [" + p_strTableName + "$]", l_oleDbConn);

                using (OleDbDataReader l_dbDataReader = l_strCmd.ExecuteReader())
                {
                    l_ds.Load(l_dbDataReader, LoadOption.OverwriteChanges, new string[] { p_strTableName });
                    l_dt = l_ds.Tables[p_strTableName];
                }

                l_oleDbConn.Close();

                return l_dt;
            }
        }
    }
}
