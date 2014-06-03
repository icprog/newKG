<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmSelectKGPartOrderDetailOut.aspx.cs"
    Inherits="KGUi.part.FrmSelectKGPartOrderDetailOut" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>高輊小百貨退貨記錄修改查詢列印作業</title>

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
                <cc1:calendarextender id="CalendarExtender1" runat="server" targetcontrolid="_txtBDate"
                    format="yyyy/MM/dd">
                </cc1:calendarextender>
                <cc1:calendarextender id="CalendarExtender2" runat="server" targetcontrolid="_txtEDate"
                    format="yyyy/MM/dd">
                </cc1:calendarextender>
                <table id="Table2" style="border-right: lightblue thin solid; border-top: lightblue thin solid;
                    border-left: lightblue thin solid; width: 450px; border-bottom: lightblue thin solid">
                    <tr bgcolor="#e8eef4">
                        <td colspan="16" style="background-image: url(../Images/table_bg_blue.gif)">
                            <asp:Label ID="Label1" runat="server" BackColor="Transparent" Font-Bold="True" ForeColor="White"
                                Style="position: static" Text="高輊小百貨退貨記錄修改查詢列印作業" Width="297px"></asp:Label>
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
                                Text="退貨日期 起"></asp:Label>
                        </td>
                        <td colspan="13" style="background-color: #eaeaea">
                            <asp:TextBox ID="_txtBDate" runat="server" Width="80px" MaxLength="8"></asp:TextBox>&nbsp;
                        </td>
                        <td colspan="1" style="background-color: #87c5f4">
                            <asp:Label ID="Label6" runat="server" Font-Bold="False" Style="position: static"
                                Text="退貨日期 止"></asp:Label>
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
                <asp:Label ID="iv_lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>
                <asp:Panel ID="iv_pnl查詢結果" runat="server" Visible="False">
                    <asp:Button ID="iv_btn取消退貨" runat="server" Text="取消退貨" Width="76px" OnClick="iv_btn取消退貨_Click" /><br />
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" BackColor="White"
                        BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1"
                        Font-Size="Smaller" GridLines="None">
                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" HorizontalAlign="Center" />
                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                        <Columns>
                            <asp:TemplateField HeaderText="取消">
                                <ItemTemplate>
                                    <asp:CheckBox ID="iv_chk取消" runat="server" />
                                    <asp:Label ID="iv_lblID" runat="server" Text='<%# Eval("id") %>' Visible="False"></asp:Label>
                                    <asp:Label ID="iv_lblEID" runat="server" Text='<%# Eval("EID") %>' Visible="False"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="列印退貨單">
                                <ItemTemplate>
                                    <asp:Button ID="iv_btn列印" runat="server" Text="列印" OnClick="iv_btn列印_Click" Visible='<%# Convert.ToBoolean(Eval("Visible")) %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="請購單號">
                                <ItemTemplate>
                                    <asp:Label ID="iv_lbl請購單號" runat="server" Text='<%# Eval("請購單號") %>'></asp:Label>
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
