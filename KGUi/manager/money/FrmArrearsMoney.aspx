<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmArrearsMoney.aspx.cs" Inherits="KGUi.manager.money.FrmArrearsMoney" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>欠款紀錄</title>
   
    <style type="text/css">
* {
  margin: 0;
  padding: 0;
}

a {
  color: #3B5998;
  text-decoration: none;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptLocalization="False" EnableScriptGlobalization="false">
    </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="_txtBDate" Format="yyyy/MM/dd">
    </cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="_txtEDate" Format="yyyy/MM/dd">
    </cc1:CalendarExtender>
    
    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="_txtB帳款日期" Format="yyyy/MM/dd">
    </cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="_txtE帳款日期" Format="yyyy/MM/dd">
    </cc1:CalendarExtender>
            <table border="1" cellpadding="0" cellspacing="0" bordercolor="#BDCFE1">
             <tr>
                    <td colspan="2" align="center" bgcolor="#FFD7D7" style="background-image: url(../../Images/table_bg_blue.gif);
                        height: 16px;">
                        <asp:Label ID="Label3" runat="server" Text="欠款紀錄" ForeColor="White" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="帳款日期"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="_txtB帳款日期" runat="server"></asp:TextBox>
                        ~
                        <asp:TextBox ID="_txtE帳款日期" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="沖帳日期"></asp:Label>
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
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="種類"></asp:Label>
                    </td>
                    <td>
                        <asp:RadioButtonList ID="_rdolist" runat="server">
                        <asp:ListItem Value="N" Text="未沖" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="Y" Text="已沖"></asp:ListItem>
                        </asp:RadioButtonList>
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
                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                Width="100%">
                <RowStyle ForeColor="#000066" />
                <Columns>
                    <asp:TemplateField HeaderText="項次">
                        <ItemTemplate>
                            <asp:Label ID="Label21" runat="server" Text='<%# Eval("項次")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="據點">
                        <ItemTemplate>
                            <asp:Label ID="Label20" runat="server" Text='<%# Eval("據點")%>'></asp:Label>
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
                    <asp:TemplateField HeaderText="洗車款項">
                        <ItemTemplate>
                            <asp:Label ID="Label371" runat="server" Text='<%# Eval("洗車款項")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="小百貨款項">
                        <ItemTemplate>
                            <asp:Label ID="Label372" runat="server" Text='<%# Eval("小百貨款項")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="應收金額">
                        <ItemTemplate>
                            <asp:Label ID="Label37" runat="server" Text='<%# Eval("應收金額")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="剩餘點數" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="Label112" runat="server" Text='<%# Eval("剩餘點數")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="實收金額" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="Label1121" runat="server" Text='<%# Eval("實收金額")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    
                    <asp:TemplateField HeaderText="明細">
                        <ItemTemplate>
                        <%--<a href='<%# Eval("明細")%>' rel="facebox" >
                            <img alt="" src="../../images/home_63.gif" border="0" /></a>  --%>
                            <asp:Button ID="_btn明細" runat="server" Text="明細" OnClick="_btn明細_Click" /> 
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
