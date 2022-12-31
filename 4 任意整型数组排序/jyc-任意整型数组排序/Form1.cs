using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jyc_任意整型数组排序
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (input.Text.Trim() == "")
            {
                MessageBox.Show("请输入排序数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            string s = input.Text.Trim();

            //先纠正用户输入不正确内容，增强容错性
            //将中文逗号替换成英文逗号
            s = s.Replace('，',',');

            //将多个逗号换成一个
            //Regex r1 = new Regex(",{1,}");
            //s = r1.Replace(s, ",");
            //逗号换成空格
            s = s.Replace(',', ' ');

            //将回车替换成空格，并去除首尾空格
            s = s.Replace('\n', ' ').Trim();

            //将连续空格换成一个
            Regex replaceSpace = new Regex(@"\s{1,}");
            s = replaceSpace.Replace(s, " ").Trim();

            //进行合理性判断
            string str = @"^[-]?\d+(\s{1}[-]?\d+)*$";
            Regex re = new Regex(str);
            if (!re.IsMatch(s))
            {
                MessageBox.Show("您输入的数组有问题，请仔细检查！");
                return;
            }

            //排序处理
            string[] ss = s.Split(' ');//用空格分割数组
            int[] ints = new int[ss.Length];
            for(int i = 0; i < ss.Length; i++)
            {
                ints[i] = int.Parse(ss[i]);
            }
            Array.Sort(ints);
            if (radioButton2.Checked) Array.Reverse(ints);

            //输出
            output.Text = "";
            foreach (int a in ints) output.Text += a.ToString() + " ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            input.Text = output.Text = "";
        }
    }
}
