<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmUpdateKGPart.aspx.cs" Inherits="KGUi.manager.part.FrmUpdateKGPart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
   <script>
window.resizeTo(700,350);

function Button1_onclick() 
{
    window.opener=null; 
    window.close();
}

    </script>
</head>
<body>
   <form id="form1" runat="server">
    <div>
        <div>
            <div>
                <div>
                    <asp:ScriptManager ID="ScriptManager1" runat="server" />
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table id="TABLE1" style="border-right: lightblue thin solid; border-top: lightblue thin solid;
                                border-left: lightblue thin solid; width: 570px; border-bottom: lightblue thin solid">
                                <tr bgcolor="#e8eef4">
                                    <td colspan="11" style="background-image: url(../Images/table_bg_blue.gif)">
                                        <asp:Image ID="Image33331" runat="server" Height="11px" ImageUrl="~/Images/icon.gif" />
                                        <asp:Label ID="iv_lblTitleBar" runat="server" BackColor="Transparent" Font-Bold="True"
                                            ForeColor="White" Style="position: static" Width="216px">高輊小百貨產品檔修改作業</asp:Label>
                                    </td>
                                </tr>
                                <tr bgcolor="#e8eef4">
                                    <td style="background-color: #87c5f4">
                                        <asp:Label ID="Label18" runat="server" Font-Bold="False" Style="position: static"
                                            Text="類別編號" Width="64px"></asp:Label></td>
                                    <td colspan="4" style="background-color: #eaeaea">
                                        <asp:TextBox ID="iv_txt類別編號" runat="server" BackColor="#FFFFC0" ReadOnly="True" Width="40px"></asp:TextBox></td>
                                    <td colspan="1" style="background-color: #87c5f4">
                                        <asp:Label ID="Label1" runat="server" Font-Bold="False" Style="position: static"
                                            Text="類別名稱" Width="64px"></asp:Label></td>
                                    <td colspan="1" style="background-color: #eaeaea">
                                        <asp:TextBox ID="iv_txt類別名稱" runat="server" BackColor="#FFFFC0" ReadOnly="True" Width="100px"></asp:TextBox></td>
                                    <td colspan="1" style="background-color: #87c5f4">
                                        <asp:Label ID="Label5" runat="server" Font-Bold="False" Style="position: static"
                                            Text="種類編號" Width="64px"></asp:Label></td>
                                    <td colspan="1" style="width: 59px; background-color: #eaeaea">
                                        <asp:TextBox ID="iv_txt種類編號" runat="server" BackColor="#FFC0FF" ReadOnly="True" Width="40px"></asp:TextBox></td>
                                    <td colspan="1" style="background-color: #87c5f4">
                                        <asp:Label ID="Label9" runat="server" Font-Bold="False" Style="position: static"
                                            Text="種類名稱" Width="64px"></asp:Label></td>
                                    <td colspan="1" style="background-color: #eaeaea">
                                        <asp:TextBox ID="iv_txt種類名稱" runat="server" BackColor="#FFC0FF" ReadOnly="True" Width="120px"></asp:TextBox></td>
                                </tr>
                                <tr bgcolor="#e8eef4">
                                    <td style="background-color: #87c5f4">
                                        <asp:Label ID="Label3334" runat="server" Font-Bold="False" Style="position: static"
                                            Text="產品編號" Width="64px"></asp:Label></td>
                                    <td colspan="6" style="background-color: #eaeaea">
                                        <asp:TextBox ID="iv_txt產品編號" runat="server" BackColor="#FFE0C0" ReadOnly="True" Width="220px"></asp:TextBox></td>
                                    <td colspan="1" style="background-color: #87c5f4">
                                        <asp:Label ID="Label3" runat="server" Font-Bold="False" Style="position: static"
                                            Text="產品名稱" Width="64px"></asp:Label></td>
                                    <td colspan="3" style="background-color: #eaeaea">
                                        <asp:TextBox ID="iv_txt產品名稱" runat="server" BackColor="#FFE0C0" Width="240px"></asp:TextBox></td>
                                </tr>
                                <tr bgcolor="#e8eef4">
                                    <td style="background-color: #87c5f4">
                                        <asp:Label ID="Label8" runat="server" Text="產品單位"></asp:Label></td>
                                    <td colspan="4" style="background-color: #eaeaea">
                                        <asp:TextBox ID="iv_txt產品單位" runat="server" BackColor="#C0FFC0" Width="40px"></asp:TextBox></td>
                                    <td colspan="1" style="background-color: #87c5f4">
                                        <asp:Label ID="Label12" runat="server" Text="成本價" Width="52px"></asp:Label></td>
                                    <td colspan="1" style="background-color: #eaeaea">
                                        <asp:TextBox ID="iv_txt成本價" runat="server" BackColor="#FF8080" Width="100px"></asp:TextBox></td>
                                    <td colspan="1" style="background-color: #87c5f4">
                                        <asp:Label ID="Label6" runat="server" Text="業代價"></asp:Label></td>
                                    <td colspan="1" style="width: 59px; background-color: #eaeaea">
                                        <asp:TextBox ID="iv_txt業代價" runat="server" BackColor="Yellow" Width="40px"></asp:TextBox></td>
                                    <td colspan="1" style="background-color: #87c5f4">
                                        <asp:Label ID="Label2" runat="server" Text="建議售價" Width="66px"></asp:Label></td>
                                    <td colspan="1" style="background-color: #eaeaea">
                                        <asp:TextBox ID="iv_txt建議售價" runat="server" BackColor="#C0FFFF" Width="50px"></asp:TextBox></td>
                                </tr>
                                <tr bgcolor="#e8eef4">
                                    <td colspan="11" style="background-color: #eaeaea" headers="1234">
                                        <asp:Button ID="iv_btn修改" runat="server" Text="修改產品檔" Width="100px" OnClick="iv_btn修改_Click" />
                                        <input id="Button1" style="width: 100px" type="button" value="關閉視窗" onclick="return Button1_onclick()" /></td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    
    </div>
    </form>
</body>
</html>
