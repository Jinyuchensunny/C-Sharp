<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="student.aspx.cs" Inherits="靳雨晨_webdb_1.student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>学生管理</title>
</head>
<body>
    <form id="form1" runat="server">
        <div><h1 style="text-align: center">学生信息管理</h1>
            <p style="text-align: center">
                <asp:GridView ID="gv1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" OnPageIndexChanging="gv1_PageIndexChanging" Width="95%" DataKeyNames="sid" OnRowCancelingEdit="gv1_RowCancelingEdit" OnRowDeleting="gv1_RowDeleting" OnRowEditing="gv1_RowEditing" OnRowUpdating="gv1_RowUpdating">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="sid" HeaderText="学号" ReadOnly="True" >
                        <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="sname" HeaderText="姓名" >
                        <ControlStyle Width="60px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="性别">
                            <EditItemTemplate>
                                <asp:DropDownList ID="dsex" runat="server">
                                    <asp:ListItem Value="True">男</asp:ListItem>
                                    <asp:ListItem Value="False">女</asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("sex2") %>'></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="50px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="birthdate" DataFormatString="{0:yyyy-MM-dd}" HeaderText="出生日期" >
                        <ControlStyle Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="email" HeaderText="邮箱" >
                        <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="sclass" HeaderText="班级" >
                        <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="department" HeaderText="学院" >
                        <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="hobby" HeaderText="兴趣爱好" >
                        <ControlStyle Width="90px" />
                        </asp:BoundField>
                        <asp:CommandField HeaderText="操作" ShowEditButton="True" />
                        <asp:CommandField ShowDeleteButton="True" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </p>
        </div>
    </form>
</body>
</html>
