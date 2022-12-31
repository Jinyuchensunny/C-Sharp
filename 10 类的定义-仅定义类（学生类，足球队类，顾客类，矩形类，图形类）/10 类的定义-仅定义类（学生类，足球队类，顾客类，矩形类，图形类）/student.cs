using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _10_类的定义_仅定义类_学生类_足球队类_顾客类_矩形类_图形类_
{
    class student : reader_inft
    {
        string sno, sname;
        ArrayList books = new ArrayList();//借书列表
        public student(string n, string m)
        {
            sno = n;
            sname = m;
        }

        public string ReaderNO
        {
            get { return sno; }
            set { if (value != null && value != "") sno = value; }
        }

        public string ReaderName
        {
            get { return sname; }
            set { sname = value; }
        }

        public void Borrowbook(string bookno)
        {
            if (books.Count < 5)
            {
                books.Add(bookno);
                MessageBox.Show(sname + "同学，借书成功");
            }
            else
            {
                MessageBox.Show(sname + "同学，你已经借满5本书，不能再借书了！");
            }
        }

        public void Returnbook(string bookno)
        {
            if (books.Contains(bookno))
            {
                books.Remove(bookno);
                MessageBox.Show(sname + "同学，还书成功");
            }
            else
            {
                MessageBox.Show(sname + "同学，你没有借这本书");
            }
        }
    }
}
