<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="靳雨晨_webdb_1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="信任登录" Height="36px" OnClick="Button1_Click" Width="190px" />
        </div>
        <asp:Label ID="Label1" runat="server" Font-Size="20pt"></asp:Label>
        <br />
        <br />
            <asp:Button ID="Button2" runat="server" Text="SQL验证方式" Height="36px" Width="189px" OnClick="Button2_Click" />
        <br />
        <asp:Label ID="Label2" runat="server" Font-Size="20pt"></asp:Label>
        <br />
        <br />
            <asp:Button ID="Button3" runat="server" Text="web.config获取数据库连接信息" Height="36px" Width="291px" OnClick="Button3_Click"/>
        <br />
        <asp:Label ID="Label3" runat="server" Font-Size="20pt"></asp:Label>
    </form>
</body>
</html>
