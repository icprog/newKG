using System;
using System.Collections.Generic;
using System.Text;

namespace tw.com.kg.lib
{
    public class CKGPartOrderDetailOut
    {
        public static string TypeName
        {
            get { return "tw.com.yyt.epaper.lib.dl.CKGPartOrderDetailOut"; }
        }
        private int iv_intf_id = 0;
        public int f_id
        {
            get { return iv_intf_id; }
            set { iv_intf_id = value; }
        }

        private string iv_strf_ExchangeID請購單號 = "";
        public string f_ExchangeID請購單號
        {
            get { return iv_strf_ExchangeID請購單號; }
            set { iv_strf_ExchangeID請購單號 = value; }
        }

        private string iv_strf_AssistantSmid退貨助理員編 = "";
        public string f_AssistantSmid退貨助理員編
        {
            get { return iv_strf_AssistantSmid退貨助理員編; }
            set { iv_strf_AssistantSmid退貨助理員編 = value; }
        }

        private string iv_strf_AssistantName退貨助理姓名 = "";
        public string f_AssistantName退貨助理姓名
        {
            get { return iv_strf_AssistantName退貨助理姓名; }
            set { iv_strf_AssistantName退貨助理姓名 = value; }
        }

        private string iv_strf_SalesSmid業代員編 = "";
        public string f_SalesSmid業代員編
        {
            get { return iv_strf_SalesSmid業代員編; }
            set { iv_strf_SalesSmid業代員編 = value; }
        }

        private string iv_strf_SalesName業代姓名 = "";
        public string f_SalesName業代姓名
        {
            get { return iv_strf_SalesName業代姓名; }
            set { iv_strf_SalesName業代姓名 = value; }
        }

        private string iv_strf_SalesBranch業代單位 = "";
        public string f_SalesBranch業代單位
        {
            get { return iv_strf_SalesBranch業代單位; }
            set { iv_strf_SalesBranch業代單位 = value; }
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

        private int iv_intf_OutAmount退貨數量 = 0;
        public int f_OutAmount退貨數量
        {
            get { return iv_intf_OutAmount退貨數量; }
            set { iv_intf_OutAmount退貨數量 = value; }
        }

        private string iv_strf_OutDate退貨日期 = "";
        public string f_OutDate退貨日期
        {
            get { return iv_strf_OutDate退貨日期; }
            set { iv_strf_OutDate退貨日期 = value; }
        }

        private string iv_strf_Qty產品單位 = "";
        public string f_Qty產品單位
        {
            get { return iv_strf_Qty產品單位; }
            set { iv_strf_Qty產品單位 = value; }
        }

        private int iv_intf_Cost產品成本 = 0;
        public int f_Cost產品成本
        {
            get { return iv_intf_Cost產品成本; }
            set { iv_intf_Cost產品成本 = value; }
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

        private int iv_intf_OutTotal總計退貨價格 = 0;
        public int f_OutTotal總計退貨價格
        {
            get { return iv_intf_OutTotal總計退貨價格; }
            set { iv_intf_OutTotal總計退貨價格 = value; }
        }


        private string iv_strf_OutReasons退貨原因 = "";
        public string f_OutReasons退貨原因
        {
            get { return iv_strf_OutReasons退貨原因; }
            set { iv_strf_OutReasons退貨原因 = value; }
        }

        private string iv_strf_Check管理者確認退貨 = "";
        public string f_Check管理者確認退貨
        {
            get { return iv_strf_Check管理者確認退貨; }
            set { iv_strf_Check管理者確認退貨 = value; }
        }

        private string iv_strf_CheckDate確認退貨日期 = "";
        public string f_CheckDate確認退貨日期
        {
            get { return iv_strf_CheckDate確認退貨日期; }
            set { iv_strf_CheckDate確認退貨日期 = value; }
        }

        private string iv_strf_EditDate編輯日期 = "";
        public string f_EditDate編輯日期
        {
            get { return iv_strf_EditDate編輯日期; }
            set { iv_strf_EditDate編輯日期 = value; }
        }

    }
}