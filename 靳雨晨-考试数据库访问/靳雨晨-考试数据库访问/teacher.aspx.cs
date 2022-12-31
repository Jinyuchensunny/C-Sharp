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

namespace 靳雨晨_考试数据库访问
{
    public partial class teacher : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void dd1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Text = "";
            getcourse(dd1.SelectedValue);

        }

        private void getcourse(string n)
        {
            ListBox1.Items.Clear();
            string d = ConfigurationManager.ConnectionStrings["con1"].ConnectionString;
            SqlConnection con = new SqlConnection(d);
            try
            {
                con.Open();//打开数据库
                string s = "select cname,cid from courses c,teachers t where c.tid = t.tid and tname=@tname";
                SqlCommand cmd = new SqlCommand(s, con);
                cmd.Parameters.Add("@tname", SqlDbType.VarChar).Value = dd1.SelectedValue;
                SqlDataReader dr = cmd.ExecuteReader();
                //dd1.SelectedIndex = 0;
                if (dr.HasRows)//有结果
                {
                    while (dr.Read())
                    {
                        ListBox1.Items.Add(new ListItem(dr["cname"].ToString(), dr["cid"].ToString()));//显示内容和值
                    }
                }
                else Label1.Text = "该教师未任课！";
                dr.Close();//关闭结果集

            }
            catch (Exception ee)
            {
                Label1.Text = Server.HtmlEncode(ee.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open) con.Close();
            }
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBox1.SelectedIndex == -1) return;
            string d = ConfigurationManager.ConnectionStrings["con1"].ConnectionString;
            SqlConnection con = new SqlConnection(d);
            SqlCommand cmd = new SqlCommand("select *from courses where cname=@cname", con);
            cmd.Parameters.Add("@cname", SqlDbType.VarChar).Value = ListBox1.SelectedValue;
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    TextBox1.Text = dr["credits"].ToString();//学分
                    Panel1.Visible = true;
                }
                else
                {
                    Panel1.Visible = false;
                    Label1.Text = "获取学分失败！";
                }
                con.Close();
            }
            catch (Exception ee)
            {
                Label1.Text = Server.HtmlEncode(ee.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open) con.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)//修改学分
        {
            Regex r = new Regex(@"^\d+(\.{0,1}\d+){0,1}$");//非负数
            string s = TextBox1.Text.Trim();
            if (r.IsMatch(s))
            {
                string d = ConfigurationManager.ConnectionStrings["connctest"].ConnectionString;
                SqlConnection con = new SqlConnection(d);
                SqlCommand cmd = new SqlCommand("update courses set credits=@c where cname=@cname", con);
                cmd.Parameters.Add("@cname", SqlDbType.VarChar).Value = dd1.SelectedValue;
                cmd.Parameters.Add("@c", SqlDbType.Float).Value = s;
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('学分修改成功！')</script>");
                    con.Close();
                }
                catch (Exception ee)
                {
                    Response.Write(Server.HtmlEncode(ee.Message));
                    if (con != null && con.State == ConnectionState.Open) con.Close();
                }
            }
            else
            {
                Response.Write("<script>alert('学分值不合法！')</script>");
            }
        }

        protected void btn_del_Click(object sender, EventArgs e)
        {
            if (dd1.SelectedIndex == -1) return;
            string d = ConfigurationManager.ConnectionStrings["con1"].ConnectionString;
            SqlConnection con = new SqlConnection(d);
            SqlCommand cmd = new SqlCommand(" delete from courses where cname=@cname", con);
            cmd.Parameters.Add("@cname", SqlDbType.Int).Value = dd1.SelectedValue;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('删除成功！')</script>");
                con.Close();
                Panel1.Visible = false;
                ListBox1_SelectedIndexChanged(null, null);
            }
            catch (Exception ee)
            {
                Response.Write(Server.HtmlEncode(ee.Message));
                if (con != null && con.State == ConnectionState.Open) con.Close();
            }
        }
    }
}