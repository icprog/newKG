<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmInsertKGPartOrder.aspx.cs"
    Inherits="KGUi.part.FrmInsertKGPartOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未命名頁面</title>

    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>

    <style type="text/css">
        .style1
        {
            width: 82px;
        }
        .style2
        {
            width: 170px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <table id="Table2" style="border-right: lightblue thin solid; border-top: lightblue thin solid;
            border-left: lightblue thin solid; width: 280px; border-bottom: lightblue thin solid">
            <tr bgcolor="#e8eef4">
                <td colspan="11" style="background-image: url(../Images/table_bg_blue.gif)">
                    <asp:Image ID="Image2" runat="server" Height="11px" ImageUrl="~/Images/icon.gif" />
                    <asp:Label ID="Label2" runat="server" BackColor="Transparent" Font-Bold="True" ForeColor="White"
                        Style="position: static" Text="高輊小百貨請購作業" Width="158px"></asp:Label>
                </td>
            </tr>
            <tr bgcolor="#e8eef4">
                <td style="background-color: #87c5f4; width: 100px;">
                    <asp:Label ID="Label25" runat="server" Font-Bold="False" Style="position: static"
                        Text="業代員編" Width="64px"></asp:Label>
                </td>
                <td colspan="10" style="background-color: #eaeaea">
                    <asp:TextBox ID="_txt業代員編" runat="server" Width="120px"></asp:TextBox>
                </td>
            </tr>
            <tr bgcolor="#e8eef4">
                <td colspan="11" style="background-color: #eaeaea">
                    <asp:Button ID="_btn選購作業" runat="server" OnClick="iv_btn選購作業_Click" Text="進入請購作業"
                        Width="96px" style="height: 21px" />
                    <asp:Label ID="iv_lblErrorMsg" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <asp:Label ID="_lbl業代資料" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Brown">請購者資料:OO所 XXX</asp:Label>
        <asp:Label ID="_lblSmid" runat="server" Text="Label" Visible="False"></asp:Label>
        <br />
        <table>
            <tr>
                <td style="background-color: #87c5f4;" class="style1">
                    <asp:Label ID="Label54" runat="server" Font-Bold="False" Style="position: static"
                        Text="小百貨供應廠商：" Width="107px" Font-Size="Smaller"></asp:Label>
                </td>
                <td style="width: 100px; background-color: #eaeaea;">
                    <asp:RadioButtonList ID="_rbl廠商" runat="server" Font-Size="Smaller" Width="600px"
                        AutoPostBack="True" OnSelectedIndexChanged="_rbl廠商_SelectedIndexChanged" Font-Overline="False"
                        RepeatColumns="4">
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:ListBox ID="_lbx類別名稱" runat="server" AutoPostBack="True" Height="150px" OnSelectedIndexChanged="_lbx類別名稱_SelectedIndexChanged"
                        Width="110px"></asp:ListBox>
                    <asp:ListBox ID="_lbx種類名稱" runat="server" AutoPostBack="True" Height="150px" OnSelectedIndexChanged="_lbx種類名稱_SelectedIndexChanged"
                        Width="160px"></asp:ListBox>
                    <asp:ListBox ID="_lbx百貨商品" runat="server" AutoPostBack="True" Height="150px" OnSelectedIndexChanged="_lbx百貨商品_SelectedIndexChanged"
                        Width="400px"></asp:ListBox>
                </td>
            </tr>
        </table>
        <table id="Table1" style="border-right: lightblue thin solid; border-top: lightblue thin solid;
            border-left: lightblue thin solid; width: 600px; border-bottom: lightblue thin solid">
            <tr bgcolor="#e8eef4">
                <td style="background-color: #87c5f4">
                    <asp:Label ID="Label34" runat="server" Font-Bold="False" Style="position: static"
                        Text="產品編號" Width="64px"></asp:Label>
                </td>
                <td colspan="4" style="background-color: #eaeaea">
                    <asp:Label ID="_lbl商品編號" runat="server" Font-Bold="False" Font-Size="Smaller" ForeColor="Brown"
                        Style="position: static"></asp:Label>
                </td>
                <td colspan="1" style="background-color: #87c5f4">
                    <asp:Label ID="Label230" runat="server" Font-Bold="False" Style="position: static"
                        Text="產品名稱" Width="64px"></asp:Label>
                </td>
                <td colspan="3" style="background-color: #eaeaea">
                    <asp:Label ID="_lbl商品名稱" runat="server" Font-Bold="False" Font-Size="Smaller" ForeColor="Brown"
                        Style="position: static"></asp:Label>
                </td>
            </tr>
            <tr bgcolor="#e8eef4">
                <td style="background-color: #87c5f4">
                    <asp:Label ID="Label8" runat="server" Font-Bold="False" Style="position: static"
                        Text="建議售價" Width="64px"></asp:Label>
                </td>
                <td colspan="4" style="background-color: #eaeaea">
                    <asp:Label ID="_lbl售價" runat="server" Font-Bold="False" Style="position: static"></asp:Label>
                </td>
                <td colspan="1" style="background-color: #87c5f4">
                    <asp:Label ID="Label9" runat="server" Font-Bold="False" Style="position: static">業代價</asp:Label>
                </td>
                <td colspan="1" style="background-color: #eaeaea">
                    <asp:Label ID="_lbl業代價" runat="server" Font-Bold="False" Style="position: static"></asp:Label>
                    
                </td>
                <td colspan="1" style="background-color: #87c5f4">
                    <asp:Label ID="Label6" runat="server" Font-Bold="False" Style="position: static"
                        Text="單位" Width="38px"></asp:Label>
                </td>
                <td colspan="1" style="background-color: #eaeaea">
                    <asp:Label ID="_lbl單位個數" runat="server" Font-Bold="False" Style="position: static"
                        Width="76px"></asp:Label>
                </td>
            </tr>
            <tr bgcolor="#e8eef4">
                <td style="background-color: #87c5f4">
                    <asp:Label ID="Label10" runat="server" Font-Bold="False" Style="position: static"
                        Text="數量" Width="64px"></asp:Label>
                </td>
                <td colspan="6" style="background-color: #eaeaea">
                    <asp:TextBox ID="_txt數量" runat="server" 
                        Width="28px">1</asp:TextBox>
                    <asp:Label ID="_lblCalc" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label>
                </td>
                 <td style="background-color: #87c5f4">
                    <asp:Label ID="Label1" runat="server" Font-Bold="False" Style="position: static"
                        Text="服務廠實際販賣金額" Width="147px"></asp:Label>
                </td>
                <td colspan="8" style="background-color: #eaeaea">
                   
                 <asp:TextBox ID="_txt業代價" runat="server" Width="71px" 
                        ></asp:TextBox>
                </td>
            </tr>
            <tr bgcolor="#e8eef4">
                <td bgcolor="#eaeaea" colspan="9">
                    <asp:Button ID="_btn加入選購清單" runat="server" OnClick="iv_btn加入選購清單_Click" Text="加入請購清單"
                        Width="114px" />
                    <asp:Label ID="_lbl產品成本價" runat="server" Visible="False"></asp:Label>
                    
                </td>
            </tr>
            <tr bgcolor="#e8eef4">
                <td bgcolor="#eaeaea" colspan="9">
                    <asp:Label ID="Label5" Text="請注意 : 每張請購單只對應一組引擎號碼 . 請勿合併 請購." runat="server" Visible="False" 
                        ForeColor="Red"></asp:Label>
                    
                </td>
            </tr>
        </table>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" BackColor="White"
                        BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1"
                        Font-Size="Smaller" GridLines="None" 
                        Width="650px">
                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" HorizontalAlign="Center" />
                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                        <Columns>
                            <asp:TemplateField HeaderText="刪除">
                                <ItemTemplate>
                                    <asp:Button ID="_btn刪除" runat="server" Text="刪除" onclick="_btn刪除_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="產品編號">
                                <ItemTemplate>
                                    <asp:Label ID="iv_lbl產品編號" runat="server" Text='<%# Eval("產品編號") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="產品名稱">
                                <ItemTemplate>
                                    <asp:Label ID="iv_lbl產品名稱" runat="server" Text='<%# Eval("產品名稱") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="數量">
                                <ItemTemplate>
                                    <asp:Label ID="iv_lbl數量" runat="server" Text='<%# Eval("數量") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="單位" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="iv_lbl單位" runat="server" Text='<%# Eval("單位") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="建議售價">
                                <ItemTemplate>
                                    <asp:Label ID="iv_lbl建議售價" runat="server" Text='<%# Eval("建議售價") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="業代價">
                                <ItemTemplate>
                                    <asp:Label ID="iv_lbl業代價" runat="server" Text='<%# Eval("業代價") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="販賣價">
                                <ItemTemplate>
                                    <asp:Label ID="iv_lbl販賣價" runat="server" Text='<%# Eval("販賣價") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="總計">
                                <ItemTemplate>
                                    <asp:Label ID="iv_lbl總計" runat="server" Text='<%# Eval("總計") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="總販賣">
                                <ItemTemplate>
                                    <asp:Label ID="iv_lbl總販賣" runat="server" Text='<%# Eval("總販賣") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <table style="width: 600px">
                    <tr>
                    <td>備註</td>
                    <td colspan="8">
                        <asp:TextBox ID="_txt備註" runat="server" Width="522px" Height="34px" 
                            TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                        <tr>
                            <td align="right" colspan="3" style="background-color: #87c5f4">
                                <asp:Label ID="Label11" runat="server" Font-Size="Smaller" Text="總計金額：" Width="65px"></asp:Label></td>
                            <td colspan="1" style="background-color: #eaeaea;" class="style2">
                                <asp:Label ID="_lblTotal" runat="server" Font-Bold="True" ForeColor="Blue" 
                                    Font-Size="Smaller">0</asp:Label>
                                     <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="Blue" 
                                    Font-Size="Smaller">(</asp:Label>
                                     <asp:Label ID="_lblSaleTotal" runat="server" Font-Bold="True" ForeColor="Blue" 
                                    Font-Size="Smaller">0</asp:Label>
                                    
                                     <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="Blue" 
                                    Font-Size="Smaller">)</asp:Label></td>
                            <td colspan="3" style="background-color: #87c5f4">
                                <asp:Label ID="Label13" runat="server" Font-Size="Smaller" Text="引擎號碼：" 
                                    Width="81px"></asp:Label></td>
                            <td colspan="1" style="background-color: #eaeaea">
                                <asp:TextBox ID="iv_txt引擎號碼" runat="server" Width="100px"></asp:TextBox></td>
                            <td align="center" colspan="1" style="background-color: #ffcc00">
                                <asp:Button ID="_btn送出清單" runat="server" OnClick="_btn送出清單_Click" Text="送出請購清單" 
                                    OnClientClick="return confirm('送出清單前，請確認請購內容，完成請購手續後請至單據列印作業進行列印')" />
                                </td>
                        </tr>
                    </table>
                    
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
