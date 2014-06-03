<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmCheckCarSale.aspx.cs"
    Inherits="KGUi.carsale.FrmCheckCarSale" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>特販審核</title>

    <script type="text/javascript">

        function pageLoad() {
        }
    
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <table>
            <tr>
                <td valign="top">
                 <asp:Label ID="Label14" runat="server" Text="所別:"></asp:Label>
                    <asp:DropDownList ID="_cbo所別" runat="server" Width="70px">
                        <asp:ListItem Text="" Value=""></asp:ListItem>
                        <asp:ListItem Text="F03" Value="F03"></asp:ListItem>
                        <asp:ListItem Text="F04" Value="F04"></asp:ListItem>
                        <asp:ListItem Text="F05" Value="F05"></asp:ListItem>
                        <asp:ListItem Text="F07" Value="F07"></asp:ListItem>
                        <asp:ListItem Text="F08" Value="F08"></asp:ListItem>
                        <asp:ListItem Text="F09" Value="F09"></asp:ListItem>
                        <asp:ListItem Text="F10" Value="F10"></asp:ListItem>
                        <asp:ListItem Text="F11" Value="F11"></asp:ListItem>
                        <asp:ListItem Text="F12" Value="F12"></asp:ListItem>
                        <asp:ListItem Text="F13" Value="F13"></asp:ListItem>
                        <asp:ListItem Text="F14" Value="F14"></asp:ListItem>
                        <asp:ListItem Text="F15" Value="F15"></asp:ListItem>
                        <asp:ListItem Text="F16" Value="F16"></asp:ListItem>
                        <asp:ListItem Text="F17" Value="F17"></asp:ListItem>
                        <asp:ListItem Text="F18" Value="F18"></asp:ListItem>
                        <asp:ListItem Text="F20" Value="F20"></asp:ListItem>
                        <asp:ListItem Text="F22" Value="F22"></asp:ListItem>
                        <asp:ListItem Text="F23" Value="F23"></asp:ListItem>
                        <asp:ListItem Text="F24" Value="F24"></asp:ListItem>
                        <asp:ListItem Text="F27" Value="F27"></asp:ListItem>
                        <asp:ListItem Text="F52" Value="F52"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="_btn查詢" runat="server" Text="查詢" OnClick="_btn查詢_Click" />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:GridView ID="_gvOrder" runat="server" AutoGenerateColumns="False" BackColor="White"
                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="366px">
                        <RowStyle ForeColor="#000066" />
                        <Columns>
                            <asp:TemplateField HeaderText="項次">
                                <ItemTemplate>
                                    <asp:Label ID="Label21" runat="server" Text='<%# Eval("項次")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="身分證字號">
                                <ItemTemplate>
                                    <asp:Label ID="Label20" runat="server" Text='<%# Eval("身分證字號")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="客戶姓名">
                                <ItemTemplate>
                                    <asp:Label ID="Label26" runat="server" Text='<%# Eval("客戶姓名")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText="狀態">
                        <ItemTemplate>
                            <asp:Label ID="Label27" runat="server" Text='<%# Eval("狀態")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="審核">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("審核")%>' Visible="false"></asp:Label>
                                    <asp:Button ID="_btn審核" runat="server" Text="審" OnClick="_btn審核_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                </td>
                <td valign="top">
                    <asp:Panel ID="Panel1" runat="server" Visible="false">
                        <table>
                            <tr>
                                <td colspan="2" align="right">
                                    <asp:Button ID="_btn詳細資料" runat="server" Text="詳細資料" Height="32px" OnClick="_btn詳細資料_Click"
                                        Width="123px" />
                                </td>
                            </tr>
                            <tr>
                                <td style="background-color: #87c5f4;">
                                    <asp:Label ID="Label7" runat="server" Text="業代說明"></asp:Label>
                                </td>
                                <td style="background-color: #eaeaea">
                                    <asp:TextBox ID="_txt業代說明" runat="server" Height="81px" TextMode="MultiLine" Width="319px"
                                        Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                            <%-- <tr>
                                    <td style="background-color: #87c5f4;">
                                        <asp:Label ID="Label8" runat="server" Text="課長說明"></asp:Label>
                                    </td>
                                    <td style="background-color: #eaeaea">
                                        <asp:TextBox ID="_txt課長說明" runat="server"  Height="81px" TextMode="MultiLine" 
                                            Width="319px" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>--%>
                            <tr>
                                <td style="background-color: #87c5f4;">
                                    <asp:Label ID="Label9" runat="server" Text="所長說明"></asp:Label>
                                </td>
                                <td style="background-color: #eaeaea">
                                    <asp:TextBox ID="_txt所長說明" runat="server" Height="81px" TextMode="MultiLine" Width="319px"
                                        Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label11" runat="server" Text="報備對象"></asp:Label>
                                </td>
                                <td style="background-color: #eaeaea">
                                    <asp:Label ID="_lbl對象" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="_lblCutid" runat="server" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="background-color: #87c5f4;">
                                    <asp:Label ID="Label12" runat="server" Text="是否到部長"></asp:Label>
                                    <br />
                                    <asp:Label ID="Label13" runat="server" Text="超過權限" Font-Size="10pt" ForeColor="Red"></asp:Label>
                                </td>
                                <td style="background-color: #eaeaea">
                                    <asp:CheckBoxList ID="_chklist是否到部長" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="是" Value="Y"></asp:ListItem>
                                        <asp:ListItem Text="否" Value="N"></asp:ListItem>
                                    </asp:CheckBoxList>
                                    <asp:Label ID="_lbl部長" runat="server" Text="部長"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="background-color: #87c5f4;">
                                    <asp:Label ID="Label2" runat="server" Text="批示"></asp:Label>
                                </td>
                                <td style="background-color: #eaeaea">
                                    <asp:CheckBoxList ID="_chklist批示" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="核准" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="不核准" Value="3"></asp:ListItem>
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="_txtDate"
                                Format="yyyy-MM-dd">
                            </cc1:CalendarExtender>
                            <tr>
                                <td style="background-color: #87c5f4;">
                                    <asp:Label ID="Label3" runat="server" Text="批示日期"></asp:Label>
                                </td>
                                <td style="background-color: #eaeaea">
                                    <asp:TextBox ID="_txtDate" runat="server" Width="100px"></asp:TextBox>
                                    <asp:Label ID="Label8" runat="server" Text="申請日:"></asp:Label>
                                    <asp:Label ID="_lbl申請日" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="background-color: #87c5f4;">
                                    <asp:Label ID="Label4" runat="server" Text="支援金額"></asp:Label>
                                </td>
                                <td style="background-color: #eaeaea">
                                    <asp:TextBox ID="_txt支援金額" runat="server" Width="76px"></asp:TextBox>
                                    <asp:Label ID="Label27" runat="server" Text="常用金額:"></asp:Label>
                                    &nbsp;<asp:Button ID="_btn1500" runat="server" Text="1500" OnClick="_btn1500_Click" />
                                    &nbsp;<asp:Button ID="_btn2500" runat="server" Text="2500" OnClick="_btn1500_Click" />
                                    &nbsp;<asp:Button ID="_btn4500" runat="server" Text="4500" OnClick="_btn1500_Click" />
                                    &nbsp;<asp:Button ID="_btn6000" runat="server" Text="6000" OnClick="_btn1500_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td style="background-color: #87c5f4;">
                                    <asp:Label ID="Label5" runat="server" Text="非一般申請種類"></asp:Label>
                                </td>
                                <td style="background-color: #eaeaea">
                                    <asp:CheckBoxList ID="_chklist非一般申請種類" runat="server">
                                        <asp:ListItem Text="大口批售" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="僅核發交車獎金" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="員工購車" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="全不計" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="一般" Value="5"></asp:ListItem>
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr>
                                <td style="background-color: #87c5f4;">
                                    <asp:Label ID="Label6" runat="server" Text="年終年節"></asp:Label>
                                </td>
                                <td style="background-color: #eaeaea">
                                    <asp:CheckBoxList ID="_chklist特別獎勵" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="准" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="不准" Value="1"></asp:ListItem>
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr>
                                <td style="background-color: #87c5f4;">
                                    <asp:Label ID="Label10" runat="server" Text="車輛部說明"></asp:Label>
                                </td>
                                <td style="background-color: #eaeaea">
                                    <asp:TextBox ID="_txt車輛部說明" runat="server" Height="81px" TextMode="MultiLine" Width="319px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="_btn儲存" runat="server" Text="儲存" Height="35px" OnClick="_btn儲存_Click"
                                        Width="80px" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
