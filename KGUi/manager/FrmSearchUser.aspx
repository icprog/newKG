<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmSearchUser.aspx.cs" Inherits="KGUi.manager.FrmSearchUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table border="1" cellpadding="0" cellspacing="0" bordercolor="#BDCFE1">
                <tr>
                    <td colspan="2" align="center" bgcolor="#FFD7D7" style="background-image: url(../Images/table_bg_blue.gif);
                        height: 16px;">
                        <asp:Label ID="Label1" runat="server" Text="人員設定_查詢" ForeColor="White" Font-Bold="True"></asp:Label>
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
                        <asp:Button ID="_btn查詢" runat="server" Text="查詢" OnClick="_btn查詢_Click" />
                        <asp:Button ID="_btn取消" runat="server" Text="取消" OnClick="_btn取消_Click" />
                    </td>
                </tr>
            </table>
            
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
            <br />
             <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="500px">
                    <RowStyle ForeColor="#000066" />
                    <Columns>
                        <asp:TemplateField HeaderText="項次" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="Label21" runat="server" Text='<%# Eval("項次")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="所別">
                            <ItemTemplate>
                                <asp:Label ID="Label47" runat="server" Text='<%# Eval("所別")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="帳號">
                            <ItemTemplate>
                                <asp:Label ID="Label26" runat="server" Text='<%# Eval("帳號")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="密碼">
                            <ItemTemplate>
                                <asp:Label ID="Label27" runat="server" Text='<%# Eval("密碼")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="姓名">
                            <ItemTemplate>
                                <asp:Label ID="Label37" runat="server" Text='<%# Eval("姓名")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="等級">
                            <ItemTemplate>
                                <asp:Label ID="Label57" runat="server" Text='<%# Eval("等級")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="刪除">
                            <ItemTemplate>
                                <asp:Button ID="_btn刪除" runat="server" Text="刪除" OnClick="_btn刪除_Click" OnClientClick="return confirm('是否刪除此人員?')"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="修改">
                            <ItemTemplate>
                                <asp:Button ID="_btn修改" runat="server" Text="修改" OnClick="_btn修改_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
                </ContentTemplate></asp:UpdatePanel>

    </form>
</body>
</html>
