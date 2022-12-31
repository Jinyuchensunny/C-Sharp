using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10_类的定义_仅定义类_学生类_足球队类_顾客类_矩形类_图形类_
{
    class teacher : reader_inft
    {
        string tno, tname;
        ArrayList books = new ArrayList();
        public teacher(string n, string m)
        {
            tno = n; tname = m;
        }

        public string ReaderNO
        {
            get { return tno; }
            set { if (value != null && value != "") tno = value; }
        }

        public string ReaderName
        {
            get { return tname; }
            set { tname = value; }
        }

        public void Borrowbook(string bookno)
        {
            if (books.Count < 10)
            {
                books.Add(bookno);
                MessageBox.Show(tname + "老师，借书成功");
            }
            else
            {
                MessageBox.Show(tname + "老师，你已经借满10本书，不能再借书了！");
            }
        }

        public void Returnbook(string bookno)
        {
            if (books.Contains(bookno))
            {
                books.Remove(bookno);
                MessageBox.Show(tname + "老师，还书成功");
            }
            else
            {
                MessageBox.Show(tname + "老师，你没有借这本书");
            }
        }
    }
}
