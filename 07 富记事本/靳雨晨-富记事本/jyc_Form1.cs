using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace 靳雨晨_富记事本
{
    public partial class jyc_Form1 : Form
    {
        public jyc_Form1()
        {
            InitializeComponent();
        }

        public jyc_Form1(string s)//新增有参构造
        {
            InitializeComponent();
            filename = s;//获取文件名
        }


        //字体大小对应
        float[] v = new float[] { 42, 36, 26, 24, 22, 18, 16, 15, 14, 12, 10.5f, 9, 7.5f, 6.75f, 5.5f };
        string[] d = new string[] { "初号", "小初", "一号", "小一", "二号", "小二", "三号", "小三", "四号", "小四", "五号", "小五", "六号", "小六", "七号" };

        //事件有效标记
        bool font_flag = true;//快捷工具栏-字体种类选中内容发生变化事件响应
        bool size_flag = true;//快捷工具栏字体大小选中内容发生变化事件响应;
        bool toolflag = true;//如果是用户引起的选中位置改变，则为true;避免程序进行临时选中内容改变引发相关事件处理

        private void jyc_Form1_Load(object sender, EventArgs e)
        {
            // 收起左侧
            splitContainer1.Panel1Collapsed = true;

            // 读取系统字体
            ts_cbfont.Items.Clear();
            InstalledFontCollection f = new InstalledFontCollection();
            foreach(FontFamily ff in f.Families)
            {
                ts_cbfont.Items.Add(ff.Name);
            }

            //设置默认值
            ts_cbfont.Text = "宋体";
            ts_cbfontsize.SelectedIndex = 9;//五号字体

            //安装事件
            ts_cbfont.SelectedIndexChanged += Ts_cbfont_SelectedIndexChanged;//字体种类
            ts_cbfontsize.SelectedIndexChanged += Ts_cbsize_SelectedIndexChanged;//字体大小
            ts_cbfontsize.KeyUp += Ts_cbsize_KeyUp; //处理字体大小输入


            //打开文件
            if (filename == null) return;
            string a = filename.Substring(filename.LastIndexOf(".") + 1).ToLower();
            try
            {
                if (a.Equals("rtf")) rh.LoadFile(filename);
                else rh.LoadFile(filename, RichTextBoxStreamType.PlainText);
                rh.Modified = false;//未修改状态
                string t = filename.Substring(filename.LastIndexOf(@"\") + 1);
                this.Text = "jyc-富记事本" + t;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                filename = null;
            }
        }

        //工具栏字体大小输入-键松开事件,回车键输入后，正式改变大小，因为非列表字体大小,selectedindex均为-1
        private void Ts_cbsize_KeyUp(object sender, KeyEventArgs e)
        {
            if (ts_cbfontsize.SelectedIndex != -1) return;
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    float fontsize = float.Parse(ts_cbfontsize.Text.Trim());
                    int len = rh.SelectionLength;
                    int selectstart = rh.SelectionStart;
                    toolflag = false;//在字体设置期间,选中位置变化引起字体变化，工具栏字体设置控件内容保持不变
                    for(int i=0;i<len;i++)//逐字修改字体种类，其余样式保留
                    {
                        rh.Select(selectstart + i, 1);
                        rh.SelectionFont = new Font(rh.SelectionFont.FontFamily, fontsize, rh.SelectionFont.Style);
                    }
                    rh.SelectionStart = selectstart;
                    rh.SelectionLength = len;
                    toolflag = true;
                    rh.Focus();
                }
                catch
                {
                    MessageBox.Show("属性值不正确");
                    ts_cbfontsize.Focus();
                }


            }
        }

        //工具栏字体大小改变
        private void Ts_cbsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (size_flag == false) return;//程序调整字体大小选中项，以保持和菜单字体设置—致，不需要响应事件
            float fontsize = 0;
            if (ts_cbfontsize.SelectedIndex == -1) return;
            else//不为-1，选中项是列表内容
            {
                int k = Array.IndexOf(d, ts_cbfontsize.Text.Trim());
                fontsize = v[k];
            }

            int len = rh.SelectionLength;
            int selectstart = rh.SelectionStart;
            toolflag = false;//在字体设置期间的光标位置改变引起的字体变化，工具栏字体设置控件内容保持不变
            for (int i = 0; i < len; i++)//逐字修改字体种类.其全样术保留
            {
                rh.Select(selectstart + i, 1);
                rh.SelectionFont = new Font(rh.SelectionFont.FontFamily, fontsize, rh.SelectionFont.Style);
            }
            rh.SelectionStart = selectstart;
            rh.SelectionLength = len;
            toolflag = true;
            rh.Focus();
        }

        //工具栏字体种类改变
        private void Ts_cbfont_SelectedIndexChanged(object sender, EventArgs e)
        {
            //程序调整字体种类选中项，以保持和菜单字体设置一致，不需要响应事件,字体选中为-1，不需要处理
            if (size_flag == false || ts_cbfont.SelectedIndex == -1) return;
            //字体种类不同，就会使SelectionFont为null，因此只能单个字符循环处理
            int len = rh.SelectionLength;
            int selectstart = rh.SelectionStart;
            toolflag = false;//在字体设置期间的光标位置改变引起的字体变化，工具栏字体设置控件内容保持不变
            for(int i=0;i<len;i++)//逐字修改字体种类.其全样术保留
            {
                rh.Select(selectstart + i, 1);
                rh.SelectionFont = new Font(ts_cbfont.Text, rh.SelectionFont.Size, rh.SelectionFont.Style);
            }
            rh.SelectionStart = selectstart;
            rh.SelectionLength = len;
            toolflag = true;
            rh.Focus();
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rh.SelectedRtf != "") rh.Copy();
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Rtf) == true)
                rh.Paste();
        }

        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rh.SelectedRtf != "") rh.Cut();
        }

        private void 自动换行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ts = sender as ToolStripMenuItem;
            ts.Checked = !ts.Checked;
            rh.WordWrap = !rh.WordWrap;
        }

        private void 背景ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.FullOpen = true;
            cd.Color = rh.BackColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                rh.BackColor = cd.Color;
            }
        }

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rh.SelectAll();
        }

        private void 撤销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rh.Undo();
        }

        private void 恢复ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rh.Redo();
        }

        private void 左对齐toolStripButton1_Click(object sender, EventArgs e)
        {
            rh.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void 居中toolStripButton1_Click(object sender, EventArgs e)
        {
            rh.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void 右对齐toolStripButton1_Click(object sender, EventArgs e)
        {
            rh.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void 时间日期ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rh.SelectedText = DateTime.Now.ToString();
        }

        private void 图片ToolStripMenuItem_Click(object sender, EventArgs e)
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
                    if(sf.ShowDialog()==DialogResult.OK)//单击确定
                    {
                        string s = sf.FileName;//获取需要的文件名
                        if (sf.FilterIndex == 1) rh.SaveFile(s);//保存为rtf格式
                        else rh.SaveFile(s, RichTextBoxStreamType.PlainText);//保存为纯文本，可增加判断文档里是否有非纯文本内容，进行提示
                        rh.Modified = false;//设置控件为未修改状态
                        filename = s;
                        string t = filename.Substring(filename.LastIndexOf(@"\") + 1);//去除路径
                        this.Text = "jyc-富记事本" + t;
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = dosave();
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {   //判断原文档内容是否发生变化
            if(rh.Modified==true)// 变化了，需要询问用户是否保存原文档
            {
                DialogResult r = MessageBox.Show("文件内容已经发生改变，是否保存？", "询问", MessageBoxButtons.YesNoCancel);
                if (r.Equals(DialogResult.Cancel)) return;//选择取消，则返回
                if(r.Equals(DialogResult.Yes))//选择是，则保存原文件
                {
                    int i = dosave();
                    if (i < 1) return;//保存失败或在保存时选择取消，则都返回，放弃新建操作
                }//是，保存文件
            }//有变化

            //新建
            filename = null;
            rh.Clear();
            rh.Modified = false;
            this.Text = "jyc-富记事本" + filename;

        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {   //判断原文档内容是否发生变化
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
                    this.Text = "jyc-富记事本" + of.SafeFileName;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    filename = null;//打开失败，文档空白，文件名清空
                    this.Text = "jyc-富记事本";
                }
                rh.Modified = false;//设置文本框为未修改状态
            }//ok
        }


        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = dosave();
        }

        private void jyc_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rh.Modified == true)
            {
                DialogResult r = MessageBox.Show("文件内容已经发生改变，是否保存？", "询问", MessageBoxButtons.YesNoCancel);
                if (r==DialogResult.Cancel)//取消，取消关闭窗体的事件
                {
                    e.Cancel = true;
                    return;
                }
                if(r==DialogResult.Yes)//是，保存原文档
                {
                    int i = dosave();
                    if(i < 1)//失败或在保存对话框单击了取消
                    {
                        e.Cancel = true;
                        return;
                    }//<1
                }//是
                //r==no 不需要处理
            }//有变化
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void 字体ToolStripMenuItem_Click(object sender, EventArgs e)
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

            //处理快捷工具栏字体信息同步设置
            font_flag = false;
            size_flag = false;
            ts_color.BackColor = fd.Color;
            ts_cbfont.Text = fd.Font.FontFamily.Name;
            //ts_cbfontsize.Text = fd.Font.Size.ToString();
            int k = Array.IndexOf(v,fd.Font.Size);
            if (k > -1)//找到了
            {
                ts_cbfontsize.Text = d[k];
            }
            else//没找到
            {
                ts_cbfontsize.Text = fd.Font.Size.ToString();
            }
            ts_bold.Checked = fd.Font.Bold;
            ts_itallc.Checked = fd.Font.Italic;
            ts_underline.Checked = fd.Font.Underline;
            font_flag = size_flag = true;
        }

        private void 字体颜色toolStripButton1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.FullOpen = true;
            cd.Color = rh.SelectionColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                rh.SelectionColor = cd.Color;
                ts_color.BackColor = cd.Color;
            }
        }

        private void 项目符号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jyc_bulletform f = new jyc_bulletform(rh);
            f.ShowDialog();
        }

        private void 特殊字符ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (jyc_global.sp == null)
            {
                jyc_global.sp = new jyc_specialForm(rh);
                jyc_global.sp.Show();
            }
            else
            {
                jyc_global.sp.Activate();
                //防止已经打卡窗体，但是看不到又去重复打开窗体
                jyc_global.sp.Left = Screen.PrimaryScreen.WorkingArea.Width / 3;
                jyc_global.sp.Top = Screen.PrimaryScreen.WorkingArea.Height / 3;
            }
        }

        //菜单的查找，打开左侧的查找界面
        private void 查找ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (rh.SelectedText != null) tb_findtext.Text = rh.SelectedText;
            lbl_findnum.Text = "";//清空结果
            splitContainer1.Panel1Collapsed = false;//展开左侧
        }

        string lastfindtext = "";//记录已经完成查找的上一次待查找内容
        private void clear_findbackcolor()//清除查找到的内容的高亮显示
        {
            if (rh.Text.Length != 0)
            {
                int startindex = 0, endindex = rh.Text.Length;//查找范围
                toolflag = false;
                while ((startindex = rh.Find(lastfindtext, endindex, RichTextBoxFinds.MatchCase)) >= 0)
                {
                    rh.SelectionStart = startindex;
                    rh.SelectionLength = lastfindtext.Length;
                    rh.SelectionBackColor = rh.BackColor;//bug：会使局部的文字底纹消失
                    startindex += lastfindtext.Length;
                    if (startindex >= endindex) break;
                }
                toolflag = true;
            }
            rh.SelectionLength = 0;
            lastfindtext = "";
        }

        private void button1_Click(object sender, EventArgs e)//查找按钮
        {
            if (tb_findtext.Text == "")
            {
                MessageBox.Show("请输入待查找的内容");
                tb_findtext.Focus();
                return;
            }

            if (lastfindtext != "") clear_findbackcolor();//清除上一次的查找结果高亮显示
            
            if (rh.Text.Length == 0)
            {
                lbl_findnum.Text = "不存在查找的内容";
                return;
            }

            toolflag = false;
            int i = 0;//结果个数
            int startindex = 0, endindex = rh.Text.Length;//查找范围
            while ((startindex = rh.Find(tb_findtext.Text, startindex, endindex, RichTextBoxFinds.MatchCase)) >= 0)
            {
                rh.SelectionStart = startindex;
                rh.SelectionLength = tb_findtext.Text.Length;
                rh.SelectionBackColor = Color.YellowGreen;
                i++;
                startindex += tb_findtext.Text.Length;
                if (startindex >= endindex) break;
            }
            if (i > 0) lastfindtext = tb_findtext.Text;
            lbl_findnum.Text = "查找到" + i.ToString() + "个结果";
            rh.ScrollToCaret();//将滚动条的位置设置到最后一个查找到的内容的位置
            toolflag = true;
        }

        //splitcontainer.panel1关闭按钮，关闭左侧界面panel1
        private void pb_leftclose_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;
            //如有查找结果，清空并消除高亮显示
            if (lastfindtext != "") clear_findbackcolor();
        }

        //查找界面宽度发生变化处理代码：
        private void splitContainer1_Panel1_ClientSizeChanged(object sender, EventArgs e)
        {
            Panel p1 = sender as Panel;
            tb_findtext.Width = p1.Width - 10;
        }

        private void tb_findtext_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btn_dofind.PerformClick();
        }

        private void btn_dofind_Leave(object sender, EventArgs e)
        {
            if (lastfindtext != "" && !tb_findtext.Text.Equals(lastfindtext) && splitContainer1.Panel1Collapsed == false)
                btn_dofind.PerformClick();
        }

        private void jyc_Form1_DragEnter(object sender, DragEventArgs e)
        {// 鼠标按下
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else e.Effect = DragDropEffects.None;
        }

        private void jyc_Form1_DragDrop(object sender, DragEventArgs e)
        {//鼠标松开
            string[] ss = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (ss.Length == 0) return;//没有文件对象，返回
            foreach(string s in ss)
            {
                //新建进程法
                //Process p = new Process();
                //p.StartInfo.FileName = Process.GetCurrentProcess().ProcessName;
                //p.StartInfo.Arguments = s;
                //p.Start();

                //新建窗体法
                string t = s.Substring(s.LastIndexOf(".") + 1).ToLower();//提取扩展名
                if (t.Equals("rtf") || t.Equals("txt"))
                {
                    jyc_Form1 f = new jyc_Form1(s);
                    f.Show();
                }
                else MessageBox.Show("无法打开文件" + s);
              
            }//foreach
        }

        private void 替换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (jyc_global.rp == null)
            {
                jyc_global.rp = new jyc_replaceForm(rh);
                jyc_global.rp.Show();
            }
            else
            {
                jyc_global.rp.Activate();
                //以下两句仅仅是防止窗体被我们放置到边缘后，一下子看不到，当激活时，放到显眼的位置而已。
                jyc_global.rp.Left = Screen.PrimaryScreen.WorkingArea.Width / 3;
                jyc_global.rp.Left = Screen.PrimaryScreen.WorkingArea.Height / 3;
            }
        }

        private void ts_bold_Click(object sender, EventArgs e)//加粗
        {
            toolflag = false;
            //字体种类不同，就会使SelectionFont为null，因此只能单个字符循环处理
            int len = rh.SelectionLength;
            int selectstart = rh.SelectionStart;
            toolflag = false;//在字体设置期间的光标位置改变引起的字体变化，工具栏字体相关设置控件内容保持不变
            bool isbold = true;
            for(int i =0;i<len;i++)//逐宁修改字体的加粗与否，其其样式保留
            {
                rh.Select(selectstart + i, 1);
                if (i == 0) isbold = rh.SelectionFont.Bold;//以第一个字符为基准，第一个字符为加粗，则此次全部选中文本撤销加粗，反之同理。
                if (isbold) rh.SelectionFont = new Font(rh.SelectionFont, rh.SelectionFont.Style & ~FontStyle.Bold);//撤销加粗
                else rh.SelectionFont = new Font(rh.SelectionFont, rh.SelectionFont.Style | FontStyle.Bold);//撤销加粗
            }
            ts_bold.Checked = !isbold;
            rh.SelectionStart = selectstart;
            rh.SelectionLength = len;
            toolflag = true;
            rh.Focus();
        }

        private void ts_itallc_Click(object sender, EventArgs e)
        {
            toolflag = false;
            //字体种类不同，就会使SelectionFont为null，因此只能单个字符循环处理
            int len = rh.SelectionLength;
            int selectstart = rh.SelectionStart;
            toolflag = false;//在字体设置期间的光标位置改变引起的字体变化，工具栏字体相关设置控件内容保持不变
            bool isitalic = true;
            for (int i = 0; i < len; i++)//逐宁修改字体的加粗与否，其其样式保留
            {
                rh.Select(selectstart + i, 1);
                if (i == 0) isitalic = rh.SelectionFont.Italic;//以第一个字符为基准，第一个字符为加粗，则此次全部选中文本撤销加粗，反之同理。
                if (isitalic) rh.SelectionFont = new Font(rh.SelectionFont, rh.SelectionFont.Style & ~FontStyle.Italic);//撤销加粗
                else rh.SelectionFont = new Font(rh.SelectionFont, rh.SelectionFont.Style | FontStyle.Italic);//撤销加粗
            }
            ts_itallc.Checked = !isitalic;
            rh.SelectionStart = selectstart;
            rh.SelectionLength = len;
            toolflag = true;
            rh.Focus();
        }

        private void ts_underline_Click(object sender, EventArgs e)
        {
            toolflag = false;
            //字体种类不同，就会使SelectionFont为null，因此只能单个字符循环处理
            int len = rh.SelectionLength;
            int selectstart = rh.SelectionStart;
            toolflag = false;//在字体设置期间的光标位置改变引起的字体变化，工具栏字体相关设置控件内容保持不变
            bool underline = true;
            for (int i = 0; i < len; i++)//逐宁修改字体的加粗与否，其其样式保留
            {
                rh.Select(selectstart + i, 1);
                if (i == 0) underline = rh.SelectionFont.Underline;//以第一个字符为基准，第一个字符为加粗，则此次全部选中文本撤销加粗，反之同理。
                if (underline) rh.SelectionFont = new Font(rh.SelectionFont, rh.SelectionFont.Style & ~FontStyle.Underline);//撤销加粗
                else rh.SelectionFont = new Font(rh.SelectionFont, rh.SelectionFont.Style | FontStyle.Underline);//撤销加粗
            }
            ts_itallc.Checked = !underline;
            rh.SelectionStart = selectstart;
            rh.SelectionLength = len;
            toolflag = true;
            rh.Focus();
        }

        private void 字体阴影toolStripButton1_Click(object sender, EventArgs e)//底纹
        {
            if (rh.SelectionBackColor == null)//如果无法获取底纹，则直接设置底纹
            {
                rh.SelectionBackColor = Color.LightGray;
            }
            else
            {
                if(rh.SelectionBackColor.Equals(Color.LightGray))//底纹正好是我们设置的标准色，则取消底纹
                {
                    rh.SelectionBackColor = rh.BackColor;
                }
                else//底纹颜色不是标准色，则设置底纹为标准色
                {
                    rh.SelectionBackColor = Color.LightGray;
                }
            }

        }

        private void rh_SelectionChanged(object sender, EventArgs e)
        {
            //行号，列号
            if (toolflag == false) return;//如果非用户操作引起的事件，忽略
            tlab_row.Text = (rh.GetLineFromCharIndex(rh.SelectionStart) + 1).ToString();//行号
            tlab_col.Text = (rh.SelectionStart - rh.GetFirstCharIndexOfCurrentLine() + 1).ToString();//列号

            //工具栏字体信息显示的实时更新:字体颜色控件，字体种类，字体大小，加粗，斜体，下划线
            font_flag = false;
            size_flag = false;
            if (rh.SelectionLength == 0)
            {
                ts_cbfont.Text = rh.SelectionFont.FontFamily.Name;
                ts_cbfontsize.Text = rh.SelectionFont.Size.ToString();//后面一起处理别名显示
                ts_bold.Checked = rh.SelectionFont.Bold;
                ts_itallc.Checked = rh.SelectionFont.Italic;
                ts_underline.Checked = rh.SelectionFont.Underline;
                ts_color.BackColor = rh.SelectionColor;
            }
            else//有选中文本，则考虑选中文本的字体各属性可能是不一致的，只有某属性一致时才设置快捷工具栏的对应字体属性值,
            {
                string u_fontfamily = "";
                string u_fontsize ="";
                bool u_bold = false;
                bool u_italic = false;
                bool u_underline = false;
                char[]flags = new char[] { '1', '1', '1', '1', '1'};//分别表示宁体种类，大小，加粗，斜体，下划线是否—致,1为—致
                RichTextBox rhtemp = new RichTextBox();
                rhtemp.Rtf = rh.SelectedRtf;

                for(int i = 0; i < rh.SelectionLength; i++)//逐字判断，各字体属性是否一致
                {
                    rhtemp.Select(i, 1);
                    if (i == 0)
                    {
                        u_fontfamily = rhtemp.SelectionFont.FontFamily.Name; 
                        u_fontsize = rhtemp.SelectionFont.Size.ToString();
                        u_bold = rhtemp.SelectionFont.Bold;
                        u_italic = rhtemp.SelectionFont.Italic;
                        u_underline = rhtemp.SelectionFont.Underline;
                        ts_color.BackColor = rhtemp.SelectionColor;//颜色处理为和第一个字符相同
                    }
                    else
                    {
                        if (!u_fontfamily.Equals(rhtemp.SelectionFont.FontFamily.Name)) flags[0] = '0';
                        if (!u_fontsize.Equals(rhtemp.SelectionFont.Size.ToString())) flags[1] = '0';
                        if (!u_bold.Equals(rhtemp.SelectionFont.Bold)) flags[2] = '0';
                        if (!u_bold.Equals(rhtemp.SelectionFont.Italic)) flags[3] = '0';
                        if (!u_bold.Equals(rhtemp.SelectionFont.Underline)) flags[4] = '0';
                    }
                    if ((new string(flags)).Equals("00000")) break;//如果每个属性都发现存在不—致，则跳出循环
                }//for
                if (flags[0].Equals('1')) ts_cbfont.Text = u_fontfamily;//字体
                else ts_cbfont.SelectedIndex = -1;
                if (flags[1].Equals('1')) ts_cbfontsize.Text = u_fontsize;//字体大小
                else ts_cbfontsize.Text = "";
                if (flags[2].Equals('1') && u_bold == true) ts_bold.Checked = true;//加粗
                else ts_bold.Checked = false;
                if (flags[3].Equals('1') && u_italic == true) ts_itallc.Checked = true;//斜体
                else ts_itallc.Checked = false;
                if (flags[4].Equals('1')&&u_underline==true) ts_underline.Checked = true;//下划线
                else ts_underline.Checked = false;
            }//有选中文本结束
            if(ts_cbfontsize.Text!="")//字体大小部位空，则处理下别名显示
            {
                int k = Array.IndexOf(v, float.Parse(ts_cbfontsize.Text));
                if (k > -1) ts_cbfontsize.Text = d[k];
            }
            font_flag = true;
            size_flag = true;
        }

        
        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //为了简化处理，这里直接将文件送到打印机打印,不是特别好
            //有兴趣的话可以尝试打印richtextbox的内容，注意需要保留图片和格式
            if(filename == null || filename == "")
            {
                MessageBox.Show("save first,please!");
                return;
            }
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            try
            {
                p.StartInfo.FileName = filename;
                //p.StartInfo.WorkingDirectory=(new FileVersionInfo(filename)).Dir
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                p.StartInfo.Verb = "Print";
                p.Start();
                if (!p.HasExited)
                {
                    p.WaitForInputIdle(10000);
                    int i = 1;
                    bool running = true;
                    while(running && i <= 20)
                    {
                        System.Threading.Thread.Sleep(500);
                        if (p.HasExited) running = false;
                        else running = !p.CloseMainWindow();
                        i++;
                    }
                    if (running && !p.HasExited) p.Kill();
                }
                p.Dispose();
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }


        }

        private void 字数统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s;
            if (rh.SelectedText == "") s = rh.Text;
            else s = rh.SelectedText;
            int c_all = 0; //计算空格
            int c = 0;//不计空格
            int c_ch = 0;//中文
            c_all = s.Replace("\n", "").Length;
            s = s.Replace(" ", "").Replace("\n", "");//去除空格和回车
            c = s.Length;
            CharEnumerator charEnumerator = s.GetEnumerator();
            Regex regex = new Regex("^[\u4e00-\u9FA5]{0,}$");
            while (charEnumerator.MoveNext())
            {
                if (regex.IsMatch(charEnumerator.Current.ToString(), 0)) c_ch++;
            }
            MessageBox.Show("字符总数：" + c_all + "\n不计空格字符数：" + c + "\n中文字符数" + c_ch, "字数统计");
        }

        private void 显示工具栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            任务栏menuStrip1.Visible = true;
        }

        private void 隐藏快捷工具栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            快捷工具栏toolStrip1.Visible = false;
        }

        private void 隐藏任务栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            任务栏menuStrip1.Visible = false;
        }

        private void 显示快捷工具栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            快捷工具栏toolStrip1.Visible = true;
        }

        private void 关于记事本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("作者" + Environment.UserName + "，版本V1.0");
        }
    }
}
