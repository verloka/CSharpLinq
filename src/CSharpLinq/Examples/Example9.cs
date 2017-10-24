using System;
using System.Linq;

namespace CSharpLinq.Examples
{
    public static class Example9
    {
        /// <summary>
        /// В этом примере производятся раличные дейсвия надо множиствами (пересичение, обьединение, вычитание)
        /// </summary>
        public static void Show()
        {
            Console.WriteLine("Example #9:");

            string[] one = { "Microsoft", "Google", "Apple", "Nokia" };
            string[] two = { "Apple", "IBM", "Samsung", "Nokia" };

            //Из первого множиства вычетается второе, т.е. из первого множиства удаляются все элементы, что есть во втором
            var except = one.Except(two);

            Console.WriteLine("Except:");
            foreach (var item in except)
                Console.WriteLine(item);

            //Возвращает коллекцию пересечения двух множеств, т.е. те которые есть и в той и в той
            var intersect = one.Intersect(two);

            Console.WriteLine("Intersect:");
            foreach (var item in intersect)
                Console.WriteLine(item);

            //Обьеденяет два множества, одинаковые элементы добавляются один раз
            var union = one.Union(two);

            Console.WriteLine("Union:");
            foreach (var item in union)
                Console.WriteLine(item);

            //Обьеденяет две последовательности без удаления дубликатов
            var concat = one.Concat(two);

            Console.WriteLine("Concat:");
            foreach (var item in concat)
                Console.WriteLine(item);

            //Удаляет дубликаты Concat + Distinct = Union
            var distinct = concat.Distinct();

            Console.WriteLine("Distinct:");
            foreach (var item in distinct)
                Console.WriteLine(item);
        }
    }
}
