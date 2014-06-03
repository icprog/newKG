<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmPrintWork.aspx.cs" Inherits="KGUi.insert.FrmPrintWork" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>高輊洗車</title>
    <style type="text/css">
        
         @media print
        {
            .noprint
            {
                display: none;
            }
        }
        #printBnt2
        {
            height: 47px;
            width: 134px;
        }
        </style>

    <script language="JavaScript" type="text/JavaScript">

function DP() {
window.print();
window.close();
}

    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="Div2" class="noprint">
        <input type="button" value="列印" onclick="javascript:DP();" id="printBnt2">
    </div>
    <div id="Div1">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <table width="600" border="1">
            <tr>
                <td colspan="3">
                    <div align="center">
                        =====高輊洗車工單(存根聯)=====</div>
                </td>
            </tr>
            <tr>
                <td width="80">
                    <div align="right">
                        工單單號:</div>
                </td>
                <td width="224">
                   <asp:Label ID="_lbl工單單號" runat="server" Text="Label"></asp:Label>
                </td>
                <td width="282">
                    <div align="center">
                        施工人員簽名處</div>
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        引擎號碼:</div>
                </td>
                <td>
                    <asp:Label ID="_lbl引擎號碼" runat="server" Text="Label"></asp:Label>
                </td>
                <td rowspan="5">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        顧客名稱:</div>
                </td>
                <td>
                    <asp:Label ID="_lbl顧客名稱" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        洗車種類:</div>
                </td>
                <td>
                    <asp:Label ID="_lbl洗車種類" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        金額:</div>
                </td>
                <td>
                    <asp:Label ID="_lbl金額" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        開單人員:</div>
                </td>
                <td>
                    <asp:Label ID="_lbl開單人員" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        工單種類:</div>
                </td>
                <td>
                    <asp:Label ID="_lbl工單種類" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <div align="center">
                        服務廠確認簽名處</div>
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        開單日期:</div>
                </td>
                <td>
                    <asp:Label ID="_lbl開單日期" runat="server" Text="Label"></asp:Label>
                </td>
                <td rowspan="5">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        介紹人:</div>
                </td>
                <td>
                    <asp:Label ID="_lbl介紹人" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        保險代碼:</div>
                </td>
                <td>
                    <asp:Label ID="_lbl保險代碼" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        工單所別:</div>
                </td>
                <td>
                    <asp:Label ID="_lbl工單所別" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        備註:</div>
                </td>
                <td>
                    <asp:Label ID="_lbl備註" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
        <p align="center" width="400">
            ＝＝＝＝＝＝＝＝＝＝＝＝＝裁切線＝＝＝＝＝＝＝＝＝＝＝＝＝</p>
            <table width="600" border="1">
            <tr>
                <td colspan="3">
                    <div align="center">
                        =====高輊洗車工單(存根聯)=====</div>
                </td>
            </tr>
            <tr>
                <td width="80">
                    <div align="right">
                        工單單號:</div>
                </td>
                <td width="224">
                    <asp:Label ID="_lbl工單單號1" runat="server" Text="Label"></asp:Label>
                </td>
                <td width="282">
                    <div align="center">
                        施工人員簽名處</div>
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        引擎號碼:</div>
                </td>
                <td>
                    <asp:Label ID="_lbl引擎號碼1" runat="server" Text="Label"></asp:Label>
                </td>
                <td rowspan="5">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        顧客名稱:</div>
                </td>
                <td>
                    <asp:Label ID="_lbl顧客名稱1" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        洗車種類:</div>
                </td>
                <td>
                    <asp:Label ID="_lbl洗車種類1" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        金額:</div>
                </td>
                <td>
                    <asp:Label ID="_lbl金額1" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        開單人員:</div>
                </td>
                <td>
                    <asp:Label ID="_lbl開單人員1" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        工單種類:</div>
                </td>
                <td>
                    <asp:Label ID="_lbl工單種類1" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <div align="center">
                        服務廠確認簽名處</div>
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        開單日期:</div>
                </td>
                <td>
                    <asp:Label ID="_lbl開單日期1" runat="server" Text="Label"></asp:Label>
                </td>
                <td rowspan="5">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        介紹人:</div>
                </td>
                <td>
                    <asp:Label ID="_lbl介紹人1" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        保險代碼:</div>
                </td>
                <td>
                    <asp:Label ID="_lbl保險代碼1" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        工單所別:</div>
                </td>
                <td>
                    <asp:Label ID="_lbl工單所別1" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        備註:</div>
                </td>
                <td>
                    <asp:Label ID="_lbl備註1" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
