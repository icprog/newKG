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
using KGUi.tools;

namespace KGUi.manager
{
    public partial class FrmWashTotalAmount : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);

            if (!this.IsPostBack)
            {
                CTools.get所別(_ddl據點別, _context);
            }
            CUser l_user = Session[SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA] as CUser;

            if (l_user == null)
            {
                Session.Remove(SealedGlobalPage.SESSIONKEY_LOGIN_USER_DATA);
                Response.Redirect("../FrmLogin.aspx");
            }
        }

        private void display(C台數統計[] p_C台數統計)
        {
            if (p_C台數統計.Length <=0)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('無符合資料!請重新確認');", true);

                _gvWork.DataSource = null;
                _gvWork.DataBind();
                return;
            }
            _gvWork.DataSource = getDataTableBydisplay(p_C台數統計);
            _gvWork.DataBind();
        }

        private DataTable getDataTableBydisplay(C台數統計[] p_C台數統計)
        {
            string[] l_Msg = new string[] { "所別", "精緻台數","精緻實績", "磁土台數","磁土實績", 
                "小美容台數","小美容實績","覆膜台數","覆膜實績","超值台數","超值實績", "亮新I台數","亮新I實績", "亮新II台數", "亮新II實績", 
                "內裝台數","內裝實績", "引擎台數","引擎實績", "玻璃台數","玻璃實績","CPO1台數","CPO1實績","CPO2台數","CPO2實績","總台數","小計"};
            DataTable l_dt = CTools.getFilledColumnsDataTable(l_Msg);

            int l_int精緻 = 0, l_int磁土 = 0, l_int超值 = 0, l_int小美容 = 0, l_int覆膜 = 0, l_int亮新I = 0, l_int亮新II = 0,
                l_int內裝 = 0, l_int引擎 = 0, l_int小計 = 0, l_total = 0, l_int高運 = 0, l_intCPO2 = 0, l_int玻璃 = 0;

            int l_int精緻數 = 0, l_int磁土數 = 0, l_int超值數 = 0, l_int小美容數 = 0, l_int覆膜數 = 0, l_int亮新I數 = 0, l_int亮新II數 = 0,
                l_int內裝數 = 0, l_int引擎數 = 0, l_int小計數 = 0, l_total數 = 0, l_int高運數 = 0, l_intCPO2數 = 0, l_int玻璃數 = 0;

            for (int i = 0; i < p_C台數統計.Length; i++)
            {
                DataRow l_row = l_dt.NewRow();

                l_row["所別"] = CTools.get轉換據點中英文(p_C台數統計[i].所別);

                
                l_row["精緻台數"] = p_C台數統計[i].R_精緻洗車;
                l_row["精緻實績"] = p_C台數統計[i].R_精緻洗車money;
                l_int精緻數 += p_C台數統計[i].R_精緻洗車;
                l_int精緻 += p_C台數統計[i].R_精緻洗車money;
                l_row["磁土台數"] = p_C台數統計[i].M_磁土美容;
                l_row["磁土實績"] = p_C台數統計[i].M_磁土美容money;
                l_int磁土數 += p_C台數統計[i].M_磁土美容;
                l_int磁土 += p_C台數統計[i].M_磁土美容money;
                l_row["超值台數"] = p_C台數統計[i].S_超值美容;
                l_row["超值實績"] = p_C台數統計[i].S_超值美容money;
                l_int超值數 += p_C台數統計[i].S_超值美容;
                l_int超值 += p_C台數統計[i].S_超值美容money;

                l_row["小美容台數"] = p_C台數統計[i].A_小美容;
                l_row["小美容實績"] = p_C台數統計[i].A_小美容money;
                l_int小美容數 += p_C台數統計[i].A_小美容;
                l_int小美容 += p_C台數統計[i].A_小美容money;


                l_row["覆膜台數"] = p_C台數統計[i].B_覆膜;
                l_row["覆膜實績"] = p_C台數統計[i].B_覆膜money;
                l_int覆膜數 += p_C台數統計[i].B_覆膜;
                l_int覆膜 += p_C台數統計[i].B_覆膜money;

                l_row["亮新I台數"] = p_C台數統計[i].L_亮新I;
                l_row["亮新I實績"] = p_C台數統計[i].L_亮新Imoney;
                l_int亮新I數 += p_C台數統計[i].L_亮新I;
                l_int亮新I += p_C台數統計[i].L_亮新Imoney;
                l_row["亮新II台數"] = p_C台數統計[i].N_亮新II;
                l_row["亮新II實績"] = p_C台數統計[i].N_亮新IImoney;
                l_int亮新II數 += p_C台數統計[i].N_亮新II;
                l_int亮新II += p_C台數統計[i].N_亮新IImoney;
                l_row["內裝台數"] = p_C台數統計[i].I_內裝美容;
                l_row["內裝實績"] = p_C台數統計[i].I_內裝美容money;
                l_int內裝數 += p_C台數統計[i].I_內裝美容;
                l_int內裝 += p_C台數統計[i].I_內裝美容money;
                l_row["引擎台數"] = p_C台數統計[i].E_引擎清潔;
                l_row["引擎實績"] = p_C台數統計[i].E_引擎清潔money;
                l_int引擎數 += p_C台數統計[i].E_引擎清潔;
                l_int引擎 += p_C台數統計[i].E_引擎清潔money;

                l_row["玻璃台數"] = p_C台數統計[i].G_玻璃油膜;
                l_row["玻璃實績"] = p_C台數統計[i].G_玻璃油膜money;
                l_int玻璃數 += p_C台數統計[i].G_玻璃油膜;
                l_int玻璃 += p_C台數統計[i].G_玻璃油膜money;

                l_row["CPO1台數"] = p_C台數統計[i].D00_高運;
                l_row["CPO1實績"] = p_C台數統計[i].D00_高運money;

                //多區分中古車整備 2011-11-23 way
                l_row["CPO2台數"] = p_C台數統計[i].D00_CPO2;
                l_row["CPO2實績"] = p_C台數統計[i].D00_CPO2money;
                l_int高運數 += p_C台數統計[i].D00_高運;
                l_int高運 += p_C台數統計[i].D00_高運money;


                l_int小計數 = (p_C台數統計[i].R_精緻洗車 + p_C台數統計[i].M_磁土美容 + p_C台數統計[i].S_超值美容 +
                    p_C台數統計[i].L_亮新I + p_C台數統計[i].N_亮新II + p_C台數統計[i].I_內裝美容 +
                    p_C台數統計[i].E_引擎清潔 + p_C台數統計[i].D00_高運 + p_C台數統計[i].G_玻璃油膜 + p_C台數統計[i].A_小美容 + p_C台數統計[i].B_覆膜);

                l_int小計 = (p_C台數統計[i].R_精緻洗車money + p_C台數統計[i].M_磁土美容money + p_C台數統計[i].S_超值美容money +
                    p_C台數統計[i].L_亮新Imoney + p_C台數統計[i].N_亮新IImoney + p_C台數統計[i].I_內裝美容money + p_C台數統計[i].E_引擎清潔money +
                    p_C台數統計[i].D00_高運money + p_C台數統計[i].G_玻璃油膜money + p_C台數統計[i].A_小美容money + p_C台數統計[i].B_覆膜money);

                l_row["總台數"] = l_int小計數.ToString();

                l_row["小計"] = l_int小計.ToString();

                l_total += l_int小計;
                l_total數 += l_int小計數;
                l_dt.Rows.Add(l_row);
            }

            //最後計算總計
            DataRow l_row總計 = l_dt.NewRow();
            l_row總計["所別"] = "總計:";

            l_row總計["精緻台數"] = l_int精緻數.ToString();
            l_row總計["精緻實績"] = l_int精緻.ToString();

            l_row總計["磁土台數"] = l_int磁土數.ToString();
            l_row總計["磁土實績"] = l_int磁土.ToString();

            l_row總計["超值台數"] = l_int超值數.ToString();
            l_row總計["超值實績"] = l_int超值.ToString();


            l_row總計["小美容台數"] = l_int小美容數.ToString();
            l_row總計["小美容實績"] = l_int小美容.ToString();

            l_row總計["覆膜台數"] = l_int覆膜數.ToString();
            l_row總計["覆膜實績"] = l_int覆膜.ToString();

            l_row總計["亮新I台數"] = l_int亮新I數.ToString();
            l_row總計["亮新I實績"] = l_int亮新I.ToString();

            l_row總計["亮新II台數"] = l_int亮新II數.ToString();
            l_row總計["亮新II實績"] = l_int亮新II.ToString();

            l_row總計["內裝台數"] = l_int內裝數.ToString();
            l_row總計["內裝實績"] = l_int內裝.ToString();

            l_row總計["引擎台數"] = l_int引擎數.ToString();
            l_row總計["引擎實績"] = l_int引擎.ToString();

            l_row總計["玻璃台數"] = l_int玻璃數.ToString();
            l_row總計["玻璃實績"] = l_int玻璃.ToString();


            l_row總計["CPO1台數"] = l_int高運數.ToString();
            l_row總計["CPO1實績"] = l_int高運.ToString();


            //多區分中古車整備 2011-11-23 way
            l_row總計["CPO2台數"] = l_intCPO2數.ToString();
            l_row總計["CPO2實績"] = l_intCPO2.ToString();

            l_row總計["總台數"] = l_total數.ToString();
            l_row總計["小計"] = l_total.ToString();
            l_dt.Rows.Add(l_row總計);

            Session.Add("FrmWashTotalAmount", l_dt);
            return l_dt;
        }
        protected void _btn查詢_Click(object sender, EventArgs e)
        {
            string l_strBDate = _txtBDate.Text.Trim();
            string l_strEDate = _txtEDate.Text.Trim();
            string l_strBranchid = _ddl據點別.SelectedValue;
            string l_str所廠 = _rdo據點別.SelectedValue;

            C台數統計[] l_C台數統計 = _context.CFactoryManager.C台數統計Factory.get台數統計(l_strBDate, l_strEDate, l_strBranchid, l_str所廠);
            display(l_C台數統計);
        }

        protected void _btn匯出_Click(object sender, EventArgs e)
        {
            DataTable l_table = Session["FrmWashTotalAmount"] as DataTable;
            if (l_table == null)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "Error", "alert('無匯出資料!請先執行查詢');", true);
                return;

            }
            string l_strPath = "../report/" + DateTime.Today.ToString("yyyyMMdd") + "FrmWashTotalAmount.xls";
            CTools.toExcelByDataView(new DataView(l_table), Server.MapPath(l_strPath), DateTime.Today.ToString("yyyyMMdd") + "台數統計");
            Response.Redirect(l_strPath);
        }
    }
}
