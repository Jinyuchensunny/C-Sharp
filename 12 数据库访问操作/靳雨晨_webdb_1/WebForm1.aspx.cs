using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace 靳雨晨_webdb_1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = ConfigurationManager.ConnectionStrings["con1"].ConnectionString;
            SqlConnection con = new SqlConnection(s);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from teachers";
                cmd.Connection = con;
                SqlDataReader dr = cmd.ExecuteReader();//执行
                while(dr.Read())//读取下一条
                {
                    Response.Write(dr["tname"].ToString() + "<br/>");
                }
                dr.Close();//关闭结果集
                con.Close();//关闭数据库连接串
            }
            catch(Exception ee)
            {
                string c = Server.HtmlEncode(ee.Message);
                Response.Write(c);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open) con.Close();//数据库已经打开，操作过程中运行至catch，关闭数据库连接
            }
        }

        protected void Button1_Click(object sender, EventArgs e)//信任登录
        {
            string s = @"server=(localdb)\MSSQLLocalDB;database=E:\WORKSPACEVS\0519\CTEST_DATA-2008\ctest_Data.MDF;integrated security=sspi;";//uid=sa;pwd=xxxxx;
            SqlConnection con = new SqlConnection(s);
            con.Close();//关闭数据库
            try
            {
                con.Open();//打开数据库
                Label1.Text = "可信任登录方式数据库连接成功！";
                con.Close();
            }
            catch(Exception ee)
            {
                Label1.Text = Server.HtmlEncode(ee.Message);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)//sql验证方式
        {
            string c = @"data source=(localdb)\MSSQLLocalDB;integrated security=sspi;AttachDbFilename=E:\WORKSPACEVS\0519\CTEST_DATA-2008\ctest_Data.MDF";
            SqlConnection con = new SqlConnection(c);
            try
            {
                con.Open();//打开数据库
                Label2.Text = "数据文件登录方式数据库连接成功！";
                con.Close();
            }
            catch (Exception ee)
            {
                Label2.Text = Server.HtmlEncode(ee.Message);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)//web.config
        {
            string d = ConfigurationManager.ConnectionStrings["connctest"].ConnectionString;
            SqlConnection con = new SqlConnection(d);
            try
            {
                con.Open();//打开数据库
                Label3.Text = "web.config获取数据库连接信息-数据库连接成功！";
                // 数据查询
                string s = "select * from teachers";
                SqlCommand cmd = new SqlCommand(s, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Response.Write(dr["tname"].ToString() + "<br/>");
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ee)
            {
                Label3.Text = Server.HtmlEncode(ee.Message);
            }
        }
    }
}