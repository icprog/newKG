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

namespace KGUi.carsale
{
    public partial class FrmCheckCarSaleDetail : System.Web.UI.Page
    {
        private CUIContext _context;
        protected void Page_Load(object sender, EventArgs e)
        {
            _context = SealedGlobalPage.getContext(this);
            string l_strCustomerid = Request["id"];
            display();
        }

        private void display()
        {
            特販審核 l_code = _context.CFactoryManager.特販審核Factory.
                get客戶資料Bycustid(Request["id"]);

            _lbl身分證字號.Text = l_code.CustomerId;
            _lbl姓名.Text = l_code.Name;
            _lbl生日.Text = l_code.Birthday;
            _lbl戶籍地址.Text = l_code.FormalAddress;
            _lbl郵寄地址.Text = l_code.MailAddress;
            _lbl發票地址.Text = l_code.InvoiceAddress;

            _lbl營業所.Text = l_code.BranchId + "_" + l_code.Title;
            _lbl業代編號.Text = l_code.EmpId + "_" + l_code.Empname;
            _lbl車種.Text = l_code.CarTypeName;
            _lbl車型.Text = l_code.CarType;
            _lblSFX.Text = l_code.SFX;
            _lbl年份.Text = l_code.YearType;
            _lbl訂購日.Text = l_code.OrderDate;
        }

        
    }
}
