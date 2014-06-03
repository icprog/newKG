<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmPlantReprotDetail.aspx.cs" Inherits="KGUi.manager.FrmPlantReprotDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
   
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="一般總計:" Font-Bold="True" 
            ForeColor="#003300"></asp:Label>
        <asp:Label ID="_lbl一般" runat="server" Text=""></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Label ID="Label2" runat="server" Text="保險總計:" Font-Bold="True" 
            ForeColor="Maroon"></asp:Label>
        <asp:Label ID="_lbl保險" runat="server" Text=""></asp:Label>
         <asp:GridView ID="_gvAmt" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
             CellPadding="3" Width="744px">
                    <RowStyle ForeColor="#000066" />
                    <Columns>
                        <asp:TemplateField HeaderText="開單日期">
                            <ItemTemplate>
                                <asp:Label ID="Label26" runat="server" Text='<%# Eval("開單日期")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="工單號碼">
                            <ItemTemplate>
                                <asp:Label ID="Label27" runat="server" Text='<%# Eval("工單號碼")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="引擎號碼">
                            <ItemTemplate>
                                <asp:Label ID="Label28" runat="server" Text='<%# Eval("引擎號碼")%>'></asp:Label>
                            </ItemTemplate>   
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="洗車種類">
                            <ItemTemplate>
                                <asp:Label ID="Label29" runat="server" Text='<%# Eval("洗車種類")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="開單人員">
                            <ItemTemplate>
                                <asp:Label ID="Label30" runat="server" Text='<%# Eval("開單人員")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="名稱">
                            <ItemTemplate>
                                <asp:Label ID="Label31" runat="server" Text='<%# Eval("名稱")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="金額">
                            <ItemTemplate>
                                <asp:Label ID="Label32" runat="server" Text='<%# Eval("金額")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="工單類型">
                            <ItemTemplate>
                                <asp:Label ID="Label33" runat="server" Text='<%# Eval("工單類型")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="保險公司">
                            <ItemTemplate>
                                <asp:Label ID="Label34" runat="server" Text='<%# Eval("保險公司")%>'></asp:Label>
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
