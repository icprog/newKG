<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmLogin.aspx.cs" Inherits="KGUi.carsale.FrmLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>特販審核LOGIN</title>

    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table border="1" cellpadding="0" cellspacing="0" bordercolor="#BDCFE1" 
                    style="height: 109px; width: 199px">
                    <tr>
                        <td colspan="2" align="center" bgcolor="#FFD7D7" style="background-image: url(../Images/table_bg_blue.gif);
                            height: 16px;">
                            <asp:Label ID="Label3" runat="server" Text="特販審核" ForeColor="White" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="帳號:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="_txt帳號" runat="server" Width="144px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="密碼:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="_txt密碼" runat="server" TextMode="Password" Width="144px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="_btn登入" runat="server" Text="登入" OnClick="_btn登入_Click" />
                            <br />
                            <div style="color: #FF0000; font-size: 12px">
                                2010/10/21 更改流程:<br />
                                若所長說明超過地擔權限(詳細%請洽車輛部)<br />
                                請直接勾選[是否給部長]按下[儲存]即可<br />
                                該case要多給部長簽核<br />
                                該狀態會先變成&quot;不核准&quot;,說明會變成&quot;等待部長簽核&quot;<br />
                                詳細請洽資訊室_宏瑋2361</div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
