using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 靳雨晨_考试记事本
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Form1(string s)
        {
            InitializeComponent();
            filename = s;//获取文件名
        }

        private void button4_Click(object sender, EventArgs e)//字体设置
        {
            //新建字体对话框并初始化
            FontDialog fd = new FontDialog();
            fd.Font = rh.SelectionFont;
            fd.Color = rh.SelectionColor;
            fd.ShowColor = true;

            //打开字体对话框并尽心设置
            if (fd.ShowDialog() == DialogResult.OK)
            {
                rh.SelectionColor = fd.Color;
                rh.SelectionFont = fd.Font;
            }
        }

        private void button3_Click(object sender, EventArgs e)//插入图片
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "BMP,JPEG,GIF,icon,png|*.bmp;*.jpg;*.gif;*.icon;*.png";
            if (of.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(of.FileName);
                Clipboard.SetDataObject(img);
                rh.Paste(DataFormats.GetFormat(DataFormats.Bitmap));
            }
        }

        private void button1_Click(object sender, EventArgs e)//打开文件
        {
            //判断原文档内容是否发生变化
            if (rh.Modified == true)// 变化了，需要询问用户是否保存原文档
            {
                DialogResult r = MessageBox.Show("文件内容已经发生改变，是否保存？", "询问", MessageBoxButtons.YesNoCancel);
                if (r.Equals(DialogResult.Cancel)) return;//选择取消，则返回
                if (r.Equals(DialogResult.Yes))//选择是，则保存原文件
                {
                    int i = dosave();
                    if (i < 1) return;//保存失败或在保存时选择取消，则都返回，取消打开操作
                }//是，保存文件
            }//有变化

            //打开
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "RTF,TXT|*.rtf;*.txt";
            of.Title = "打开文件";
            if (filename != null) of.InitialDirectory = filename.Substring(0, filename.LastIndexOf(@"\"));
            if (of.ShowDialog() == DialogResult.OK)
            {
                filename = of.FileName;
                rh.Clear();
                string a = filename.Substring(filename.LastIndexOf(".") + 1).ToLower();
                try
                {
                    if (a.Equals("rtf")) rh.LoadFile(filename);//rtf格式
                    else rh.LoadFile(filename, RichTextBoxStreamType.PlainText);//txt格式
                    this.Text = "jyc-记事本" + of.SafeFileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    filename = null;//打开失败，文档空白，文件名清空
                    this.Text = "jyc-记事本";
                }
                rh.Modified = false;//设置文本框为未修改状态
            }//ok
        }



        //对当前文档的保存，保存成功返回1，失败-1，未执行0
        String filename = null;
        private int dosave()
        {
            try
            {
                if (filename == null)// 第一次保存
                {
                    SaveFileDialog sf = new SaveFileDialog();
                    sf.Filter = "RTF格式|*.rtf|TXT纯文本|*.txt";
                    sf.Title = "保存文件";
                    sf.OverwritePrompt = true;//覆盖提示（可不写，默认为true）
                    if (sf.ShowDialog() == DialogResult.OK)//单击确定
                    {
                        string s = sf.FileName;//获取需要的文件名
                        if (sf.FilterIndex == 1) rh.SaveFile(s);//保存为rtf格式
                        else rh.SaveFile(s, RichTextBoxStreamType.PlainText);//保存为纯文本，可增加判断文档里是否有非纯文本内容，进行提示
                        rh.Modified = false;//设置控件为未修改状态
                        filename = s;
                        string t = filename.Substring(filename.LastIndexOf(@"\") + 1);//去除路径
                        this.Text = "jyc-记事本" + t;
                        return 1;
                    }//单击确定
                    else//单击取消
                    {
                        return 0;//放弃保存，取消保存操作
                    }//单击取消
                }// 第一次保存
                else//非第一次保存
                {
                    string a = filename.Substring(filename.LastIndexOf('.') + 1).ToLower();//扩展名
                    if (a.ToLower().Equals("rft")) rh.SaveFile(filename);
                    else rh.SaveFile(filename, RichTextBoxStreamType.PlainText);//可改进判断是否为春文本
                    rh.Modified = false;//设置控件为未修改状态
                    return 1;
                }//非第一次
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

        private void button2_Click(object sender, EventArgs e)//保存文件
        {
            int i = dosave();
        }
    }
}
