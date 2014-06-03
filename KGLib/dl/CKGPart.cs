using System;
using System.Collections.Generic;
using System.Text;

namespace tw.com.kg.lib
{
    public class CKGPart
    {
        public static string TypeName
        {
            get { return "tw.com.yyt.epaper.lib.dl.CKGPart"; }
        }
        private int iv_intf_id = 0;
        public int f_id
        {
            get { return iv_intf_id; }
            set { iv_intf_id = value; }
        }

        private string iv_strf_TypeID類別編號 = "";
        public string f_TypeID類別編號
        {
            get { return iv_strf_TypeID類別編號; }
            set { iv_strf_TypeID類別編號 = value; }
        }

        private string iv_strf_TypeName類別名稱 = "";
        public string f_TypeName類別名稱
        {
            get { return iv_strf_TypeName類別名稱; }
            set { iv_strf_TypeName類別名稱 = value; }
        }

        private string iv_strf_CategoryID種類編號 = "";
        public string f_CategoryID種類編號
        {
            get { return iv_strf_CategoryID種類編號; }
            set { iv_strf_CategoryID種類編號 = value; }
        }

        private string iv_strf_CategoryName種類名稱 = "";
        public string f_CategoryName種類名稱
        {
            get { return iv_strf_CategoryName種類名稱; }
            set { iv_strf_CategoryName種類名稱 = value; }
        }

        private string iv_strf_ProductID產品編號 = "";
        public string f_ProductID產品編號
        {
            get { return iv_strf_ProductID產品編號; }
            set { iv_strf_ProductID產品編號 = value; }
        }

        private string iv_strf_ProductName產品名稱 = "";
        public string f_ProductName產品名稱
        {
            get { return iv_strf_ProductName產品名稱; }
            set { iv_strf_ProductName產品名稱 = value; }
        }

        private string iv_strf_Qty單位 = "";
        public string f_Qty單位
        {
            get { return iv_strf_Qty單位; }
            set { iv_strf_Qty單位 = value; }
        }

        private int iv_intf_Cost成本價 = 0;
        public int f_Cost成本價
        {
            get { return iv_intf_Cost成本價; }
            set { iv_intf_Cost成本價 = value; }
        }

        private int iv_intf_SalePrice業代價 = 0;
        public int f_SalePrice業代價
        {
            get { return iv_intf_SalePrice業代價; }
            set { iv_intf_SalePrice業代價 = value; }
        }

        private int iv_intf_ListPrice售價 = 0;
        public int f_ListPrice售價
        {
            get { return iv_intf_ListPrice售價; }
            set { iv_intf_ListPrice售價 = value; }
        }

    }
}