<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmSelectPrintKGPartOrder.aspx.cs"
    Inherits="KGUi.part.FrmSelectPrintKGPartOrder" %>

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
                    border-left: lightblue thin solid; width: 460px; border-bottom: lightblue thin solid">
                    <tr bgcolor="#e8eef4">
                        <td colspan="12" style="background-image: url(../Images/table_bg_blue.gif)">
                            <asp:Label ID="Label1" runat="server" BackColor="Transparent" Font-Bold="True" ForeColor="White"
                                Style="position: static" Text="高輊小百貨請購單列印作業" Width="214px"></asp:Label>
                        </td>
                    </tr>
                    <tr bgcolor="#e8eef4">
                        <td style="background-color: #87c5f4">
                            <asp:Label ID="Label5" runat="server" Font-Bold="False" Style="position: static"
                                Text="請購單號" Width="64px"></asp:Label>
                        </td>
                        <td colspan="4" style="background-color: #eaeaea">
                            <asp:TextBox ID="_txt請購編號" runat="server" Width="100px"></asp:TextBox>
                        </td>
                        <td colspan="1" style="background-color: #87c5f4">
                            <asp:Label ID="Label8" runat="server" Font-Bold="False" Style="position: static"
                                Text="訂購廠商" Width="64px"></asp:Label>
                        </td>
                        <td colspan="6" style="background-color: #eaeaea">
                            <asp:DropDownList ID="_cbo廠商" runat="server" Width="100px">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="亙長" Value="KC"></asp:ListItem>
                                <asp:ListItem Text="劦大" Value="LD"></asp:ListItem>
                                <asp:ListItem Text="惠明" Value="HM"></asp:ListItem>
                                <asp:ListItem Text="PDS" Value="PDS"></asp:ListItem>
                                <asp:ListItem Text="高輊" Value="KG"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr bgcolor="#e8eef4">
                        <td style="background-color: #87c5f4">
                            <asp:Label ID="Label6" runat="server" Text="請購日期 起" Width="98px"></asp:Label>
                        </td>
                        <td colspan="4" style="background-color: #eaeaea">
                            <asp:TextBox ID="_txtBDate" runat="server" Width="82px" MaxLength="8" ></asp:TextBox>
                        </td>
                        <td colspan="1" style="background-color: #87c5f4">
                            <asp:Label ID="Label4" runat="server" Text="請購日期 止" Width="98px"></asp:Label>
                        </td>
                        <td colspan="6" style="background-color: #eaeaea">
                            <asp:TextBox ID="_txtEDate" runat="server" Width="82px" MaxLength="8" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr bgcolor="#e8eef4">
                        <td colspan="12" style="background-color: #eaeaea">
                            <asp:Button ID="iv_btn查詢請購單號" runat="server" OnClick="iv_btn查詢請購單號_Click" Text="查詢請購單號" />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Label ID="Label2" runat="server" Text="總計:" ForeColor="Red" ></asp:Label>
                <asp:Label ID="_lblTotal" runat="server" Text="0" ></asp:Label>
                <br />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" BackColor="White"
                    BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1"
                    Font-Size="Smaller" GridLines="None">
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" HorizontalAlign="Center" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                    <Columns>
                        <asp:TemplateField HeaderText="列印">
                            <ItemTemplate>
                                <asp:Label ID="iv_lblEID" runat="server" Text='<%# Eval("EID") %>' Visible="False"></asp:Label>
                                <asp:Button ID="_btn列印" runat="server" OnClick="_btn列印_Click" Text="列印" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="廠商">
                            <ItemTemplate>
                                <asp:Label ID="iv_lbl廠商" runat="server" Text='<%# Eval("廠商") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="日期">
                            <ItemTemplate>
                                <asp:Label ID="iv_lbl日期" runat="server" Text='<%# Eval("日期") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="員編">
                            <ItemTemplate>
                                <asp:Label ID="iv_lbl員編" runat="server" Text='<%# Eval("員編") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="姓名">
                            <ItemTemplate>
                                <asp:Label ID="iv_lbl姓名" runat="server" Text='<%# Eval("姓名") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="單位">
                            <ItemTemplate>
                                <asp:Label ID="iv_lbl單位" runat="server" Text='<%# Eval("單位") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="總計金額">
                            <ItemTemplate>
                                <asp:Label ID="iv_lbl總計金額" runat="server" Text='<%# Eval("總計金額") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="備註">
                            <ItemTemplate>
                                <asp:Label ID="iv_lbl備註" runat="server" Text='<%# Eval("備註") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
