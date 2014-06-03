<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmCheckCarSaleDetail.aspx.cs"
    Inherits="KGUi.carsale.FrmCheckCarSaleDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>客戶資料</title>

    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>

    <style type="text/css">
        .style1
        {
            width: 94px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <table border="1" cellpadding="0" cellspacing="0" bordercolor="#BDCFE1" 
            style="height: 144px; width: 350px">
            <tr>
                <td colspan="2" align="center" bgcolor="#FFD7D7" style="background-image: url(../Images/table_bg_blue.gif);
                    height: 16px;">
                    <asp:Label ID="Label9" runat="server" Text="客戶基本資料" ForeColor="White" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label  ID="Label2" runat="server" Text="身分證字號"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="_lbl身分證字號" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="Label3" runat="server" Text="姓名"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="_lbl姓名" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="Label4" runat="server" Text="生日"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="_lbl生日" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="Label5" runat="server" Text="戶籍地址"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="_lbl戶籍地址" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="Label6" runat="server" Text="郵寄地址"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="_lbl郵寄地址" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="Label7" runat="server" Text="發票地址"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="_lbl發票地址" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
         <table border="1" cellpadding="0" cellspacing="0" bordercolor="#BDCFE1" style="height: 144px; width: 350px">
            <tr>
                <td colspan="2" align="center" bgcolor="#FFD7D7" style="background-image: url(../Images/table_bg_blue.gif);
                    height: 16px;">
                    <asp:Label ID="Label11" runat="server" Text="購車基本資料" ForeColor="White" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="營業所"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="_lbl營業所" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label10" runat="server" Text="車型"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="_lbl車型" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label12" runat="server" Text="業代編號"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="_lbl業代編號" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label14" runat="server" Text="SFX"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="_lblSFX" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label16" runat="server" Text="車種"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="_lbl車種" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label18" runat="server" Text="年份"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="_lbl年份" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="訂購日"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="_lbl訂購日" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                     <input type="button" value="關閉視窗" onClick="javascript:window.close();" >
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
