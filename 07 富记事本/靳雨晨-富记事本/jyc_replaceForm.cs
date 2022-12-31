using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 靳雨晨_富记事本
{
    public partial class jyc_replaceForm : Form
    {
        RichTextBox rtb = null;
        int beginindex = 0;//特定内容的首次查找替换开始位置，默认是替换窗体打开时光标的当前位置或查找内容发生变化时，光标所在的位置。
        bool frombegin = true;//本次特定内容的查找是否是冲文档开始处的，是为true

        public jyc_replaceForm(RichTextBox rh)//有参构造
        {
            InitializeComponent();
            rtb = rh;
        }

        private void jyc_replaceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            jyc_global.rp = null;
        }

        private void jyc_replaceForm_Load(object sender, EventArgs e)
        {
            if (rtb.SelectedText != "")//如果编辑区有选中的文本，则将其设置为默认的查找内容
            {
                tb_findtext.Text = rtb.SelectedText;
            }
            beginindex = rtb.SelectionStart;//记住首次查找替换的位置，以便到文末后重新从开头查找替换，到此处汇合。
            if (beginindex == 0) frombegin = true;//"敦**如果开始位置是0，即文档开始处，则frombegin=true
            else frombegin = false;
        }

        private void button1_Click(object sender, EventArgs e)//查找按钮
        {
            if (tb_findtext.Text == "")
            {
                MessageBox.Show("请输入待查找的内容");
                return;
            }
            if (rtb.Text.Length == 0)
            {
                MessageBox.Show("你目前的文档没有文字内容，查找替换结束");
                return;
            }
            int startindex, endindex, index;
            endindex = rtb.Text.Length;

            if (rtb.SelectedText == "")
            {
                startindex = rtb.SelectionStart;
            }
            else startindex = rtb.SelectionStart + rtb.SelectionLength;
            if (startindex >= endindex || (beginindex != 0 && startindex >= beginindex && frombegin == true))
            {
                //startIndex >= endlndex指开始位置超过结束位置，或两者重合，说明查找到文末了，不需要在查找
                //(startIndex > beginindex &.& frombegin == true)，在从头开始查找时，开始位置与上一查找开始位置已经成功汇合了，也不用再查找了
                index = -1;
            }
            else//没查找到或没找(已经到文件末尾或从头开始时与上一次查找开始位置汇合，则没有查找)
            {
                index = rtb.Find(tb_findtext.Text, startindex, endindex, RichTextBoxFinds.MatchCase);//*****区分大小写
            }
            if (index >= 0) rtb.Focus();//找到****
            else
            {
                rtb.SelectionStart += rtb.SelectionLength;//没查找到或没找(已经到文件末尾或从头开始时与上一次查找开始位置汇合，则没有查找)
                rtb.SelectionLength = 0;///取消上一次的选中，不处理关系不大
                if (startindex >= beginindex && frombegin == false)//如果刚才不是从文件开始处查找替换的，则询问是否回到文档开头进行完整查找
                {
                    if (MessageBox.Show("已到达文档末尾，没有发现匹配内容，是否尝试从文档开始处查找？", "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        frombegin = true;
                        rtb.SelectionStart = 0;//光标移动至文档开头
                        button1.PerformClick();//用程序激发一次替换按钮的单击事件
                    }
                }

                else//已经完成从文档开头到结尾的完整查找
                {
                    if (MessageBox.Show("没有找到内容。已经完成对文档的一次遍历搜索。是否从头开始新一轮查找?", "查找完毕", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        frombegin = true;
                        beginindex = 0;
                        rtb.SelectionStart = 0;
                    }
                }

            }
        }


        private void button2_Click(object sender, EventArgs e)//替换按钮处理代码
        {
            if (tb_findtext.Text == "")
            {
                MessageBox.Show("请输入待替换的内容");
                return;
            }
            if (rtb.Text.Length == 0)
            {
                MessageBox.Show("你目前的文档没有文字内容，替换结束");
                return;
            }
            int startindex, endindex, index;
            endindex = rtb.Text.Length;
            // 如果选中内容和替换结果相同，则开始查找替换位置从选中内容右侧开始
            if (rtb.SelectedText != "" && rtb.SelectedText.Equals(tb_replacetext.Text))
                startindex = rtb.SelectionStart + tb_replacetext.Text.Length;
            else//否则从选中内容第一个字符开始查找替换
                startindex = rtb.SelectionStart;
            //如果没有选中内容或选中内容与待替换内容不符合，则先查找待替换内容
            if (rtb.SelectedText == "" || rtb.SelectedText != tb_findtext.Text)
            {
                rtb.SelectionLength = 0;
                if (startindex < endindex && !(beginindex != 0 && startindex >= beginindex && frombegin == true))
                {
                    //startIndex >= endlndex指开始位置超过结束位置，或两者重合，说明查找到文末了，不需要在查找
                    //(startIndex > beginindex &.& frombegin == true)，在从头开始查找时，开始位置与上一查找开始位置已经成功汇合了，也不用再查找了
                    index = rtb.Find(tb_findtext.Text, startindex, endindex, RichTextBoxFinds.MatchCase);//*****区分大小写
                }
            }
            if (rtb.SelectedText != "")
            {
                rtb.SelectedText = tb_replacetext.Text;
                rtb.SelectionStart = rtb.SelectionStart - tb_replacetext.Text.Length;
                rtb.SelectionLength = tb_replacetext.Text.Length;
                rtb.Focus();
            }
            else//没有找到替换内容
            {
                if (startindex >= beginindex && frombegin == false)//如果刚才不是从文件开始处查找替换的，则询问是否回到文档开头进行完整查找替换
                {
                    if (MessageBox.Show("已到达文档末尾，没有发现匹配内容，是否尝试从文档开始处查找替换？", "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        frombegin = true;
                        rtb.SelectionStart = 0;//光标移动至文档开头
                        button1.PerformClick();//用程序激发一次替换按钮的单击事件
                    }
                }

                else//已经完成从文档开头到结尾的完整查找
                {
                    if (MessageBox.Show("没有找到内容。已经完成对文档的一次遍历查找替换。是否从重新开始一轮查找替换?", "查找完毕", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        frombegin = true;
                        beginindex = 0;
                        rtb.SelectionStart = 0;
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)//全部替换
        {
            if (tb_findtext.Text == "")
            {
                MessageBox.Show("请输入替换的原文内容");
                return;
            }
            if (rtb.Text.Length == 0)
            {
                MessageBox.Show("你目前的文档没有文字内容，替换结束");
                return;
            }
            int n = 0;//统计替换次数
            int startindex = 0;
            while ((startindex = rtb.Find(tb_findtext.Text, rtb.Text.Length, RichTextBoxFinds.MatchCase)) >= 0)
            {
                n++;
                rtb.SelectedText = rtb.SelectedText.Replace(tb_findtext.Text, tb_replacetext.Text);
                startindex += tb_replacetext.Text.Length;
                if (startindex >= rtb.Text.Length) break;
            }
            rtb.ScrollToCaret();//将滚动条的位置设置到当前关心的位詈*******
            MessageBox.Show("替换完成，总共替换了" + n.ToString() + "处");
        }

        private void tb_findtext_TextChanged(object sender, EventArgs e)//查找内容发生变化，则重新设置开始位置
        {
            beginindex = rtb.SelectionStart;//设置新替换的开始处为当前位置，往文未方向进行查找替换
            if (beginindex == 0) frombegin = true;
            else frombegin = false;
        }
    }
}
