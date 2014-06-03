<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmSelectKGPartReportDaily.aspx.cs"
    Inherits="KGUi.manager.part.FrmSelectKGPartReportDaily" %>

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
                    border-left: lightblue thin solid; width: 470px; border-bottom: lightblue thin solid">
                    <tr bgcolor="#e8eef4">
                        <td colspan="14" style="background-image: url(../../Images/table_bg_blue.gif)">
                            <asp:Image ID="Image1" runat="server" Height="11px" ImageUrl="~/Images/icon.gif" />
                            <asp:Label ID="Label1" runat="server" BackColor="Transparent" Font-Bold="True" ForeColor="White"
                                Style="position: static" Text="高輊小百貨訂購日報表查詢" Width="221px"></asp:Label>
                        </td>
                    </tr>
                    <tr bgcolor="#e8eef4">
                        <td style="background-color: #87c5f4">
                            <asp:Label ID="Label5" runat="server" Font-Bold="False" Style="position: static"
                                Text="營業所別" Width="64px"></asp:Label>
                        </td>
                        <td colspan="4" style="background-color: #eaeaea">
                            <asp:DropDownList ID="iv_cbo營業所別" runat="server" Width="120px">
                            </asp:DropDownList>
                        </td>
                        <td colspan="1" style="background-color: #87c5f4">
                            <asp:Label ID="Label8" runat="server" Font-Bold="False" Style="position: static"
                                Text="訂購廠商" Width="64px"></asp:Label>
                        </td>
                        <td colspan="8" style="background-color: #eaeaea">
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
                            <asp:Label ID="Label6" runat="server" Text="訂購日期 起" Width="98px"></asp:Label>
                        </td>
                        <td colspan="4" style="background-color: #eaeaea">
                            <asp:TextBox ID="_txtBDate" runat="server" Width="82px" MaxLength="8" 
                                ></asp:TextBox></td>
                        <td colspan="1" style="background-color: #87c5f4">
                            <asp:Label ID="Label4" runat="server" Text="訂購日期 止" Width="98px"></asp:Label>
                        </td>
                        <td colspan="8" style="background-color: #eaeaea">
                            <asp:TextBox ID="_txtEDate" runat="server" Width="82px" MaxLength="8" 
                                ></asp:TextBox> </td>
                    </tr>
                    <tr bgcolor="#e8eef4">
                        <td colspan="5" style="background-color: #eaeaea">
                            <asp:Button ID="iv_btn報表查詢" runat="server" OnClick="iv_btn報表查詢_Click" Text="報表查詢" />
                        </td>
                        <td colspan="9" style="background-color: #87c5f4">
                            
                        </td>
                    </tr>
                </table>
                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="White"
                    BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" Font-Size="Smaller"
                    GridLines="None" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True">
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" HorizontalAlign="Center" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
