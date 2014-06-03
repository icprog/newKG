<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmLogin.aspx.cs" Inherits="KGUi.FrmLogin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>登入畫面</title>
    <script type="text/javascript" src="./js/jquery-1.4.2.min.js"></script>
	<script type="text/javascript">
		$(document).ready(function() {
			$('input[type="text"]').addClass("idleField");
			$('input[type="password"]').addClass("idleField");
       		$('input[type="text"]').focus(function() {
       			$(this).removeClass("idleField").addClass("focusField");
    		    if (this.value == this.defaultValue){ 
    		    	this.value = '';
				}
				if(this.value != this.defaultValue){
	    			this.select();
	    		}
    		});
       		$('input[type="password"]').focus(function() {
       			$(this).removeClass("idleField").addClass("focusField");
    		    if (this.value == this.defaultValue){ 
    		    	this.value = '';
				}
				if(this.value != this.defaultValue){
	    			this.select();
	    		}
    		});
    		$('input[type="text"]').blur(function() {
    			$(this).removeClass("focusField").addClass("idleField");
    		    if ($.trim(this.value) == ''){
			    	this.value = (this.defaultValue ? this.defaultValue : '');
				}
    		});
    		$('input[type="password"]').blur(function() {
    			$(this).removeClass("focusField").addClass("idleField");
    		    if ($.trim(this.value) == ''){
			    	this.value = (this.defaultValue ? this.defaultValue : '');
				}
    		});
		});			
	</script>
<style type="text/css">
body {
	background-image: url(images/index_bg.jpg);
	background-repeat: repeat-x;
	margin-top: -5px;
}
  *{
    	margin:0;
    	padding:0;
    	font:bold 12px "Lucida Grande", Arial, sans-serif;
    }
    body {
    	padding: 10px;
    }
    h1{
    	font-size:14px;
    }
    #status{
    	width:50%;
    	padding:10px;
    	height:42px;
    	outline:none;
    }
    .focusField{
    	border:solid 3px #73A6FF ;
    	background:#EFF5FF;
    	color:#000;
    }
    .idleField{
    	background:#EEE;
    	color: #6F6F6F;
		border: solid 2px #DFDFDF;
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
 
</head>
<body >
    <form id="form1" runat="server" >
    <div >
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table border="0" align="center" cellpadding="0" cellspacing="0" >
                    <tr>
                        <td height="183" colspan="3"  >
                            <img src="images/index_t.jpg" width="800" height="183" />
                        </td>
                    </tr>
                    <tr>
                        <td width="90" height="343">
                            <img src="images/index_l.jpg" width="90" height="343" />
                        </td>
                        <td width="620" align="center">
                            <table width="200" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td colspan="3" align="left">
                                        <img src="images/index_title.gif" width="588" height="110" /><br />
                                       <asp:Label ID="Label2" runat="server" ForeColor="red" 
                                            Text="1. 2011/08/31 NEW!!!新增工單完工日查詢By施工人員" Font-Size="10pt"></asp:Label>
                                             <br/>
                                        <asp:Label ID="Label9999" runat="server" ForeColor="red" 
                                            Text="2. 2011/06/14 注意!!新增試乘車工單須為建檔之試乘車才能開立，若有錯誤請回報資訊室" Font-Size="10pt"></asp:Label>
                                       <br/>
                                        <asp:Label ID="Label7" runat="server" ForeColor="#660000" 
                                            Text="3. 2011/05/24 工單總類新增試乘車種類，相關問題請洽高輊，若有錯誤請回報資訊室" Font-Size="10pt"></asp:Label>
                                       <br/> 
                                       
                                        </td>
                                        
                                        </td>
                                </tr>
                                <tr>
                                    <td width="195">
                                        <img src="images/index_id.gif" width="149" height="71" />
                                    </td>
                                    <td width="202" align="left">
                                        <asp:TextBox ID="_txt帳號" runat="server" Height="55px" Width="180px" 
                                            Font-Size="28pt" TabIndex="1"></asp:TextBox>
                                    </td>
                                    <td width="191" rowspan="2">
                                            <asp:ImageButton ID="_btn登入" ImageUrl="images/index_login.gif" runat="server"
                                                width="140" height="145" border="0" onclick="_btn登入_Click" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('_btn登入','','./images/index_login2.gif',1)"/>         
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="images/index_pass.gif" width="150" height="74" />
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="_txt密碼" runat="server" Height="55px" Width="180px" 
                                            Font-Size="28pt" TextMode="Password" TabIndex="3"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="90">
                            <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="12pt" 
                                NavigateUrl="~/FrmSatisfaction.aspx" Target="_blank">滿意度調查GO!!</asp:HyperLink>
                            <img src="images/index_r.jpg" width="90" height="343" border="0" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <img src="images/index_d.jpg" width="800" height="74" />
                        </td>
                    </tr>
                </table>
                
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
