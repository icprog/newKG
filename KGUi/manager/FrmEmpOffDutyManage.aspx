<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmEmpOffDutyManage.aspx.cs" Inherits="KGUi.manager.FrmEmpOffDutyManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                員工編號:
                <asp:TextBox ID="txtEmp" runat="server"></asp:TextBox><br />
                名字:
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
                <asp:Button ID="btnAdd" runat="server" Text="新增" OnClick="btnAdd_Click" />
                <asp:Button ID="btnCheck" runat="server" Text="查詢" OnClick="btnCheck_Click" />

                <asp:GridView ID="gvOffDuty" runat="server" EnableModelValidation="True" AllowPaging="True" DataKeyNames="EMPNO" OnPageIndexChanging="gvOffDuty_PageIndexChanging" OnRowCommand="gvOffDuty_RowCommand" OnRowDeleting="gvOffDuty_RowDeleting">
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True"></asp:CommandField>
                    </Columns>

                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                </asp:GridView>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
