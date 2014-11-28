<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WfrmInsertKGPoint.aspx.cs" Inherits="KGUi.manager.money.WfrmInsertKGPoint" %>
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
       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       
            <ContentTemplate>
            
                <table id="Table2" style="border-right: lightblue thin solid; border-top: lightblue thin solid;
                    border-left: lightblue thin solid; width: 238px; border-bottom: lightblue thin solid">
                    <tr bgcolor="#e8eef4">
                        <td colspan="14" align="center" bgcolor="#FFD7D7" style="background-image: url(../../Images/table_bg_blue.gif);>
                            <asp:Label ID="Label1" runat="server" BackColor="Transparent" Font-Bold="True" ForeColor="White"
                                Style="position: static" Text="業務代表點數儲值作業" Width="178px"></asp:Label></td>
                    </tr>
                    
                    <tr bgcolor="#e8eef4">
                        <td style="background-color: #87c5f4">
                            <asp:Label ID="Label5" runat="server" Font-Bold="False" Style="position: static"
                                Text="業代員編" Width="64px"></asp:Label></td>
                        <td colspan="13" style="background-color: #eaeaea">
                            <asp:TextBox ID="iv_txt業代員編" runat="server" Width="89px"></asp:TextBox></td>
                    </tr>
                    <tr bgcolor="#e8eef4">
                        <td colspan="14" style="background-color: #eaeaea; height: 25px;">
                            <asp:Button ID="iv_btn查詢" runat="server" OnClick="iv_btn查詢_Click" Text="查詢" Width="74px" />
                            </td>
                    </tr>
                </table>
                           
               
                <asp:Image ID="Image14" runat="server" Height="11px" ImageUrl="~/Images/01.gif" /><asp:Label
                    ID="Label222" runat="server" Font-Size="Smaller" Text="業代編號："></asp:Label><asp:Label
                        ID="iv_lblSmid" runat="server" Font-Size="Smaller" ForeColor="Blue"></asp:Label>
                <asp:Image
                            ID="Image225" runat="server" Height="11px" ImageUrl="~/Images/01.gif" /><asp:Label
                    ID="Label2227" runat="server" Font-Size="Smaller" Text="業代姓名："></asp:Label>&nbsp;
                    <asp:Label
                        ID="iv_lbl業代姓名" runat="server" Font-Size="Smaller" ForeColor="Blue"></asp:Label><br />
                <table id="Table4" style="border-right: lightblue thin solid; border-top: lightblue thin solid;
                    border-left: lightblue thin solid; width: 400px; border-bottom: lightblue thin solid">
                    <tr bgcolor="#e8eef4">
                        <td colspan="16" align="center" bgcolor="#FFD7D7" style="background-image: url(../../Images/table_bg_blue.gif);>
                            <asp:Label ID="Label3" runat="server" BackColor="Transparent" Font-Bold="True" ForeColor="White"
                                Style="position: static" Text="儲值作業" Width="73px"></asp:Label></td>
                    </tr>
                    <tr bgcolor="#e8eef4">
                        <td style="background-color: #87c5f4">
                            <asp:Label ID="Label2" runat="server" Font-Bold="False" Style="position: static"
                                Text="儲值方式" Width="64px"></asp:Label></td>
                        <td colspan="13" style="background-color: #eaeaea">
                            <asp:DropDownList ID="iv_cbo儲值方式" runat="server" Width="110px" OnSelectedIndexChanged="iv_cbo刷卡銀行_SelectedIndexChanged">
                                <asp:ListItem Selected="True">現金儲值</asp:ListItem>
                                <asp:ListItem>刷卡儲值</asp:ListItem>
                                <asp:ListItem>作廢扣回</asp:ListItem>
                            </asp:DropDownList></td>
                        <td colspan="1" style="background-color: #87c5f4">
                            <asp:Label ID="Label6" runat="server" Font-Bold="False" Style="position: static"
                                Text="現有點數" Width="64px"></asp:Label></td>
                        <td colspan="1" style="background-color: #eaeaea">
                            <asp:Label ID="iv_lbl現有點數" runat="server" Font-Bold="True" ForeColor="Blue" Style="position: static"></asp:Label></td>
                    </tr>
                    <tr bgcolor="#e8eef4">
                        <td style="background-color: #87c5f4">
                            <asp:Label ID="Label4" runat="server" Font-Bold="False" Style="position: static"
                                Text="儲值點數" Width="64px"></asp:Label></td>
                        <td colspan="13" style="background-color: #eaeaea">
                            <asp:TextBox ID="iv_txt儲值點數" runat="server" Width="90px" AutoPostBack="True"></asp:TextBox></td>
                        <td colspan="1" style="background-color: #87c5f4">
                            <asp:Label ID="Label12" runat="server" Font-Bold="False" Style="position: static"
                                Text="刷卡銀行" Width="64px"></asp:Label></td>
                        <td colspan="1" style="background-color: #eaeaea">
                            <asp:DropDownList ID="iv_cbo刷卡銀行" runat="server" Width="110px" AutoPostBack="True" OnSelectedIndexChanged="iv_cbo刷卡銀行_SelectedIndexChanged">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>台新銀行</asp:ListItem>
                                <asp:ListItem>中國信託</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr bgcolor="#e8eef4">
                        <td style="background-color: #87c5f4">
                            <asp:Label ID="Label8" runat="server" Font-Bold="False" Style="position: static"
                                Text="發票號碼" Width="64px"></asp:Label></td>
                        <td colspan="13" style="background-color: #eaeaea">
                            <asp:TextBox ID="iv_txt發票號碼" runat="server" Width="89px"></asp:TextBox></td>
                        <td colspan="1" style="background-color: #87c5f4">
                            <asp:Label ID="Label13" runat="server" Font-Bold="False" Style="position: static"
                                Text="手續費" Width="64px"></asp:Label></td>
                        <td colspan="1" style="background-color: #eaeaea">
                            <asp:TextBox ID="iv_txt手續費" runat="server" Width="68px">0</asp:TextBox></td>
                    </tr>
                    <tr bgcolor="#e8eef4">
                        <td style="background-color: #87c5f4">
                            <asp:Label ID="Label14" runat="server" Font-Bold="False" Style="position: static"
                                Text="入帳銀行" Width="64px"></asp:Label></td>
                        <td colspan="13" style="background-color: #eaeaea">
                            <asp:DropDownList ID="iv_cbo入帳銀行" runat="server" Width="110px" OnSelectedIndexChanged="iv_cbo刷卡銀行_SelectedIndexChanged">
                                <asp:ListItem Selected="True">合庫三民</asp:ListItem>
                                <asp:ListItem>中國信託</asp:ListItem>
                                <asp:ListItem>台新銀行</asp:ListItem>
                            </asp:DropDownList></td>
                        <td align="center" colspan="2" style="background-color: #eaeaea">
                            <asp:Button ID="iv_btn儲值" runat="server" OnClick="iv_btn儲值_Click" Text="儲值" Width="70px" /></td>
                    </tr>
                    <tr>
                        <td  style="background-color: #87c5f4">
                            <asp:Label ID="Label7" runat="server" Font-Bold="False" Style="position: static"
                                Text="備註" Width="64px"></asp:Label>
                        </td>
                        <td colspan="13">
                            <asp:TextBox ID="txtMemo" runat="server" TextMode="MultiLine"></asp:TextBox>

                        </td>
                    </tr>
                </table>
                    <br />
                    <br />
            
                <br />
           </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
