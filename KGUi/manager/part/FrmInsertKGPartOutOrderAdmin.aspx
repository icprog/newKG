<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmInsertKGPartOutOrderAdmin.aspx.cs"
    Inherits="KGUi.manager.part.FrmInsertKGPartOutOrderAdmin" %>

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
                <table id="Table1" style="border-right: lightblue thin solid; border-top: lightblue thin solid;
                    border-left: lightblue thin solid; width: 500px; border-bottom: lightblue thin solid">
                    <tr bgcolor="#e8eef4">
                        <td colspan="9" style="background-image: url(../../Images/table_bg_blue.gif)">
                            <asp:Label ID="Label1" runat="server" BackColor="Transparent" Font-Bold="True" ForeColor="White"
                                Style="position: static" Text="高輊小百貨訂購作業" Width="158px"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="background-color: #87c5f4">
                            <asp:Label ID="Label6" runat="server" Font-Size="Smaller" Text="廠商：" Width="40px"></asp:Label>
                        </td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="iv_cbo廠商" runat="server" Width="110px" 
                                OnSelectedIndexChanged="iv_cbo廠商_SelectedIndexChanged1" AutoPostBack="True">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="亙長" Value="KC"></asp:ListItem>
                                <asp:ListItem Text="劦大" Value="LD"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="background-color: #87c5f4">
                            <asp:Label ID="Label9" runat="server" Font-Size="Smaller" Text="請購所別：" Width="70px"></asp:Label>
                        </td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="iv_cbo請購所別" runat="server" Width="100px" AutoPostBack="True"
                                OnSelectedIndexChanged="iv_cbo請購所別_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" BackColor="White"
                    BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1"
                    Font-Size="Smaller" GridLines="None" 
                    OnRowDataBound="GridView3_RowDataBound" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged">
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                    <Columns>
                        <asp:TemplateField HeaderText="請購明細">
                            <ItemTemplate>
                                <asp:Button ID="iv_btn請購明細" runat="server" Text="請購明細" OnClick="iv_btn請購明細_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="請購所別">
                            <ItemTemplate>
                                <asp:Label ID="iv_lbl請購所別" runat="server" Text='<%# Eval("請購所別") %>'></asp:Label>
                                <asp:Label ID="iv_lbl請購所別id" runat="server" Text='<%# Eval("請購所別id") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="對象廠商">
                            <ItemTemplate>
                                <asp:Label ID="iv_lbl對象廠商" runat="server" Text='<%# Eval("對象廠商") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="請購筆數">
                            <ItemTemplate>
                                <asp:Label ID="iv_lbl請購筆數" runat="server" Text='<%# Eval("請購筆數") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                &nbsp; &nbsp;&nbsp;&nbsp;<br />
                <table>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label3" runat="server" Text="請購單號"></asp:Label>
                        </td>
                        <td align="center">
                        </td>
                        <td colspan="2">
                            <asp:Label ID="Label2" runat="server" Text="要訂購的清單" Width="98px"></asp:Label>
                        </td>
                        <td colspan="1">
                            <asp:Button ID="iv_btn送出清單" runat="server" OnClientClick="return confirm('送出清單後，系統將自動發送訂購單給廠商，請確認訂購內容是否正確再送出請購單')"
                                Text="送出訂購清單" OnClick="iv_btn送出清單_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:ListBox ID="iv_lbx請購單號" runat="server" Height="200px" SelectionMode="Multiple"
                                TabIndex="2" Width="220px" AutoPostBack="True" OnSelectedIndexChanged="iv_lbx請購單號_SelectedIndexChanged">
                            </asp:ListBox>
                        </td>
                        <td align="center">
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" TabIndex="4" Text=">"
                                Width="50px" /><br />
                            <br />
                            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" TabIndex="5" Text=">>"
                                Width="50px" /><br />
                            <br />
                            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" TabIndex="6" Text="<"
                                Width="50px" /><br />
                            <br />
                            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" TabIndex="7" Text="<<"
                                Width="50px" />
                        </td>
                        <td colspan="3">
                            <asp:ListBox ID="iv_lbx要訂購的請購單號" runat="server" Height="200px" SelectionMode="Multiple"
                                TabIndex="3" Width="220px"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:Label ID="Label8" runat="server" Text="請購單號："></asp:Label>
                            <asp:Label ID="iv_lblTitle請購單號" runat="server"></asp:Label>&nbsp;<asp:GridView ID="GridView2"
                                runat="server" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px"
                                CellPadding="3" CellSpacing="1" Font-Size="Smaller" GridLines="None">
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:Label ID="Label5" runat="server">備註欄：</asp:Label><br />
                            <asp:TextBox ID="iv_txt備註" runat="server" Height="60px" TextMode="MultiLine" Width="260px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
