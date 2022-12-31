using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jyc_排序
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int[] a = new int[]{23, 56, 46, 12, 87, 34, 6, 69, 10, 76};
			int i, j;//用于循环
			int temp;//中间变量用于交换数组中的数值
			for (i = 0; i < 7; i++)//外层循环要循环数字数值长度减1次
			{
				/*内层循环的次数将越来越少，因为冒牌排序第一趟就可以将数
				组中最大的一个数放到最后，第二趟就可以将次大的数放在后面
				，所以随着外层循环次数的增多，内层循环将会变少。*/
				for (j = 0; j < 7 - i; j++)
				{
					if (a[j] > a[j + 1])//逆序则借助中间变量交换数值
					{
						temp = a[j];
						a[j] = a[j + 1];
						a[j + 1] = temp;
					}
				}
			}
			//Array.Sort(a);//顺序
			//Array.Reverse(a);//逆序
			foreach (int k in a)
				textBox1.Text += (k.ToString() + " ");
            for (i = 0; i < 8; i++)//将数组输出
			{
				textBox1.Text += a[i] + ",";
            }
			textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
		}
    }
}
