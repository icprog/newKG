<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmInsertWork.aspx.cs"
    Inherits="KGUi.insert.FrmInsertWork" %>

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
            background-image: url(../images/index_bg.jpg);
            background-repeat: repeat-x;
            margin-top: -5px;
            background-color: #272727;
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
    </style>
    <link href="../css/word.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td background="../images/assistant_p3_bg.jpg">
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
                                                        ImageUrl="../images/Exit.gif" onclick="ImageButton1_Click" />  > <a href="FrmIndex.aspx" class="b1">功能選單</a>><a href="FrmWorkType.aspx" class="b1">挑選工單類型</a>><span class="w1">輸入工單</span>
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
                            <table width="690" border="0" align="center" cellpadding="0" cellspacing="0">
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
                                    <td width="677" bgcolor="#FFFFFF">
                                       <table width="100%" border="0" align="center" cellpadding="5" cellspacing="0">
          <tr bgcolor="#E1E1E1">
            <td width="23%">工單種類<br /></td>
            <td width="77%"><asp:Label ID="_lbl工單種類" runat="server" Font-Bold="True" 
                    Font-Size="16pt"></asp:Label></td>
          </tr>
          <tr>
            <td>工單號碼</td>
            <td><asp:TextBox ID="_txt工單號碼" runat="server" Enabled="False" Height="30px" 
                    Width="211px" Font-Bold="True" Font-Size="16pt"></asp:TextBox></td>
          </tr> 
          <tr>
            <td>服務專員</td>
            <td><asp:TextBox ID="_txt服務專員" runat="server" Height="30px" 
                    Width="77px" Font-Bold="True" Font-Size="16pt" AutoPostBack="True" 
                    ontextchanged="_txt服務專員_TextChanged"></asp:TextBox>
                <asp:Label ID="_lbl服務專員" runat="server"></asp:Label>
                <asp:Label ID="_lbl新車員工2" runat="server" Font-Bold="True" Font-Size="10pt" 
                    ForeColor="Red" Text="若服務廠開單人員非本人接待車輛,請輸入和泰工單專員員編"></asp:Label>
              </td>
          </tr>
          <tr bgcolor="#E1E1E1">
            <td>
                <asp:Label ID="_lbl引擎號碼和車牌" runat="server" Text="引擎號碼"></asp:Label>
              </td>
            <td><asp:TextBox ID="_txt引擎號碼" runat="server" Height="30px" 
                    Width="250px" Font-Bold="True" Font-Size="16pt" AutoPostBack="True" 
                    ontextchanged="_txt引擎號碼_TextChanged"></asp:TextBox>
                <asp:Label ID="_lbl引擎號碼" runat="server" Font-Bold="True" Font-Size="10pt" 
                    ForeColor="Red" Text=""></asp:Label>
                <asp:Label ID="_lblTip" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>

              </td>
          </tr>
          <tr>
            <td>顧客名稱</td>
            <td><asp:TextBox ID="_txt顧客名稱" runat="server" Height="30px" 
                    Width="100px" AutoPostBack="True" Font-Bold="True" Font-Size="16pt" 
                    ontextchanged="_txt顧客名稱_TextChanged"></asp:TextBox>
              <asp:Label ID="_lbl新車員工" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Red"
                                                        Text="新車or試乘車直接輸入員編"></asp:Label>
          </tr>
          <tr bgcolor="#E1E1E1">
            <td>洗車種類</td>
            <td>
            <asp:DropDownList ID="_ddl洗車種類0" runat="server" OnSelectedIndexChanged="_ddl洗車種類0_SelectedIndexChanged" 
                    Width="150px" Font-Bold="True" Font-Size="12pt" AutoPostBack="True">
                    <asp:ListItem Value=""></asp:ListItem>
                                                    <asp:ListItem Value="R">R_精緻洗車</asp:ListItem>
                                                    <asp:ListItem Value="M">M_磁土美容</asp:ListItem>
                                                    <asp:ListItem Value="S">S_超值美容</asp:ListItem>
                                                    <asp:ListItem Value="A">A_小美容</asp:ListItem>
                                                    <asp:ListItem Value="B">B_覆膜專案</asp:ListItem>
                                                    <asp:ListItem Value="L">L_亮新專案</asp:ListItem>
                                                    <asp:ListItem Value="N">N_亮新專案Ⅱ</asp:ListItem>
                                                    <asp:ListItem Value="I">I_內裝美容</asp:ListItem>
                                                    <asp:ListItem Value="E">E_引擎室深度清潔</asp:ListItem>
                                                    <asp:ListItem Value="G">G_玻璃油膜處理</asp:ListItem>
                                                    <asp:ListItem Value="C">C_速霸陸/馬自達 磁土美容</asp:ListItem>
                                                    <asp:ListItem Value="J">J_速霸陸/馬自達 小美容</asp:ListItem>
                                                    <asp:ListItem Value="P">P_速霸陸/馬自達 覆膜處理</asp:ListItem>
                                                    <asp:ListItem Value="T">T_速霸陸/馬自達 新車覆膜</asp:ListItem>
                                                    <asp:ListItem Value="K">K_速霸陸/馬自達 大美容</asp:ListItem>
                                                    <asp:ListItem Value="H">H_速霸陸/馬自達 內裝美容</asp:ListItem>
                                                    <asp:ListItem Value="F">F_速霸陸/馬自達 引擎室深度清潔</asp:ListItem>
                                                    <asp:ListItem Value="D00">D_和榮</asp:ListItem>
                                                    <asp:ListItem Value="W">W_保值(新車,TN腹膜)</asp:ListItem>
                                                    <asp:ListItem Value="Y">Y_保值(需拋光,TN腹膜)</asp:ListItem>
                                                    </asp:DropDownList>
            <asp:DropDownList ID="_ddl洗車種類" runat="server" AutoPostBack="True" OnSelectedIndexChanged="_ddl洗車種類_SelectedIndexChanged" 
                    Width="350px" Font-Bold="True" Font-Size="11pt">
                                                    </asp:DropDownList></td>
          </tr>
          <tr>
            <td>金　　額</td>
            <td><asp:TextBox ID="_txt金額" runat="server" Enabled="False" Height="30px" 
                    Width="100px" Font-Bold="True" Font-Size="16pt"></asp:TextBox></td>
          </tr>
          <tr bgcolor="#E1E1E1">
            <td>保險公司</td>
            <td> 
                <asp:RadioButtonList ID="_rdo保險公司" runat="server" RepeatDirection="Horizontal" 
                    Font-Bold="True" Font-Size="16pt" RepeatColumns="6" AutoPostBack="True" 
                    onselectedindexchanged="_rdo保險公司_SelectedIndexChanged" Enabled="False">
                                                    </asp:RadioButtonList></td>
          </tr>
          <tr bgcolor="#E1E1E1">
            <td>保險型態</td>
            <td> 
                <asp:RadioButtonList ID="_rdo保險型態" runat="server" RepeatDirection="Horizontal" 
                    Font-Bold="True" Font-Size="16pt" RepeatColumns="6" Enabled="False">
                    <asp:ListItem Text="出險(警察紀錄)" Value="出險" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="財損" Value="財損"></asp:ListItem>
                    <asp:ListItem Text="保險到期" Value="保險到期"></asp:ListItem>
                                                    </asp:RadioButtonList></td>
          </tr>
          <tr>
            <td>備　　註</td>
            <td><asp:TextBox ID="_txt備註" runat="server" Height="58px" TextMode="MultiLine" 
                    Width="396px" Font-Bold="True" Font-Size="16pt"></asp:TextBox></td>
          </tr>
          <tr bgcolor="#E1E1E1">
            <td>是否招攬</td>
            <td><asp:RadioButtonList ID="_rdo是否招攬" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
                                                        
                    OnSelectedIndexChanged="_rdo是否招攬_SelectedIndexChanged" Font-Bold="True" 
                    Font-Size="16pt">
                                                        <asp:ListItem Value="是" Text="是(營業所)"></asp:ListItem>
                                                        <asp:ListItem Value="否" Text="否(服務廠)" Selected="True"></asp:ListItem>
                                                    </asp:RadioButtonList></td>
          </tr>
          <tr>
            <td>介紹人</td>
            <td><asp:TextBox ID="_txt介紹人" runat="server" Visible="False" Height="30px" 
                    Width="100px" AutoPostBack="True" Font-Bold="True" Font-Size="16pt" 
                    ontextchanged="_txt介紹人_TextChanged"></asp:TextBox>
                <asp:Label ID="_lbl新車員工1" runat="server" Font-Bold="True" Font-Size="10pt" 
                    ForeColor="Red" Text="新車直接輸入員編"></asp:Label>
                <br />
                <asp:Label ID="_lbl新車員工3" runat="server" Font-Bold="True" Font-Size="10pt" 
                    ForeColor="Red" Text="*請確認該人員是否離職，若影響獎金發放則扣KEY單人員薪資"></asp:Label>
              </td>
          </tr>
        </table>
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
                                <tr>
                                    <td colspan="3">
                                        <table border="0" align="right" cellpadding="5" cellspacing="5">
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="_btn開立" ImageUrl="../images/assistant_p3_b1.gif" runat="server"
                                                        border="0" OnClick="_btn開立_Click" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('_btn開立','','../images/assistant_p3_b1_2.gif',1)" />
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="_btn取消" ImageUrl="../images/assistant_p3_b2.gif" runat="server"
                                                        border="0" OnClick="_btn取消_Click" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('_btn取消','','../images/assistant_p3_b2_2.gif',1)" />
                                                </td>
                                            </tr>
                                        </table>
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
