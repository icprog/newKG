<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WfrmMenu.aspx.cs" Inherits="KGUi.manager.WfrmMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
       <a target="_parent" href="../FrmLogin.aspx">
                                                        <asp:Image ID="Image2" runat="server" Height="35px" ImageUrl="../images/Exit.gif"
            Style="position: static" ToolTip="主畫面" Width="35px" /> </a>
     <asp:TreeView ID="TreeView1" runat="server">
                        <Nodes>
                            <asp:TreeNode Text="參數設定" Value="參數設定">
                                <asp:TreeNode NavigateUrl="~/manager/FrmSetInsurance.aspx" Text="保險設定" Value="保險設定" Target="Operating">
                                </asp:TreeNode>
                                <asp:TreeNode NavigateUrl="~/manager/FrmSetWorkType.aspx" Text="洗車種類設定" Value="洗車種類設定" Target="Operating">
                                </asp:TreeNode>
                                <asp:TreeNode NavigateUrl="~/manager/FrmSetUser.aspx" Text="人員設定" Value="人員設定" Target="Operating"></asp:TreeNode>
                            
                                <asp:TreeNode NavigateUrl="~/manager/part/FrmInsertKGPart.aspx" Text="小百貨產品新增" Value="小百貨產品新增" Target="Operating">
                                </asp:TreeNode>
                            
                            </asp:TreeNode>
                            <asp:TreeNode Text="實績報表" Value="實績報表">
                                <asp:TreeNode NavigateUrl="~/manager/FrmSelectWork.aspx" Text="工單查詢" Value="工單查詢" Target="Operating">
                                </asp:TreeNode>
                                <asp:TreeNode NavigateUrl="~/manager/FrmAmtReport.aspx" Text="薪資報表" Value="薪資報表" Target="Operating">
                                </asp:TreeNode>
                                <asp:TreeNode NavigateUrl="~/manager/FrmWorkReport.aspx" Text="工單實績統計" Value="工單實績統計" Target="Operating">
                                </asp:TreeNode>
                                <asp:TreeNode NavigateUrl="~/manager/FrmInsuranceReport.aspx" Text="保險實績統計" Value="保險實績統計" Target="Operating">
                                </asp:TreeNode>
                                <asp:TreeNode NavigateUrl="~/manager/FrmInsuranceComReport.aspx" Text="保險介紹實績統計" Value="保險實績統計" Target="Operating">
                                </asp:TreeNode>
                                <asp:TreeNode NavigateUrl="~/manager/FrmWashTotalAmount.aspx" Text="台數統計" Value="台數統計" Target="Operating">
                                </asp:TreeNode>
                                <asp:TreeNode NavigateUrl="~/manager/FrmLNProjectReport.aspx" Text="亮新專案招攬明細" Value="亮新專案招攬明細" Target="Operating">
                                </asp:TreeNode>
                                <asp:TreeNode NavigateUrl="~/manager/FrmPlantReprot.aspx" Text="各廠介紹獎金" Value="各廠介紹獎金" Target="Operating">
                                </asp:TreeNode>
                            </asp:TreeNode>
                            <asp:TreeNode Text="財務資料" Value="財務資料">
                                <asp:TreeNode NavigateUrl="~/manager/money/FrmInMoney.aspx" Text="沖帳作業" Value="沖帳作業" Target="Operating">
                                </asp:TreeNode>
                                <asp:TreeNode NavigateUrl="~/manager/money/FrmArrearsMoney.aspx" Text="欠款紀錄" Value="欠款紀錄" Target="Operating">
                                </asp:TreeNode>
                                
                                <asp:TreeNode NavigateUrl="~/manager/part/FrmSelectKGPartInMoneyCheck.aspx" Text="小百貨對帳單明細查詢" Value="小百貨對帳單明細查詢" Target="Operating">
                                </asp:TreeNode>
                            </asp:TreeNode>
                            
                            <asp:TreeNode Text="小百貨作業" Value="小百貨作業">
                             
                                <asp:TreeNode NavigateUrl="~/manager/part/FrmSelectKGPart.aspx" Text="小百貨產品維護" Value="小百貨產品維護" Target="Operating">
                                </asp:TreeNode>
                                <asp:TreeNode NavigateUrl="~/manager/part/FrmSelectKGPartReportDaily.aspx" Text="訂購報表查詢" Value="訂購報表查詢" Target="Operating">
                                </asp:TreeNode>
                                <asp:TreeNode NavigateUrl="~/manager/part/FrmSelectKGPartReportDetail.aspx" Text="訂購報表查詢(明細)" Value="訂購報表查詢(明細)" Target="Operating">
                                </asp:TreeNode>

                                <asp:TreeNode NavigateUrl="~/manager/part/FrmInsertKGPartOutOrderAdmin.aspx" Text="小百貨訂貨申請作業" Value="小百貨訂貨申請作業" Target="Operating">
                                </asp:TreeNode>
                                <asp:TreeNode NavigateUrl="~/manager/part/FrmSelectKGPartOrderDetailOutAdmin.aspx" Text="退貨確認" Value="退貨確認" Target="Operating">
                                </asp:TreeNode>
                                <asp:TreeNode NavigateUrl="~/manager/part/FrmSalesRankReport.aspx" Text="小百貨銷售排行榜" Value="小百貨銷售排行榜" Target="Operating">
                                </asp:TreeNode>
                                
                                  
                            </asp:TreeNode>
                            <asp:TreeNode Text="點數作業" Value="點數作業">
                                <asp:TreeNode NavigateUrl="~/manager/point/WfrmInsertKGPoint.aspx" Text="儲值點數" Value="儲值點數" Target="Operating">
                                </asp:TreeNode>
                                <asp:TreeNode NavigateUrl="~/manager/point/FrmSelectKGPointDetail.aspx" Text="點數使用明細" Value="點數使用明細" Target="Operating">
                                </asp:TreeNode>
                                
                                <asp:TreeNode NavigateUrl="~/manager/point/FrmImportKGPoint.aspx" Text="點數匯入作業" Value="點數匯入作業" Target="Operating">
                                </asp:TreeNode>
                            </asp:TreeNode>
                            
                            <asp:TreeNode Text="小百貨申請(前)" Value="小百貨申請(前)">
                                <asp:TreeNode NavigateUrl="~/part/FrmInsertKGPartOrder.aspx" Text="小百貨訂購" Value="小百貨訂購" Target="Operating">
                                </asp:TreeNode>
                                 <asp:TreeNode NavigateUrl="~/part/FrmSelectPrintKGPartOrder.aspx" Text="請購單列印作業" Value="請購單列印作業" Target="Operating">
                                </asp:TreeNode>
                                 <asp:TreeNode NavigateUrl="~/part/FrmInsertKGPartOrderDetailOut.aspx" Text="退貨申請作業" Value="退貨申請作業" Target="Operating">
                                </asp:TreeNode>
                                 <asp:TreeNode NavigateUrl="~/part/FrmSelectKGPartOrderDetailOut.aspx" Text="退貨取消列印作業 " Value="退貨取消列印作業 " Target="Operating">
                                </asp:TreeNode>
                            </asp:TreeNode>
                        </Nodes>
                    </asp:TreeView>
    </div>
    </form>
</body>
</html>
