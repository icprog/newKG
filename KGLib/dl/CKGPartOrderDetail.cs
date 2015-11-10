using System;
using System.Collections.Generic;
using System.Text;

namespace tw.com.kg.lib
{
    public class CKGPartOrderDetail
    {
        public static string TypeName
        {
            get { return "tw.com.yyt.epaper.lib.dl.CKGPartOrderDetail"; }
        }
        private string iv_strf_ExchangeID請購單號 = "";
        public string f_ExchangeID請購單號
        {
            get { return iv_strf_ExchangeID請購單號; }
            set { iv_strf_ExchangeID請購單號 = value; }
        }

        private string iv_strf_AssistantSmid助理員編 = "";
        public string f_AssistantSmid助理員編
        {
            get { return iv_strf_AssistantSmid助理員編; }
            set { iv_strf_AssistantSmid助理員編 = value; }
        }

        private string iv_strf_SalesSmid業代員編 = "";
        public string f_SalesSmid業代員編
        {
            get { return iv_strf_SalesSmid業代員編; }
            set { iv_strf_SalesSmid業代員編 = value; }
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

        private int iv_intf_Amount選購數量 = 0;
        public int f_Amount選購數量
        {
            get { return iv_intf_Amount選購數量; }
            set { iv_intf_Amount選購數量 = value; }
        }

        private string iv_strf_Qty產品單位 = "";
        public string f_Qty產品單位
        {
            get { return iv_strf_Qty產品單位; }
            set { iv_strf_Qty產品單位 = value; }
        }

        private int iv_intf_Cost產品成本價 = 0;
        public int f_Cost產品成本價
        {
            get { return iv_intf_Cost產品成本價; }
            set { iv_intf_Cost產品成本價 = value; }
        }

        private int iv_intf_UnitPrice產品單價 = 0;
        public int f_UnitPrice產品單價
        {
            get { return iv_intf_UnitPrice產品單價; }
            set { iv_intf_UnitPrice產品單價 = value; }
        }

        private int iv_intf_ListPrice建議售價 = 0;
        public int f_ListPrice建議售價
        {
            get { return iv_intf_ListPrice建議售價; }
            set { iv_intf_ListPrice建議售價 = value; }
        }

        private int iv_intf_SalePrice販賣價 = 0;
        public int f_SalePrice販賣價
        {
            get { return iv_intf_SalePrice販賣價; }
            set { iv_intf_SalePrice販賣價 = value; }
        }

        private int iv_intf_Total總計價格 = 0;
        public int f_Total總計價格
        {
            get { return iv_intf_Total總計價格; }
            set { iv_intf_Total總計價格 = value; }
        }

        //private string iv_strf_Cancel取消原因 = "";
        //public string f_Cancel取消原因
        //{
        //    get { return iv_strf_Cancel取消原因; }
        //    set { iv_strf_Cancel取消原因 = value; }
        //}

        private string iv_strf_EditDate編輯日期 = "";
        public string f_EditDate編輯日期
        {
            get { return iv_strf_EditDate編輯日期; }
            set { iv_strf_EditDate編輯日期 = value; }
        }

        //2013/05/20 新增顧客姓名欄位
        public string 顧客姓名 { get; set; }

    }
}