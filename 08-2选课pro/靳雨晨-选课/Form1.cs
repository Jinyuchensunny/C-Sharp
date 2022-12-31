using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 靳雨晨_选课
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static int count = 0;

        private void button1_Click(object sender, EventArgs e)
        {   // >
           
            if (listBox1.SelectedItems.Count == 0) MessageBox.Show("您没有要添加的课程！");

            if (listBox1.SelectedItems.Count <= 4)
            {
                while (listBox1.SelectedItems.Count != 0)
                {
                    listBox2.Items.Add(listBox1.SelectedItem);
                    listBox1.Items.Remove(listBox1.SelectedItem);
                }
            }
            else MessageBox.Show("您只能选择4门课！");
        }



        private void button2_Click(object sender, EventArgs e)
        {   // <
            //if (listBox2.SelectedItems.Count > 0)
            //{
            //    string s = listBox2.SelectedItem.ToString();
            //    listBox1.Items.Add(s);
            //    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            //}
            //else MessageBox.Show("您没有选择需要退选的课程！");

            if (listBox2.SelectedItems.Count == 0) MessageBox.Show("您没有要退选的课程！");


            while (listBox2.SelectedItems.Count > 0)
            {
                listBox1.Items.Add(listBox2.SelectedItem);
                listBox2.Items.Remove(listBox2.SelectedItem);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {   // <<
            if (listBox2.Items.Count > 0)
            {
                for (int i=0;i< listBox2.Items.Count;i++)
                    {
                         listBox1.Items.Add(listBox2.Items[i]);
                         count--;
                    }
                listBox2.Items.Clear();
            }
            else MessageBox.Show("您没有选择需要退选的课程！");
        }


        private void button4_Click(object sender, EventArgs e)
        {   //提交
            if (listBox2.Items.Count == 4)
            {
                MessageBox.Show("您选择的课程是：" + "\n" + listBox2.Items[0] + "、" + listBox2.Items[1] + "\n" + listBox2.Items[2] + "、" + listBox2.Items[3]);//listBox2.Text 
            }
            else MessageBox.Show("您未选满4门课程，请继续选择！");
        }

        private void button5_Click(object sender, EventArgs e)
        {   //取消
            this.Close();
        }
    }
}
