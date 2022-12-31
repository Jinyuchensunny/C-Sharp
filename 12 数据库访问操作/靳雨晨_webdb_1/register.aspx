<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="靳雨晨_webdb_1.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 80px;
        }
        .auto-style4 {
            height: 80px;
            width: 290px;
        }
        .auto-style5 {
            width: 290px;
        }
        .auto-style6 {
            width: 290px;
            height: 24px;
        }
        .auto-style8 {
            height: 24px;
        }
        .auto-style9 {
            height: 80px;
            width: 405px;
        }
        .auto-style10 {
            width: 405px;
        }
        .auto-style11 {
            width: 405px;
            height: 24px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style4"></td>
                    <td class="auto-style9">用户注册</td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td class="auto-style5" style="text-align: right">用户名：</td>
                    <td class="auto-style10">
                        <asp:TextBox ID="username" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="username" ErrorMessage="请输入用户名！"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6" style="text-align: right">密 码：</td>
                    <td class="auto-style11">
                        <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="auto-style8">
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="password" ErrorMessage="请输入密码！"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5" style="text-align: right">确认密码：</td>
                    <td class="auto-style10">
                        <asp:TextBox ID="passagain" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        <asp:CompareValidator runat="server" ControlToCompare="password" ControlToValidate="passagain" ErrorMessage="请确保两次密码一致！"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5" style="text-align: right">性 别：</td>
                    <td class="auto-style10">
                        <asp:RadioButtonList ID="sex" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="true">男</asp:ListItem>
                            <asp:ListItem Value="False">女</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5" style="text-align: right">年 龄：</td>
                    <td class="auto-style10">
                        <asp:TextBox ID="age" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RangeValidator runat="server" ControlToValidate="age" ErrorMessage="不合法年龄！" MaximumValue="150" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5" style="text-align: right">Email：</td>
                    <td class="auto-style10">
                        <asp:TextBox ID="email" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator runat="server" ControlToValidate="email" ErrorMessage="邮箱格式有误！" ValidationExpression="^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style10">
                        <asp:Button ID="btnregister" runat="server" OnClick="btnregister_Click" Text="提交" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
