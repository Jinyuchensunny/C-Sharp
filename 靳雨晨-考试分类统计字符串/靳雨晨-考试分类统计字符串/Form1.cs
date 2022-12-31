using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 靳雨晨_考试分类统计字符串
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            letter.Text = "";
            digit.Text = "";
            p.Text = "";
            symbol.Text = "";
            ws.Text = "";
            other.Text = "";
            textBox1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //存放字母的个数
            int cLetters = 0;
            //存放数字的个数
            int cDigits = 0;
            //存放标点符号的个数
            int cp = 0;
            //存放空白字符的个数
            int csymbol = 0;
            //获取待统计字符串
            int cwp = 0;
            //存放字母的个数
            string input = textBox1.Text;
            foreach (char chr in input)
            {
                // 检查字母
                if (char.IsLetter(chr))
                    cLetters++;
                // 检查数字
                if (char.IsDigit(chr))
                    cDigits++;
                // 检查标点符号
                if (char.IsPunctuation(chr))
                    cp++;
                if (char.IsSymbol(chr))
                    csymbol++;
                if (char.IsWhiteSpace(chr))
                    cwp++;
            }//foreach结束
            // 显示结果
            letter.Text = cLetters.ToString();
            digit.Text = cDigits.ToString();
            p.Text = cp.ToString();
            symbol.Text = csymbol.ToString();
            ws.Text = cwp.ToString();
            //其他字符
            other.Text = (input.Length - cwp - csymbol - cp - cLetters - cDigits).ToString();
        }
    }
}
