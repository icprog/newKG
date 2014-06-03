<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmUpdateIndex.aspx.cs"
    Inherits="KGUi.update.FrmUpdateIndex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>高輊洗車</title>
    <style type="text/css">
        body
        {
            background-image: url(../images/index_bg.jpg);
            background-repeat: repeat-x;
            margin-top: -5px;
        }
    </style>

    <script type="text/javascript">
<!--
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

function MM_nbGroup(event, grpName) { //v6.0
  var i,img,nbArr,args=MM_nbGroup.arguments;
  if (event == "init" && args.length > 2) {
    if ((img = MM_findObj(args[2])) != null && !img.MM_init) {
      img.MM_init = true; img.MM_up = args[3]; img.MM_dn = img.src;
      if ((nbArr = document[grpName]) == null) nbArr = document[grpName] = new Array();
      nbArr[nbArr.length] = img;
      for (i=4; i < args.length-1; i+=2) if ((img = MM_findObj(args[i])) != null) {
        if (!img.MM_up) img.MM_up = img.src;
        img.src = img.MM_dn = args[i+1];
        nbArr[nbArr.length] = img;
    } }
  } else if (event == "over") {
    document.MM_nbOver = nbArr = new Array();
    for (i=1; i < args.length-1; i+=3) if ((img = MM_findObj(args[i])) != null) {
      if (!img.MM_up) img.MM_up = img.src;
      img.src = (img.MM_dn && args[i+2]) ? args[i+2] : ((args[i+1])? args[i+1] : img.MM_up);
      nbArr[nbArr.length] = img;
    }
  } else if (event == "out" ) {
    for (i=0; i < document.MM_nbOver.length; i++) {
      img = document.MM_nbOver[i]; img.src = (img.MM_dn) ? img.MM_dn : img.MM_up; }
  } else if (event == "down") {
    nbArr = document[grpName];
    if (nbArr)
      for (i=0; i < nbArr.length; i++) { img=nbArr[i]; img.src = img.MM_up; img.MM_dn = 0; }
    document[grpName] = nbArr = new Array();
    for (i=2; i < args.length-1; i+=2) if ((img = MM_findObj(args[i])) != null) {
      if (!img.MM_up) img.MM_up = img.src;
      img.src = img.MM_dn = (args[i+1])? args[i+1] : img.MM_up;
      nbArr[nbArr.length] = img;
  } }
}
//-->
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <table border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <table border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="183" colspan="3" align="center">
                            <img src="../images/index_t.jpg" width="735" height="171" />
                        </td>
                    </tr>
                    <tr>
                        <td width="90">
                            &nbsp;
                        </td>
                        <td width="620" height="343" align="center">
                             <table width="95%" border="0" cellpadding="5" cellspacing="15">
                                <tr>
                                    <td align="right">
                                    <asp:ImageButton ID="ImageButton1" runat="server"  
                                                       OnClientClick="return confirm('確定登出?')" 
                                                        ImageUrl="../images/Exit.gif" onclick="ImageButton1_Click" />
                                    </td>
                                </tr>
                            </table>
                            <table width="95%" border="0" cellpadding="5" cellspacing="15">
                                <tr>
                                    <td colspan="3" align="center">
                                        <p>
                                            <img src="../images/worker_index_title.gif" width="221" height="33" /><br />
                                            <br />
                                        </p>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <a href="./FrmSearchWork.aspx?type=edit" target="_top" onclick="MM_nbGroup('down','group1','workerindexb1','../images/worker_index_b1_2.gif',1)"
                                            onmouseover="MM_nbGroup('over','workerindexb1','../images/worker_index_b1_2.gif','',1)"
                                            onmouseout="MM_nbGroup('out')">
                                            <img src="../images/worker_index_b1.gif" alt="" name="workerindexb1" width="232"
                                                height="66" border="0" id="assistantp1b1" onload="" /></a>
                                    </td>
                                    <td>
                                        <a href="./FrmSearchWork.aspx?type=close" target="_top" onclick="MM_nbGroup('down','group1','workerindexb2','../images/worker_index_b2_2.gif',1)"
                                            onmouseover="MM_nbGroup('over','workerindexb2','../images/worker_index_b2_2.gif','',1)"
                                            onmouseout="MM_nbGroup('out')">
                                            <img src="../images/worker_index_b2.gif" alt="" name="workerindexb2" width="232"
                                                height="66" border="0" id="assistantp1b2" onload="" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" align="center">
                                        <a href="./FrmHistory.aspx" target="_top" onclick="MM_nbGroup('down','group1','workerindexb3','../images/worker_index_b3_2.gif',1)"
                                            onmouseover="MM_nbGroup('over','workerindexb3','../images/worker_index_b3_2.gif','',1)"
                                            onmouseout="MM_nbGroup('out')">
                                            <img src="../images/worker_index_b3.gif" alt="" name="workerindexb3" width="232"
                                                height="66" border="0" id="assistantp1b3" onload="" /></a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="90">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <img src="../images/index_d.jpg" width="800" height="74" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
