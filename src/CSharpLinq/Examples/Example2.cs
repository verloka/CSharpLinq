using System;
using System.Linq;

namespace CSharpLinq.Examples
{
    public static class Example2
    {
        /// <summary>
        /// В этом примере из масива выбираются обычные числа кратные двум и больше десяти
        /// </summary>
        public static void Show()
        {
            Console.WriteLine("Example #2:");

            int[] numbers = { 34, 12, 54, 1, 3, 54, 23, 12, 3, 6, 8, 54, 34, 543, 3, 45, 22, 1, 45, 57, 2, 2, 45, 5, 0 };

            var selected = from item in numbers                 //проходимся по масиву
                           where item % 2 == 0 && item > 10     //пропускаем дальше только числа кратные двум и больше десяти
                           select item;                         //возвращаем новый масив чисел больше десяти но кратные двум

            foreach (var item in selected)
                Console.WriteLine(item);
        }
    }
}
