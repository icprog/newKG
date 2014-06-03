<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmUpdateUser.aspx.cs" Inherits="KGUi.manager.FrmUpdateUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table border="1" cellpadding="0" cellspacing="0" bordercolor="#BDCFE1">
                <tr>
                    <td colspan="2" align="center" bgcolor="#FFD7D7" style="background-image: url(../Images/table_bg_blue.gif);
                        height: 16px;">
                        <asp:Label ID="Label1" runat="server" Text="人員修改" ForeColor="White" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="帳號"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="_txt帳號" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="密碼"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="_txt密碼" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="姓名"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="_txt姓名" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="所別"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="_ddl所別" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="等級"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="_ddl等級" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
                        <asp:Button ID="_btn修改" runat="server" Text="修改" OnClick="_btn修改_Click" />
                    </td>
                </tr>
            </table>
                
    </ContentTemplate>
    </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
