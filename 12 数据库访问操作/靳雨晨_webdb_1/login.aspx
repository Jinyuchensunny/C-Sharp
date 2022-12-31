<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="靳雨晨_webdb_1.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>登陆页面</title>
    <style type="text/css">
        .auto-style1 {
            height: 24px;
        }
        .auto-style2 {
            height: 24px;
            width: 505px;
        }
        .auto-style3 {
            width: 505px;
        }
        .auto-style4 {
            height: 24px;
            width: 662px;
        }
        .auto-style5 {
            width: 662px;
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style4">用户登录</td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td class="auto-style3" style="text-align: right" >用户名：</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txt_username" runat="server" Width="140px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3" style="text-align: right">密码：</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txt_password" runat="server" Width="140px" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style5">
                        <asp:Button ID="btn_ok" runat="server" OnClick="btn_ok_Click" Text="确定" />
&nbsp;&nbsp;
                        <asp:Button ID="register" runat="server" OnClick="register_Click" Text="注册" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
