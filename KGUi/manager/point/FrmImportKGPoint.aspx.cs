using System;
using System.Collections;
using System.Configuration;
using System.Data;
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
using System.Collections.Generic;
using KGUi.tools;

namespace KGUi.manager.point
{
    public partial class FrmImportKGPoint : System.Web.UI.Page
    {
        private CUIContext iv_context;
        protected void Page_Load(object sender, EventArgs e)
        {
            iv_context = SealedGlobalPage.getContext(this);
            string l_strExcel路徑 = @"C:\Inetpub\wwwroot\KGUi\report\upload\KGPoint";
            Session.Add(SealedGlobalPage.SESSIONKEY_KGPOINT_EXCEL_LOCATION, l_strExcel路徑);

            if (!Page.IsPostBack)
            {
                取得資料夾內的檔名(iv_cbo檔案名稱, l_strExcel路徑);
            }
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;

            if (l_user == null)
            {
                Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
                Response.Redirect("../../FrmLogin.aspx");
            }
        }

        private void 取得資料夾內的檔名(DropDownList p_cbo, string p_path)
        {
            p_cbo.Items.Clear();

            DirectoryInfo l_dirinfo = new DirectoryInfo(p_path);
            FileInfo[] l_files = l_dirinfo.GetFiles();

            if (l_files.Length == 0)
            {
                p_cbo.Items.Add("無資料");
            }
            else
            {
                p_cbo.Items.Insert(0, "");
                for (int i = 0; i < l_files.Length; i++)
                {
                    p_cbo.Items.Add(l_files[i].Name);
                }
            }
        }
        protected void iv_btn上傳_Click(object sender, EventArgs e)
        {
            上傳檔案();
        }

        private void 上傳檔案()
        {
            string l_strFileName;
            //取出完整路徑C:\xxx
            string l_strFilePath = this.iv_filePath.PostedFile.FileName;

            //取得完整路徑的長度
            int l_intFileLength = l_strFilePath.Length;

            //去除C:\的路徑名稱
            int l_strFileNameIndex = l_strFilePath.LastIndexOf("\\");

            //擷取檔案名稱
            l_strFileName = l_strFilePath.Substring(l_strFileNameIndex + 1, l_intFileLength - l_strFileNameIndex - 1);

            //取得檔案的副檔名
            string l_str副檔名 = Path.GetExtension(l_strFileName).ToLower();

            string l_strPath = "../../report/upload/KGPoint/" + l_strFileName;
            //上傳至Sever
            if (!iv_filePath.HasFile)
            {
                ScriptManager.RegisterClientScriptBlock(iv_btn上傳, typeof(Button), "OK", "alert('請選擇上傳內容');", true);
                return;
            }
            //判別檔名
            if (!".xls".Equals(l_str副檔名))
            {
                ScriptManager.RegisterClientScriptBlock(iv_btn上傳, typeof(Button), "OK", "alert('檔案格式錯誤');", true);
                return;
            }
            //判別檔案大小
            if (iv_filePath.PostedFile.ContentLength > 11000000)
            {
                ScriptManager.RegisterClientScriptBlock(iv_btn上傳, typeof(Button), "OK", "alert('檔案格式過大');", true);
                return;
            }

            iv_filePath.PostedFile.SaveAs(Server.MapPath(l_strPath));
            ScriptManager.RegisterClientScriptBlock(iv_btn上傳, typeof(Button), "OK", "alert('檔案上傳成功');", true);

            初始化();
        }
        private void 初始化()
        {
            取得資料夾內的檔名(iv_cbo檔案名稱, (string)Session[SealedGlobalPage.SESSIONKEY_KGPOINT_EXCEL_LOCATION]);
        }


        protected void iv_btn檢視_Click(object sender, EventArgs e)
        {
            string l_str檔案名稱 = iv_cbo檔案名稱.SelectedValue;
            if (!"".Equals(l_str檔案名稱) && !"無資料".Equals(l_str檔案名稱))
            {
                try
                {
                    string l_str檔案完整路徑 = (string)Session[SealedGlobalPage.SESSIONKEY_KGPOINT_EXCEL_LOCATION] + "\\" + l_str檔案名稱;

                    List<List<string>> l_lists = CTools.get高輊業代點數(l_str檔案完整路徑, "Sheet1");
                    display(l_lists);
                    Session.Add(SealedGlobalPage.SESSIONKEY_KGPOINT_IMPORT_EXCEL, l_lists);
                    iv_btnInsert.Visible = true;
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(iv_btn檢視, typeof(Button), "OK", "alert('" + ex.Message + "');", true);
                }
            }
            else
            {
                string l_str = "alert('請選擇要匯入的檔案');";
                ScriptManager.RegisterClientScriptBlock(iv_btn檢視, typeof(Button), "OK", l_str, true);
            }
        }

        private void display(List<List<string>> p_lists)
        {
            string[] l_str = { "業代員編", "業代姓名", "匯入點數" };
            DataTable l_table = CTools.getFilledColumnsDataTable(l_str);
            for (int i = 0; i < p_lists.Count; i++)
            {
                DataRow l_row = l_table.NewRow();

                l_row["業代員編"] = p_lists[i][0];//0
                l_row["業代姓名"] = p_lists[i][1];//1
                l_row["匯入點數"] = p_lists[i][2];//2

                l_table.Rows.Add(l_row);
            }

            GridView1.DataSource = l_table;
            GridView1.DataBind();
        }

        protected void iv_btnInsert_Click(object sender, EventArgs e)
        {
            iv_btnInsert.Visible = false;
            匯入資料();
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "OK", "alert('匯入成功');", true);
        }
        private void 匯入資料()
        {
            List<List<string>> l_lists = (List<List<string>>)Session[SealedGlobalPage.SESSIONKEY_KGPOINT_IMPORT_EXCEL];

            CKGPointFactory l_factory點數 = iv_context.CFactoryManager.CKGPointFactory;

            Hashtable l_ht = set匯入點數資訊並加總(l_lists);

            l_factory點數.insert點數與記錄ByHashtable(l_ht);
        }

        private Hashtable set匯入點數資訊並加總(List<List<string>> p_lists)
        {
            CKGPointDetailFactory l_factory紀錄 = iv_context.CFactoryManager.CKGPointDetailFactory;
            Hashtable l_ht = new Hashtable();
            List<CKGPointDetail> l_is = null;
            for (int i = 0; i < p_lists.Count; i++)
            {
                string l_str業代員編 = p_lists[i][0];

                CKGPointDetail l_code紀錄 = l_factory紀錄.createCKGPointDetail();
                l_code紀錄.f_Smid業代員編 = l_str業代員編;
                l_code紀錄.f_Name業代姓名 = p_lists[i][1];
                l_code紀錄.f_ImportPoint匯入點數 = Convert.ToInt32(p_lists[i][2]);
                l_code紀錄.f_ImportDate匯入日期 = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
                l_code紀錄.f_ImportSmid匯入人員員編 = "12345";//"F9446"; //
                l_code紀錄.f_ImportName匯入人員姓名 = "test";//"黃敏惠";//
                l_code紀錄.f_ImportType匯入方式 = "獎金轉入";

                if (l_ht[l_str業代員編] == null)
                {
                    l_is = new List<CKGPointDetail>();
                    l_is.Add(l_code紀錄);
                    l_ht.Add(l_str業代員編, l_is);
                }
                else
                {
                    l_is.Add(l_code紀錄);
                }
            }
            return l_ht;
        }

    }
}
