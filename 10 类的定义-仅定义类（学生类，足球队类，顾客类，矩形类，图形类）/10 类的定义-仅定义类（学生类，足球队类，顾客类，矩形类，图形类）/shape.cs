using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_类的定义_仅定义类_学生类_足球队类_顾客类_矩形类_图形类_
{
    // 图形类
    class shape
    {
        public virtual double getArea() { return 0; }
    }

    // 圆
    class circle : shape
    {
        double r;//半径
        public circle(double x) { r = x; }//有参构造

        public double R//属性
        {
            get { return r; }
            set
            {
                if (value >= 0) r = value;
                //else MessageBox.Show("半径不正确");
            }
        }
        //重写getArea方法
        public override double getArea()
        {
            return Math.PI * r * r;
        }
    }//圆定义结束

    //矩形
    class Rec : shape
    {
        protected double Len, Wid;
        public Rec(double x, double y)//有参构造
        {
            Len = x; Wid = y;
        }
        public double Length//属性
        {
            get { return Len; }
            set
            {
                if (value >= 0) Len = value;
                //else MessageBox.Show("矩形长度值不正确");
            }
        }
        public double Width//属性
        {
            get { return Wid; }
            set
            {
                if (value >= 0) Wid = value;
                //else MessageBox.Show("矩形宽度值不正确");
            }
        }
        public override double getArea()
        {
            return Len * Wid;
        }
    }//矩形结束

    //正方形
    class Square : Rec//正方形
    {
        public Square(double x) : base(x, x) { }

        public double side//边长
        {
            get { return Len; }
            set
            {
                if (value >= 0) Wid = Len = value;
                //else MessageBox.Show("边长值不正确");
            }
        }
        public new double Length
        {
            get { return side; }//只读
        }
        public new double Width
        {
            get { return side; }
        }
    }
}
