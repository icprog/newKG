<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmLNProjectReport.aspx.cs"
    Inherits="KGUi.manager.FrmLNProjectReport" %>

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
                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="_txtBClose"
                    Format="yyyy/MM/dd">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="_txtEClose"
                    Format="yyyy/MM/dd">
                </cc1:CalendarExtender>
                <table border="1" cellpadding="0" cellspacing="0" bordercolor="#BDCFE1">
                    <tr>
                        <td colspan="2" align="center" bgcolor="#FFD7D7" style="background-image: url(../Images/table_bg_blue.gif);
                            height: 16px;">
                            <asp:Label ID="Label3" runat="server" Text="亮新專案招攬明細" ForeColor="White" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="開單日期"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="_txtBDate" runat="server"></asp:TextBox>
                            ~
                            <asp:TextBox ID="_txtEDate" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="完工日期"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="_txtBClose" runat="server"></asp:TextBox>
                            ~
                            <asp:TextBox ID="_txtEClose" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="據點"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="_ddl據點" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="是否招攬"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="_rdo是否招攬" runat="server" 
                                RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Text="全部" Value=""></asp:ListItem>
                            <asp:ListItem Text="是" Value="Y"></asp:ListItem>
                            <asp:ListItem Text="否" Value="N"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="是否完工"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="_rdoisClose" runat="server" 
                                RepeatDirection="Horizontal">
                                <asp:ListItem Value="" Selected="True">全部</asp:ListItem>
                                <asp:ListItem Value="Y">是</asp:ListItem>
                                <asp:ListItem Value="N">否</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="洗車別"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="_rdo洗車別" runat="server" 
                                RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Text="亮新" Value=""></asp:ListItem>
                            <asp:ListItem Text="小美容" Value="A"></asp:ListItem>
                            <asp:ListItem Text="覆膜" Value="B"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="_btn查詢" runat="server" Text="查詢" OnClick="_btn查詢_Click" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="_btn匯出" runat="server" OnClick="_btn匯出_Click" Text="匯出" />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:GridView ID="_gvAmt" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                    <RowStyle ForeColor="#000066" />
                    <Columns>
                        <asp:TemplateField HeaderText="項次">
                            <ItemTemplate>
                                <asp:Label ID="Label26" runat="server" Text='<%# Eval("項次")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="完工日期">
                            <ItemTemplate>
                                <asp:Label ID="Label27" runat="server" Text='<%# Eval("完工日期")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="工單單號">
                            <ItemTemplate>
                                <asp:Label ID="Label28" runat="server" Text='<%# Eval("工單單號")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="引擎號碼">
                            <ItemTemplate>
                                <asp:Label ID="Label38" runat="server" Text='<%# Eval("引擎號碼")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="施工代號">
                            <ItemTemplate>
                                <asp:Label ID="Label48" runat="server" Text='<%# Eval("施工代號")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="金額">
                            <ItemTemplate>
                                <asp:Label ID="Label58" runat="server" Text='<%# Eval("金額")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="招攬單位">
                            <ItemTemplate>
                                <asp:Label ID="Label68" runat="server" Text='<%# Eval("招攬單位")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="招攬人員">
                            <ItemTemplate>
                                <asp:Label ID="Label78" runat="server" Text='<%# Eval("招攬人員")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="員編">
                            <ItemTemplate>
                                <asp:Label ID="Label88" runat="server" Text='<%# Eval("員編")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="獎金">
                            <ItemTemplate>
                                <asp:Label ID="Label98" runat="server" Text='<%# Eval("獎金")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="開單據點">
                            <ItemTemplate>
                                <asp:Label ID="Label29" runat="server" Text='<%# Eval("開單據點")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="開單人員">
                            <ItemTemplate>
                                <asp:Label ID="Label219" runat="server" Text='<%# Eval("開單人員")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="保險公司">
                            <ItemTemplate>
                                <asp:Label ID="Label220" runat="server" Text='<%# Eval("保險公司")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
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
