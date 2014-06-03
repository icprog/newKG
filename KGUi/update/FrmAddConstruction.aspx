<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmAddConstruction.aspx.cs"
    Inherits="KGUi.update.FrmAddConstruction" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>高輊洗車</title>

   <style type="text/css">

body {
	background-image: url(images/index_bg.jpg);
	background-repeat: repeat-x;
	margin-top: -5px;
	background-color: #292929;
}
.white_01 {
	color: #FFF;
	text-align: right;
	font-size: 18px;
	font-family: Arial, Helvetica, sans-serif;
}
.STYLE1 {text-align: right; font-size: 18px; color: #FFF;}
.STYLE2 {color: #FFFFFF}

</style>
<script type="text/javascript">
    
      function pageLoad() {
      }
      
     function MM_swapImgRestore() { //v3.0
         var i, x, a = document.MM_sr;
         for (i = 0; a && i < a.length && (x = a[i]) && x.oSrc; i++)
             x.src = x.oSrc;
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
                        <td >
                            <table border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td height="183">
                                        <img src="../images/index_t.jpg" width="735" height="171" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <table border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td colspan="3">
                                                    <img src="../images/worker_p3_t.gif" width="202" height="33" border="0" />
                                                </td>
                                                <td class="STYLE1">
                                                  <asp:ImageButton ID="ImageButton1" runat="server"  
                                                       OnClientClick="return confirm('確定登出?')" 
                                                        ImageUrl="../images/Exit.gif" onclick="ImageButton1_Click" />>  <a href="FrmUpdateIndex.aspx" class="b1">挑選作業項目</a>><span class="w1">加入施工人員</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <img src="../images/worker_p3_l.gif" width="25" height="37" border="0" />
                                                </td>
                                                <td>
                                                    <img src="../images/worker_p3_m1.gif" width="9" height="37" border="0" />
                                                </td>
                                                <td>
                                                    <img src="../images/worker_p3_m2.gif" width="183" height="37" border="0" />
                                                </td>
                                                <td>
                                                    <img src="../images/worker_p3_m3.gif" width="10" height="37" border="0" />
                                                </td>
                                                <td>
                                                    <img src="../images/worker_p3_r.gif" width="530" height="37" border="0" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <img src="../images/worker_p3_l2.gif" width="25" height="31" />
                                                </td>
                                                <td>
                                                    <img src="../images/worker_p3_m4.gif" width="9" height="31" border="0" />
                                                </td>
                                                <td bgcolor="#FFFFFF">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <img src="../images/worker_p3_m5.gif" width="10" height="31" />
                                                </td>
                                                <td>
                                                    <img src="../images/worker_p3_information.gif" width="530" height="31" border="0" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td background="../images/worker_p3_l3.gif">
                                                    <img src="../images/worker_p3_l3.gif" width="25" height="353" />
                                                </td>
                                                <td colspan="3" valign="top" bgcolor="#FFFFFF">
                                                    <asp:CheckBoxList ID="_check" runat="server" RepeatColumns="1" RepeatDirection="Horizontal">
                                                    </asp:CheckBoxList>
                                                    <br />
                                                    <div align="center">
                                                        <br />
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <asp:ImageButton ID="_btn加入選取人員" ImageUrl="../images/worker_p3_b1.gif" runat="server"
                                                                        border="0" onmouseout="MM_swapImgRestore()" 
                                                                        onmouseover="MM_swapImage('_btn加入選取人員','','../images/worker_p3_b1_2.gif',1)" 
                                                                        onclick="_btn加入選取人員_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                                <td valign="top" bgcolor="#FFFFFF">
                                                    <br />
                                                    <table width="85%" height="338" border="0" align="center" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                               <table width="100%" border="0" align="center" cellpadding="5" cellspacing="0" 
                                                                    style="height: 308px">
         
          <tr>
            <td>工單號碼</td>
            <td><asp:Label ID="_lbl工單號碼" runat="server" Text=""></asp:Label></td>
          </tr>
          <tr bgcolor="#E1E1E1">
            <td>引擎號碼</td>
            <td><asp:Label ID="_lbl引擎號碼" runat="server" Text=""></asp:Label></td>
          </tr>
          <tr>
            <td>顧客名稱</td>
            <td><asp:Label ID="_lbl顧客名稱" runat="server" Text=""></asp:Label></td>
          </tr>
          <tr bgcolor="#E1E1E1">
            <td>洗車種類</td>
            <td><asp:Label ID="_lbl洗車種類" runat="server" Text=""></asp:Label></td>
          </tr>
          <tr>
            <td>金　　額</td>
            <td><asp:Label ID="_lbl金額" runat="server" Text=""></asp:Label></td>
          </tr>
          <tr>
            <td>備　　註</td>
            <td><asp:Label ID="_lbl備註" runat="server" Text=""></asp:Label></td>
          </tr>
          <tr>
            <td>開單人員</td>
            <td><asp:Label ID="_lbl開單人員" runat="server" Text=""></asp:Label></td>
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
