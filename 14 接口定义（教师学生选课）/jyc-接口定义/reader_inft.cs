using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jyc_接口定义
{
    interface reader_inft
    {
        string ReaderNO//属性，读者号
        {
            get;set;
        }
        string ReaderName//属性，读者姓名
        {
            get; set;
        }
        void Borrowbook(string bookno);//方法-借书
        void Returnbook(string bookno);//还书
    }
}
