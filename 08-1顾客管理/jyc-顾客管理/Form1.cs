using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jyc_顾客管理
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int i = 1;
        ArrayList cus = new ArrayList();

        private void Form1_Load(object sender, EventArgs e)
        {
            tb_no.Text = i++.ToString();
            cb_sorttype.Items.Add("出生日期");
            cb_sorttype.Items.Add("积分");
            cb_sorttype.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //添加顾客
            if (tb_no.Text.Trim() == "")
            {
                MessageBox.Show("输入姓名");
                return;
            }
            string cname = tb_name.Text.Trim();//姓名
            string cno = tb_no.Text;//编号

            long c = 0;
            try
            {
                c = long.Parse(tb_credit.Text.Trim());//积分
                if (c < 0)
                {
                    MessageBox.Show("积分必须大于等于0！");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("您输入的积分有误，请检查！");
                return;
            }

            DateTime d = dtp_birth.Value;//生日

            //创建顾客对象
            customer cc = new customer(cno, cname, d, c);

            cus.Add(cc);

            //显示
            display();

            //更新编号
            tb_no.Text = i++.ToString();

        }//添加顾客

        private void display()
        {
            listBox1.Items.Clear();
            foreach(customer i in cus)
            {
                listBox1.Items.Add(i.CNO + " 姓名：" + i.CNAME + "出生日期：" + i.BIRTH.ToLongDateString() + "当前积分：" + i.CREDIT.ToString());
            }
        }

        bool flag = true; 

        private void button2_Click(object sender, EventArgs e)//排序按钮
        {
            //sort
            if (cus.Count <= 1) return;
            if (cb_sorttype.SelectedIndex == 0)
            {
                sortbirth sb = new sortbirth();
                cus.Sort(sb);
            }
            if (cb_sorttype.SelectedIndex == 1)
            {
                sortcredit sc = new sortcredit();
                cus.Sort(sc);
            }

            if (flag == false)
            {
                cus.Reverse();
                flag = true;
            }
            else
            {
                flag = false;
            }
            display();
        }
    }
}
