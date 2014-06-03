<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmArrearsMoneyDetailTotal.aspx.cs" Inherits="KGUi.manager.money.FrmArrearsMoneyDetailTotal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptLocalization="False" EnableScriptGlobalization="false">
    </asp:ScriptManager>
                
      <asp:Label ID="_txtB帳款日期" runat="server"></asp:Label>
                        ~
                        <asp:Label ID="_txtE帳款日期" runat="server"></asp:Label>
                
         <br />
    <asp:Label ID="Label2" runat="server" Text="員編:" Font-Bold="True" ForeColor="#003300"></asp:Label>
                <asp:Label ID="_lblSmid" runat="server" Text=""></asp:Label>
         <br />
    <asp:Label ID="Label3" runat="server" Text="姓名:" Font-Bold="True" ForeColor="#003300"></asp:Label>
                <asp:Label ID="_lblName" runat="server" Text=""></asp:Label>
                
         <br />
                
    <asp:Label ID="Label1" runat="server" Text="洗車+小百貨總計:" Font-Bold="True" ForeColor="#003300"></asp:Label>
                <asp:Label ID="_lblTotal" runat="server" Text=""></asp:Label>
                
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%">
                    <RowStyle ForeColor="#000066" />
                    <Columns>
                        <asp:TemplateField HeaderText="日期">
                            <ItemTemplate>
                                <asp:Label ID="Label21" runat="server" Text='<%# Eval("日期")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="單號">
                            <ItemTemplate>
                                <asp:Label ID="Label20" runat="server" Text='<%# Eval("單號")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="顧客姓名">
                            <ItemTemplate>
                                <asp:Label ID="Label381" runat="server" Text='<%# Eval("顧客姓名")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="產品編號/洗車總類">
                            <ItemTemplate>
                                <asp:Label ID="Label26" runat="server" Text='<%# Eval("產品編號/洗車總類")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="產品名稱/引擎號碼">
                            <ItemTemplate>
                                <asp:Label ID="Label27" runat="server" Text='<%# Eval("產品名稱/引擎號碼")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="數量">
                            <ItemTemplate>
                                <asp:Label ID="Label28" runat="server" Text='<%# Eval("數量")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="金額">
                            <ItemTemplate>
                                <asp:Label ID="Label29" runat="server" Text='<%# Eval("金額")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="開單人員">
                            <ItemTemplate>
                                <asp:Label ID="Label30" runat="server" Text='<%# Eval("開單人員")%>'></asp:Label>
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
