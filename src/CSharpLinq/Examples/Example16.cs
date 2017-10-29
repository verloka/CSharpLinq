using System;
using System.Linq;

namespace CSharpLinq.Examples
{
    public static class Example16
    {
        /// <summary>
        /// В этом примере рассматривается работа методов AsParallel и AsOrdered
        /// </summary>
        public static void Show()
        {
            Console.WriteLine("Example #16:");

            int[] numbers = new int[] { -2, -1, 0, 2, 1, 2, 3, 4, 5, 6, 7, 8, };

            var fac = from item in numbers.AsParallel().AsOrdered()         //проходим по списку, AsParallel указываем, что нужно распаралелить
                      where item > 0                                        //AsOrdered указываем, что данны должны быть отсортрованы
                      select Helper.Factorial(item);                        //т.е. данные в новой коллеии будут в той последовательности в           
                                                                            //в которой они были в первой последовательности
            foreach (var item in fac)                                       //стоит отметить, что операция с использованием AsOrdered значительно медленее
                Console.WriteLine(item);                                    //ну фильтруем отрицательные и выбираем   
        }
    }
}
