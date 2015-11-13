<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmInMoneyPrint.aspx.cs"
    Inherits="KGUi.manager.money.FrmInMoneyPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未命名頁面</title>
    <style type="text/css">
        .t
        {
            text-align: center;
            font-size: 36px;
        }
        .d
        {
            font-weight: bold;
        }
        .d
        {
            text-align: right;
        }
        
         @media print
        {
            .noprint
            {
                display: none;
            }
        }
        #printBnt2
        {
            height: 47px;
            width: 134px;
        }
        .style1
        {
            font-weight: bold;
            text-align: right;
            width: 106px;
        }
        .style2
        {
            width: 203px;
        }
        .style3
        {
            font-weight: bold;
            text-align: right;
            width: 112px;
        }
        .style4
        {
            width: 235px;
        }
    </style>
    
    <script language="JavaScript" type="text/JavaScript">

function DP() {
window.print();
window.close();
}

    </script>
</head>
<body>
    <form id="form1" runat="server">
    
    <div id="Div2" class="noprint">
        <input type="button" value="列印" onclick="javascript:DP();" id="printBnt2">
    </div>
    <div id="Div1">
        <table width="600" border="1">
            <tr>
                <td colspan="4" class="t">
                    ===付款收據===
                </td>
            </tr>
            <tr>
                <td class="style1">
                    員編：
                </td>
                <td class="style2">
                    <asp:Label ID="_lbl員編" runat="server" Text="Label"></asp:Label>
                </td>
                <td width="123" class="d">
                    付款日期：
                </td>
                <td width="117">
                   <asp:Label ID="_lbl付款日期" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <br />
                    <asp:GridView ID="GridView1" runat="server" BackColor="#CCCCCC" 
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
                        CellSpacing="2" ForeColor="Black" 
                        onselectedindexchanged="GridView1_SelectedIndexChanged">
                        <RowStyle BackColor="White" />
                        <FooterStyle BackColor="#CCCCCC" />
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="style1">
                    尚餘點數：
                </td>
                <td class="style2">
                     <asp:Label ID="_lbl尚餘點數" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="d">
                    總計：
                </td>
                <td>
                   <asp:Label ID="_lbl總計" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="49" class="style1">
                    經辦人簽名：
                </td>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
        </table>
        
        <p align="center" width="400">
            ＝＝＝＝＝＝＝＝＝＝＝＝＝裁切線＝＝＝＝＝＝＝＝＝＝＝＝＝</p>
            
         <table width="600" border="1">
            <tr>
                <td colspan="4" class="t">
                    ===付款收據===
                </td>
            </tr>
            <tr>
                <td class="style3">
                    員編：
                </td>
                <td class="style4">
                   <asp:Label ID="_lbl員編1" runat="server" Text="Label"></asp:Label>
                </td>
                <td width="123" class="d">
                    付款日期：
                </td>
                <td width="117">
                   <asp:Label ID="_lbl付款日期1" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <br />
                    <asp:GridView ID="GridView2" runat="server" BackColor="#CCCCCC" 
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
                        CellSpacing="2" ForeColor="Black" 
                        onselectedindexchanged="GridView1_SelectedIndexChanged">
                        <RowStyle BackColor="White" />
                        <FooterStyle BackColor="#CCCCCC" />
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="style3">
                    尚餘點數：
                </td>
                <td class="style4">
                     <asp:Label ID="_lbl尚餘點數1" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="d">
                    總計：
                </td>
                <td>
                   <asp:Label ID="_lbl總計1" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="49" class="style3">
                    經辦人簽名：
                </td>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
