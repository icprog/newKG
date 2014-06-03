<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmSetWorkType.aspx.cs" Inherits="KGUi.manager.FrmSetWorkType"%>

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
                    <td colspan="4" align="center" bgcolor="#FFD7D7" style="background-image: url(../Images/table_bg_blue.gif);
                        height: 16px;">
                        <asp:Label ID="Label1" runat="server" Text="洗車種類設定" ForeColor="White" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="代號"></asp:Label>
                    </td>
                    <td  colspan="3">
                        <asp:TextBox ID="_txt代碼" runat="server" Width="68px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="名稱"></asp:Label>
                    </td>
                    <td  colspan="3">
                        <asp:TextBox ID="_txt名稱" runat="server" Width="232px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="價錢"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="_txt價錢" runat="server" Width="70px"></asp:TextBox>
                    </td>
                    
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="員工價"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="_txt員工價" runat="server" Width="70px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="內部薪資"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="_txt內部薪資" runat="server" Width="70px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="外部薪資"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="_txt外部薪資" runat="server" Width="70px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="服務獎金%數"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="_txt服務獎金" runat="server" Width="70px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="業代獎金%數"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="_txt業代獎金" runat="server" Width="70px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="left">
                        <asp:Button ID="_btn設定" runat="server" Text="設定" OnClick="_btn設定_Click" 
                            style="height: 21px" />
                    </td>
                </tr>
            </table>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="700px">
                <RowStyle ForeColor="#000066" />
                <Columns>
                    <asp:TemplateField HeaderText="項次" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="Label21" runat="server" Text='<%# Eval("項次")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="代號">
                        <ItemTemplate>
                            <asp:Label ID="Label26" runat="server" Text='<%# Eval("代號")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="名稱">
                        <ItemTemplate>
                            <asp:Label ID="Label27" runat="server" Text='<%# Eval("名稱")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="價錢">
                        <ItemTemplate>
                            <asp:Label ID="Label28" runat="server" Text='<%# Eval("價錢")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="員工價">
                        <ItemTemplate>
                            <asp:Label ID="Label29" runat="server" Text='<%# Eval("員工價")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="內部薪資">
                        <ItemTemplate>
                            <asp:Label ID="Label37" runat="server" Text='<%# Eval("內部薪資")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="外部薪資">
                        <ItemTemplate>
                            <asp:Label ID="Label36" runat="server" Text='<%# Eval("外部薪資")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="服務獎金">
                        <ItemTemplate>
                            <asp:Label ID="Label47" runat="server" Text='<%# Eval("服務獎金")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="業代獎金">
                        <ItemTemplate>
                            <asp:Label ID="Label38" runat="server" Text='<%# Eval("業代獎金")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="刪除">
                        <ItemTemplate>
                            <asp:Button ID="_btn刪除" runat="server" Text="刪除" OnClick="_btn刪除_Click" OnClientClick="return confirm('是否刪除此設定?')" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>