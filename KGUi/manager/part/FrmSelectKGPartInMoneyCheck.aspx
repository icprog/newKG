<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmSelectKGPartInMoneyCheck.aspx.cs"
    Inherits="KGUi.manager.part.FrmSelectKGPartInMoneyCheck" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
             <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="_txtBDate"
                    Format="yyyy/MM/dd">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="_txtEDate"
                    Format="yyyy/MM/dd">
                </cc1:CalendarExtender>
        <table id="Table2" style="border-right: lightblue thin solid; border-top: lightblue thin solid;
            border-left: lightblue thin solid; width: 426px; border-bottom: lightblue thin solid">
            <tr bgcolor="#e8eef4">
                <td colspan="18" style="background-image: url(../../Images/table_bg_blue.gif)">
                    <asp:Label ID="Label1" runat="server" BackColor="Transparent" Font-Bold="True" ForeColor="White"
                        Style="position: static" Text="小百貨訂貨對帳單明細查詢" Width="223px"></asp:Label>
                </td>
            </tr>
            <tr bgcolor="#e8eef4">
                <td style="background-color: #87c5f4">
                    <asp:Label ID="Label6" runat="server" Font-Bold="False" Style="position: static"
                        Text="所別" Width="64px"></asp:Label>
                </td>
                <td colspan="15" style="background-color: #eaeaea">
                    <asp:DropDownList ID="iv_cbo所別" runat="server" Width="100px">
                    </asp:DropDownList>
                </td>
                <td colspan="1" style="background-color: #87c5f4">
                    <asp:Label ID="Label3" runat="server" Font-Bold="False" Style="position: static"
                        Text="廠商" Width="64px"></asp:Label>
                </td>
                <td colspan="1" style="background-color: #eaeaea">
                    <asp:DropDownList ID="iv_cbo廠商" runat="server" Width="110px">
                        <asp:ListItem Text="" Value=""></asp:ListItem>
                        <asp:ListItem Text="亙長" Value="KC"></asp:ListItem>
                        <asp:ListItem Text="亙長(服務廠)" Value="KCF"></asp:ListItem>
                        <asp:ListItem Text="劦大" Value="LD"></asp:ListItem>
                        <asp:ListItem Text="劦大(服務廠)" Value="LDF"></asp:ListItem>
                        <asp:ListItem Text="惠明" Value="HM"></asp:ListItem>
                        <asp:ListItem Text="PDS" Value="PDS"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr bgcolor="#e8eef4">
                <td style="background-color: #87c5f4">
                    <asp:Label ID="Label2" runat="server" Font-Bold="False" Style="position: static"
                        Text="訂貨日期 起" Width="88px"></asp:Label>
                </td>
                <td colspan="15" style="background-color: #eaeaea">
                    <asp:TextBox ID="_txtBDate" runat="server" Width="70px" MaxLength="8"></asp:TextBox>&nbsp;
                </td>
                <td colspan="1" style="background-color: #87c5f4">
                    <asp:Label ID="Label5" runat="server" Font-Bold="False" Style="position: static"
                        Text="訂貨日期 止" Width="94px"></asp:Label>
                </td>
                <td colspan="1" style="background-color: #eaeaea">
                    <asp:TextBox ID="_txtEDate" runat="server" Width="70px" MaxLength="8"></asp:TextBox>
            </tr>
            <tr bgcolor="#e8eef4">
                <td colspan="16" style="background-color: #eaeaea">
                    <asp:Button ID="iv_btn查詢" runat="server" OnClick="iv_btn查詢_Click" Text="對帳單查詢" Width="100px" />
                </td>
                <td colspan="2" style="background-color: #eaeaea">
                </td>
            </tr>
        </table>
        <table>
            <tr>
               
                <td valign="top">
                <asp:Label ID="Label4" runat="server" Text="查詢結果:"></asp:Label>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" BackColor="White"
                        BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1"
                        Font-Size="Smaller" GridLines="None">
                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" HorizontalAlign="Center" />
                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                        <Columns>
                            <asp:TemplateField HeaderText="訂購單號">
                                <ItemTemplate>
                                    <asp:Label ID="iv_lbl訂購單號" runat="server" Text='<%# Eval("訂購單號") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="廠商">
                                <ItemTemplate>
                                    <asp:Label ID="iv_lbl廠商" runat="server" Text='<%# Eval("廠商代號") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("廠商") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="日期">
                                <ItemTemplate>
                                    <asp:Label ID="iv_lbl訂購日期" runat="server" Text='<%# Eval("訂購日期") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="請購單位">
                                <ItemTemplate>
                                    <asp:Label ID="iv_lbl請購單位" runat="server" Text='<%# Eval("請購單位") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="成本總計">
                                <ItemTemplate>
                                    <asp:Label ID="iv_lbl成本總計" runat="server" Text='<%# Eval("成本總計") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="訂購總計">
                                <ItemTemplate>
                                    <asp:Label ID="iv_lbl訂購總計" runat="server" Text='<%# Eval("訂購總計") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="販賣總計">
                                <ItemTemplate>
                                    <asp:Label ID="iv_lbl販賣總計" runat="server" Text='<%# Eval("販賣總計") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                          
                            <asp:TemplateField HeaderText="明細">
                            <ItemTemplate>
                                <asp:Button ID="_btn明細" runat="server" Text="明細" OnClick="_btn明細_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
                <td valign="top">
                    <asp:Label ID="iv_lbl退貨明細" runat="server"></asp:Label><asp:GridView ID="GridView4"
                        runat="server" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px"
                        CellPadding="3" CellSpacing="1" Font-Size="Smaller" GridLines="None" OnRowDataBound="GridView4_RowDataBound"
                        ShowFooter="True">
                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                    </asp:GridView>
                    
                    
                <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px"
                        CellPadding="3" CellSpacing="1" Font-Size="Smaller" GridLines="None" 
                        ShowFooter="True">
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
                        <asp:TemplateField HeaderText="金額">
                            <ItemTemplate>
                                <asp:Label ID="Label29" runat="server" Text='<%# Eval("金額")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="販賣價">
                            <ItemTemplate>
                                <asp:Label ID="Label293" runat="server" Text='<%# Eval("販賣價")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="開單人員">
                            <ItemTemplate>
                                <asp:Label ID="Label30" runat="server" Text='<%# Eval("開單人員")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                </asp:GridView>
                </td>
            </tr>
        </table>
        
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
