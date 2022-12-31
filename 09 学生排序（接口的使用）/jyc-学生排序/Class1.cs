using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jyc_学生排序
{
    struct student
    {
        public string sname;
        public int age;
        public float score;
    } 

    //年龄排序因子
    class sortage:IComparer
    {
        public int Compare(object a,object b)
        {
            int i = ((student)a).age;
            int j = ((student)b).age;
            return i - j;
        }
    }

    //成绩排序因子
    class sortsc : IComparer
    {
        public int Compare(object a, object b)
        {
            float i = ((student)a).score;
            float j = ((student)b).score;
            int k = 0;
            if (i > j) k = 1;
            else if (i < j) k = -1;
            return k;
        }
    }

}
