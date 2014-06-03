<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmInMoney.aspx.cs" Inherits="KGUi.manager.money.FrmInMoney" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>沖帳作業</title>

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
                  <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="_txtBDate" Format="yyyy/MM/dd">
    </cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="_txtEDate" Format="yyyy/MM/dd">
    </cc1:CalendarExtender>
                <table border="1" cellpadding="0" cellspacing="0" bordercolor="#BDCFE1">
                    <tr>
                        <td colspan="2" align="center" bgcolor="#FFD7D7" style="background-image: url(../../Images/table_bg_blue.gif);
                            height: 16px;">
                            <asp:Label ID="Label3" runat="server" Text="沖帳作業" ForeColor="White" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                 <tr >
                        <td >
                            <asp:Label ID="Label7" runat="server" Font-Bold="False" Style="position: static"
                                Text="日期" Width="64px"></asp:Label></td>
                        <td >
                            <asp:TextBox ID="_txtBDate" runat="server" Width="89px"></asp:TextBox>
                        ~
                            <asp:TextBox ID="_txtEDate" runat="server" Width="89px"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="員編"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="_txt員編" runat="server" Width="74px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="_btn查詢" runat="server" Text="查詢" OnClick="_btn查詢_Click" />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Label ID="Label2" runat="server" Text="目前點數:" Font-Bold="True" 
                    ForeColor="Lime"></asp:Label>
                <asp:Label ID="_lbl目前點數" runat="server" Font-Bold="True" ForeColor="Lime"></asp:Label>
                <br />
                <asp:Label ID="Label47" runat="server" Text="應收金額:" Font-Bold="True"></asp:Label>
                <asp:Label ID="_lbl應收金額" runat="server" Font-Bold="True"></asp:Label>
                <br />
                <asp:Label ID="Label48" runat="server" Text="已收金額:" Font-Bold="True" 
                    ForeColor="#FF3300"></asp:Label>
                <asp:Label ID="_lbl已收金額" runat="server" Text="0" Font-Bold="True" 
                    ForeColor="#FF3300"></asp:Label>
                <br />
                <asp:GridView ID="_gvAmt" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="569px">
                    <RowStyle ForeColor="#000066" />
                    <Columns>
                        <asp:TemplateField HeaderText="沖">
                            <ItemTemplate>
                                <asp:CheckBox ID="_chk沖帳" runat="server" OnCheckedChanged="CheckBox_CheckedChanged"
                                    AutoPostBack="True" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="項次">
                            <ItemTemplate>
                                <asp:Label ID="Label21" runat="server" Text='<%# Eval("項次")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="工單號碼">
                            <ItemTemplate>
                                <asp:Label ID="Label26" runat="server" Text='<%# Eval("工單號碼")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="員工編號">
                            <ItemTemplate>
                                <asp:Label ID="Label36" runat="server" Text='<%# Eval("員工編號")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="名稱">
                            <ItemTemplate>
                                <asp:Label ID="Label46" runat="server" Text='<%# Eval("名稱")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="應收帳款">
                            <ItemTemplate>
                                <asp:Label ID="Label27" runat="server" Text='<%# Eval("應收帳款")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="帳款日期">
                            <ItemTemplate>
                                <asp:Label ID="Label47" runat="server" Text='<%# Eval("帳款日期")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
                <br />
                <asp:Button ID="_btn沖帳" runat="server" Text="沖帳" onclick="_btn沖帳_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
