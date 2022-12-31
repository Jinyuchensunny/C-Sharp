using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;

namespace 靳雨晨_webdb_1
{
    public partial class student : System.Web.UI.Page
    {
        //定义全局变量
        SqlDataAdapter da;//数据适配器
        SqlConnection con;
        DataSet ds = null;
        private void stu_bind()
        {
            string d = ConfigurationManager.ConnectionStrings["con1"].ConnectionString;
            con = new SqlConnection(d);//创建数据库连接
            string s = "select *,case sex when 1 then '男' when 0 then '女' end sex2 from students";
            da = new SqlDataAdapter(s, con);//创建数据适配器
            ds = new DataSet();
            da.Fill(ds, "stu");//读取数据并填充至结果集stu
            gv1.DataSource = ds.Tables["stu"];//属性，说明数据位置在stu
            gv1.DataBind();//取数据
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//第一次
                stu_bind();
        }

        protected void gv1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv1.PageIndex = e.NewPageIndex;
            stu_bind();
        }

        protected void gv1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //该行正在被修改
            //获取性别标签
            Label lb = gv1.Rows[e.NewEditIndex].Cells[2].FindControl("Label1") as Label;
            string sex1 = lb.Text;

            gv1.EditIndex = e.NewEditIndex;
            stu_bind();
            DropDownList dsex = gv1.Rows[e.NewEditIndex].Cells[2].FindControl("dsex") as DropDownList;
            if (sex1.Equals("男")) dsex.SelectedIndex = 0;
            else dsex.SelectedIndex = 1;
        }

        protected void gv1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //点击取消
            gv1.EditIndex = -1;
            stu_bind();
        }

        protected void gv1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //更新
            try
            {
                string d = ConfigurationManager.ConnectionStrings["con1"].ConnectionString;//连接数据库
                con = new SqlConnection(d);
                string s = "update students set sname=@n,sex=@s,birthdate=@b,email=@e,department=@d,hobby=@h,sclass=@c where sid=@sid";
                SqlCommand m = new SqlCommand(s, con);
                m.Parameters.Add("@sid", SqlDbType.Int).Value = gv1.DataKeys[e.RowIndex][0].ToString();
                TextBox t = gv1.Rows[e.RowIndex].Cells[1].Controls[0] as TextBox;
                m.Parameters.Add("@n", SqlDbType.VarChar).Value = t.Text.Trim();
                t = gv1.Rows[e.RowIndex].Cells[3].Controls[0] as TextBox;
                m.Parameters.Add("@b", SqlDbType.DateTime).Value = t.Text.Trim();
                t = gv1.Rows[e.RowIndex].Cells[4].Controls[0] as TextBox;
                m.Parameters.Add("@e", SqlDbType.VarChar).Value = t.Text.Trim();
                t = gv1.Rows[e.RowIndex].Cells[5].Controls[0] as TextBox;
                m.Parameters.Add("@c", SqlDbType.VarChar).Value = t.Text.Trim();
                t = gv1.Rows[e.RowIndex].Cells[6].Controls[0] as TextBox;
                m.Parameters.Add("@d", SqlDbType.VarChar).Value = t.Text.Trim();
                t = gv1.Rows[e.RowIndex].Cells[7].Controls[0] as TextBox;
                m.Parameters.Add("@h", SqlDbType.VarChar).Value = t.Text.Trim();
                DropDownList dd = gv1.Rows[e.RowIndex].Cells[2].FindControl("dsex") as DropDownList;
                m.Parameters.Add("@s", SqlDbType.Bit).Value = dd.SelectedValue;
                con.Open();
                int i = m.ExecuteNonQuery();
                con.Close();
                if (i == 1) Response.Write("<script>alert('更新成功！');</script>");
                else Response.Write("<script>alert('学生不存在，更新失败！');</script>");
                gv1.EditIndex = -1;
                stu_bind();
            }
            catch (Exception ee)
            {
                string s = Server.HtmlEncode(ee.Message);
                Response.Write(s);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open) con.Close();
            }
        }

        protected void gv1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //删除
            try
            {
                string sid = gv1.DataKeys[e.RowIndex][0].ToString();//提取学号
                string d = ConfigurationManager.ConnectionStrings["con1"].ConnectionString;//连接数据库
                con = new SqlConnection(d);
                SqlCommand m = new SqlCommand("delete from students where sid = @sid", con);
                m.Parameters.Add("@sid", SqlDbType.Int).Value = sid;
                con.Open();
                int i = m.ExecuteNonQuery();
                con.Close();
                if (i == 1) Response.Write("<script>alert('删除成功！');</script>");
                else Response.Write("<script>alert('学生不存在，删除失败！');</script>");
                gv1.EditIndex = -1;
                stu_bind();
            }
            catch(Exception ee)
            {
                string s = Server.HtmlEncode(ee.Message);
                Response.Write(s);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open) con.Close();
            }
        }

    }
}