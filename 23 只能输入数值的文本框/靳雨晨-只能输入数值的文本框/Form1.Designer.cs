﻿
namespace 靳雨晨_只能输入数值的文本框
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
            this.t1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // t1
            // 
            this.t1.Location = new System.Drawing.Point(123, 68);
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(390, 25);
            this.t1.TabIndex = 0;
            this.t1.Enter += new System.EventHandler(this.t1_Enter);
            this.t1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.t1_KeyDown);
            this.t1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.t1_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 177);
            this.Controls.Add(this.t1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox t1;
    }
}

