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


namespace jyc_学生排序
{
    public partial class Form1 : Form
    {

        student s1, s2, s3;
        ArrayList a = new ArrayList();
        bool flag = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //年龄排序
            sortage age = new sortage();
            a.Sort(age);
            if (flag == false)
            {
                a.Reverse();
                flag = true;
            }
            else
            {
                flag = false;
            }
            //显示
            display();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //年龄排序
            sortsc sc = new sortsc();
            a.Sort(sc);
            if (flag == false)
                a.Reverse();
            flag = !flag;
            //显示
            display();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            s1.sname = "小明"; s1.age = 21; s1.score = 87.5f;
            s2.sname = "小红"; s2.age = 27; s2.score = 76;
            s3.sname = "小花"; s3.age = 23; s3.score = 98;
            a.Add(s1);
            a.Add(s2);
            a.Add(s3);

            //显示
            display();
        }

        private void display()
        {
            listBox1.Items.Clear();//清空列表元素
            foreach (student i in a)
                listBox1.Items.Add(i.sname + "-年龄:" + i.age + "-成绩:" + i.score);
        }
    }
}
