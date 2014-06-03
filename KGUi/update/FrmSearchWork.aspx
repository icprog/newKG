<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmSearchWork.aspx.cs" Inherits="KGUi.update.FrmSearchWork" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>高輊洗車</title>
    <style type="text/css">

body {
	background-image: url(../images/index_bg.jpg);
	background-repeat: repeat-x;
	margin-top: -5px;
}

        .STYLE1
        {
            text-align: right;
            font-size: 18px;
            color: #FFF;
        }
</style>
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
    <td><table border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td height="183" colspan="3" align="center"><img src="../images/index_t.jpg" width="735" height="171" /></td>
      </tr>
      <tr>
        <td width="90">&nbsp;</td>
        <td width="620" align="center" valign="top"><table width="200" border="0" cellpadding="10" cellspacing="0">
            <tr>
              <td colspan="2" class="STYLE1"><asp:ImageButton ID="ImageButton1" runat="server"  
                                                       OnClientClick="return confirm('確定登出?')" 
                                                        ImageUrl="../images/Exit.gif" onclick="ImageButton1_Click" />> <a href="FrmUpdateIndex.aspx"  class="b1">挑選作業項目</a>><span class="w1">輸入工單</span></td>
            </tr>
            <tr>
              <td colspan="2"><img src="../images/worker_p1_title.gif" width="588" height="100" /></td>
            </tr>
            <tr>
              <td width="378">
                  <asp:TextBox ID="_txt工單號碼" runat="server" Font-Size="32pt" 
                      Height="52px" Width="418px"></asp:TextBox></td>
              <td width="190"><table border="0" cellpadding="0" cellspacing="0">
                  <tr>
                    <td>
                        <asp:ImageButton ID="_btn查詢" runat="server"  border="0" imageUrl="../images/worker_p1_b1.gif" onclick="_btn查詢_Click" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('_btn查詢','','../images/worker_p1_b1_2.gif',1)"/>
                    </td>
                  </tr>
              </table></td>
            </tr>
            
        </table></td>
        <td width="90" height="343">&nbsp;</td>
      </tr>
      <tr>
        <td colspan="3"><img src="../images/index_d.jpg" width="800" height="74" /></td>
      </tr>
    </table></td>
  </tr>
</table>

        
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
