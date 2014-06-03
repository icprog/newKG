<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmSatisfaction.aspx.cs"
    Inherits="KGUi.FrmSatisfaction" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>洗車滿意度調查表</title>

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
                <table>
                    <tr>
                        <td colspan="2">
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/test.jpg" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            說明 : 1.下列問題中，係採取十分評分法方式，例如 : 很滿意是10分，<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 很差是2分，依此類 推，請您以打V方式表示您對該項目的滿意程度。<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 2.各單位煩請依據新車販賣台數*30%做為有效樣本件數。
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/test1.jpg" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="1.玻璃清潔良好"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="_rdo玻璃清潔良好" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="很滿意" Value="10"></asp:ListItem>
                                <asp:ListItem Text="滿意" Value="8"></asp:ListItem>
                                <asp:ListItem Text="普通" Value="6"></asp:ListItem>
                                <asp:ListItem Text="不滿意" Value="4"></asp:ListItem>
                                <asp:ListItem Text="很差" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="2.漆面髒汙清潔良好"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="_rdo漆面髒汙清潔良好" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="很滿意" Value="10"></asp:ListItem>
                                <asp:ListItem Text="滿意" Value="8"></asp:ListItem>
                                <asp:ListItem Text="普通" Value="6"></asp:ListItem>
                                <asp:ListItem Text="不滿意" Value="4"></asp:ListItem>
                                <asp:ListItem Text="很差" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="3.漆面打蠟良好"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="_rdo漆面打蠟良好" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="很滿意" Value="10"></asp:ListItem>
                                <asp:ListItem Text="滿意" Value="8"></asp:ListItem>
                                <asp:ListItem Text="普通" Value="6"></asp:ListItem>
                                <asp:ListItem Text="不滿意" Value="4"></asp:ListItem>
                                <asp:ListItem Text="很差" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="4.引擎室周圍擦拭"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="_rdo引擎室周圍擦拭" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="很滿意" Value="10"></asp:ListItem>
                                <asp:ListItem Text="滿意" Value="8"></asp:ListItem>
                                <asp:ListItem Text="普通" Value="6"></asp:ListItem>
                                <asp:ListItem Text="不滿意" Value="4"></asp:ListItem>
                                <asp:ListItem Text="很差" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="5.輪胎鋼圈清潔"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="_rdo輪胎鋼圈清潔" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="很滿意" Value="10"></asp:ListItem>
                                <asp:ListItem Text="滿意" Value="8"></asp:ListItem>
                                <asp:ListItem Text="普通" Value="6"></asp:ListItem>
                                <asp:ListItem Text="不滿意" Value="4"></asp:ListItem>
                                <asp:ListItem Text="很差" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/images/test2.jpg" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="1.皮椅及門飾板清水擦拭"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="_rdo皮椅及門飾板清水擦拭" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="很滿意" Value="10"></asp:ListItem>
                                <asp:ListItem Text="滿意" Value="8"></asp:ListItem>
                                <asp:ListItem Text="普通" Value="6"></asp:ListItem>
                                <asp:ListItem Text="不滿意" Value="4"></asp:ListItem>
                                <asp:ListItem Text="很差" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="2.儀錶板清潔"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="_rdo儀錶板清潔" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="很滿意" Value="10"></asp:ListItem>
                                <asp:ListItem Text="滿意" Value="8"></asp:ListItem>
                                <asp:ListItem Text="普通" Value="6"></asp:ListItem>
                                <asp:ListItem Text="不滿意" Value="4"></asp:ListItem>
                                <asp:ListItem Text="很差" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label8" runat="server" Text="3.地毯清潔"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="_rdo地毯清潔" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="很滿意" Value="10"></asp:ListItem>
                                <asp:ListItem Text="滿意" Value="8"></asp:ListItem>
                                <asp:ListItem Text="普通" Value="6"></asp:ListItem>
                                <asp:ListItem Text="不滿意" Value="4"></asp:ListItem>
                                <asp:ListItem Text="很差" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Image ID="Image4" runat="server" ImageUrl="~/images/test4.jpg" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label9" runat="server" Text="1.小配件裝置"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="_rdo小配件裝置" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="很滿意" Value="10"></asp:ListItem>
                                <asp:ListItem Text="滿意" Value="8"></asp:ListItem>
                                <asp:ListItem Text="普通" Value="6"></asp:ListItem>
                                <asp:ListItem Text="不滿意" Value="4"></asp:ListItem>
                                <asp:ListItem Text="很差" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label10" runat="server" Text="2.交車時間及人員互動"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="_rdo交車時間及人員互動" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="很滿意" Value="10"></asp:ListItem>
                                <asp:ListItem Text="滿意" Value="8"></asp:ListItem>
                                <asp:ListItem Text="普通" Value="6"></asp:ListItem>
                                <asp:ListItem Text="不滿意" Value="4"></asp:ListItem>
                                <asp:ListItem Text="很差" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label11" runat="server" Text="四.如你有其他的寶貴意見,請以文字敘述,以提供高輊做為改善的參考" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="_txtMemo" runat="server" Height="56px" TextMode="MultiLine" Width="563px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label12" runat="server" Text="施工地點"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="_cbo施工地點" runat="server">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="岡山廠" Value="岡山廠"></asp:ListItem>
                                        <asp:ListItem Text="屏東廠" Value="屏東廠"></asp:ListItem>
                                        <asp:ListItem Text="北高廠" Value="北高廠"></asp:ListItem>
                                        <asp:ListItem Text="旗山廠" Value="旗山廠"></asp:ListItem>
                                        <asp:ListItem Text="潮州廠" Value="潮州廠"></asp:ListItem>
                                        <asp:ListItem Text="小港廠" Value="小港廠"></asp:ListItem>
                                        <asp:ListItem Text="九如廠" Value="九如廠"></asp:ListItem>
                                        <asp:ListItem Text="鳳山廠" Value="鳳山廠"></asp:ListItem>
                                        <asp:ListItem Text="湖內廠" Value="湖內廠"></asp:ListItem>
                                        <asp:ListItem Text="北屏廠" Value="北屏廠"></asp:ListItem>
                                        <asp:ListItem Text="青年廠" Value="青年廠"></asp:ListItem> 
                                        <asp:ListItem Text="楠梓廠" Value="楠梓廠"></asp:ListItem> 
                                        <asp:ListItem Text="瑞豐廠" Value="瑞豐廠"></asp:ListItem> 
                                        <asp:ListItem Text="東港廠" Value="東港廠"></asp:ListItem> 
                                        <asp:ListItem Text="鳳林廠" Value="鳳林廠"></asp:ListItem> 
                                        <asp:ListItem Text="三多廠" Value="三多廠"></asp:ListItem> 
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label13" runat="server" Text="車牌"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="_txt車牌" runat="server" Width="100px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label14" runat="server" Text="員編"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="_txt員編" runat="server" Width="72px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2">
                            <asp:Button ID="_btn送出" runat="server" Text="送出" Height="34px" Width="78px" OnClick="_btn送出_Click" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
