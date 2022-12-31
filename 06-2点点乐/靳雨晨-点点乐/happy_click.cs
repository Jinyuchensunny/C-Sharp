using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 靳雨晨_点点乐
{
   public class happy_click
    {
        Point cur_house;//当前位置
        Point[] houses;//宠物所有的可去位置
        int playtime;//游戏时长
        int diffcute;//难度值
        Image pet;//宠物
        int pet_index;//宠物索引号
        Size pet_size;//宠物大小
        bool flag;//true表示正在搬家（切换到另一个位置）
        bool flag2;//true可以搬家******改进单击宠物时多切换一次草丛的问题
        int score;//得分

        /// <summary>
        /// 带参构造函数
        /// </summary>
        /// <param name="ipet">当前宠物图片</param>
        /// <param name="imgindex">当前宠物索引号</param>
        /// <param name="ihouses">宠物所有的位置（家）集合</param>
        /// <param name="h_index"></param>
        /// <param name="size"></param>
        public happy_click(Image ipet,int imgindex,Point[] ihouses,int h_index,Size isize)
        {
            pet = ipet;//从参数获取默认宠物图片
            pet_index = imgindex;//默认宠物索引号

            houses = new Point[ihouses.Length];
            Array.Copy(ihouses, houses, ihouses.Length);

            pet_size = isize;//从参数获取宠物的大小
            cur_house = houses[h_index];
            playtime = 1;//默认时长1分钟
            diffcute = 1;//默认难度值为简单=1
            score = 0;//默认得分为0
            flag = false;//默认并未进行搬家活动
            flag2 = true;//默认可以搬家
        }

        public Point CUR_HOUSE //属性，获取当前宠物的位置
        {
            get { return cur_house; }
        }

        public int PLAYTIME //属性，游戏时间
        {
            get { return playtime; }
            set
            {
                Regex r = new Regex(@"^[1-9]\d*$");//正整数正则表达式
                if (r.IsMatch(value.ToString())) playtime = value;
                else MessageBox.Show("游戏时长只能赋值为正整数");
            }
        }

        public int DIFFCUTE//属性，游戏难度
        {
            get { return diffcute; }
            set
            {
                Regex r = new Regex(@"^[1-9]\d*$");//正整数正则表达式
                if (r.IsMatch(value.ToString())) diffcute = value;
                else MessageBox.Show("游戏难度值不合法");
            }
        }

        public Image PET//属性，宠物
        {
            get { return pet; }
            set { pet = value; }
        }

        public int PET_INDEX//属性，宠物索引
        {
            get { return pet_index; }
            set
            {
                Regex r = new Regex(@"^\d*$");//非负整数正则表达式
                if (r.IsMatch(value.ToString())) pet_index = value;
                else MessageBox.Show("索引值不合法");
            }
        }

        public int SCORE//属性，得分
        {
            get { return score; }
            set
            {
                Regex r = new Regex(@"^\d+$");//非负整数正则表达式
                if (r.IsMatch(value.ToString())) score = value;
                else MessageBox.Show("得分数据不合法");
            }
        }

        public bool FLAG//属性，是否正在搬家
        {
            get { return flag; }
        }

        public void change_house()//搬家
        {
            Random r = new Random((int)DateTime.Now.Millisecond);
            int i;
            i = r.Next(0, houses.Length);
            if (cur_house.Equals(houses[i]))//如果随机得到的新位置和当前位置相同，则调整
                i = (i + 2) % houses.Length;
            cur_house = houses[i];//设置新家位置
        }


        public bool do_run(int x, int y)//true表示预知危险，跑了
        {
            int d = 20 * diffcute;
            //是否危险
            if (x > cur_house.X - d && x < cur_house.X + pet_size.Width + d && y > cur_house.Y - d && y < cur_house.Y + pet_size.Height + d)
            {
                flag = true;//开始搬家
                //为了提高抓住几率，鼠标接近宠物到宠物换位置进行延时
                DateTime dt = new DateTime();
                dt = DateTime.Now;
                while (dt.AddSeconds(0.3 / diffcute) > DateTime.Now)
                {
                    Application.DoEvents();
                }
                if (flag2 == true)
                {
                    change_house();
                    flag = false;//结束搬家
                    return true;//搬家成功
                }
                else
                {
                    flag = false;//一次搬家结束，其实是click事件完成的搬家
                    flag2 = true;//允许搬家
                }
            }//if
            return false;//未搬家
        }

        public void catched()
        {
            //被抓住后分数+10，并立刻切换到其他位置（避免挨打不走）
            score += 10;
            change_house();
            flag2 = false;//已经切换一次位置，禁止搬家，避免mousemove事件中再次切换草丛
        }

    }//class happy_click
    
}
