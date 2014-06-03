<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmWashTotalAmount.aspx.cs" Inherits="KGUi.manager.FrmWashTotalAmount" %>

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
         <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="_txtBDate" Format="yyyy/MM/dd">
    </cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="_txtEDate" Format="yyyy/MM/dd">
    </cc1:CalendarExtender>
         <table border="1" cellpadding="0" cellspacing="0" bordercolor="#BDCFE1">
                    <tr>
                        <td colspan="2" align="center" bgcolor="#FFD7D7" style="background-image: url(../Images/table_bg_blue.gif);
                            height: 16px;">
                            <asp:Label ID="Label3" runat="server" Text="台數統計" ForeColor="White" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="完工日期"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="_txtBDate" runat="server"></asp:TextBox>
                            ~
                            <asp:TextBox ID="_txtEDate" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="據點別"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="_ddl據點別" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="所OR廠"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="_rdo據點別" runat="server" RepeatDirection="Horizontal" >
                            <asp:ListItem Text="全部" Value="" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="所" Value="所"></asp:ListItem>
                            <asp:ListItem Text="廠" Value="廠"></asp:ListItem>
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
                
                <br/>
                
                 <asp:GridView ID="_gvWork" runat="server" 
        AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" 
                    >
                    <RowStyle ForeColor="#000066" />
                    <Columns>
                        <asp:TemplateField HeaderText="所別">
                            <ItemTemplate>
                                <asp:Label ID="Label11" runat="server" Text='<%# Eval("所別")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="精緻台數">
                            <ItemTemplate>
                                <asp:Label ID="Label26" runat="server" Text='<%# Eval("精緻台數")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="精緻實績">
                            <ItemTemplate>
                                <asp:Label ID="Label266" runat="server" Text='<%# Eval("精緻實績")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="磁土台數">
                            <ItemTemplate>
                                <asp:Label ID="Label27" runat="server" Text='<%# Eval("磁土台數")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="磁土實績">
                            <ItemTemplate>
                                <asp:Label ID="Label277" runat="server" Text='<%# Eval("磁土實績")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="小美容台數">
                            <ItemTemplate>
                                <asp:Label ID="Label529" runat="server" Text='<%# Eval("小美容台數")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="小美容實績">
                            <ItemTemplate>
                                <asp:Label ID="Label599" runat="server" Text='<%# Eval("小美容實績")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="覆膜台數">
                            <ItemTemplate>
                                <asp:Label ID="Label629" runat="server" Text='<%# Eval("覆膜台數")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="覆膜實績">
                            <ItemTemplate>
                                <asp:Label ID="Label699" runat="server" Text='<%# Eval("覆膜實績")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="超值台數">
                            <ItemTemplate>
                                <asp:Label ID="Label28" runat="server" Text='<%# Eval("超值台數")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="超值實績">
                            <ItemTemplate>
                                <asp:Label ID="Label288" runat="server" Text='<%# Eval("超值實績")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="亮新I台數">
                            <ItemTemplate>
                                <asp:Label ID="Label29" runat="server" Text='<%# Eval("亮新I台數")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="亮新I實績">
                            <ItemTemplate>
                                <asp:Label ID="Label299" runat="server" Text='<%# Eval("亮新I實績")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="亮新II台數">
                            <ItemTemplate>
                                <asp:Label ID="Label37" runat="server" Text='<%# Eval("亮新II台數")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="亮新II實績">
                            <ItemTemplate>
                                <asp:Label ID="Label377" runat="server" Text='<%# Eval("亮新II實績")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="內裝台數">
                            <ItemTemplate>
                                <asp:Label ID="Label47" runat="server" Text='<%# Eval("內裝台數")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="內裝實績">
                            <ItemTemplate>
                                <asp:Label ID="Label477" runat="server" Text='<%# Eval("內裝實績")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="引擎台數">
                            <ItemTemplate>
                                <asp:Label ID="Label57" runat="server" Text='<%# Eval("引擎台數")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="引擎實績">
                            <ItemTemplate>
                                <asp:Label ID="Label577" runat="server" Text='<%# Eval("引擎實績")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="玻璃台數">
                            <ItemTemplate>
                                <asp:Label ID="Label678" runat="server" Text='<%# Eval("玻璃台數")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="玻璃實績">
                            <ItemTemplate>
                                <asp:Label ID="Label679" runat="server" Text='<%# Eval("玻璃實績")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CPO1台數">
                            <ItemTemplate>
                                <asp:Label ID="Label578" runat="server" Text='<%# Eval("CPO1台數")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CPO1實績">
                            <ItemTemplate>
                                <asp:Label ID="Label579" runat="server" Text='<%# Eval("CPO1實績")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CPO2台數">
                            <ItemTemplate>
                                <asp:Label ID="Label578" runat="server" Text='<%# Eval("CPO2台數")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CPO2實績">
                            <ItemTemplate>
                                <asp:Label ID="Label579" runat="server" Text='<%# Eval("CPO2實績")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="總台數">
                            <ItemTemplate>
                                <asp:Label ID="Label107" runat="server" Text='<%# Eval("總台數")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="小計">
                            <ItemTemplate>
                                <asp:Label ID="Label67" runat="server" Text='<%# Eval("小計")%>'></asp:Label>
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
    </div>
    </form>
</body>
</html>
