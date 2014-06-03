<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="FrmAmtReportDetail.aspx.cs" Inherits="KGUi.manager.FrmAmtReportDetail" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>薪資報表明細</title>
</head>
<body>
    <form id="form1" runat="server">
 <asp:GridView ID="_gvWork" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" Width="708px" >
                    <RowStyle ForeColor="#000066" />
                    <Columns>
                        <asp:TemplateField HeaderText="項次" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="Label21" runat="server" Text='<%# Eval("項次")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="工單號碼">
                            <ItemTemplate>
                                <asp:Label ID="Label26" runat="server" Text='<%# Eval("工單號碼")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="引擎號碼">
                            <ItemTemplate>
                                <asp:Label ID="Label27" runat="server" Text='<%# Eval("引擎號碼")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="顧客名稱">
                            <ItemTemplate>
                                <asp:Label ID="Label28" runat="server" Text='<%# Eval("顧客名稱")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="洗車種類">
                            <ItemTemplate>
                                <asp:Label ID="Label29" runat="server" Text='<%# Eval("洗車種類")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="金額">
                            <ItemTemplate>
                                <asp:Label ID="Label30" runat="server" Text='<%# Eval("金額")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="開單日期">
                            <ItemTemplate>
                                <asp:Label ID="Label31" runat="server" Text='<%# Eval("開單日期")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="完工日期">
                            <ItemTemplate>
                                <asp:Label ID="Label31" runat="server" Text='<%# Eval("完工日")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
    </form>
</body>
</html>
