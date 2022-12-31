
namespace jyc_顾客管理
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
            this.lable1 = new System.Windows.Forms.Label();
            this.lable2 = new System.Windows.Forms.Label();
            this.lable3 = new System.Windows.Forms.Label();
            this.lable4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.dtp_birth = new System.Windows.Forms.DateTimePicker();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tb_no = new System.Windows.Forms.TextBox();
            this.tb_credit = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.cb_sorttype = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lable1.Location = new System.Drawing.Point(36, 29);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(69, 20);
            this.lable1.TabIndex = 0;
            this.lable1.Text = "姓名：";
            // 
            // lable2
            // 
            this.lable2.AutoSize = true;
            this.lable2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lable2.Location = new System.Drawing.Point(304, 29);
            this.lable2.Name = "lable2";
            this.lable2.Size = new System.Drawing.Size(109, 20);
            this.lable2.TabIndex = 0;
            this.lable2.Text = "出生日期：";
            // 
            // lable3
            // 
            this.lable3.AutoSize = true;
            this.lable3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lable3.Location = new System.Drawing.Point(36, 93);
            this.lable3.Name = "lable3";
            this.lable3.Size = new System.Drawing.Size(69, 20);
            this.lable3.TabIndex = 0;
            this.lable3.Text = "编号：";
            // 
            // lable4
            // 
            this.lable4.AutoSize = true;
            this.lable4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lable4.Location = new System.Drawing.Point(304, 93);
            this.lable4.Name = "lable4";
            this.lable4.Size = new System.Drawing.Size(109, 20);
            this.lable4.TabIndex = 0;
            this.lable4.Text = "初始积分：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(36, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "顾客信息：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(54, 525);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "排序方式：";
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(111, 29);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(139, 25);
            this.tb_name.TabIndex = 1;
            // 
            // dtp_birth
            // 
            this.dtp_birth.Location = new System.Drawing.Point(427, 26);
            this.dtp_birth.Name = "dtp_birth";
            this.dtp_birth.Size = new System.Drawing.Size(200, 25);
            this.dtp_birth.TabIndex = 2;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(40, 205);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(587, 274);
            this.listBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(583, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 27);
            this.button1.TabIndex = 4;
            this.button1.Text = "添加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tb_no
            // 
            this.tb_no.Location = new System.Drawing.Point(111, 93);
            this.tb_no.Name = "tb_no";
            this.tb_no.ReadOnly = true;
            this.tb_no.Size = new System.Drawing.Size(139, 25);
            this.tb_no.TabIndex = 1;
            // 
            // tb_credit
            // 
            this.tb_credit.Location = new System.Drawing.Point(427, 93);
            this.tb_credit.Name = "tb_credit";
            this.tb_credit.Size = new System.Drawing.Size(139, 25);
            this.tb_credit.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(506, 514);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 43);
            this.button2.TabIndex = 4;
            this.button2.Text = "排序";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cb_sorttype
            // 
            this.cb_sorttype.FormattingEnabled = true;
            this.cb_sorttype.Location = new System.Drawing.Point(170, 525);
            this.cb_sorttype.Name = "cb_sorttype";
            this.cb_sorttype.Size = new System.Drawing.Size(169, 23);
            this.cb_sorttype.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 628);
            this.Controls.Add(this.cb_sorttype);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.dtp_birth);
            this.Controls.Add(this.tb_credit);
            this.Controls.Add(this.tb_no);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lable4);
            this.Controls.Add(this.lable3);
            this.Controls.Add(this.lable2);
            this.Controls.Add(this.lable1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lable1;
        private System.Windows.Forms.Label lable2;
        private System.Windows.Forms.Label lable3;
        private System.Windows.Forms.Label lable4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.DateTimePicker dtp_birth;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tb_no;
        private System.Windows.Forms.TextBox tb_credit;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cb_sorttype;
    }
}

