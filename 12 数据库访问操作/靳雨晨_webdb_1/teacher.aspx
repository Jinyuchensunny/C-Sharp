<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="teacher.aspx.cs" Inherits="靳雨晨_webdb_1.teacher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>教师信息</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            选择教师职称：<asp:DropDownList ID="dd1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem Selected="True">全部</asp:ListItem>
                <asp:ListItem>教授</asp:ListItem>
                <asp:ListItem>副教授</asp:ListItem>
                <asp:ListItem>讲师</asp:ListItem>
                <asp:ListItem>助教</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            查询结果：<br />
            <asp:ListBox ID="ListBox1" runat="server" Height="278px" Width="257px" AutoPostBack="True" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"></asp:ListBox>
            <asp:Button ID="btn_add" runat="server" Height="36px" OnClick="btn_add_Click" Text="添加" Width="81px" />
&nbsp;<asp:Button ID="btn_del" runat="server" Height="36px" OnClick="btn_del_Click" Text="删除" Width="81px" />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Panel ID="Panel1" runat="server" Visible="False">
                教师详细信息：<br /> 
                <br />
                教师编号：<asp:TextBox ID="tb_tid" runat="server" ReadOnly="True"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:Button ID="btn_tid" runat="server" Height="40px" OnClick="btn_tid_Click" Text="更新编号" Width="78px" />
&nbsp;<asp:TextBox ID="tb_newtid" runat="server" Visible="False"></asp:TextBox>
                &nbsp;<asp:Button ID="btn_ok" runat="server" Height="40px" OnClick="btn_ok_Click" Text="确定" Visible="False" Width="78px" />
                &nbsp;<asp:Button ID="btn_cancel" runat="server" Height="40px" OnClick="btn_cancel_Click" Text="取消" Visible="False" Width="78px" />
                <br />
                教师名称：<asp:TextBox ID="tb_tname" runat="server"></asp:TextBox>
                <br />
                职&nbsp; 称：<asp:DropDownList ID="d_title" runat="server">
                    <asp:ListItem>教授</asp:ListItem>
                    <asp:ListItem>副教授</asp:ListItem>
                    <asp:ListItem>讲师</asp:ListItem>
                    <asp:ListItem>助教</asp:ListItem>
                </asp:DropDownList>
                <br />
                性&nbsp; 别：<asp:DropDownList ID="d_sex" runat="server">
                    <asp:ListItem Selected="True" Value="True">男</asp:ListItem>
                    <asp:ListItem Value="False">女</asp:ListItem>
                </asp:DropDownList>
                <br />
                年&nbsp; 龄：<asp:TextBox ID="tb_age" runat="server"></asp:TextBox>
                <br />
                籍&nbsp; 贯：<asp:TextBox ID="tb_birthplace" runat="server"></asp:TextBox>
                <br />
                电子信箱：<asp:TextBox ID="tb_email" runat="server"></asp:TextBox>
                &nbsp;&nbsp;<asp:Button ID="btn_update" runat="server" Height="40px" OnClick="Button1_Click" Text="更新" Width="78px" />
                &nbsp;&nbsp;<asp:Button ID="btn_insert" runat="server" Height="40px" OnClick="btn_insert_Click1" Text="保存" Width="78px" />
                &nbsp;
            </asp:Panel>
        </div>
    </form>
</body>
</html>
