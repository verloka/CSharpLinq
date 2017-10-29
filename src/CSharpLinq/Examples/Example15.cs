using System;
using System.Linq;

namespace CSharpLinq.Examples
{
    public static class Example15
    {
        /// <summary>
        /// В этом примере рассматривается распаралеливание работы над коллекцией, для работы на всех ядрах машины
        /// </summary>
        public static void Show()
        {
            Console.WriteLine("Example #15:");

            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, };
            int[] numbers2 = new int[] { 11, 12, 13, 14, 15, 16, 17, 18, };

            var fac = from item in numbers.AsParallel()                 //проходим по списку методом AsParallel указываем, что задачу нужно распралелить
                      select new                                        //создаем новый обьект в котрый записываем число и число фибоначи по этому числу
                      {
                          Number = item,
                          Factorial = Helper.Factorial(item)
                      };

            Console.WriteLine("#1");

            //вывод на экран просто цклом 
            foreach (var item in fac)
                Console.WriteLine($"Factorial of {item.Number} is {item.Factorial}");


            Console.WriteLine("#2");

            (from item in numbers2.AsParallel()                 //проходим по списку методом AsParallel указываем, что задачу нужно распралелить
             select new                                        //создаем новый обьект в котрый записываем число и число фибоначи по этому числу
             {                                                 //далее методом ForAll выводим все на экран
                 Number = item,                                //вывод происходит в том же потоко, что и расчеты
                 Factorial = Helper.Factorial(item)
             }).ForAll(item => Console.WriteLine($"Factorial of {item.Number} is {item.Factorial}"));
        }
    }
}
