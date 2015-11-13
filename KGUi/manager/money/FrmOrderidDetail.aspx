<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmOrderidDetail.aspx.cs" Inherits="KGUi.manager.money.FrmOrderidDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
   
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                Width="661px">
                <RowStyle ForeColor="#000066" />
                <Columns>
                    <asp:TemplateField HeaderText="項次">
                        <ItemTemplate>
                            <asp:Label ID="Label21" runat="server" Text='<%# Eval("項次")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="單號">
                        <ItemTemplate>
                            <asp:Label ID="Label20" runat="server" Text='<%# Eval("單號")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="產品編號">
                        <ItemTemplate>
                            <asp:Label ID="Label26" runat="server" Text='<%# Eval("產品編號")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="產品名稱">
                        <ItemTemplate>
                            <asp:Label ID="Label27" runat="server" Text='<%# Eval("產品名稱")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="數量">
                        <ItemTemplate>
                            <asp:Label ID="Label28" runat="server" Text='<%# Eval("數量")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            </asp:GridView>
    </div>
    </form>
</body>
</html>
