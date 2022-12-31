using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aspose.Words;

namespace jyc_wordpdf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button3.Enabled = false;
            textBox1.Visible = false;

        }

        string doc1 = "", doc2 = "";
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "doc|*.doc";
            of.Title = "选择文件";
            if (of.ShowDialog() == DialogResult.OK)
            {
                doc1 = of.FileName;
                label1.Text = doc1;
                if (doc2 != "") button3.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "doc|*.doc";
            of.Title = "选择文件";
            if (of.ShowDialog() == DialogResult.OK)
            {
                doc2 = of.FileName;
                label2.Text = doc2;
                if (doc1 != "") button3.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "PDF|*.pdf";
            sf.Title = "保存文件";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Document d1 = new Document(doc1);
                    Document d2 = new Document(doc2);
                    d2.FirstSection.PageSetup.SectionStart = SectionStart.Continuous;
                    d1.AppendDocument(d2, ImportFormatMode.UseDestinationStyles);
                    d1.Save(sf.FileName, SaveFormat.Pdf);
                    textBox1.Text = sf.FileName;
                    textBox1.Visible = true;
                    MessageBox.Show("合并成功");
                }
                catch(Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
        }

    }
}
