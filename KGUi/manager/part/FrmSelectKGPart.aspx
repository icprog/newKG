<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmSelectKGPart.aspx.cs"
    Inherits="KGUi.manager.part.FrmSelectKGPart" %>

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
        <div>
            <div>
                <div>
                    <asp:ScriptManager ID="ScriptManager1" runat="server" />
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table id="TABLE1" style="border-right: lightblue thin solid; border-top: lightblue thin solid;
                                border-left: lightblue thin solid; width: 464px; border-bottom: lightblue thin solid">
                                <tr bgcolor="#e8eef4">
                                    <td colspan="11" style="background-image: url(../Images/table_bg_blue.gif)">
                                        <asp:Image ID="Image33331" runat="server" Height="11px" ImageUrl="~/Images/icon.gif" />
                                        <asp:Label ID="iv_lblTitleBar" runat="server" BackColor="Transparent" Font-Bold="True"
                                            ForeColor="White" Style="position: static" Width="216px">高輊小百貨產品檔查詢作業</asp:Label>
                                    </td>
                                </tr>
                                <tr bgcolor="#e8eef4">
                                    <td style="background-color: #87c5f4">
                                        <asp:Label ID="Label18" runat="server" Font-Bold="False" Style="position: static"
                                            Text="產品類別" Width="64px"></asp:Label>
                                    </td>
                                    <td colspan="6" style="background-color: #eaeaea">
                                        <asp:DropDownList ID="iv_cbo類別名稱" runat="server" AutoPostBack="True" OnSelectedIndexChanged="iv_cbo類別名稱_SelectedIndexChanged"
                                            Width="140px">
                                        </asp:DropDownList>
                                    </td>
                                    <td colspan="1" style="background-color: #87c5f4">
                                        <asp:Label ID="Label5" runat="server" Font-Bold="False" Style="position: static"
                                            Text="產品種類" Width="64px"></asp:Label>
                                    </td>
                                    <td colspan="3" style="background-color: #eaeaea">
                                        <asp:DropDownList ID="iv_cbo種類名稱" runat="server" Width="165px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr bgcolor="#e8eef4">
                                    <td style="background-color: #87c5f4">
                                        <asp:Label ID="Label3334" runat="server" Font-Bold="False" Style="position: static"
                                            Text="產品編號" Width="64px"></asp:Label>
                                    </td>
                                    <td colspan="6" style="background-color: #eaeaea">
                                        <asp:TextBox ID="iv_txt產品編號" runat="server" Width="141px"></asp:TextBox>
                                    </td>
                                    <td colspan="1" style="background-color: #87c5f4">
                                        <asp:Label ID="Label3" runat="server" Font-Bold="False" Style="position: static"
                                            Text="產品名稱" Width="64px"></asp:Label>
                                    </td>
                                    <td colspan="3" style="background-color: #eaeaea">
                                        <asp:TextBox ID="iv_txt產品名稱" runat="server" Width="160px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr bgcolor="#e8eef4">
                                    <td colspan="11" style="background-color: #eaeaea">
                                        <asp:Button ID="iv_btn查詢" runat="server" OnClick="iv_btn查詢_Click" Text="查詢" Width="100px" />
                                        &nbsp;&nbsp;
                                        <asp:Button ID="_btn匯出" runat="server" OnClick="_btn匯出_Click" Text="匯出" 
                                            Width="76px" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" BackColor="White"
                                BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1"
                                Font-Size="Smaller" GridLines="None">
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <Columns>
                                    <asp:TemplateField HeaderText="項次">
                                        <ItemTemplate>
                                            <asp:Label ID="iv_lbl項次" runat="server" Text='<%# Eval("項次") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="刪除">
                                        <ItemTemplate>
                                            <asp:Button ID="iv_btn刪除" runat="server" OnClientClick="return confirm('確定刪除？');"
                                                OnClick="iv_btn刪除_Click" Text="刪除" />
                                            <asp:Label ID="iv_lblID" runat="server" Text='<%# Eval("ID") %>' Visible="False"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="類別編號">
                                        <ItemTemplate>
                                            <asp:Label ID="iv_lbl類別編號" runat="server" Text='<%# Eval("類別編號") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="類別名稱">
                                        <ItemTemplate>
                                            <asp:Label ID="iv_lbl類別名稱" runat="server" Text='<%# Eval("類別名稱") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="種類編號">
                                        <ItemTemplate>
                                            <asp:Label ID="iv_lbl種類編號" runat="server" Text='<%# Eval("種類編號") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="種類名稱">
                                        <ItemTemplate>
                                            <asp:Label ID="iv_lbl種類名稱" runat="server" Text='<%# Eval("種類名稱") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="產品編號">
                                        <ItemTemplate>
                                            <asp:Label ID="iv_lbl產品編號" runat="server" Text='<%# Eval("產品編號") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="產品名稱" ItemStyle-HorizontalAlign="left">
                                        <ItemTemplate>
                                            <asp:Label ID="iv_lbl產品名稱" runat="server" Text='<%# Eval("產品名稱") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="單位" ItemStyle-HorizontalAlign="left">
                                        <ItemTemplate>
                                            <asp:Label ID="iv_lbl單位" runat="server" Text='<%# Eval("單位") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="成本價" ItemStyle-HorizontalAlign="left">
                                        <ItemTemplate>
                                            <asp:Label ID="iv_lbl成本價" runat="server" Text='<%# Eval("成本價") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="業代價" ItemStyle-HorizontalAlign="left">
                                        <ItemTemplate>
                                            <asp:Label ID="iv_lbl業代價" runat="server" Text='<%# Eval("業代價") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="售價" ItemStyle-HorizontalAlign="left">
                                        <ItemTemplate>
                                            <asp:Label ID="iv_lbl售價" runat="server" Text='<%# Eval("售價") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="修改">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="iv_link修改" Target="_blank" NavigateUrl='<%# Eval("修改") %>' runat="server">修改</asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
