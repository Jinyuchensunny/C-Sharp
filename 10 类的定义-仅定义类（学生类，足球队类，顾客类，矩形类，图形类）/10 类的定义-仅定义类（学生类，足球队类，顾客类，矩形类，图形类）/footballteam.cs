using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _10_类的定义_仅定义类_学生类_足球队类_顾客类_矩形类_图形类_
{
    class footballteam
    {
        string teamname, coach;
        string[] footballers = new string[11];

        //无参构造
        public footballteam()
        {
            teamname = coach = "";
        }

        //有参构造
        public footballteam(string n, string c, string[] f)//有参构造
        {
            teamname = n;
            coach = c;
            int k = f.Length;
            k = k <= footballers.Length ? k : footballers.Length;
            Array.Copy(f, footballers, k);
        }

        // 属性
        public string TNAME
        {
            get { return teamname; }
            set { teamname = value; }
        }
        public string COACH
        {
            get { return coach; }
            set { coach = value; }
        }

        //索引器
        public string this[int index]
        {   // ft[0] ft.footballers[0]
            get
            {
                if (index < 0 || index >= footballers.Length) return "";
                else return footballers[index];
            }
            set
            {
                if (index >= 0 || index < footballers.Length)
                    footballers[index] = value;
            }
        }

        //方法
        public string getfootballers()//返回球员名单
        {
            string s = string.Join(",", footballers);
            // 用正则表达式 将多个逗号变为一个
            Regex r = new Regex(@",{2,}");
            s = r.Replace(s, ",");
            if (s.EndsWith(","))
                s = s.Remove(s.Length - 1);
            return s;
        }
    }
}
