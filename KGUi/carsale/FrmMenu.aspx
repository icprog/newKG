<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmMenu.aspx.cs" Inherits="KGUi.carsale.FrmMenu" %>

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
        
     <asp:TreeView ID="TreeView1" runat="server">
                        <Nodes>
                            <asp:TreeNode Text="特販作業" Value="特販作業">
                                <asp:TreeNode NavigateUrl="./FrmCheckCarSale.aspx" Text="特販審核" Value="特販審核" Target="Operating">
                                </asp:TreeNode>
                                <asp:TreeNode NavigateUrl="./FrmSearchCarSale.aspx" Text="特販查詢" Value="特販查詢" Target="Operating">
                                </asp:TreeNode>
                            </asp:TreeNode>
                        </Nodes>
                    </asp:TreeView>
        
    </div>
    </form>
</body>
</html>
