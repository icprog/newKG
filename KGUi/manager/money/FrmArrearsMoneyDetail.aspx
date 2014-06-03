<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmArrearsMoneyDetail.aspx.cs"
    Inherits="KGUi.manager.money.FrmArrearsMoneyDetail" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未命名頁面</title>
    <link href="../../css/facebox.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../../css/faceplant.css" media="screen" rel="stylesheet" type="text/css" />

    <script src="../../js/jquery.js" type="text/javascript"></script>

    <script src="../../js/facebox.js" type="text/javascript"></script>

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
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptLocalization="False" EnableScriptGlobalization="false">
    </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            
    <asp:Label ID="Label3" runat="server" Text="員編:" Font-Bold="True" ForeColor="#003300"></asp:Label>
                <asp:Label ID="_lblSmid" runat="server" Text=""></asp:Label>
         <br />
    <asp:Label ID="Label4" runat="server" Text="姓名:" Font-Bold="True" ForeColor="#003300"></asp:Label>
                <asp:Label ID="_lblName" runat="server" Text=""></asp:Label>
                
         <br />
                <asp:Label ID="Label1" runat="server" Text="洗車總計:" Font-Bold="True" ForeColor="#003300"></asp:Label>
                <asp:Label ID="_lbl洗車" runat="server" Text=""></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <asp:Label ID="Label2" runat="server" Text="小百貨總計:" Font-Bold="True" ForeColor="Maroon"></asp:Label>
                <asp:Label ID="_lbl小百貨" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <asp:Button ID="_btn明細總覽" runat="server" Text="明細總覽" onclick="_btn明細總覽_Click" 
                    Width="177px" />
                <br />
                <asp:GridView ID="_gvAmt" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="744px">
                    <RowStyle ForeColor="#000066" />
                    <Columns>
                        <asp:TemplateField HeaderText="項次">
                            <ItemTemplate>
                                <asp:Label ID="Label21" runat="server" Text='<%# Eval("項次")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="單號">
                            <ItemTemplate>
                                <asp:Label ID="Label20" runat="server" Text='<%# Eval("單號")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="金額">
                            <ItemTemplate>
                                <asp:Label ID="Label26" runat="server" Text='<%# Eval("金額")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="帳款日期">
                            <ItemTemplate>
                                <asp:Label ID="Label27" runat="server" Text='<%# Eval("帳款日期")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       <%-- <asp:TemplateField HeaderText="顧客姓名">
                            <ItemTemplate>
                                <asp:Label ID="Label371" runat="server" Text='<%# Eval("顧客姓名")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="總類">
                            <ItemTemplate>
                                <asp:Label ID="Label38" runat="server" Text='<%# Eval("總類")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="明細">
                            <ItemTemplate>
                                <asp:Button ID="_btn明細" runat="server" Text="明細" OnClick="_btn明細_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="備註">
                            <ItemTemplate>
                                <asp:Label ID="Label37" runat="server" Text='<%# Eval("備註")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
                <br />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                    Width="659px">
                    <RowStyle ForeColor="#000066" />
                    <Columns>
                        <asp:TemplateField HeaderText="項次">
                            <ItemTemplate>
                                <asp:Label ID="Label121" runat="server" Text='<%# Eval("項次")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="單號">
                            <ItemTemplate>
                                <asp:Label ID="Label220" runat="server" Text='<%# Eval("單號")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="引擎號碼">
                            <ItemTemplate>
                                <asp:Label ID="Label120" runat="server" Text='<%# Eval("引擎號碼")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="顧客姓名">
                            <ItemTemplate>
                                <asp:Label ID="Label1201" runat="server" Text='<%# Eval("顧客姓名")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="洗車總類">
                            <ItemTemplate>
                                <asp:Label ID="Label126" runat="server" Text='<%# Eval("洗車總類")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="金額">
                            <ItemTemplate>
                                <asp:Label ID="Label127" runat="server" Text='<%# Eval("金額")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="開單人員">
                            <ItemTemplate>
                                <asp:Label ID="Label130" runat="server" Text='<%# Eval("開單人員")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="661px">
                    <RowStyle ForeColor="#000066" />
                    <Columns>
                        <asp:TemplateField HeaderText="項次">
                            <ItemTemplate>
                                <asp:Label ID="Label21" runat="server" Text='<%# Eval("項次")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="單號">
                            <ItemTemplate>
                                <asp:Label ID="Label20" runat="server" Text='<%# Eval("單號")%>'></asp:Label>
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
                        <asp:TemplateField HeaderText="數量">
                            <ItemTemplate>
                                <asp:Label ID="Label28" runat="server" Text='<%# Eval("數量")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="金額">
                            <ItemTemplate>
                                <asp:Label ID="Label29" runat="server" Text='<%# Eval("金額")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="開單人員">
                            <ItemTemplate>
                                <asp:Label ID="Label30" runat="server" Text='<%# Eval("開單人員")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                  
                        <asp:TemplateField HeaderText="顧客姓名">
                            <ItemTemplate>
                                <asp:Label ID="Label381" runat="server" Text='<%# Eval("顧客姓名")%>'></asp:Label>
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
