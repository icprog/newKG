<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmSelectKGPointDetail.aspx.cs" Inherits="KGUi.manager.point.FrmSelectKGPointDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
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
                    <table id="TABLE1" style="border-right: lightblue thin solid; border-top: lightblue thin solid;
                        border-left: lightblue thin solid; width: 365px; border-bottom: lightblue thin solid">
                        <tr bgcolor="#e8eef4">
                            <td colspan="12" style="background-image: url(../Images/table_bg_blue.gif)">
                                <asp:Image ID="Image1" runat="server" Height="11px" ImageUrl="~/Images/icon.gif" />&nbsp;
                                <asp:Label ID="Label2" runat="server" BackColor="Transparent" Font-Bold="True" ForeColor="White"
                                    Style="position: static" Text="點數使用紀錄查詢作業" Width="174px"></asp:Label></td>
                        </tr>
                        <tr bgcolor="#e8eef4">
                            <td style="background-color: #87c5f4">
                                <asp:Label ID="Label1" runat="server" Font-Bold="False" Style="position: static"
                                    Text="所別" Width="64px"></asp:Label></td>
                            <td colspan="4" style="background-color: #eaeaea">
                                <asp:DropDownList ID="iv_cbo所別" runat="server" Width="120px">
                                </asp:DropDownList></td>
                            <td colspan="1" style="background-color: #87c5f4">
                                <asp:Label ID="Label4" runat="server" Font-Bold="False" Style="position: static"
                                    Text="業代員編" Width="64px"></asp:Label></td>
                            <td colspan="6" style="background-color: #eaeaea">
                                <asp:TextBox ID="iv_txt業代員編" runat="server" Width="110px"></asp:TextBox></td>
                        </tr>
                        <tr bgcolor="#e8eef4">
                            <td style="background-color: #87c5f4">
                                <asp:Label ID="Label3" runat="server" Font-Bold="False" Style="position: static"
                                    Text="匯入方式" Width="64px"></asp:Label></td>
                            <td colspan="4" style="background-color: #eaeaea"><asp:DropDownList ID="iv_cbo匯入方式" runat="server" Width="120px">
                            </asp:DropDownList></td>
                            <td colspan="1" style="background-color: #87c5f4">
                                <asp:Label ID="Label7" runat="server" Font-Bold="False" Style="position: static"
                                    Text="入帳銀行" Width="64px"></asp:Label></td>
                            <td colspan="6" style="background-color: #eaeaea">
                                <asp:DropDownList ID="iv_cbo入帳銀行" runat="server" Width="120px">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>合庫三民</asp:ListItem>
                                    <asp:ListItem>台新銀行</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr bgcolor="#e8eef4">
                            <td style="background-color: #87c5f4">
                                <asp:Label ID="Label5" runat="server" Font-Bold="False" Style="position: static"
                                    Text="匯入日期 起" Width="92px"></asp:Label></td>
                            <td colspan="4" style="background-color: #eaeaea">
                                <asp:TextBox ID="iv_txt匯入日期起" runat="server" Width="82px" MaxLength="8" 
                                    ></asp:TextBox>&nbsp;</td>
                            <td colspan="1" style="background-color: #87c5f4">
                                <asp:Label ID="Label6" runat="server" Font-Bold="False" Style="position: static"
                                    Text="匯入日期 止" Width="92px"></asp:Label></td>
                            <td colspan="6" style="background-color: #eaeaea">
                                <asp:TextBox ID="iv_txt匯入日期止" runat="server" Width="82px" MaxLength="8" 
                                    ></asp:TextBox>&nbsp;</td>
                        </tr>
                        <tr bgcolor="#e8eef4">
                            <td colspan="12" style="height: 26px; background-color: #eaeaea">
                                <asp:Button ID="iv_btn查詢" runat="server" OnClick="iv_btn查詢_Click" Text="查詢" Width="84px" />
                                <asp:Button ID="iv_btn匯出" runat="server" OnClick="iv_btn匯出_Click" Text="匯出" Width="84px" /></td>
                        </tr>
                    </table>
                     <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="iv_txt匯入日期起"
                    Format="yyyy/MM/dd">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="iv_txt匯入日期止"
                    Format="yyyy/MM/dd">
                </cc1:CalendarExtender>
                    &nbsp;<br />
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="White"
                        BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" Font-Size="Smaller"
                        GridLines="None" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True" AutoGenerateColumns="False" EnableModelValidation="True" DataKeyNames="f_id">
                        <Columns>
                            <asp:TemplateField HeaderText="項次">
                                <ItemTemplate>
                                    <asp:Label ID="lbf_id" runat="server" Text='<%# Bind("f_id") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="所別">
                                <ItemTemplate>
                                    <asp:Label ID="lbBranch" runat="server" Text='<%# Bind("Branch所別") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="員編">
                                <ItemTemplate>
                                    <asp:Label ID="lbf_Smid" runat="server" Text='<%# Bind("f_Smid業代員編") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="姓名">
                                <ItemTemplate>
                                    <asp:Label ID="lbf_Name" runat="server" Text='<%# Bind("f_Name業代姓名") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="匯入點數">
                                <ItemTemplate>
                                    <asp:Label ID="lbf_ImportPoint" runat="server" Text='<%# Bind("f_ImportPoint匯入點數") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="匯入日期">
                                <ItemTemplate>
                                    <asp:Label ID="lbf_ImportDate" runat="server" Text='<%# Bind("f_ImportDate匯入日期") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="匯入者員編">
                                <ItemTemplate>
                                    <asp:Label ID="lbf_ImportSmid" runat="server" Text='<%# Bind("f_ImportSmid匯入人員員編") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="匯入者姓名">
                                <ItemTemplate>
                                    <asp:Label ID="lbf_ImportName" runat="server" Text='<%# Bind("f_ImportName匯入人員姓名") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="匯入方式">
                                <ItemTemplate>
                                    <asp:Label ID="lbf_ImportType" runat="server" Text='<%# Bind("f_ImportType匯入方式") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="刷卡銀行">
                                <ItemTemplate>
                                    <asp:Label ID="lbf_PayBank" runat="server" Text='<%# Bind("f_PayBank刷卡銀行") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="手續費">
                                <ItemTemplate>
                                    <asp:Label ID="lbf_BankCharge" runat="server" Text='<%# Bind("f_BankCharge手續費") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="發票號碼">
                                <ItemTemplate>
                                    <asp:Label ID="lbf_InvoiceNo" runat="server" Text='<%# Bind("f_InvoiceNo發票號碼") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="入帳銀行">
                                <ItemTemplate>
                                    <asp:Label ID="lbf_InMoneyBank" runat="server" Text='<%# Bind("f_InMoneyBank入帳銀行") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="備註">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtMemo" runat="server" Text='<%# Bind("f_Memo") %>' AutoPostBack="True" OnTextChanged="txtMemo_TextChanged"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                    </asp:GridView>
                    &nbsp;
                </ContentTemplate>
            </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
