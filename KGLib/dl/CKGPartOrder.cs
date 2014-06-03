using System;
using System.Collections.Generic;
using System.Text;

namespace tw.com.kg.lib
{
    public class CKGPartOrder
    {
        public static string TypeName
        {
            get { return "tw.com.yyt.epaper.lib.dl.CKGPartOrder"; }
        }
        private string iv_strf_ExchangeID請購單號 = "";
        public string f_ExchangeID請購單號
        {
            get { return iv_strf_ExchangeID請購單號; }
            set { iv_strf_ExchangeID請購單號 = value; }
        }

        private string iv_strf_Vendor請購廠商 = "";
        public string f_Vendor請購廠商
        {
            get { return iv_strf_Vendor請購廠商; }
            set { iv_strf_Vendor請購廠商 = value; }
        }

        private string iv_strf_EngineNo引擎號碼 = "";
        public string f_EngineNo引擎號碼
        {
            get { return iv_strf_EngineNo引擎號碼; }
            set { iv_strf_EngineNo引擎號碼 = value; }
        }

        private string iv_strf_AssistantSmid助理員編 = "";
        public string f_AssistantSmid助理員編
        {
            get { return iv_strf_AssistantSmid助理員編; }
            set { iv_strf_AssistantSmid助理員編 = value; }
        }

        private string iv_strf_AssistantName助理姓名 = "";
        public string f_AssistantName助理姓名
        {
            get { return iv_strf_AssistantName助理姓名; }
            set { iv_strf_AssistantName助理姓名 = value; }
        }

        private string iv_strf_AssistantBranchid助理單位編號 = "";
        public string f_AssistantBranchid助理單位編號
        {
            get { return iv_strf_AssistantBranchid助理單位編號; }
            set { iv_strf_AssistantBranchid助理單位編號 = value; }
        }
        private string iv_strf_AssistantBranch助理單位 = "";
        public string f_AssistantBranch助理單位
        {
            get { return iv_strf_AssistantBranch助理單位; }
            set { iv_strf_AssistantBranch助理單位 = value; }
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

        private string iv_strf_SalesBranchid業代單位編號 = "";
        public string f_SalesBranchid業代單位編號
        {
            get { return iv_strf_SalesBranchid業代單位編號; }
            set { iv_strf_SalesBranchid業代單位編號 = value; }
        }
        
        private string iv_strf_SalesBranch業代單位 = "";
        public string f_SalesBranch業代單位
        {
            get { return iv_strf_SalesBranch業代單位; }
            set { iv_strf_SalesBranch業代單位 = value; }
        }

        private int iv_intf_TotalCost總成本價 = 0;
        public int f_TotalCost總成本價
        {
            get { return iv_intf_TotalCost總成本價; }
            set { iv_intf_TotalCost總成本價 = value; }
        }
        private int iv_intf_TotalSale總販賣價 = 0;
        public int f_TotalSale總販賣價
        {
            get { return iv_intf_TotalSale總販賣價; }
            set { iv_intf_TotalSale總販賣價 = value; }
        }

        private int iv_intf_TotalPrice總計價格 = 0;
        public int f_TotalPrice總計價格
        {
            get { return iv_intf_TotalPrice總計價格; }
            set { iv_intf_TotalPrice總計價格 = value; }
        }

        private string iv_strf_IsSend是否發送 = "";
        public string f_IsSend是否發送
        {
            get { return iv_strf_IsSend是否發送; }
            set { iv_strf_IsSend是否發送 = value; }
        }
        
        private string iv_strf_Status請購狀態 = "";
        public string f_Status請購狀態
        {
            get { return iv_strf_Status請購狀態; }
            set { iv_strf_Status請購狀態 = value; }
        }

        private string iv_strf_Memo備註說明 = "";
        public string f_Memo備註說明
        {
            get { return iv_strf_Memo備註說明; }
            set { iv_strf_Memo備註說明 = value; }
        }

        private string iv_strf_InsertDate請購日期 = "";
        public string f_InsertDate請購日期
        {
            get { return iv_strf_InsertDate請購日期; }
            set { iv_strf_InsertDate請購日期 = value; }
        }

        private string iv_strf_InsertIP輸入電腦IP = "";
        public string f_InsertIP輸入電腦IP
        {
            get { return iv_strf_InsertIP輸入電腦IP; }
            set { iv_strf_InsertIP輸入電腦IP = value; }
        }

        private string iv_strf_EditDate編輯日期 = "";
        public string f_EditDate編輯日期
        {
            get { return iv_strf_EditDate編輯日期; }
            set { iv_strf_EditDate編輯日期 = value; }
        }
        
        private CKGPartOrderDetail[] iv_str明細;
        public CKGPartOrderDetail[] 明細
        {
            get { return iv_str明細; }
            set { iv_str明細 = value; }
        }
        private string iv_strcustomername = "";
        public string f_customername顧客姓名
        {
            get { return iv_strcustomername; }
            set { iv_strcustomername = value; }
        }

        //***************查詢使用******************
        private string iv_strNonSendCount未發送的請購筆數 = "";
        public string NonSendCount未發送的請購筆數
        {
            get { return iv_strNonSendCount未發送的請購筆數; }
            set { iv_strNonSendCount未發送的請購筆數 = value; }
        }

        private string iv_strType種類 = "";
        public string Type種類
        {
            get { return iv_strType種類; }
            set { iv_strType種類 = value; }
        }
        private string iv_strf_Branchid請購單位 = "";
        public string f_Branchid請購單位
        {
            get { return iv_strf_Branchid請購單位; }
            set { iv_strf_Branchid請購單位 = value; }
        }

    }
}