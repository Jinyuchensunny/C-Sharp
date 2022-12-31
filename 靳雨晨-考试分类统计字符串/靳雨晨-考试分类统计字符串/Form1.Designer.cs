
namespace 靳雨晨_考试分类统计字符串
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.other = new System.Windows.Forms.Label();
            this.ws = new System.Windows.Forms.Label();
            this.la6 = new System.Windows.Forms.Label();
            this.p = new System.Windows.Forms.Label();
            this.la5 = new System.Windows.Forms.Label();
            this.la3 = new System.Windows.Forms.Label();
            this.digit = new System.Windows.Forms.Label();
            this.la2 = new System.Windows.Forms.Label();
            this.symbol = new System.Windows.Forms.Label();
            this.la4 = new System.Windows.Forms.Label();
            this.letter = new System.Windows.Forms.Label();
            this.la1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "请输入需要分类统计的字符串：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(46, 67);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(654, 163);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(500, 379);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 34);
            this.button2.TabIndex = 16;
            this.button2.Text = "清空";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // other
            // 
            this.other.AutoSize = true;
            this.other.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.other.Location = new System.Drawing.Point(627, 316);
            this.other.Name = "other";
            this.other.Size = new System.Drawing.Size(0, 19);
            this.other.TabIndex = 4;
            // 
            // ws
            // 
            this.ws.AutoSize = true;
            this.ws.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ws.Location = new System.Drawing.Point(387, 316);
            this.ws.Name = "ws";
            this.ws.Size = new System.Drawing.Size(0, 19);
            this.ws.TabIndex = 5;
            // 
            // la6
            // 
            this.la6.AutoSize = true;
            this.la6.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.la6.Location = new System.Drawing.Point(505, 316);
            this.la6.Name = "la6";
            this.la6.Size = new System.Drawing.Size(123, 19);
            this.la6.TabIndex = 6;
            this.la6.Text = "其他字符数：";
            // 
            // p
            // 
            this.p.AutoSize = true;
            this.p.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.p.Location = new System.Drawing.Point(627, 269);
            this.p.Name = "p";
            this.p.Size = new System.Drawing.Size(0, 19);
            this.p.TabIndex = 7;
            // 
            // la5
            // 
            this.la5.AutoSize = true;
            this.la5.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.la5.Location = new System.Drawing.Point(271, 316);
            this.la5.Name = "la5";
            this.la5.Size = new System.Drawing.Size(123, 19);
            this.la5.TabIndex = 8;
            this.la5.Text = "空白字符数：";
            // 
            // la3
            // 
            this.la3.AutoSize = true;
            this.la3.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.la3.Location = new System.Drawing.Point(505, 269);
            this.la3.Name = "la3";
            this.la3.Size = new System.Drawing.Size(123, 19);
            this.la3.TabIndex = 9;
            this.la3.Text = "标点符号数：";
            // 
            // digit
            // 
            this.digit.AutoSize = true;
            this.digit.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.digit.Location = new System.Drawing.Point(387, 269);
            this.digit.Name = "digit";
            this.digit.Size = new System.Drawing.Size(0, 19);
            this.digit.TabIndex = 10;
            // 
            // la2
            // 
            this.la2.AutoSize = true;
            this.la2.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.la2.Location = new System.Drawing.Point(271, 269);
            this.la2.Name = "la2";
            this.la2.Size = new System.Drawing.Size(85, 19);
            this.la2.TabIndex = 11;
            this.la2.Text = "数字数：";
            // 
            // symbol
            // 
            this.symbol.AutoSize = true;
            this.symbol.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.symbol.Location = new System.Drawing.Point(139, 316);
            this.symbol.Name = "symbol";
            this.symbol.Size = new System.Drawing.Size(0, 19);
            this.symbol.TabIndex = 12;
            // 
            // la4
            // 
            this.la4.AutoSize = true;
            this.la4.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.la4.Location = new System.Drawing.Point(59, 316);
            this.la4.Name = "la4";
            this.la4.Size = new System.Drawing.Size(85, 19);
            this.la4.TabIndex = 13;
            this.la4.Text = "符号数：";
            // 
            // letter
            // 
            this.letter.AutoSize = true;
            this.letter.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.letter.Location = new System.Drawing.Point(139, 269);
            this.letter.Name = "letter";
            this.letter.Size = new System.Drawing.Size(0, 19);
            this.letter.TabIndex = 14;
            // 
            // la1
            // 
            this.la1.AutoSize = true;
            this.la1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.la1.Location = new System.Drawing.Point(59, 269);
            this.la1.Name = "la1";
            this.la1.Size = new System.Drawing.Size(85, 19);
            this.la1.TabIndex = 15;
            this.la1.Text = "字母数：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.other);
            this.Controls.Add(this.ws);
            this.Controls.Add(this.la6);
            this.Controls.Add(this.p);
            this.Controls.Add(this.la5);
            this.Controls.Add(this.la3);
            this.Controls.Add(this.digit);
            this.Controls.Add(this.la2);
            this.Controls.Add(this.symbol);
            this.Controls.Add(this.la4);
            this.Controls.Add(this.letter);
            this.Controls.Add(this.la1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "字符串分类统计";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label other;
        private System.Windows.Forms.Label ws;
        private System.Windows.Forms.Label la6;
        private System.Windows.Forms.Label p;
        private System.Windows.Forms.Label la5;
        private System.Windows.Forms.Label la3;
        private System.Windows.Forms.Label digit;
        private System.Windows.Forms.Label la2;
        private System.Windows.Forms.Label symbol;
        private System.Windows.Forms.Label la4;
        private System.Windows.Forms.Label letter;
        private System.Windows.Forms.Label la1;
    }
}

