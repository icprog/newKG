<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmPlantReprot.aspx.cs"
    Inherits="KGUi.manager.FrmPlantReprot" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="_txtBDate"
                    Format="yyyy/MM/dd">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="_txtEDate"
                    Format="yyyy/MM/dd">
                </cc1:CalendarExtender>
                <table border="1" cellpadding="0" cellspacing="0" bordercolor="#BDCFE1">
                    <tr>
                        <td colspan="2" align="center" bgcolor="#FFD7D7" style="background-image: url(../Images/table_bg_blue.gif);
                            height: 16px;">
                            <asp:Label ID="Label3" runat="server" Text="各廠介紹獎金" ForeColor="White" Font-Bold="True"></asp:Label>
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
                            &nbsp;
                            <asp:Button ID="_btn匯出" runat="server" Text="匯出" onclick="_btn匯出_Click" />
                        
                        </td>
                    </tr>
                </table>
                <br />
                <asp:GridView ID="_gvAmt" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                    <RowStyle ForeColor="#000066" />
                    <Columns>
                        <asp:TemplateField HeaderText="廠別">
                            <ItemTemplate>
                                <asp:Label ID="Label26" runat="server" Text='<%# Eval("廠別")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="一般">
                            <ItemTemplate>
                                <asp:Label ID="Label27" runat="server" Text='<%# Eval("一般")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="一般獎金">
                            <ItemTemplate>
                                <asp:Label ID="Label28" runat="server" Text='<%# Eval("一般獎金")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="保險">
                            <ItemTemplate>
                                <asp:Label ID="Label38" runat="server" Text='<%# Eval("保險")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="保險獎金">
                            <ItemTemplate>
                                <asp:Label ID="Label48" runat="server" Text='<%# Eval("保險獎金")%>'></asp:Label>
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
                
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
