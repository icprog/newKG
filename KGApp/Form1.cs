using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using tw.com.kg.lib;
using KGUi.tools;
using System.Collections;
using System.Net.Mail;
using System.Net;

namespace KGApp
{
    public partial class Form1 : Form
    {
        private CUIContext _context;
        private CKGPartOrder[] _CKGPartOrder { get; set; }
        public Form1()
        {
            InitializeComponent();
            _context = new CUIContext();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //get請購清單();
        }

        private void get請購清單()
        {
            CKGPartOrderFactory l_factory = _context.CFactoryManager.CKGPartOrderFactory;
            _CKGPartOrder = l_factory.getGroupBy未訂購所別筆數("", "");
            display請購單(_CKGPartOrder);
        }

        private void display請購單(CKGPartOrder[] p_codes)
        {
            dataGridView1.DataSource = getDataTableBydisplay請購單(p_codes);
        }

        private DataTable getDataTableBydisplay請購單(CKGPartOrder[] p_codes)
        {
            string[] l_str = { "請購所別", "對象廠商", "請購筆數" };


            DataTable l_table = CTools.getFilledColumnsDataTable(l_str);

            if (p_codes == null)
            {
                return l_table;
            }

            for (int i = 0; i < p_codes.Length; i++)
            {
                DataRow l_row = l_table.NewRow();

                l_row["請購所別"] = p_codes[i].f_SalesBranch業代單位;//1
                l_row["對象廠商"] = p_codes[i].f_Vendor請購廠商;//2
                l_row["請購筆數"] = p_codes[i].NonSendCount未發送的請購筆數;//3

                l_table.Rows.Add(l_row);
            }

            return l_table;
        }

        private void 自動發信()
        {
            get請購清單();

            if (_CKGPartOrder == null)
            {
                return;
            }
            if (_CKGPartOrder.Length <= 0)
            {
                return;
            }
            for (int i = 0; i < _CKGPartOrder.Length; i++)
            {
                string l_str請購所別 = dataGridView1.Rows[i].Cells["請購所別"].Value.ToString();
                string l_str對象廠商 = dataGridView1.Rows[i].Cells["對象廠商"].Value.ToString();

                CKGPartOrderFactory l_factory = _context.CFactoryManager.CKGPartOrderFactory;
                CKGPartOrder[] l_codes = l_factory.get所別未定購的請購明細(l_str對象廠商, l_str請購所別);

                ArrayList l_al = new ArrayList();
                for (int j = 0; j < l_codes.Length; j++)
                {
                    //CUser l_user = _context.CFactoryManager.CUserFactory.get高都員工檔(l_codes[j].f_SalesSmid業代員編);
                    //l_codes[j].f_SalesName業代姓名 = l_user.f_username姓名;
                    //string l_str顯示字串 = l_codes[i].f_ExchangeID請購單號 + " " + l_codes[i].f_Branchid請購單位 + " " + l_codes[i].f_SalesName業代姓名;
                    //iv_lbx請購單號.Items.Add(new ListItem(l_str顯示字串, l_codes[i].f_ExchangeID請購單號));

                    l_al.Add(l_codes[j].f_ExchangeID請購單號);         
                }

                CKGPartOrder[] l_code選擇 = new CKGPartOrder[l_al.Count];

                for (int k = 0; k < l_code選擇.Length; k++)
                {
                    //try
                    //{
                        l_code選擇[k] = l_factory.getKGPartOrderBy請購單號((string)l_al[k]);

                        確認訂購並發送Email(l_code選擇[k]);

                        _txtLog.Text += l_code選擇[k].f_ExchangeID請購單號 + "發送完成!" + DateTime.Now + "\r\n";
                    //}
                    //catch { _txtLog.Text += l_code選擇[k].f_ExchangeID請購單號 + "發送失敗!" + DateTime.Now + "\r\n"; }
                }
            }
        }

        private void 確認訂購並發送Email(CKGPartOrder p_codes)
        {
            if (!"KG".Equals(p_codes.f_Vendor請購廠商))//廠商不是高輊時都要發送Email
            {
                發送Email(p_codes.f_Branchid請購單位, p_codes);
            }

            _context.CFactoryManager.CKGPartOrderFactory.update訂購或點收後請購單的狀態(p_codes);
        }
        private void 發送Email(string p_str請購單位, CKGPartOrder p_codes)
        {
            CKGPartOrderMail l_mail = new CKGPartOrderMail(_context);

            l_mail.設定Mail(p_str請購單位, p_codes);
            l_mail.發送Mail();//發送Mail*********測試期間先拿掉**************
        }
        private void button1_Click(object sender, EventArgs e)
        {
            自動發信();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int l_inthour = DateTime.Now.Hour;

            if (l_inthour == 8 || l_inthour == 10 || l_inthour == 11 || l_inthour == 12
                || l_inthour == 14 || l_inthour == 15 || l_inthour == 16)
            {
                自動發信();
                //同步卡鐘資料();
            }      
        }

        private void _btnClock_Click(object sender, EventArgs e)
        {
            同步卡鐘資料();
        }

        private void 同步卡鐘資料()
        {
            try
            {
                CClock[] l_clock = _context.CFactoryManager.CClockFactory.get原始卡鐘記錄();

                _context.CFactoryManager.CClockFactory.insert_同步資料到EIP主機(l_clock);

                _txtLog.Text += "同步完成! 筆數: " + l_clock.Length;
            }
            catch (Exception ex)
            {
                _txtLog.Text += "同步失敗! 錯誤訊息:" + ex.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _context.CFactoryManager.CClockFactory.tempfun2();

        }
    }
}
