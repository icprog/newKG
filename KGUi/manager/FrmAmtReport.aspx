<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmAmtReport.aspx.cs" Inherits="KGUi.manager.FrmAmtReport"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>薪資報表</title>
    
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
                        <asp:Label ID="Label3" runat="server" Text="薪資報表" ForeColor="White" Font-Bold="True"></asp:Label>
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
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="員編"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="_txt員編" runat="server"></asp:TextBox>
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
                Width="357px">
                <RowStyle ForeColor="#000066" />
                <Columns>
                    <asp:TemplateField HeaderText="項次">
                        <ItemTemplate>
                            <asp:Label ID="Label21" runat="server" Text='<%# Eval("項次")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="員編">
                        <ItemTemplate>
                            <asp:Label ID="Label26" runat="server" Text='<%# Eval("員編")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="姓名">
                        <ItemTemplate>
                            <asp:Label ID="Label27" runat="server" Text='<%# Eval("姓名")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="業績">
                        <ItemTemplate>
                            <asp:Label ID="Label137" runat="server" Text='<%# Eval("業績")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="薪資">
                        <ItemTemplate>
                            <asp:Label ID="Label37" runat="server" Text='<%# Eval("薪資")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="明細">
                        <ItemTemplate>
                        <a href='<%# Eval("明細")%>' rel="facebox" >
                            <img alt="" src="../images/home_63.gif" border="0" /></a>   
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            </asp:GridView>
             
    </form>
</body>
</html>