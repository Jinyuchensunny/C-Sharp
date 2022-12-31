using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 靳雨晨_图片查看器
{
    public partial class Form1 : Form
    {
        public Form1() //无参构造
        {
            InitializeComponent();
        }

        String fname = null;//文件名对象
        public Form1(string s)//有参构造，接收文件名
        {
            InitializeComponent();
            fname = s;
        }


        Image img = null;//图片对象

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            //文件过滤设置
            of.Filter = "bmp,png,jpg,gif,icon|*.bmp;*.png;*.jpg;*.gif;*.icon";
            if (of.ShowDialog() == DialogResult.OK)
            {
                img = Image.FromFile(of.FileName);
                display();
                this.Text = "图像查看程序-" + of.SafeFileName;
            }
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)//图片缩放
        {
            if (img == null) return;
            if (img.Height > pictureBox1.Height || img.Width > pictureBox1.Width)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            }
        }

        private void button2_Click(object sender, EventArgs e)//背景设置
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = this.BackColor;
            cd.FullOpen = true;
            cd.AllowFullOpen = true;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = cd.Color;
            }
        }

        private void button3_Click(object sender, EventArgs e)//另存为
        {
            if (img == null) return;
            SaveFileDialog sf = new SaveFileDialog();
            sf.Title = "图片另存为";
            sf.Filter = "bmp|*.bmp|jpg|*.jpg|gif|*.gif|png|*.png|icon|*.icon";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                string s = sf.FileName;
                Image img1 = new Bitmap(img);//避免另存和打开图片是相同未见而导致文件错误
                img.Dispose();//销毁原来的图片,以便于覆盖


                switch (sf.FilterIndex)
                {
                    case 1: img1.Save(s, System.Drawing.Imaging.ImageFormat.Bmp); break;
                    case 2: img1.Save(s, System.Drawing.Imaging.ImageFormat.Jpeg); break;
                    case 3: img1.Save(s, System.Drawing.Imaging.ImageFormat.Gif); break;
                    case 4: img1.Save(s, System.Drawing.Imaging.ImageFormat.Png); break;
                    case 5: img1.Save(s, System.Drawing.Imaging.ImageFormat.Icon); break;
                }


                img = Image.FromFile(s);
                pictureBox1.Image = img;
                string s1 = s.Substring(s.LastIndexOf(@"\") + 1);
                this.Text = "jyc图片查看器-" + s1;
            }
        }

        private void button4_Click(object sender, EventArgs e)//字体设置
        {
            FontDialog fa = new FontDialog();
            fa.ShowColor = true;
            fa.ShowEffects = true;
            fa.Color = button1.ForeColor;
            fa.Font = button1.Font;

            if (fa.ShowDialog() == DialogResult.OK)
            {
                button1.ForeColor = button2.ForeColor = button3.ForeColor = button4.ForeColor = fa.Color;
                button1.Font = button2.Font = button3.Font = button4.Font = fa.Font;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if (fname != null)
            {
                img = Image.FromFile(fname);
                display();
                string s1 = fname.Substring(fname.LastIndexOf(@"\") + 1);
                this.Text = "jyc-图片查看器" + s1;
            }
        }



        private void display()//图片大小与控件的关系
        {
            if (img.Height > pictureBox1.Height || img.Width > pictureBox1.Width)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            pictureBox1.Image = img;
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else e.Effect = DragDropEffects.None;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] ss = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (ss.Length == 0) return;
            foreach (string s in ss)
            {
                string ex = s.Substring(s.LastIndexOf(".") + 1);
                if (ex.ToLower().Equals("bmp") || ex.ToLower().Equals("jpg") || ex.ToLower().Equals("gif") || ex.ToLower().Equals("png") || ex.ToLower().Equals("icon") || ex.ToLower().Equals("tiff"))
                {
                    Form1 f = new Form1(s);
                    f.Show();
                }
                else
                {
                    MessageBox.Show("无法打开指定文件" + s);
                }
            }
        }
    }
}
