<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmSalesRankReport.aspx.cs"
    Inherits="KGUi.manager.part.FrmSalesRankReport" %>

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
                <table border="1" cellpadding="0" cellspacing="0" bordercolor="#BDCFE1">
                    <tr>
                        <td colspan="2" align="center" bgcolor="#FFD7D7" style="background-image: url(../../Images/table_bg_blue.gif);
                            height: 16px;">
                            <asp:Label ID="Label3" runat="server" Text="小百貨銷售排行榜" ForeColor="White" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="日期"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="_txtBDate" runat="server"></asp:TextBox>
                            ~
                            <asp:TextBox ID="_txtEDate" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="_btn查詢" runat="server" Text="查詢" OnClick="_btn查詢_Click" />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:GridView ID="_gvAmt" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                    Width="769px">
                    <RowStyle ForeColor="#000066" />
                    <Columns>
                        <asp:TemplateField HeaderText="項次">
                            <ItemTemplate>
                                <asp:Label ID="Label21" runat="server" Text='<%# Eval("項次")%>'></asp:Label>
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
                        <asp:TemplateField HeaderText="銷售次數">
                            <ItemTemplate>
                                <asp:Label ID="Label28" runat="server" Text='<%# Eval("銷售次數")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="總銷售金額">
                            <ItemTemplate>
                                <asp:Label ID="Label29" runat="server" Text='<%# Eval("總銷售金額")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <%-- <asp:TemplateField HeaderText="明細">
                        <ItemTemplate>
                        <a href='<%# Eval("明細")%>' rel="facebox" >
                            <img alt="" src="../images/home_63.gif" border="0" /></a>   
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
