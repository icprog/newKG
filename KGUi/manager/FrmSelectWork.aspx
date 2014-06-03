<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmSelectWork.aspx.cs"
    Inherits="KGUi.manager.FrmSelectWork" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>未命名頁面</title>
    <link href="../css/facebox.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../css/faceplant.css" media="screen" rel="stylesheet" type="text/css" />

    <script src="../js/jquery.js" type="text/javascript"></script>

    <script src="../js/facebox.js" type="text/javascript"></script>

    <script type="text/javascript">
    jQuery(document).ready(function($) {
      $('a[rel*=facebox]').facebox({
        loading_image : '../images/facebook/loading.gif',
        close_image   : '../images/facebook/closelabel.gif'
      }) 
    })
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptLocalization="False" EnableScriptGlobalization="false">
    </asp:ScriptManager>
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="_txtBDate" Format="yyyy/MM/dd">
    </cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="_txtEDate" Format="yyyy/MM/dd">
    </cc1:CalendarExtender>
    <table border="1" cellpadding="0" cellspacing="0" bordercolor="#BDCFE1">
        <tr>
            <td colspan="2" align="center" bgcolor="#FFD7D7" style="background-image: url(../Images/table_bg_blue.gif);
                height: 16px;">
                <asp:Label ID="Label3" runat="server" Text="工單查詢" ForeColor="White" Font-Bold="True"></asp:Label>
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
                <asp:Label ID="Label1" runat="server" Text="工單號碼"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="_txt工單號碼" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="所別"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="_ddl所別" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="是否完工"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="_rdo是否完工" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="Y" Value="Y"></asp:ListItem>
                    <asp:ListItem Text="N" Value="N"></asp:ListItem>
                    <asp:ListItem Text="ALL" Value="ALL" Selected="True"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="工單類型"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="_ddl工單類型" runat="server">
                    <asp:ListItem Text="" Value=""></asp:ListItem>
                    <asp:ListItem Text="新車" Value="新車"></asp:ListItem>
                    <asp:ListItem Text="一般" Value="一般"></asp:ListItem>
                    <asp:ListItem Text="保險" Value="保險"></asp:ListItem>
                    <asp:ListItem Text="員工" Value="員工"></asp:ListItem>
                    <asp:ListItem Text="試乘" Value="試乘"></asp:ListItem>
                    <asp:ListItem Text="購車周年" Value="購車周年"></asp:ListItem>
                    
                    
                </asp:DropDownList>
            &nbsp;
                <asp:CheckBox ID="_chk服務廠" runat="server" Text="服務廠" />
                 <asp:CheckBox ID="_chkD00" runat="server" Text="和榮" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="是否招攬"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="_rdo是否招攬" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="Y" Value="Y"></asp:ListItem>
                    <asp:ListItem Text="N" Value="N"></asp:ListItem>
                    <asp:ListItem Text="ALL" Value="" Selected="True"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label8" runat="server" Text="車牌或引擎"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="_txt車牌或引擎" runat="server"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="_btn查詢" runat="server" Text="查詢" OnClick="_btn查詢_Click" />
                &nbsp;
                <asp:Button ID="_btn匯出" runat="server" Text="匯出" onclick="_btn匯出_Click" />
            </td>
        </tr>
    </table>
    <br />
    <asp:GridView ID="_gvWork" runat="server" AutoGenerateColumns="False" BackColor="White"
        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
        <RowStyle ForeColor="#000066" />
        <Columns>
            <asp:TemplateField HeaderText="項次">
                <ItemTemplate>
                    <asp:Label ID="Label21" runat="server" Text='<%# Eval("項次")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="所別">
                <ItemTemplate>
                    <asp:Label ID="Label11" runat="server" Text='<%# Eval("所別")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="工單號碼" >
                <ItemTemplate>
                    <asp:Label ID="Label26" runat="server" Text='<%# Eval("工單號碼")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="引擎號碼" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="Label27" runat="server" Text='<%# Eval("引擎號碼")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="顧客名稱">
                <ItemTemplate>
                    <asp:Label ID="Label28" runat="server" Text='<%# Eval("顧客名稱")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="洗車種類">
                <ItemTemplate>
                    <asp:Label ID="Label29" runat="server" Text='<%# Eval("洗車種類")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="金額">
                <ItemTemplate>
                    <asp:Label ID="Label30" runat="server" Text='<%# Eval("金額")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="開單日期" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="Label31" runat="server" Text='<%# Eval("開單日期")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="完工日期">
                <ItemTemplate>
                    <asp:Label ID="Label41" runat="server" Text='<%# Eval("完工日")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="工單類型" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="Label32" runat="server" Text='<%# Eval("工單類型")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="招攬人員">
                <ItemTemplate>
                    <asp:Label ID="Label33" runat="server" Text='<%# Eval("招攬人員")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="開單人員">
                <ItemTemplate>
                    <asp:Label ID="Label133" runat="server" Text='<%# Eval("開單人員")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="施工人員" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <a href='<%# Eval("施工人員")%>' rel="facebox">
                        <img alt="" src="../images/personel.gif" border="0" width="23" height="22" />
                    </a>
                </ItemTemplate>
                <FooterStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="取消">
                <ItemTemplate>
                    <asp:Button ID="_btn刪除" runat="server" Text="刪除" OnClick="_btn刪除_Click" OnClientClick="return confirm('是否取消此工單?')"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    </asp:UpdatePanel>
    </form>
</body>
</html>
