#define ITEM6
using System;
using ChapterOne;
namespace EffectiveCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
#if ITEM1
            #region  第1条：优先使用隐式类型的局部变量
            Item1 item1 = new Item1();
            var item1Data = item1.FindCustomersStartingWith1("start");
            foreach (var s in item1Data)
            {
                Console.WriteLine(s);
            }
            #endregion
#elif ITEM4
            #region 第4条：用内插字符串取代string.Format()
            Item4 item4 = new Item4();
            item4.printPI();
            #endregion
#elif ITEM5
            #region 第5条：用FormattableString取代专门为特定区域而写的字符串
            Item5 item5 = new Item5();
            item5.printDate();
            #endregion
#elif ITEM6
            #region 第6条：不要用表示符号名称的硬字符串来调用API
            Item6 item6 = new Item6();
            item6.Name = null;
            #endregion
#else
            #region backup
            Console.WriteLine("没有测试用例");
            #endregion
#endif
        }
    }
}
