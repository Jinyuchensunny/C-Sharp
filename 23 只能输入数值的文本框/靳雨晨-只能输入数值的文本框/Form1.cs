using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 靳雨晨_只能输入数值的文本框
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool flag = true;   //表示按键有效
        private void t1_KeyDown(object sender, KeyEventArgs e)
        {
            flag = true; //初始化
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9) //非大键盘0-9
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9) //非小键盘0-9
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.Delete)
                    {
                        if (e.KeyCode == Keys.OemPeriod)//非以上内容下，小数点
                        {
                            if (t1.Text.Contains(".")) flag = false;    //是否第一次有小数点
                        }
                        else//是否为负号
                        {
                            if (e.KeyCode == Keys.OemMinus)//是负号
                            {
                                if (t1.Text.StartsWith("-")) flag = false;
                                else t1.SelectionStart = 0;//光标放在最左侧
                            }
                            //t1.SelectionStart = t1.Text.Length + 1;
                            else flag = false;
                        }
                    }

            //假如是0-9，但要排除同时按下shift键
            if (e.Modifiers == Keys.Shift) flag = false;
            
        }

        private void t1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (flag == false) e.Handled = true;
        }

        private void t1_Enter(object sender, EventArgs e)//鼠标进入文本框
        {
            t1.ImeMode = ImeMode.Disable;//英文模式，禁止改为中文
        }
    }
}
