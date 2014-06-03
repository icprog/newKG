<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmSelectKGPartOrderDetailOutAdmin.aspx.cs"
    Inherits="KGUi.manager.part.FrmSelectKGPartOrderDetailOutAdmin" %>

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
                    border-left: lightblue thin solid; width: 223px; border-bottom: lightblue thin solid">
                    <tr bgcolor="#e8eef4">
                        <td colspan="18" style="background-image: url(../../Images/table_bg_blue.gif)">
                            <asp:Label ID="Label1" runat="server" BackColor="Transparent" Font-Bold="True" ForeColor="White"
                                Style="position: static" Text="小百貨確認退貨作業" Width="158px"></asp:Label>
                        </td>
                    </tr>
                    <tr bgcolor="#e8eef4">
                        <td style="background-color: #87c5f4">
                            <asp:Label ID="Label3" runat="server" Font-Bold="False" Style="position: static"
                                Text="請購單號" Width="64px"></asp:Label>
                        </td>
                        <td colspan="15" style="background-color: #eaeaea">
                            <asp:TextBox ID="iv_txt請購單號" runat="server" Width="100px"></asp:TextBox>
                        </td>
                        <td colspan="1" style="background-color: #87c5f4">
                            <asp:Label ID="Label6" runat="server" Font-Bold="False" Style="position: static"
                                Text="退貨所別" Width="64px"></asp:Label>
                        </td>
                        <td colspan="1" style="background-color: #eaeaea">
                            <asp:DropDownList ID="iv_cbo退貨所別" runat="server" Width="120px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr bgcolor="#e8eef4">
                        <td style="background-color: #87c5f4">
                            <asp:Label ID="Label2" runat="server" Font-Bold="False" Style="position: static"
                                Text="退貨日期 起" Width="88px"></asp:Label>
                        </td>
                        <td colspan="15" style="background-color: #eaeaea">
                            <asp:TextBox ID="_txtBDate" runat="server" Width="70px" MaxLength="10"></asp:TextBox>&nbsp;
                        </td>
                        <td colspan="1" style="background-color: #87c5f4">
                            <asp:Label ID="Label5" runat="server" Font-Bold="False" Style="position: static"
                                Text="退貨日期止" Width="94px"></asp:Label>
                        </td>
                        <td colspan="1" style="background-color: #eaeaea">
                            <asp:TextBox ID="_txtEDate" runat="server" Width="70px" MaxLength="10"></asp:TextBox>
                        </td>
                    </tr>
                    <tr bgcolor="#e8eef4">
                        <td colspan="18" style="height: 25px; background-color: #eaeaea">
                            <asp:Button ID="iv_btn查詢" runat="server" OnClick="iv_btn查詢_Click" Text="尚未確認記錄查詢"
                                Width="153px" />
                            <asp:Button ID="iv_btn完成退貨記錄查詢" runat="server" Text="完成退貨記錄查詢" Width="138px" OnClick="iv_btn完成退貨記錄查詢_Click" />
                        </td>
                    </tr>
                </table>
                <asp:Label ID="iv_lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>&nbsp;
                <br />
                <asp:Panel ID="iv_pnl查詢結果" runat="server" Visible="False">
                    <asp:Button ID="iv_btn確認退貨" runat="server" OnClick="iv_btn確認退貨_Click" Text="確認退貨"
                        Width="76px" /><br />
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" BackColor="White"
                        BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1"
                        Font-Size="Smaller" GridLines="None">
                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                        <Columns>
                            <asp:TemplateField HeaderText="確認">
                                <ItemTemplate>
                                    <asp:CheckBox ID="iv_chk確認" runat="server" />
                                    <asp:Label ID="iv_lblID" runat="server" Text='<%# Eval("確認") %>' Visible="False"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="請購單號">
                                <ItemTemplate>
                                    <asp:Label ID="iv_lbl請購單號" runat="server" Text='<%# Eval("請購單號") %>' Visible='<%# Convert.ToBoolean(Eval("Visible"))%>'>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="退貨日期">
                                <ItemTemplate>
                                    <asp:Label ID="iv_lbl退貨日期" runat="server" Text='<%# Eval("退貨日期") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="員編">
                                <ItemTemplate>
                                    <asp:Label ID="iv_lbl業代員編" runat="server" Text='<%# Eval("業代員編") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="姓名">
                                <ItemTemplate>
                                    <asp:Label ID="iv_lbl業代姓名" runat="server" Text='<%# Eval("業代姓名") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="單位">
                                <ItemTemplate>
                                    <asp:Label ID="iv_lbl業代單位" runat="server" Text='<%# Eval("業代單位") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="產品編號">
                                <ItemTemplate>
                                    <asp:Label ID="iv_lbl產品編號" runat="server" Text='<%# Eval("產品編號") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="產品名稱">
                                <ItemTemplate>
                                    <asp:Label ID="iv_lbl產品名稱" runat="server" Text='<%# Eval("產品名稱") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="單價">
                                <ItemTemplate>
                                    <asp:Label ID="iv_lbl單價" runat="server" Text='<%# Eval("單價") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="數量">
                                <ItemTemplate>
                                    <asp:Label ID="iv_lbl退貨數量" runat="server" Text='<%# Eval("退貨數量") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="總計">
                                <ItemTemplate>
                                    <asp:Label ID="iv_lbl總計" runat="server" Text='<%# Eval("總計") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="退貨原因">
                                <ItemTemplate>
                                    <asp:Label ID="iv_lbl退貨原因" runat="server" Text='<%# Eval("退貨原因") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
                <br />
                <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="White"
                    BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" Font-Size="Smaller"
                    GridLines="None">
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                </asp:GridView>
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
