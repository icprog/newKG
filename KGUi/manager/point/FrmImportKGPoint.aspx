<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmImportKGPoint.aspx.cs"
    Inherits="KGUi.manager.point.FrmImportKGPoint" %>

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
        <table id="TABLE1" border="1" style="border-right: lightblue thin solid; border-top: lightblue thin solid;
            border-left: lightblue thin solid; width: 1px; border-bottom: lightblue thin solid;
            height: 1px;">
            <tr bgcolor="#e8eef4">
                <td colspan="13" style="background-image: url(../Images/table_bg_blue.gif)">
                    <asp:Image ID="Image1" runat="server" Height="11px" ImageUrl="~/Images/icon.gif" />
                    <asp:Label ID="Label1" runat="server" BackColor="Transparent" Font-Bold="True" ForeColor="Black"
                        Style="position: static" Text="Excel檔案上傳" Width="177px"></asp:Label>
                </td>
            </tr>
            <tr bgcolor="#e8eef4">
                <td style="background-color: #87c5f4">
                    <asp:Label ID="Label11" runat="server" Font-Bold="True" Style="position: static"
                        Text="上傳檔案：" Width="86px"></asp:Label>
                </td>
                <td colspan="12" style="width: 400px; background-color: #eaeaea">
                    <asp:FileUpload ID="iv_filePath" runat="server" Width="258px" /><asp:Button ID="iv_btn上傳"
                        runat="server" OnClick="iv_btn上傳_Click" Text="上傳" Width="57px" />
                </td>
            </tr>
            <tr bgcolor="#e8eef4">
                <td style="background-color: #87c5f4">
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Style="position: static" Text="選擇檔案："
                        Width="86px"></asp:Label>
                </td>
                <td colspan="12" style="width: 400px; background-color: #eaeaea">
                    <asp:DropDownList ID="iv_cbo檔案名稱" runat="server" AutoPostBack="True" Width="190px">
                    </asp:DropDownList>
                    <asp:Label ID="Label13" runat="server" ForeColor="#00C000" Text="檔案請上傳Excel檔(.xls)"
                        Font-Size="Smaller"></asp:Label>
                </td>
            </tr>
            <tr bgcolor="#e8eef4">
                <td>
                    <asp:Button ID="iv_btn檢視" runat="server" OnClick="iv_btn檢視_Click" Text="檢視匯入資料" />
                </td>
                <td colspan="12" style="width: 400px; background-color: #eaeaea">
                </td>
            </tr>
        </table>
    </div>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
            DisplayAfter="100">
            <ProgressTemplate>
                &nbsp;<table>
                    <tr>
                        <td style="width: 100px">
                            <img src="../Images/loading.gif" /></td>
                        <td style="width: 100px">
                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Smaller" ForeColor="Blue"
                                Text="程式執行中，請稍後......" Width="159px"></asp:Label></td>
                    </tr>
                </table>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
       
               
            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="White"
                    BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" Font-Size="Smaller"
                    GridLines="None">
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                </asp:GridView>
                <asp:Button ID="iv_btnInsert" runat="server" Font-Strikeout="False" 
                    OnClick="iv_btnInsert_Click" OnClientClick="return confirm('確認匯入資料？')" 
                    Text="匯入資料" Visible="False" Width="110px" />
            </ContentTemplate>
            </asp:UpdatePanel>
    </form>
</body>
</html>
