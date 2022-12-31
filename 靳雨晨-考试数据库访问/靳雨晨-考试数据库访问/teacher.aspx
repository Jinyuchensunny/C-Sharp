<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="teacher.aspx.cs" Inherits="靳雨晨_考试数据库访问.teacher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>教师任课情况</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1 style="text-align: center">教师任课情况</h1>
        <p>请选择教师：<asp:DropDownList ID="dd1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="tname" DataValueField="tname" OnSelectedIndexChanged="dd1_SelectedIndexChanged" >
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:con1 %>" SelectCommand="SELECT [tname] FROM [teachers]"></asp:SqlDataSource>
            <br />
            <br />
            任课情况：<br />
            <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" Height="278px"  Width="257px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"></asp:ListBox>
            &nbsp;<asp:Button ID="btn_del" runat="server" Height="36px"  Text="删除课程记录" Width="144px" OnClick="btn_del_Click" />
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </p>
        <p>
        </p>
        <asp:Panel ID="Panel1" runat="server">
            学分：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="修改学分" Width="132px" OnClick="Button1_Click" />
        </asp:Panel>
        <p>&nbsp;</p>
    </form>
</body>
</html>
