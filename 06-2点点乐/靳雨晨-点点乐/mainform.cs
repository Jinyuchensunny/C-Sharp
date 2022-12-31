using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 靳雨晨_点点乐
{
    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
        }

        happy_click hc;
        Timer t = new Timer();
        private void mainform_Load(object sender, EventArgs e)
        {   //103, 72//319, 187//545, 307

            Point[] p = new Point[9];
            p[0].X = 123; p[0].Y = 72;
            p[1].X = 339; p[1].Y = 72;
            p[2].X = 555; p[2].Y = 72;

            p[3].X = 123; p[3].Y = 187;
            p[4].X = 339; p[4].Y = 187;
            p[5].X = 565; p[5].Y = 187;

            p[6].X = 123; p[6].Y = 307;
            p[7].X = 339; p[7].Y = 307;
            p[8].X = 565; p[8].Y = 307;

            //创建点点乐对象
            hc = new happy_click(pb_pet.Image, 6, p, 4, pb_pet.Size);

            //设置定时器
            t.Interval = 1000;//1000毫秒，每一秒进度条更新，并进行判断时间是否到了
            t.Tick += T_Tick;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
            if (progressBar1.Value >= progressBar1.Maximum)
            {
                t.Stop();
                MessageBox.Show("时间到！您的得分是：" + label2.Text);
                this.MouseMove -= Mainform_MouseMove;//卸载事件
                pb_pet.Click -= Pb_pet_Click;//卸载事件
                button1.Text = "开始";
                progressBar1.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals("开始"))
            {
                //分数清零
                hc.SCORE = 0;
                label2.Text = hc.SCORE.ToString();
                //设置进度条（开始值，最大值，可见）
                progressBar1.Value = 0;
                progressBar1.Maximum = hc.PLAYTIME * 60;
                progressBar1.Visible = true;
                //安装事件
                this.MouseMove += Mainform_MouseMove;
                pb_pet.Click += Pb_pet_Click;
                //启动定时器
                t.Start();

                button1.Text = "暂停";
            }
            else
            {
                if (button1.Text.Equals("暂停"))
                {
                    this.MouseMove -= Mainform_MouseMove;//卸载事件
                    pb_pet.Click -= Pb_pet_Click;//卸载事件
                    t.Stop();
                    button1.Text = "继续";
                }
                else
                {
                    this.MouseMove += Mainform_MouseMove;//安装form的鼠标移动事件
                    pb_pet.Click += Pb_pet_Click;//安装宠物控件被单击事件
                    t.Start();
                    button1.Text = "暂停";
                }
            }
        }

        private void Pb_pet_Click(object sender, EventArgs e)
        {
            hc.catched();
            //处理界面显示
            label2.Text = hc.SCORE.ToString();
            pb_pet.Location = hc.CUR_HOUSE;
        }

        private void Mainform_MouseMove(object sender, MouseEventArgs e)
        {
            if (hc.FLAG == true) return;//正在搬家，则不再处理鼠标接近事件
            if (hc.do_run(e.X, e.Y))
                pb_pet.Location = hc.CUR_HOUSE;
        }

        private void button2_Click(object sender, EventArgs e)//设置按钮
        {
            //若为游戏进行时，则先暂停游戏
            if (button1.Text.Equals("暂停")) button1.PerformClick();
            Form2 f = new Form2(hc);
            if (f.ShowDialog() == DialogResult.Yes) pb_pet.Image = hc.PET;
            if (button1.Text.Equals("继续")) button1.PerformClick();

        }

    }//class
}
