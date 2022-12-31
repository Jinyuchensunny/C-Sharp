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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_ok_Click(object sender, EventArgs e)//确定按钮
        {
            string uname = txt_username.Text.Trim();
            string ps = txt_password.Text.Trim();
            string d = ConfigurationManager.ConnectionStrings["con1"].ConnectionString;//连接数据库
            SqlConnection con = new SqlConnection(d);
            //SqlCommand cmd = new SqlCommand("select * from admin where username=@uname, con");
            SqlCommand cmd = new SqlCommand("select * from admin where username=@uname", con);
            cmd.Parameters.Add("@uname", SqlDbType.VarChar).Value = uname;
            SqlDataReader dr = null;
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    
                    string ps2 = dr["passwd"].ToString();
                    if (ps2.Equals(ps)) Response.Redirect("teacher.aspx");//也可以是其它存在的某页面
                    else Response.Write("<script>alert('密码错误！');</script>");
                }
                else { Response.Write("<script>alert('用户不存在');</script>"); }
                dr.Close();
                //con.Close();
            }
            catch (Exception ex)
            {
                string m = ex.Message.Replace("'", "");//防止提示信息中单引号对脚本的影响
                Response.Write("<script>alert('" + m + "');</script>");
            }
            finally 
            { 
                if (con != null && con.State == ConnectionState.Open) con.Close(); 
            }
        }//确定结束

        protected void register_Click(object sender, EventArgs e)//注册
        {
            Response.Redirect("register.aspx");//转跳到注册界面
        }
    }
}