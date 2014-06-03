<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmSelectKGPartReportDetail.aspx.cs"
    Inherits="KGUi.manager.part.FrmSelectKGPartReportDetail" %>

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
                    border-left: lightblue thin solid; width: 470px; border-bottom: lightblue thin solid">
                    <tr bgcolor="#e8eef4">
                        <td colspan="14" style="background-image: url(../../Images/table_bg_blue.gif)">
                            <asp:Label ID="Label1" runat="server" BackColor="Transparent" Font-Bold="True" ForeColor="White"
                                Style="position: static" Text="高輊小百貨訂購明細查詢" Width="221px"></asp:Label>
                        </td>
                    </tr>
                    <tr bgcolor="#e8eef4">
                        <td style="background-color: #87c5f4">
                            <asp:Label ID="Label5" runat="server" Font-Bold="False" Style="position: static"
                                Text="單號" Width="64px"></asp:Label>
                        </td>
                        <td colspan="4" style="background-color: #eaeaea">
                            <asp:TextBox ID="_txt單號" runat="server"></asp:TextBox>
                        </td>
                        <td colspan="1" style="background-color: #87c5f4">
                            <asp:Label ID="Label8" runat="server" Font-Bold="False" Style="position: static"
                                Text="員編" Width="64px"></asp:Label>
                        </td>
                        <td colspan="8" style="background-color: #eaeaea">
                            <asp:TextBox ID="_txt員編" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr bgcolor="#e8eef4">
                        <td style="background-color: #87c5f4">
                            <asp:Label ID="Label6" runat="server" Text="訂購日期 起" Width="98px"></asp:Label>
                        </td>
                        <td colspan="4" style="background-color: #eaeaea">
                            <asp:TextBox ID="_txtBDate" runat="server" Width="82px" MaxLength="8"></asp:TextBox>
                        </td>
                        <td colspan="1" style="background-color: #87c5f4">
                            <asp:Label ID="Label4" runat="server" Text="訂購日期 止" Width="98px"></asp:Label>
                        </td>
                        <td colspan="8" style="background-color: #eaeaea">
                            <asp:TextBox ID="_txtEDate" runat="server" Width="82px" MaxLength="8"></asp:TextBox>
                        </td>
                    </tr>
                    <tr bgcolor="#e8eef4">
                        <td colspan="5" style="background-color: #eaeaea">
                            <asp:Button ID="iv_btn報表查詢" runat="server" OnClick="iv_btn報表查詢_Click" Text="報表查詢" />
                        </td>
                        <td colspan="9" style="background-color: #87c5f4">
                            <asp:RadioButtonList ID="_rdoType" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="營業所" Value = "營業所"></asp:ListItem>
                            <asp:ListItem Text="服務廠" Value = "服務廠"></asp:ListItem>
                            <asp:ListItem Text="全部" Value = "全部" Selected="True"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
                <br>
                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="White"
                    BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" Font-Size="Smaller"
                    GridLines="None" ShowFooter="True" OnRowDataBound="GridView1_RowDataBound">
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" HorizontalAlign="Center" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
