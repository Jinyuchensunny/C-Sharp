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
    public partial class teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getteacher("全部");
                //Response.Write("<script>alert('load')</script>");
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)//dd1 职称下拉列表
        {
            //Response.Write("<script>alert('changed')</script>");
            Label1.Text = "";
            getteacher(dd1.SelectedValue);
            Panel1.Visible = false;
        }

        private void getteacher(string n)
        {
            ListBox1.Items.Clear();//88888
            string d = ConfigurationManager.ConnectionStrings["con1"].ConnectionString;
            SqlConnection con = new SqlConnection(d);
            try
            {
                con.Open();//打开数据库
                string s = "select *from teachers";
                if (!n.Equals("全部")) s = s + " where title=@t";//定义数据库的查询命令
                SqlCommand cmd = new SqlCommand(s, con);
                cmd.Parameters.Add("@t", SqlDbType.VarChar).Value = n;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)//有结果
                {
                    while (dr.Read())
                    {
                        ListBox1.Items.Add(new ListItem(dr["tname"].ToString(), dr["tid"].ToString()));//显示内容和值
                    }
                }
                else Label1.Text = "没有符合条件的教师！";
                dr.Close();//关闭结果集

                //显示符合条件的教师是几位
                //第一种
                //cmd.CommandText = "select count(*) from teachers";
                //if (!n.Equals("全部")) cmd.CommandText += " where title=@t";
                //string i = cmd.ExecuteScalar().ToString();//符合条件的教师数目
                //Label1.Text = "符合条件的教师共" + i + "位";
                //con.Close();//关闭数据库

                //第二种
                Label1.Text= "符合条件的教师共" + ListBox1.Items.Count.ToString() + "位";
            }
            catch(Exception ee)
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
            if (ListBox1.SelectedIndex == -1) return;//没有选择任何教师
            string d = ConfigurationManager.ConnectionStrings["con1"].ConnectionString;
            SqlConnection con = new SqlConnection(d);
            try
            {
                string s = "select *from teachers where tid=@tid";
                con.Open();
                SqlCommand cmd = new SqlCommand(s, con);
                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = ListBox1.SelectedValue;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    tb_tid.Text = dr["tid"].ToString();//教师编号
                    tb_tname.Text = dr["tname"].ToString();
                    tb_age.Text = dr["age"].ToString();
                    tb_birthplace.Text = dr["birthplace"].ToString();
                    tb_email.Text = dr["email"].ToString();
                    d_title.Text = dr["title"].ToString();
                    d_sex.SelectedValue = dr["sex"].ToString();
                    Panel1.Visible = true;
                    tb_tid.ReadOnly = true;//保证正确性
                    btn_update.Visible = true;
                    btn_insert.Visible = false;
                    btn_tid.Visible = true;
                    btn_ok.Visible = btn_cancel.Visible = tb_newtid.Visible = false;
                }
                else
                {
                    Label1.Text = "获取" + ListBox1.SelectedItem.Text + "老师的详细信息获取失败";
                    Panel1.Visible = false;
                }
                dr.Close();
            }
            catch(Exception ee)
            {
                Label1.Text = Server.HtmlEncode(ee.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open) con.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)//更新
        {
            string d = ConfigurationManager.ConnectionStrings["con1"].ConnectionString;
            SqlConnection con = new SqlConnection(d);
            try
            {
                string s = "update teachers set tname=@tname,title=@title,sex=@sex,birthplace=@bp," + "age=@age,email=@e where tid=@tid";
                SqlCommand cmd = new SqlCommand(s, con);
                cmd.Parameters.Add("tname", SqlDbType.VarChar).Value = tb_tname.Text.Trim();
                cmd.Parameters.Add("@title", SqlDbType.VarChar).Value = d_title.SelectedValue;
                cmd.Parameters.Add("@sex", SqlDbType.Bit).Value = d_sex.SelectedValue;
                cmd.Parameters.Add("@bp", SqlDbType.VarChar).Value = tb_birthplace.Text.Trim();
                cmd.Parameters.Add("@e", SqlDbType.VarChar).Value = tb_email.Text.Trim();
                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tb_tid.Text.Trim();
                Regex r = new Regex(@"^\d+$");//非负整数
                if (r.IsMatch(tb_age.Text.Trim()))
                {
                    cmd.Parameters.Add("@age", SqlDbType.Int).Value = tb_age.Text.Trim();
                }
                else cmd.Parameters.Add("@age", SqlDbType.Int).Value = 0;
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i == 1)//成功
                {
                    con.Close();
                    getteacher("全部");
                    dd1.SelectedIndex = 0;
                    ListBox1.SelectedValue = tb_tid.Text;
                    Response.Write("<script>alert('更新成功！');</script>");
                }
                else//失败
                    Response.Write("<script>alert('更新失败，指定教师不存在！');</script>");
            }
            catch(Exception ee)
            {
                Label1.Text = Server.HtmlEncode(ee.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open) con.Close();
            }
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            tb_age.Text = tb_birthplace.Text = tb_email.Text = tb_tname.Text = "";
            tb_tid.ReadOnly = false;
            Panel1.Visible = true;
            btn_tid.Visible = false;
            btn_insert.Visible = true;
            btn_update.Visible = false;
            btn_ok.Visible = btn_cancel.Visible = tb_newtid.Visible = false;
        }


        protected void btn_insert_Click1(object sender, EventArgs e)
        {
            //插入新教师+教师编号的合法判断，不合法，直接返回（需要自己添加）
            string d = ConfigurationManager.ConnectionStrings["con1"].ConnectionString;
            SqlConnection con = new SqlConnection(d);
            try
            {
                string s = "select *from teachers where tid=@tid";
                SqlCommand cmd = new SqlCommand(s, con);
                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tb_tid.Text.Trim();
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)//已存在
                {
                    Response.Write("<script>alert('教师编号已存在');</script>");
                    dr.Close();
                    con.Close();
                    tb_tid.Focus();
                    return;//处理结束，返回
                }
                //不存在
                dr.Close();
                //年龄合法性判断
                Regex t = new Regex(@"^\d+$");//非负整数
                string age1;
                if (t.IsMatch(tb_age.Text.Trim()))
                    age1 = tb_age.Text.Trim();
                else age1 = "0";//可以另外处理
                //插入数据
                s = "insert into teachers values(@tid,@n,@title,@sex,@age,@bp,@e)";
                cmd.CommandText = s;
                cmd.Parameters.Add("@n", SqlDbType.VarChar).Value = tb_tname.Text.Trim();
                cmd.Parameters.Add("@title", SqlDbType.VarChar).Value = d_title.SelectedValue;
                cmd.Parameters.Add("@sex", SqlDbType.Bit).Value = d_sex.SelectedValue;
                cmd.Parameters.Add("@bp", SqlDbType.VarChar).Value = tb_birthplace.Text.Trim();
                cmd.Parameters.Add("@age", SqlDbType.Int).Value = age1;
                cmd.Parameters.Add("@e", SqlDbType.VarChar).Value = tb_email.Text.Trim();
                cmd.ExecuteNonQuery();
                con.Close();
                //重新读取教师列表
                if (!dd1.SelectedValue.Equals("全部"))
                    dd1.SelectedValue = d_title.SelectedValue;
                getteacher(dd1.SelectedValue);
                ListBox1.SelectedValue = tb_tid.Text.Trim();
                tb_tid.ReadOnly = true;
                btn_insert.Visible = false;
                btn_update.Visible = true;
                btn_tid.Visible = true;
                Response.Write("<script>alert('添加成功！');</script>");
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

        protected void btn_del_Click(object sender, EventArgs e)//删除按钮
        {
            if (ListBox1.SelectedIndex == -1)
            {
                Response.Write("<script>alert('没有选择老师！');</script>");
                return;
            }
            string d = ConfigurationManager.ConnectionStrings["con1"].ConnectionString;
            SqlConnection con = new SqlConnection(d);
            try
            {
                //先检查教师是否任课，若任课，不能删除
                SqlCommand cmd = new SqlCommand("select *from courses where tid=" + ListBox1.SelectedValue, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)//教师有授课记录
                {
                    Response.Write("<script>alert('教师有课，不能删除！');</script>");
                    dr.Close();
                    con.Close();
                    return;
                }
                dr.Close();
                cmd.CommandText = "delete from teachers where tid=" + ListBox1.SelectedValue;
                cmd.ExecuteNonQuery();
                con.Close();
                getteacher(dd1.SelectedValue);
                Panel1.Visible = false;
                Response.Write("<script>alert('删除成功！');</script>");

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

        protected void btn_tid_Click(object sender, EventArgs e)//更新编号按钮
        {
            //显示相关的控件
            tb_newtid.Visible = btn_cancel.Visible = btn_ok.Visible = true;
            tb_newtid.Text = "";
        }

        protected void btn_cancel_Click(object sender, EventArgs e)//取消编号更新
        {
            tb_newtid.Visible = btn_cancel.Visible = btn_ok.Visible = false;
        }

        protected void btn_ok_Click(object sender, EventArgs e)//确定按钮
        {
            Regex t = new Regex(@"^\d+$");//非负整数
            if (!t.IsMatch(tb_newtid.Text.Trim()))
            {
                Response.Write("<script>alert('教师编号不合法！');</script>");
            }
            string d = ConfigurationManager.ConnectionStrings["con1"].ConnectionString;
            SqlConnection con = new SqlConnection(d);
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "update_teachers_tid";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@newtid", SqlDbType.Int).Value = tb_newtid.Text.Trim();
                cmd.Parameters.Add("@oldtid", SqlDbType.Int).Value = tb_tid.Text.Trim();
                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                con.Close();
                string flag = cmd.Parameters["@flag"].Value.ToString();//提取返回值
                if (flag.Equals("0"))
                {
                    tb_tid.Text = tb_newtid.Text.Trim();
                    getteacher(dd1.SelectedValue);
                    Response.Write("<script>alert('教师编号更新成功！');</script>");
                    tb_newtid.Visible = btn_cancel.Visible = btn_ok.Visible = false;
                }
                if (flag.Equals("1"))
                    Response.Write("<script>alert('调用存储过程失败，事务回退！');</script>");
                if (flag.Equals("2"))
                    Response.Write("<script>alert('新的教师编号已经被占用！');</script>");
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
    }
}