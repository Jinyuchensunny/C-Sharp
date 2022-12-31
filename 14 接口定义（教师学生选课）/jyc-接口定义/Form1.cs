using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jyc_接口定义
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        student s = new student("201802330410", "小明");
        teacher t = new teacher("t001", "老李");
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add(s.ReaderName);
            comboBox1.Items.Add(t.ReaderName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("信息不全");
                return;
            }
            if(comboBox1.SelectedIndex==0)
            {
                s.Borrowbook(listBox1.SelectedItem.ToString());
            }
            else
            {
                t.Borrowbook(listBox1.SelectedItem.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("信息不全");
                return;
            }
            if (comboBox1.SelectedIndex == 0)
            {
                s.Returnbook(listBox1.SelectedItem.ToString());
            }
            else
            {
                t.Returnbook(listBox1.SelectedItem.ToString());
            }
        }
    }
}
