<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmSetUser.aspx.cs" Inherits="KGUi.manager.FrmSetUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table border="1" cellpadding="0" cellspacing="0" bordercolor="#BDCFE1">
                <tr>
                    <td colspan="2" align="center" bgcolor="#FFD7D7" style="background-image: url(../Images/table_bg_blue.gif);
                        height: 16px;">
                        <asp:Label ID="Label1" runat="server" Text="人員設定" ForeColor="White" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="帳號"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="_txt帳號" runat="server"></asp:TextBox>
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
                        <asp:Button ID="_btn設定" runat="server" Text="設定" OnClick="_btn設定_Click" />
                        <asp:Button ID="_btn查詢" runat="server" Text="查詢" OnClick="_btn查詢_Click" />
                    </td>
                </tr>
            </table>
                
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
