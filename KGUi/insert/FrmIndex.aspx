<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmIndex.aspx.cs" Inherits="KGUi.insert.FrmIndex" %>

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
            background-image: url(../../images/index_bg.jpg);
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td><table border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td height="183"><img src="../images/index_t.jpg" width="735" height="171" /></td>
      </tr>
      <tr>
        <td align="center"><table width="90%" border="0" cellpadding="5" cellspacing="0">
            <tr>
              <td class="STYLE1"><asp:ImageButton ID="ImageButton1" runat="server"  
                                                       OnClientClick="return confirm('確定登出?')" 
                                                        ImageUrl="../images/Exit.gif" onclick="ImageButton1_Click" /></td>
            </tr>
            <tr>
              <td><table width="95%" border="0" cellpadding="0" cellspacing="0">
                  <tr>
                    <td>
<asp:ImageButton ID="_btn開立工單" ImageUrl="../images/assistant_index_button1.gif" runat="server"
                                                                    border="0" OnClick="_btn開立工單_Click" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('_btn開立工單','','../images/assistant_index_button3.gif',1)" />
</td>
                    <td>&nbsp;</td>
                    <td><asp:ImageButton ID="_btn歷史查詢" ImageUrl="../images/assistant_index_button2.gif" runat="server"
                                                                    border="0" OnClick="_btn歷史查詢_Click" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('_btn歷史查詢','','../images/assistant_index_button4.gif',1)" />
 </td>
                  </tr>
                  <tr>
                    <td> 
                        <br />
                   
                    <asp:ImageButton ID="_btn小百貨" ImageUrl="../images/part_index_button1.gif" runat="server"
                                                                    border="0" 
                            onclick="_btn小百貨_Click" />
                  
                    </a>
                      </td>
                    <td>&nbsp;</td>
                    <td> </td>
                  </tr>
              </table></td>
            </tr>

        </table></td>
      </tr>

    </table></td>
  </tr>
  <tr>
    <td><br />
      <table width="690" border="0" align="center" cellpadding="0" cellspacing="0">

      <tr>
        <td colspan="3"><p><img src="../images/assistant_index_t.gif" width="690" height="27" /></p>
          </td>
        </tr>
      <tr>
        <td width="7" background="../images/assistant_index_l.gif"><img src="../images/assistant_index_l.gif" width="7" height="7" border="0" /></td>
        <td width="677" height="400" bgcolor="#FFFFFF" valign="top">
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
                                                <asp:TemplateField HeaderText="開單人員">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label32" runat="server" Text='<%# Eval("開單人員")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="列印">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="_btn列印" runat="server" OnClick="_btn列印_Click" ImageUrl="../images/icon_printer.gif"/>
                                                       
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
        <td width="6" background="../images/assistant_index_r.gif"><img src="../images/assistant_index_r.gif" width="6" height="6" /></td>
      </tr>
      <tr>
        <td colspan="3"><img src="../images/assistant_index_d.gif" width="690" height="10" /></td>
      </tr>
    </table>
        <br />
      <p><img src="../images/assistant_index_dp.gif" width="800" height="58" align="bottom" /></p>
    </td>
  </tr>
</table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
