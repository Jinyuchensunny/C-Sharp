using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jyc_顾客管理
{
    class customer
    {
        string cno;//顾客编号
        string cname;//姓名
        DateTime birth;//生日
        long credit;//积分

        public customer()//无参构造
        {
            cname = "";
            birth = Convert.ToDateTime("1990-1-1");
            credit = 0;
        }

        public customer(string no,string s,DateTime d,long c)//有参构造
        {
            CNAME = s;BIRTH = d;CREDIT = c;cno = no;
        }

        public string CNAME
        {
            get { return cname; }
            set { if (value == "" || value == null)
                    MessageBox.Show("你输入的顾客姓名不合法");
                else cname = value;
            }
        }

        public DateTime BIRTH
        {
            get { return birth; }
            set { birth = value; }
        }

        public long CREDIT
        {
            get { return credit; }
            set
            {
                if (value >= 0) credit = value;
                else
                {
                    MessageBox.Show("您的积分数据提供有误，无法赋值！");
                }
            }
        }

        public string CNO
        {
            get { return cno; }
            set { cno = value; }
        }
    }//结束

    //定义排序因子
    class sortbirth : IComparer//生日
    {
        public int Compare(object a, object b)
        {
            return DateTime.Compare(((customer)a).BIRTH, ((customer)b).BIRTH);
        }
    }

    class sortcredit : IComparer//积分
    {
        public int Compare(object a, object b)
        {
            if (((customer)a).CREDIT > ((customer)b).CREDIT) return 1;
            //if (((customer)a).CREDIT > ((customer)b).CREDIT) return 0;
            if (((customer)a).CREDIT > ((customer)b).CREDIT) return -1;
            return 0;
        }
    }
}

