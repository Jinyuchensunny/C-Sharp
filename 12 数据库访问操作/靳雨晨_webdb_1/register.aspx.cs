using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 靳雨晨_webdb_1
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btnregister_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;  //页面的验证均通过后才执行提交代码,否则返回
            string uname = username.Text.Trim();
            string pwd = password.Text.Trim();
            string usex = sex.SelectedValue.ToString();
            string uage = age.Text.Trim();
            string uemail = email.Text.Trim();
            if (uage == "") uage = "0";
            string d = ConfigurationManager.ConnectionStrings["con1"].ConnectionString;
            SqlConnection con = new SqlConnection(d);
            //SqlCommand cmd = new SqlCommand();
            SqlCommand cmd = new SqlCommand("select * from admin where username=@uname", con);
     
            cmd.Parameters.Add("@uname", SqlDbType.VarChar).Value = uname;
            SqlDataReader dr = null;
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Response.Write("<script>alert('用户已存在');</script>"); 
                    dr.Close();
                }
                else
                {
                    dr.Close();
                    string sql = "insert into admin values(@uname,@pwd,@usex,@uage,@uemail)";
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@uname", SqlDbType.VarChar).Value = uname;
                    cmd.Parameters.Add("@pwd", SqlDbType.VarChar).Value = pwd;
                    cmd.Parameters.Add("@usex", SqlDbType.Bit).Value = usex;
                    cmd.Parameters.Add("@uage", SqlDbType.Int).Value = uage;
                    cmd.Parameters.Add("@uemail", SqlDbType.VarChar).Value = uemail;

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('注册成功');</script>");
                    Response.Write("<br /><a href=login.aspx>转到登录页面</a>");
                }
            }
            catch(Exception ee)
            {
                string s = Server.HtmlEncode(ee.Message);
                Response.Write(s);
                Response.Write("<script>alert('注册失败');</script>");
            }
            finally
            { 
                if (con != null && con.State == ConnectionState.Open) con.Close();
            }
        }
    }
}