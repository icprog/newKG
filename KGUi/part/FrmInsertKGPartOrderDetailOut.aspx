<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmInsertKGPartOrderDetailOut.aspx.cs"
    Inherits="KGUi.part.FrmInsertKGPartOrderDetailOut" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>高輊小百貨退貨申請作業</title>

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
                    border-left: lightblue thin solid; width: 238px; border-bottom: lightblue thin solid">
                    <tr bgcolor="#e8eef4">
                        <td colspan="16" style="background-image: url(../Images/table_bg_blue.gif)">
                            <asp:Label ID="Label1" runat="server" BackColor="Transparent" Font-Bold="True" ForeColor="White"
                                Style="position: static" Text="高輊小百貨退貨申請作業" Width="207px"></asp:Label>
                        </td>
                    </tr>
                    <tr bgcolor="#e8eef4">
                        <td style="background-color: #87c5f4">
                            <asp:Label ID="Label3" runat="server" Font-Bold="False" Style="position: static"
                                Text="請購單號" Width="64px"></asp:Label>
                        </td>
                        <td colspan="13" style="background-color: #eaeaea">
                            <asp:TextBox ID="iv_txt請購單號" runat="server" Width="100px"></asp:TextBox>
                        </td>
                        <td colspan="1" style="background-color: #87c5f4">
                            <asp:Label ID="Label5" runat="server" Font-Bold="False" Style="position: static"
                                Text="業代員編" Width="64px"></asp:Label>
                        </td>
                        <td colspan="1" style="background-color: #eaeaea">
                            <asp:TextBox ID="iv_txt業代員編" runat="server" Width="100px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr bgcolor="#e8eef4">
                        <td style="background-color: #87c5f4">
                            <asp:Label ID="Label2224" runat="server" Font-Bold="False" Style="position: static"
                                Text="起始日期" Width="64px"></asp:Label>
                        </td>
                        <td colspan="13" style="background-color: #eaeaea">
                            <asp:TextBox ID="_txtBDate" runat="server" Width="80px" MaxLength="8"></asp:TextBox>&nbsp;
                        </td>
                        <td colspan="1" style="background-color: #87c5f4">
                            <asp:Label ID="Label6" runat="server" Font-Bold="False" Style="position: static"
                                Text="結束日期" Width="64px"></asp:Label>
                        </td>
                        <td colspan="1" style="background-color: #eaeaea">
                            <asp:TextBox ID="_txtEDate" runat="server" Width="80px" MaxLength="8"></asp:TextBox>&nbsp;
                        </td>
                    </tr>
                    <tr bgcolor="#e8eef4">
                        <td colspan="16" style="height: 25px; background-color: #eaeaea">
                            <asp:Button ID="iv_btn查詢" runat="server" OnClick="iv_btn查詢_Click" Text="查詢" Width="74px" />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" BackColor="White"
                    BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1"
                    Font-Size="Smaller" GridLines="None">
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                    <Columns>
                        <asp:TemplateField HeaderText="退貨">
                            <ItemTemplate>
                                <asp:Button ID="iv_btn退貨" runat="server" OnClick="iv_btn退貨_Click" Width="90px" Text="進入退貨流程" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="請購單號">
                            <ItemTemplate>
                                <asp:Label ID="iv_lbl請購單號" runat="server" Text='<%# Eval("請購單號") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="廠商">
                            <ItemTemplate>
                                <asp:Label ID="iv_lbl請購廠商" runat="server" Text='<%# Eval("請購廠商") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="請購日期">
                            <ItemTemplate>
                                <asp:Label ID="iv_lbl請購日期" runat="server" Text='<%# Eval("請購日期") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="引擎號碼">
                            <ItemTemplate>
                                <asp:Label ID="iv_lbl引擎號碼" runat="server" Text='<%# Eval("引擎號碼") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="業代員編">
                            <ItemTemplate>
                                <asp:Label ID="iv_lbl業代員編" runat="server" Text='<%# Eval("業代員編") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="業代姓名">
                            <ItemTemplate>
                                <asp:Label ID="iv_lbl業代姓名" runat="server" Text='<%# Eval("業代姓名") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="業代單位">
                            <ItemTemplate>
                                <asp:Label ID="iv_lbl業代單位" runat="server" Text='<%# Eval("業代單位") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="總計">
                            <ItemTemplate>
                                <asp:Label ID="iv_lbl總計價格" runat="server" Text='<%# Eval("總計價格") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="備註">
                            <ItemTemplate>
                                <asp:Label ID="iv_lbl備註" runat="server" Text='<%# Eval("備註") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
                <asp:Panel ID="iv_pnl退貨畫面" runat="server" Visible="False">
                    &nbsp;<asp:Label ID="Label2" runat="server">請購單號：</asp:Label><asp:Label ID="iv_lbl請購單號2"
                        runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label><br />
                    <table>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label9" runat="server" Text="請購產品清單"></asp:Label>
                            </td>
                            <td align="center">
                            </td>
                            <td colspan="2">
                                <asp:Label ID="Label11" runat="server" Text="要退貨的清單" Width="98px"></asp:Label>
                            </td>
                            <td colspan="1">
                                <asp:Button ID="iv_btn確認退貨" runat="server" OnClick="iv_btn確認退貨_Click" Text="確認退貨" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:ListBox ID="iv_lbx請購產品清單" runat="server" Height="200px" TabIndex="2" Width="220px">
                                </asp:ListBox>
                            </td>
                            <td align="center">
                                <asp:Button ID="Button1" runat="server" TabIndex="4" Text=">" Width="50px" OnClick="Button1_Click" /><br />
                                <br />
                                <asp:Label ID="Label8" runat="server">數量</asp:Label>
                                <asp:TextBox ID="iv_txt數量" runat="server" Width="40px">0</asp:TextBox><br />
                                <br />
                                <asp:Button ID="Button2" runat="server" TabIndex="6" Text="<" Width="50px" OnClick="Button2_Click" /><br />
                                <br />
                            </td>
                            <td colspan="3">
                                <asp:ListBox ID="iv_lbx退貨產品清單" runat="server" Height="200px" TabIndex="3" Width="220px">
                                </asp:ListBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <asp:Label ID="Label13" runat="server">退貨原因：</asp:Label><br />
                                <asp:TextBox ID="iv_txt退貨原因" runat="server" Height="60px" TextMode="MultiLine" Width="260px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
