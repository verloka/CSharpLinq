using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpLinq.Examples
{
    public static class Example10
    {
        /// <summary>
        /// В данном примере проводятся агрегативные операции над множествами
        /// найти минимальное, среднее, максимальное или суму всех елементов,
        /// а также применение функцию ко всему множеству элементов
        /// </summary>
        public static void Show()
        {
            Console.WriteLine("Example #10:");

            int[] numbers = { 1, 2, 3, 4, 5 };

            //Aggregate применяется для последовательного применения функции
            //т.е. в данном случае произойдет сумирование первых двух элементов
            //и далее к результату будет прибавлятся каждый последующий элемент
            int sum = numbers.Aggregate((x, y) => x + y);
            //В данном случае происходит умножение но задано начальное значение 10, т.е.
            //добавляется элемент в начало и последовательность выглядит так:
            //10, 1, 2, 3, 4, 5
            int op = numbers.Aggregate(10, (x, y) => x * y);
            //В Aggregate можно вставить абсолютно любые мат. операции над множиствами

            Console.WriteLine($"Sum - {sum}; Op - {op};");

            //Count - возвращает количество элементов в коллекции
            Console.WriteLine($"Count - {numbers.Count()}");

            //Count(pred) - возвращает количество элементов в коллекции
            //которые соответствуют предиканту, т.е. в данном случае
            //метод посчитате количество элементов кратных двум
            Console.WriteLine($"Count(Pred) - {numbers.Count(x => x % 2 == 0)}");

            //Sum - возвращает суму всех элементов
            Console.WriteLine($"Sum - {numbers.Sum()}");

            List<Customer> list = new List<Customer>()
            {
                new Customer() {Age = 12, Language = "Russian"},
                new Customer() {Age = 23, Language = "English"},
                new Customer() {Age = 24, Language = "Russian"},
                new Customer() {Age = 51, Language = "English"},
                new Customer() {Age = 11, Language = "Russian"},
                new Customer() {Age = 55, Language = "Russian"},
                new Customer() {Age = 64, Language = "English"},
                new Customer() {Age = 23, Language = "English"},
                new Customer() {Age = 32, Language = "English"},
                new Customer() {Age = 43, Language = "Russian"},
                new Customer() {Age = 41, Language = "English"},
                new Customer() {Age = 12, Language = "Ukranian"},
                new Customer() {Age = 21, Language = "Ukranian"},
                new Customer() {Age = 66, Language = "Ukranian"}
            };

            //Если обьект сложный то в методе Sum можно указать какой параметр сумировать
            Console.WriteLine($"Sum of ages in list - {list.Sum(n => n.Age)}");

            //Min - возвращает минимальное число в множестве
            //Average - среднее
            //Max - максимальное
            Console.WriteLine($"Min of numbers - {numbers.Min()}; Average of numbers - {numbers.Average()}; Max of numbers - {numbers.Max()}");

            //Если обьект сложный то в методах можно указать по какому параметру проводить сравнения
            //для получения минимального/среднее/максимального значения
            Console.WriteLine($"Min of age - {list.Min(n => n.Age)}; Average of age - {list.Average(n => n.Age)}; Max of age - {list.Max(n => n.Age)}");
        }
    }
}
