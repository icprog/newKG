<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmHistory.aspx.cs" Inherits="KGUi.insert.FrmHistory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>高輊洗車</title>

    <script type="text/javascript">
    
      function pageLoad() {
      }
      
     function MM_swapImgRestore() { //v3.0
      var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
    }

    function MM_preloadImages() { //v3.0
      var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
        var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
        if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
    }

    function MM_findObj(n, d) { //v4.01
      var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
        d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
      if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
      for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
      if(!x && d.getElementById) x=d.getElementById(n); return x;
    }

    function MM_swapImage() { //v3.0
      var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
       if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
    }
    </script>

    <style type="text/css">
        body
        {
            background-image: url(images/index_bg.jpg);
            background-repeat: repeat-x;
            margin-top: -5px;
            background-color: #282828;
        }
        .white_01
        {
            color: #FFF;
            text-align: right;
            font-size: 18px;
            font-family: Arial, Helvetica, sans-serif;
        }
        .STYLE1
        {
            text-align: right;
            font-size: 18px;
            color: #FFF;
        }
        .STYLE2
        {
            color: #FFFFFF;
        }
        .style1
        {
            width: 135px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
             <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="_txtBDate"
                    Format="yyyy/MM/dd">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="_txtEDate"
                    Format="yyyy/MM/dd">
                </cc1:CalendarExtender>
                <table border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <table border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td height="183">
                                        <img src="../images/index_t.jpg" width="735" height="171" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="90%" border="0" align="center" cellpadding="5" cellspacing="0">
                                            <tr>
                                                <td class="STYLE1">
                                                    <asp:ImageButton ID="ImageButton1" runat="server"  
                                                       OnClientClick="return confirm('確定登出?')" 
                                                        ImageUrl="../images/Exit.gif" onclick="ImageButton1_Click" />><a href="FrmIndex.aspx">功能選單</a>>歷史查詢
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table border="0" align="left" cellpadding="5" cellspacing="0" 
                                                        style="width: 90%">
                                                        <tr>
                                                            <td class="style1">
                                                                <img src="../images/assistant_p2_date.gif" width="120" height="35" />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="_txtBDate" runat="server" Height="35px" Font-Size="20pt" Width="150px"></asp:TextBox>
                                                                <span class="STYLE2">~ </span>
                                                                <asp:TextBox ID="_txtEDate" runat="server" Height="35px" Font-Size="20pt" Width="150px"></asp:TextBox>
                                                               <%-- <asp:CheckBox ID="_chk完工日" runat="server" Font-Size="20pt" Text="完工日" />--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style1">
                                                                <img src="../images/assistant_p2_number.gif" width="120" height="35" />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="_txt工單號碼" runat="server" Height="35px" Font-Size="20pt" Width="313px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style1">
                                                                <asp:Label ID="Label1" runat="server" Text="引擎號碼" Font-Bold="True" 
                                                                    Font-Size="XX-Large" ForeColor="White"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="_txt引擎號碼" runat="server" Height="35px" Font-Size="20pt" Width="313px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style1">
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                <table width="70%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:ImageButton ID="_btn查詢" ImageUrl="../images/assistant_p2_b1.gif" runat="server"
                                                                                border="0" OnClick="_btn查詢_Click" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('_btn查詢','','../images/assistant_p2_b1_2.gif',1)" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:ImageButton ID="_btn離開" ImageUrl="../images/assistant_p2_b2.gif" runat="server"
                                                                                border="0" OnClick="_btn離開_Click" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('_btn離開','','../images/assistant_p2_b2_2.gif',1)" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="677" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td colspan="3">
                                        <p>
                                            <img src="../images/assistant_index_t2.gif" width="690" height="27" /></p>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="7" background="../images/assistant_index_l.gif">
                                        <img src="../images/assistant_index_l.gif" width="7" height="7" border="0" />
                                    </td>
                                    <td width="677" bgcolor="#FFFFFF" height="500" valign="top">
                                        <asp:GridView ID="_gvWork" runat="server" AutoGenerateColumns="False" BackColor="White"
                                            BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="100%"
                                            ForeColor="Black" GridLines="Vertical">
                                            <RowStyle BackColor="#F7F7DE" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="項次">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label21" runat="server" Text='<%# Eval("項次")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="狀態">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label58" runat="server" Text='<%# Eval("狀態")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="工單號碼">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label26" runat="server" Text='<%# Eval("工單號碼")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="引擎號碼">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label27" runat="server" Text='<%# Eval("引擎號碼")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="顧客名稱">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label28" runat="server" Text='<%# Eval("顧客名稱")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="洗車種類">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label29" runat="server" Text='<%# Eval("洗車種類")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="金額">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label30" runat="server" Text='<%# Eval("金額")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="開單日期">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label31" runat="server" Text='<%# Eval("開單日期")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="完工日">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label32" runat="server" Text='<%# Eval("完工日")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="介紹人">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label132" runat="server" Text='<%# Eval("介紹人")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="取消">
                                                    <ItemTemplate>
                                                        <asp:Button ID="_btn刪除" runat="server" Text="刪除" OnClick="_btn刪除_Click" OnClientClick="return confirm('是否取消此工單?')"
                                                            Visible='<%# Convert.ToBoolean(Eval("是否完工")) %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#CCCC99" />
                                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </td>
                                    <td width="6" background="../images/assistant_index_r.gif">
                                        <img src="../images/assistant_index_r.gif" width="6" height="6" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <img src="../images/assistant_index_d.gif" width="690" height="10" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <p>
                                <img src="../images/assistant_index_dp.gif" width="800" height="58" align="bottom" /></p>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
