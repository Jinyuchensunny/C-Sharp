using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 靳雨晨_考试立方体类
{

    class Class1
    {
        public virtual double getA() 
        {
            return 0;
        }//面积
        public virtual double getV() 
        { 
            return 0; 
        }//体积
    }

    //立方体类
    class Cube : Class1 
    {
        private double length;

        public Cube()//无参构造
        {
            length = 0;
        }

        public Cube(double x)//有参构造
        {
            length = x;
        }

        protected double Len;
        public double Length//属性
        {
            get { return Len; }
            set
            {
                if (value >= 0) Len = value;
                else MessageBox.Show("长度值不正确");
            }
        }

        public override double getA()
        {
            return Len * Len * 6;
        }

        public override double getV()
        {
            return Len * Len * Len;
        }

    }

}
