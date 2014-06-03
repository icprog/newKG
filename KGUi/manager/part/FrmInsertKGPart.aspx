<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmInsertKGPart.aspx.cs"
    Inherits="KGUi.manager.part.FrmInsertKGPart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未命名頁面</title>

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
                <table id="TABLE1" style="border-right: lightblue thin solid; border-top: lightblue thin solid;
                    border-left: lightblue thin solid; width: 300px; border-bottom: lightblue thin solid">
                    <tr bgcolor="#e8eef4">
                        <td colspan="11" style="background-image: url(../../Images/table_bg_blue.gif)">
                            <asp:Image ID="Image33331" runat="server" Height="11px" ImageUrl="~/Images/icon.gif" />
                            <asp:Label ID="iv_lblTitleBar" runat="server" BackColor="Transparent" Font-Bold="True"
                                ForeColor="White" Style="position: static" Width="216px">高輊小百貨產品檔新增作業</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #87c5f4">
                            <asp:Label ID="_lbl類別編號" runat="server" Text="類別編號"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="_txt類別編號" runat="server" Width="50px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #87c5f4">
                            <asp:Label ID="_lbl類別名稱" runat="server" Text="類別名稱"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="_txt類別名稱" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #87c5f4">
                            <asp:Label ID="_lbl種類編號" runat="server" Text="種類編號"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="_txt種類編號" runat="server" Width="59px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #87c5f4">
                            <asp:Label ID="_lbl種類名稱" runat="server" Text="種類名稱"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="_txt種類名稱" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #87c5f4">
                            <asp:Label ID="_lbl產品編號" runat="server" Text="產品編號"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="_txt產品編號" runat="server" Width="210px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #87c5f4">
                            <asp:Label ID="_lbl產品名稱" runat="server" Text="產品名稱"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="_txt產品名稱" runat="server" Width="210px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #87c5f4">
                            <asp:Label ID="_lbl單位" runat="server" Text="單位"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="_txt單位" runat="server" Width="74px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #87c5f4">
                            <asp:Label ID="_lbl售價" runat="server" Text="售價"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="_txt售價" runat="server" Width="74px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #87c5f4">
                            <asp:Label ID="_lbl業代價" runat="server" Text="業代價"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="_txt業代價" runat="server" Width="74px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #87c5f4">
                            <asp:Label ID="_lbl成本" runat="server" Text="成本"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="_txt成本" runat="server" Width="74px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="background-color: #e8eef4" >
                            <asp:Button ID="_btn新增" runat="server" Text="新增" OnClick="_btn新增_Click" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
