<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmMenu.aspx.cs" Inherits="KGUi.part.FrmMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/insert/FrmIndex.aspx" Target="_blank" >回洗車工單</asp:HyperLink>
    <asp:TreeView ID="TreeView1" runat="server">
                        <Nodes>
                            <asp:TreeNode Text="小百貨作業" Value="小百貨作業">
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
