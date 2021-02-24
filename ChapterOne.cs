using System.ComponentModel;
using System.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
#region 第一章 C#语言的编程习惯
namespace ChapterOne
{
    #region 第1条：优先使用隐式类型的局部变量
    public class Item1
    {
        string[] customers = { "test1", "test2", "startTest", "startq" };
        public IEnumerable<string> FindCustomersStartingWith1(string start)
        {
            IEnumerable<string> q = from c in customers select c;
            var q2 = q.Where(s => s.StartsWith(start)); //这里的Where调用的是Enumerable.Where而不是Queryable.Where有性能影响
            return q2;
        }
        public IEnumerable<string> FindCustomersStartingWith(string start)
        {
            var q = from c in customers select c;
            var q2 = q.Where(s => s.StartsWith(start));
            return q2;
        }

    }
    #endregion

    #region 第2条：考虑使用readonly代替const
    public class RevisionInfo
    {
        /// <summary>
        /// const用来声明不随版本变化的值，或必须在编译器得到确定的值
        /// </summary>
        public const string RevisionString = "1.0.0";
        public const string RevisionMessage = "The first version";
        /// <summary>
        /// readonly常量是在程序运行时加以解析的，更灵活
        /// </summary>
        public static readonly string maybeModified = "This message may be modified";
    }
    #endregion

    #region 第3条：优先考虑is或as运算符，尽量少用强制类型转换
    #endregion

    #region 第4条：用内插字符串取代string.Format()
    class Item4
    {
        /// <summary>
        /// 注意使用内插字符串时，对于值类型有装箱操作
        /// </summary>
        public const float pi = 3.1415926f;
        public void printPI()
        {
            Console.WriteLine($"The value of PI is {pi:F2}");
            Console.WriteLine($"The value of pi is {pi.ToString()}");
        }
    }
    #endregion

    #region 第5条：用FormattableString取代专门为特定区域而写的字符串
    class Item5
    {
        public void printDate()
        {
            string first = $"It's the {DateTime.Now.Day} of the {DateTime.Now.Month} month";
            FormattableString second = $"It's the {DateTime.Now.Day} of the {DateTime.Now.Month} month";
            var third = $"It's the {DateTime.Now.Day} of the {DateTime.Now.Month} month";
            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(third);
            printSpecificDate();
        }
        void printSpecificDate()
        {
            string[] cultureNames = { "en-US", "fr-FR", "de-DE", "es-ES", "zh-CN" };
            double value = 9163.22;
            Console.WriteLine("Culture     Date                                value");
            foreach (string cultureName in cultureNames)
            {
                System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo(cultureName);
                string output = String.Format(cultureInfo, "{0,-11} {1,-35:D} {2:N}", cultureInfo.Name, DateTime.Now, value);
                Console.WriteLine(output);
            }
        }
    }
    #endregion

    #region 第6条：不要用表示符号名称的硬字符串来调用API
    public class Item6
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(Name), "this can not be null");
                if (value != name)
                {
                    name = value;
                }
            }
        }
    }
    #endregion

    #region 第7条：用委托表示回调
    class Item7
    {
        public delegate void Del(string message);

        Del handler;

        public Item7(Del callback)
        {
            handler = callback;
        }

        public void UseDelegate(string message)
        {
            handler(message);
        }
    }
    #endregion

    #region 第8条：用null条件运算符调用事件处理程序
    #endregion

    #region 第9条：尽量避免装箱和取消装箱这两种操作
    #endregion

    #region 第10条：只有在应对新版基类与现有子类之间的冲突时才应用new修饰符
    #endregion


}
#endregion